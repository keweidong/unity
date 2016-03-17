using System;
using System.Collections.Generic;
using DashFire.Debug;

namespace DashFire
{
  public interface IActionLogic
  {
    /// 获取技能逻辑Id
    ActionLogicId ActionLogicId { get; }
    ///
    void Tick(CharacterInfo entity, ActionInfo actionInfo);
    /// 动作开始
    bool StartAction(CharacterInfo entity, ActionInfo actionInfo);
    /// 停止动作（用于循环动作处理）
    void StopAction(CharacterInfo entity, ActionInfo actionInfo);
    /// 动作被中断回调
    void InterruptAction(CharacterInfo entity, ActionInfo actionInfo);
  }

  /**
   * @brief
   *   动作逻辑
   */
  public abstract class AbstractActionLogic : IActionLogic
  {
    public ActionLogicId m_ActionLogicId = new ActionLogicId(); // 动作逻辑Id
    public delegate void ActionPlayEffectHandler(CharacterInfo entity, ActionInfo actionInfo, CallBackPointInfo cp);
    public static ActionPlayEffectHandler OnPlayEffect;

    public ActionLogicId ActionLogicId
    {
      get { return m_ActionLogicId; }
    }

    public void Tick(CharacterInfo entity, ActionInfo actionInfo)
    {
      if (null == entity) return;
      if (null == actionInfo) return;
      if (actionInfo.IsActive) {
        OnTick(entity, actionInfo);
      }
    }

    public bool StartAction(CharacterInfo entity, ActionInfo actionInfo)
    {
      if (null == entity) return false;
      if (null == actionInfo) return false;
      ActionLogicData dataAction = actionInfo.ConfigData;
      if (null == dataAction || dataAction.SectionNumber <= 0) {
        return false;
      }
      bool ret = OnBeforeStartAction(entity, actionInfo);
      if (ret) {
        //开始播放第一节
        OnSectionStart(entity, actionInfo, 0);
      }
      OnAfterStartAction(entity, actionInfo);
      return ret;
    }

    public void StopAction(CharacterInfo entity, ActionInfo actionInfo)
    {
      if (null == entity) return;
      if (null == actionInfo) return;
      ActionLogicData dataAction = actionInfo.ConfigData;
      if (null == dataAction || dataAction.SectionNumber <= 0) {
        return;
      }
      if (OnStopAction(entity, actionInfo)) {
        EndAction(entity, actionInfo);
      }
    }


    public void InterruptAction(CharacterInfo entity, ActionInfo actionInfo)
    {
      if (null == entity) return;
      if (null == actionInfo) return;
      ActionLogicData dataAction = actionInfo.ConfigData;
      if (null == dataAction || dataAction.SectionNumber <= 0) {
        return;
      }
      EndAction(entity, actionInfo);
    }

    /************************************************************************/
    /* 重载需实现完整的动作序列过程                                         */
    /************************************************************************/
    protected virtual void OnTick(CharacterInfo entity, ActionInfo actionInfo)
    {
      DoSectionTick(entity,actionInfo);
    }
    /************************************************************************/
    /* 重载实现开始播放动作前的检查或准备工作                               */
    /************************************************************************/
    protected virtual bool OnBeforeStartAction(CharacterInfo entity, ActionInfo actionInfo)
    {
      return true;
    }
    /************************************************************************/
    /* 重载实现开始播放动作后需要做的工作                                   */
    /************************************************************************/
    protected virtual void OnAfterStartAction(CharacterInfo entity, ActionInfo actionInfo)
    {
    }
    /******************************************************************************************************************/
    /* 重载实现外界停止动作时特定逻辑要做的工作（主要用于循环动作的停止，返回true表示动作真的停止了）                 */
    /******************************************************************************************************************/
    protected virtual bool OnStopAction(CharacterInfo entity, ActionInfo actionInfo)
    {
      return true;
    }
    /************************************************************************/
    /* 重载实现动作结束时特定逻辑要做的工作(目前动作打断也是在这里处理)     */
    /************************************************************************/
    protected virtual void OnEndAction(CharacterInfo entity, ActionInfo actionInfo)
    {
    }
    /************************************************************************/
    /* 重载实现某节动作开始时的处理（包括实际播放动作本身）                 */
    /************************************************************************/
    protected virtual void OnSectionStart(CharacterInfo entity, ActionInfo actionInfo, int sectionNum)
    {
      StartSection(entity, actionInfo, sectionNum);
    }

