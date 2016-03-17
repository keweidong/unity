/**
 * @file ActionSystem.cs
 * @brief 动作系统
 *              1.管理动作逻辑配置数据，提供查询接口
 *              2.提供动作系统调用接口
 *
 * @author maguangguang
 * @version 1.0.0
 */

using System;
using System.Collections.Generic;
using DashFire.Debug;

namespace DashFire
{
  public enum ActionLogicId
  {
    ACTION_LOGIC_ID_NORMAL = 20001,   // normal action
    ACTION_LOGIC_ID_MOVETOPOS = 20002,
    ACTION_LOGIC_ID_FLASHTOPOS = 20003,//现在没用了，下次加逻辑时可以把这个号用上
    ACTION_LOGIC_ID_THROW_AIR = 20004,
    ACTION_LOGIC_ID_BEAT_BACK = 20005,
    ACTION_LOGIC_ID_SETPOS = 20006,
    ACTION_LOGIC_ID_JUMPTOPOS = 20007,
  }

  /**
   * @brief
   *   MyAction System
   */
  public sealed class ActionSystem : IActionController
  {
    #region Singleton
    private static ActionSystem s_Instance = new ActionSystem();
    public static ActionSystem Instance
    {
      get { return s_Instance; }
    }
    #endregion

    private Dictionary<int, IActionLogic> ActionLogicDict = new Dictionary<int, IActionLogic>();  // 动作逻辑容器

    public bool Init(string configFile)
    {
      ActionLogicDict.Clear();
      ActionConfigProvider.Instance.LoadActionData(configFile, "ActionData");
      registerActionLogics();
      return true;
    }

    public void Tick(CharacterInfo entity)
    {
      TickAction(entity, ActionType.SKILL);
      TickAction(entity, ActionType.IMPACT);
      TickAction(entity, ActionType.INTERACTION);
    }

    public void Release()
    {
      ActionLogicDict.Clear();
    }

    /// 开始播放一个动作
    public bool StartAction(CharacterInfo entity, int actionId, ActionType actionType, int usagerId)
    {
      ActionLogicData actionLogicData = ActionConfigProvider.Instance.GetActionDataById(actionId);
      if (null == actionLogicData)
        return false;

      if (actionType != ActionType.IMPACT) {//impact动作不打断之前的impact动作，只是替换为当前激活动作
        ActionBreakScope breakScope = GetBreakScopeForActionType(actionType);
        if (!InterruptAction(entity, breakScope, (ActionBreakLevel)actionLogicData.BreakLevel)) {
          return false;
        }
      }

      IActionLogic logic = GetActionLogicById(actionLogicData.ActionLogicId);
      if (null != logic) {
        ActionInfo actionInfo = entity.GetActionInfo(actionType);
        if (null != actionInfo) {
          if (entity.IsUser && !entity.GetAIEnable()) {
            LogSystem.Debug("StartAction, user:{0} heroid:{1} name:{2} [old] isactive:{3} isaistatechange:{4} actiontype:{5} usager:{6} currentsection:{7} [new] actiontype:{8} usager:{9} aienable:{10}", entity.GetId(), entity.GetLinkId(), entity.GetName(), 
              actionInfo.IsActive, actionInfo.IsAiStateChange, actionInfo.ActType, actionInfo.UsagerId, actionInfo.CurrentActiveSection, 
              actionType,usagerId,
              entity.GetAIEnable());
          }
          if (actionInfo.IsActive) {
            logic.InterruptAction(entity, actionInfo);
          }
          actionInfo.Reset();
          actionInfo.ActionId = actionId;
          actionInfo.BreakLevel = (ActionBreakLevel)actionLogicData.BreakLevel;
          actionInfo.IsActive = true;
          actionInfo.ActionStartTime = TimeUtility.GetServerMilliseconds();
          actionInfo.HasCallbackAtSpecifiedTime = false;
          actionInfo.UsagerId = usagerId;
          actionInfo.ActType = actionType;
          if (!entity.IsHitRecovering()) {
            actionInfo.DelayTime = 0;
          }
          actionInfo.ConfigData = actionLogicData;
          return logic.StartAction(entity, actionInfo);
        }
      }
      return false;
    }