    protected virtual void OnPlayActionEffect(CharacterInfo entity, ActionInfo actionInfo, CallBackPointInfo cp)
    {
      LogSystem.Debug("--effect: OnPlayActionEffect {0} {1}", cp.effect_time, cp.effect_name);
      if (OnPlayEffect != null) {
        OnPlayEffect(entity, actionInfo, cp);
      }
    }

    /************************************************************************/
    /* 重载实现某节动作结束时的处理                                         */
    /************************************************************************/
    protected virtual void OnSectionOver(CharacterInfo entity, ActionInfo actionInfo, int sectionNum)
    {
      EndSection(entity, actionInfo, sectionNum);
    }

    protected void DoSectionTick(CharacterInfo entity, ActionInfo actionInfo)
    {
      DoSectionTick(entity, actionInfo, -1);
    }

    protected void DoSectionTick(CharacterInfo entity, ActionInfo actionInfo, int loopSection)
    {
      ActionLogicData dataAction = actionInfo.ConfigData;
      if (null == dataAction) return;
      int totalElapsedTime = (int)(TimeUtility.GetServerMilliseconds() - actionInfo.ActionStartTime);
      
      // 检查是否到了特定时间，并触发相应通知
      if (!actionInfo.HasCallbackAtSpecifiedTime
          && dataAction.CallbackSection > 0) {
        // callback at specified time
        if (IsPlayedAtSpecifiedTime(actionInfo, dataAction.CallbackSection, dataAction.CallbackPoint)) {
          ActionAtSpecifiedTime(entity, actionInfo);
        }
      }

      // 检查特效播放节点
      foreach (CallBackPointInfo cp in actionInfo.CallBackPointList) {
        if (cp.is_triggered) {
          continue;
        }
        if (totalElapsedTime >= (cp.effect_time * 1000)) {
          OnPlayActionEffect(entity, actionInfo, cp);
          cp.is_triggered = true;
        }
      }
      

      // 是否播放下一节动作
      int curSectionNeedTime = actionInfo.DelayTime;
      for (int i = 0; i < dataAction.SectionNumber; i++) {
        curSectionNeedTime += (int)(dataAction.SectionList[i].PlayTime * 1000);
        if (i == actionInfo.CurrentActiveSection) {
          if (totalElapsedTime > curSectionNeedTime) {
            OnSectionOver(entity, actionInfo, actionInfo.CurrentActiveSection);
            if (i != dataAction.SectionNumber - 1) {
              if (loopSection>=0) {
                actionInfo.ActionStartTime = TimeUtility.GetServerMilliseconds();
                OnSectionStart(entity, actionInfo, loopSection);
              } else {
                OnSectionStart(entity, actionInfo, i + 1);
              }
            }
          }
          break;
        }
      }
    }

    protected bool IsPlayedAtSpecifiedTime(ActionInfo actionInfo, int sectionnum, float time)
    {
      ActionLogicData data = actionInfo.ConfigData;
      int totalElapsedTime = (int)(TimeUtility.GetServerMilliseconds() - actionInfo.ActionStartTime);

      for (int i = 1; i < sectionnum; i++) {
        time += data.SectionList[i - 1].PlayTime;
      }
      if (totalElapsedTime > (int)(time* 1000)) {
        return true;
      }
      return false;
    }