    public void StopAction(CharacterInfo entity, ActionType actionType)
    {
      ActionInfo actionInfo = entity.GetActionInfo(actionType);
      if (null == actionInfo) return;
      ActionLogicData logicData = actionInfo.ConfigData;
      if (null == logicData) return;
      if (actionInfo.IsActive) {
        if (ActionLogicDict.ContainsKey(logicData.ActionLogicId)) {
          ActionLogicDict[logicData.ActionLogicId].StopAction(entity, actionInfo);
        }
      }
    }

    public void StopAction(CharacterInfo entity, int impactId)
    {
      ActionInfo actionInfo = entity.GetActionInfo(impactId);
      if (null == actionInfo) return;
      ActionLogicData logicData = actionInfo.ConfigData;
      if (null == logicData) return;
      if (actionInfo.IsActive) {
        if (ActionLogicDict.ContainsKey(logicData.ActionLogicId)) {
          ActionLogicDict[logicData.ActionLogicId].StopAction(entity, actionInfo);
        }
      }
    }

    /// 中断当前正在播放的动作
    public bool InterruptAction(CharacterInfo entity, ActionBreakScope breakScope, ActionBreakLevel breakLevel)
    {
      if (null == entity) return true;
      bool ret = true;
      if ((breakScope & ActionBreakScope.SKILL) == ActionBreakScope.SKILL) {
        ret = ret && InterruptSkillAction(entity, breakLevel);
      } else if ((breakScope & ActionBreakScope.IMPACT) == ActionBreakScope.IMPACT) {
          ret = ret && InterruptImpactAction(entity, breakLevel);
      } else if ((breakScope & ActionBreakScope.INTERACTION) == ActionBreakScope.INTERACTION) {
        ret = ret && InterruptInteractionAction(entity, breakLevel);
      }
      return ret;
    }

    public bool InterruptAction(CharacterInfo entity, int impactId)
    {
      if (null != entity) {
        ActionInfo actionInfo = entity.GetActionInfo(impactId);
        if (null != actionInfo) {
          ActionLogicData logicData = actionInfo.ConfigData;
          if (null != logicData) {
            if (actionInfo.IsActive) {
              if (ActionLogicDict.ContainsKey(logicData.ActionLogicId)) {
                ActionLogicDict[logicData.ActionLogicId].InterruptAction(entity, actionInfo);
              }
            }
          }
        }
      }
      return true;
    }
    
    private ActionBreakScope GetBreakScopeForActionType(ActionType actionType)
    {
      ActionBreakScope scope = ActionBreakScope.ALL;
      switch (actionType) {
        case ActionType.SKILL:
          scope = ActionBreakScope.SKILL;
          break;
        case ActionType.IMPACT:
          scope = ActionBreakScope.IMPACT;
          break;
        case ActionType.NORMAL:
        case ActionType.INTERACTION:
          scope = ActionBreakScope.INTERACTION;
          break;
      }
      return scope;
    }

    private IActionLogic GetActionLogicById(int logicId)
    {
      if (ActionLogicDict.ContainsKey(logicId)) {
        return ActionLogicDict[logicId];
      }
      return null;
    }

    private void TickAction(CharacterInfo entity, ActionType actionType)
    {
      if (null == entity) return;
      if (ActionType.IMPACT == actionType) {
        //impact动作在逻辑上是有多个的（表现上只会有一个）。。与其它类型动作不一样。
        foreach (ImpactInfo info in entity.GetSkillStateInfo().GetAllImpact()) {
          if (null!=info && info.m_IsActivated) {
            ActionInfo actionInfo = info.m_ActionInfo;
            if (null == actionInfo || !actionInfo.IsActive) continue;
            ActionLogicData dataAction = actionInfo.ConfigData;
            if (null != dataAction
                && ActionLogicDict.ContainsKey(dataAction.ActionLogicId)) {
              ActionLogicDict[dataAction.ActionLogicId].Tick(entity, actionInfo);
            }
          }
        }
      } else {
        ActionInfo actionInfo = entity.GetActionInfo(actionType);
        if (null == actionInfo || !actionInfo.IsActive) return;
        ActionLogicData dataAction = actionInfo.ConfigData;
        if (null != dataAction
            && ActionLogicDict.ContainsKey(dataAction.ActionLogicId)) {
          ActionLogicDict[dataAction.ActionLogicId].Tick(entity, actionInfo);
        }
      }
    }

    private bool InterruptSkillAction(CharacterInfo entity, ActionBreakLevel breakLevel)
    {
      bool ret = false;
      ActionInfo actionInfo = entity.GetSkillStateInfo().GetSkillActionInfo();
      if (null != actionInfo && actionInfo.IsActive) {
        ActionLogicData logicData = actionInfo.ConfigData;
        if (null != logicData) {
          if (breakLevel < actionInfo.BreakLevel) {
            if (ActionLogicDict.ContainsKey(logicData.ActionLogicId)) {
              ActionLogicDict[logicData.ActionLogicId].InterruptAction(entity, actionInfo);
            }
            SkillSystem.Instance.OnActionInterrupted(entity, actionInfo);
            ret = true;
          }
        }
      } else {
        ret = true;
      }
      return ret;
    }

    private bool InterruptImpactAction(CharacterInfo entity, ActionBreakLevel breakLevel)
    {
      bool ret = false;
      ActionInfo actionInfo = entity.GetSkillStateInfo().GetImpactActionInfo();
      if (null != actionInfo && actionInfo.IsActive) {
        ActionLogicData logicData = actionInfo.ConfigData;
        if (null != logicData) {
          if (breakLevel < actionInfo.BreakLevel) {
            if (ActionLogicDict.ContainsKey(logicData.ActionLogicId)) {
              ActionLogicDict[logicData.ActionLogicId].InterruptAction(entity, actionInfo);
            }
            ImpactSystem.Instance.OnActionInterrupted(entity, actionInfo);
            ret = true;
          }
        }
      } else {
        ret = true;
      }
      return ret;
    }

    private bool InterruptInteractionAction(CharacterInfo entity, ActionBreakLevel breakLevel)
    {
      bool ret = false;
      ActionInfo actionInfo = entity.GetInteractionStateInfo().GetActionInfo();
      if (null != actionInfo && actionInfo.IsActive) {
        ActionLogicData logicData = actionInfo.ConfigData;
        if (null != logicData) {
          if (breakLevel < actionInfo.BreakLevel) {
            if (ActionLogicDict.ContainsKey(logicData.ActionLogicId)) {
              ActionLogicDict[logicData.ActionLogicId].InterruptAction(entity, actionInfo);
            }
            InteractionSystem.OnActionInterrupted(entity, actionInfo);
            ret = true;
          }
        }
      } else {
        ret = true;
      }
      return ret;
    }

    /// 注册所有动作逻辑
    private void registerActionLogics()
    {
      registerLogic(new ActionLogic_0001());
      registerLogic(new ActionLogic_0002());
      registerLogic(new ActionLogic_0004());
      registerLogic(new ActionLogic_0005());
      registerLogic(new ActionLogic_0006());
      registerLogic(new ActionLogic_0007());
    }

    /// 将动作逻辑添加到容器
    private void registerLogic(IActionLogic logic)
    {
      if (ActionLogicDict.ContainsKey((int)logic.ActionLogicId)) {
        return;
      }
      ActionLogicDict.Add((int)logic.ActionLogicId, logic);
    }
  }
}