    //播放某节动作并通知依赖此动作逻辑的系统，用以辅助实现OnSectionStart
    protected void StartSection(CharacterInfo entity, ActionInfo actionInfo, int sectionNum)
    {
      ActionLogicData dataAction = actionInfo.ConfigData;
      if (null == dataAction) return;
      actionInfo.CurrentActiveSection = sectionNum;
      actionInfo.PlaySpeed = dataAction.SectionList[sectionNum].PlaySpeed;
      if (dataAction.SectionList[sectionNum].ActionType >= 0) {
        entity.StartAction(
          dataAction.SectionList[sectionNum].ActionType,
          dataAction.SectionList[sectionNum].PlayTime,
          dataAction.SectionList[sectionNum].PlaySpeed,
          actionInfo.ActType,
          dataAction.SectionList[sectionNum].WapMode,
          dataAction.SectionList[sectionNum].IsUpperBody);
      }
      if (ActionType.SKILL == actionInfo.ActType) {
        SkillSystem.Instance.OnActionSectionStart(entity, actionInfo, sectionNum);
      } else if (ActionType.IMPACT == actionInfo.ActType) {
        ImpactSystem.Instance.OnActionSectionStart(entity, actionInfo, sectionNum);
      } else if (ActionType.INTERACTION == actionInfo.ActType) {
        InteractionSystem.OnActionSectionStart(entity, actionInfo, sectionNum);
      }
    }
    //某节动作的标准结束处理，同时通知依赖此动作逻辑的系统，用以辅助实现OnSectionOver。最后一节结束时会进行动作结束处理
    protected void EndSection(CharacterInfo entity, ActionInfo actionInfo, int sectionNum)
    {
      ActionLogicData dataAction = actionInfo.ConfigData;
      if (null == dataAction) return;
      // callback
      if (ActionType.SKILL == actionInfo.ActType) {
        SkillSystem.Instance.OnActionSectionOver(entity, actionInfo, sectionNum);
      } else if (ActionType.IMPACT == actionInfo.ActType) {
        ImpactSystem.Instance.OnActionSectionOver(entity, actionInfo, sectionNum);
      } else if (ActionType.INTERACTION == actionInfo.ActType) {
        InteractionSystem.OnActionSectionOver(entity, actionInfo, sectionNum);
      }
      if (sectionNum == dataAction.SectionNumber - 1) {
        EndAction(entity, actionInfo);
      }
    }
    //在动作播放过程中处理特定时间的回调，并通知依赖些动作逻辑的系统
    protected void ActionAtSpecifiedTime(CharacterInfo entity, ActionInfo actionInfo)
    {
      if (actionInfo.HasCallbackAtSpecifiedTime) return;

      if (ActionType.SKILL == actionInfo.ActType) {
        SkillSystem.Instance.OnActionAtSepcifiedTime(entity, actionInfo);
      } else if (ActionType.IMPACT == actionInfo.ActType) {
        ImpactSystem.Instance.OnActionAtSepcifiedTime(entity, actionInfo);
      } else if (ActionType.INTERACTION == actionInfo.ActType) {
        InteractionSystem.OnActionAtSepcifiedTime(entity, actionInfo);
      }
      actionInfo.HasCallbackAtSpecifiedTime = true;
    }

    protected void ActionAtEffectTime(CharacterInfo entity, ActionInfo actionInfo, CallBackPointInfo cp)
    {
      if (cp.is_triggered) return;

      if (ActionType.SKILL == actionInfo.ActType) {
        SkillSystem.Instance.OnActionAtEffectTime(entity, actionInfo, cp);
      }
      cp.is_triggered = true;
    }

    protected bool CanEntityMove(CharacterInfo entity)
    {
      bool canMove = true;
      NpcInfo npc = entity.CastNpcInfo();
      if (null != npc) {
        canMove = npc.CanMove;
      }
      return canMove;
    }

    private void EndAction(CharacterInfo entity, ActionInfo actionInfo)
    {
      if (entity.IsUser) {
        LogSystem.Debug("EndAction user:{0} heroid:{1} aistatechange:{2} actiontype:{3} usager:{4} currentsection:{5} aienable:{6}", entity.GetId(), entity.GetLinkId(), actionInfo.IsAiStateChange, actionInfo.ActType, actionInfo.UsagerId, actionInfo.CurrentActiveSection, entity.GetAIEnable());
      }

      OnEndAction(entity, actionInfo);
      actionInfo.IsActive = false;
      if (actionInfo.IsFlyStateChange) {
        entity.IsFlying = false;
        actionInfo.IsFlyStateChange = false;
      }
      if (actionInfo.IsAiStateChange) {
        entity.SetAIEnable(true);
        actionInfo.IsAiStateChange = false;
      }
      actionInfo.ClearLogicDatas();
    }
  }
}
