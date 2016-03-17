using System;
using System.Collections.Generic;

namespace DashFire
{
  public interface IImpactLogic
  {
    void StartImpact(CharacterInfo obj, int impactId);
    void Tick(CharacterInfo obj, int impactId);
    void StopImpact(CharacterInfo obj, int impactId);
    void OnInterrupted(CharacterInfo obj, int impactId);
    int RefixHpDamage(CharacterInfo obj, int impactId, int hpDamage, int senderId, ref bool isCritical, int impact_owner);
    void OnAddImpact(CharacterInfo obj, int impactId, int addImpactId);
    bool CanInterrupt(CharacterInfo obj, int impactId);
  }

  public abstract class AbstractImpactLogic : IImpactLogic {

    public delegate void ImpactLogicDamageDelegate(CharacterInfo entity, int attackerId, int damage, bool isKiller, bool isCritical, bool isOrdinary);
    public delegate void ImpactLogicSkillDelegate(CharacterInfo entity, int skillId);
    public delegate void ImpactLogicEffectDelegate(CharacterInfo entity, string effectPath, string bonePath, float recycleTime);
    public delegate void ImpactLogicScreenTipDelegate(CharacterInfo entity, string tip);
    public delegate void ImpactLogicRageDelegate(CharacterInfo entity, int rage);
    public static ImpactLogicDamageDelegate EventImpactLogicDamage;
    public static ImpactLogicSkillDelegate EventImpactLogicSkill;
    public static ImpactLogicEffectDelegate EventImpactLogicEffect;
    public static ImpactLogicScreenTipDelegate EventImpactLogicScreenTip;
    public static ImpactLogicRageDelegate EventImpactLogicRage;
    public virtual void StartImpact(CharacterInfo obj, int impactId) {
      if (null != obj) {
        ImpactInfo impactInfo = obj.GetSkillStateInfo().GetImpactInfoById(impactId);
        if (null != impactInfo) {
          if (impactInfo.ConfigData.BreakSuperArmor) {
            obj.SuperArmor = false;
          }
        }
        if (obj is NpcInfo) {
          NpcInfo npcObj = obj as NpcInfo;
          NpcAiStateInfo aiInfo = npcObj.GetAiStateInfo();
          if (null != aiInfo && 0 == aiInfo.HateTarget) {
            aiInfo.HateTarget = impactInfo.m_ImpactSenderId;
          }
        }
      }
    }
    public virtual void Tick(CharacterInfo obj, int impactId) {
      ImpactInfo impactInfo = obj.GetSkillStateInfo().GetImpactInfoById(impactId);
      if (null != impactInfo && impactInfo.m_IsActivated) {
        long curTime = TimeUtility.GetServerMilliseconds();
        if (curTime > impactInfo.m_StartTime + impactInfo.m_ImpactDuration) {
          impactInfo.m_IsActivated = false;
        }
      }
    }

    public virtual void StopImpact(CharacterInfo obj, int impactId) {
    }

    public virtual void OnInterrupted(CharacterInfo obj, int impactId) {
      StopImpact(obj, impactId);
    }

    public virtual int RefixHpDamage(CharacterInfo obj, int impactId, int hpDamage, int senderId, ref bool isCritical, int impactOwnerId)
    {
      return hpDamage;
    }

    public virtual void OnAddImpact(CharacterInfo obj, int impactId, int addImpactId)
    {
    }
    public virtual bool CanInterrupt(CharacterInfo obj, int impactId)
    {
      return true;
    }
    protected bool IsImpactDamageOrdinary(CharacterInfo target, int impactId)
    {
      if (null != target) {
        ImpactInfo impactInfo = target.GetSkillStateInfo().GetImpactInfoById(impactId);
        if (null != impactInfo) {
          CharacterInfo sender = target.SceneContext.GetCharacterInfoById(impactInfo.m_ImpactSenderId);
          if (null != sender) {
            SkillInfo skillInfo = sender.GetSkillStateInfo().GetSkillInfoById(impactInfo.m_SkillId);
            if (null != skillInfo) {
              if (skillInfo.Category == SkillCategory.kAttack) {
                return true;
              }
            }
          }
        }
      }
      return false;
    }

    protected void ApplyDamage(CharacterInfo obj, CharacterInfo sender, int damage)
    {
      if (null != obj && !obj.IsDead()) {
        if (GlobalVariables.Instance.IsClient && obj.SceneContext.IsRunWithRoomServer) {
          return;
        }
        bool isKiller = false;
        if (damage < 1) {
          return;
        }
        UserInfo user = obj as UserInfo;
        if (null != user) {
          user.GetCombatStatisticInfo().AddTotalDamageToMyself(damage);
        }
        UserInfo senderUser = sender as UserInfo;
        if (null != senderUser) {
          senderUser.GetCombatStatisticInfo().AddTotalDamageFromMyself(damage);
        }
        sender.MakeDamange += damage;
        damage = damage * -1;
        int realDamage = damage;
        if (obj.Hp + damage < 0) {
          realDamage = 0 - obj.Hp;
        }
        obj.SetHp(Operate_Type.OT_Relative, realDamage);
        if (obj.IsDead()) {
          isKiller = true;
        }
        if (null != EventImpactLogicDamage) {
          EventImpactLogicDamage(obj, sender.GetId(), damage, isKiller, false, true);
        }
      }
    }
    protected void ApplyDamage(CharacterInfo obj, int impactId) {
      if (null != obj && !obj.IsDead()) {
        if (GlobalVariables.Instance.IsClient && obj.SceneContext.IsRunWithRoomServer) {
          return;
        }
        ImpactInfo impactInfo = obj.GetSkillStateInfo().GetImpactInfoById(impactId);
        if (null != impactInfo) {
          CharacterInfo sender = obj.SceneContext.GetCharacterInfoById(impactInfo.m_ImpactSenderId);
          ApplyDamageImpl(sender, obj, impactInfo, impactInfo.ConfigData.IsIgnorePassiveCheck);
        }
      }
    }

    protected void ApplyDamageImpl(CharacterInfo sender, CharacterInfo obj, ImpactInfo impactInfo, bool is_ignore_passive_check = false)
    {
      int skillLevel = 0;
      bool isCritical = false;
      bool isOrdinary = false;
      if (null != sender) {
        SkillInfo skillInfo = sender.GetSkillStateInfo().GetSkillInfoById(impactInfo.m_SkillId);
        if (null != skillInfo) {
          skillLevel = skillInfo.SkillLevel;
          if (skillInfo.Category == SkillCategory.kAttack) {
            isOrdinary = true;
          }
        }
        int curDamage = DamageCalculator.CalcImpactDamage(
          sender,
          obj,
          (SkillDamageType)impactInfo.ConfigData.DamageType,
          ElementDamageType.DC_None == (ElementDamageType)impactInfo.ConfigData.ElementType ? sender.GetEquipmentStateInfo().WeaponDamageType : (ElementDamageType)impactInfo.ConfigData.ElementType,
          impactInfo.ConfigData.DamageRate + skillLevel * impactInfo.ConfigData.LevelRate,
          impactInfo.ConfigData.DamageValue,
          out isCritical);
        List<ImpactInfo> targetImpactInfos = obj.GetSkillStateInfo().GetAllImpact();
        for (int i = 0; i < targetImpactInfos.Count; i++ )
        {
          if (is_ignore_passive_check && targetImpactInfos[i].m_ImpactType == (int)ImpactType.PASSIVE)
          {
            continue;
          }
          IImpactLogic logic = ImpactLogicManager.Instance.GetImpactLogic(obj.GetSkillStateInfo().GetAllImpact()[i].ConfigData.ImpactLogicId);
          if (null != logic)
          {
            curDamage = logic.RefixHpDamage(obj, targetImpactInfos[i].m_ImpactId, curDamage, sender.GetId(), ref isCritical, obj.GetId());
          }
        }
        /*
        foreach (ImpactInfo ii in obj.GetSkillStateInfo().GetAllImpact()) {
          if (is_ignore_passive_check && ii.m_ImpactType == (int)ImpactType.PASSIVE) {
            continue;
          }
          IImpactLogic logic = ImpactLogicManager.Instance.GetImpactLogic(ii.ConfigData.ImpactLogicId);
          if (null != logic) {
            curDamage = logic.RefixHpDamage(obj, ii.m_ImpactId, curDamage, sender.GetId(), ref isCritical, obj.GetId());
          }
        }*/
        if (!is_ignore_passive_check) {
          List<ImpactInfo> senderImpactInfos = sender.GetSkillStateInfo().GetAllImpact();
          for (int i = 0; i < senderImpactInfos.Count; i++)
          {
            if (senderImpactInfos[i].m_ImpactType == (int)ImpactType.PASSIVE)
            {
              IImpactLogic logic = ImpactLogicManager.Instance.GetImpactLogic(senderImpactInfos[i].ConfigData.ImpactLogicId);
              if (null != logic)
              {
                curDamage = logic.RefixHpDamage(obj, senderImpactInfos[i].m_ImpactId, curDamage, sender.GetId(), ref isCritical, sender.GetId());
              }
            }
          }
          /*
          foreach (ImpactInfo passive_impact in sender.GetSkillStateInfo().GetAllImpact()) {
            if (passive_impact.m_ImpactType == (int)ImpactType.PASSIVE) {
              IImpactLogic logic = ImpactLogicManager.Instance.GetImpactLogic(passive_impact.ConfigData.ImpactLogicId);
              if (null != logic) {
                curDamage = logic.RefixHpDamage(obj, passive_impact.m_ImpactId, curDamage, sender.GetId(), ref isCritical, sender.GetId());
              }
            }
          }*/
        }
        OnCharacterDamage(sender, obj, curDamage, isCritical, isOrdinary);
      }
    }

    public void OnCharacterDamage(CharacterInfo sender, CharacterInfo obj, int curDamage, bool isCritical, bool isOrdinary)
    {
      bool isKiller = false;
      // 计算出的伤害小于1时， 不处理
      if (curDamage < 1) {
        return;
      }
      UserInfo user = obj as UserInfo;
      if (null != user) {
        user.GetCombatStatisticInfo().AddTotalDamageToMyself(curDamage);
      }
      UserInfo senderUser = sender as UserInfo;
      if (null != senderUser) {
        senderUser.GetCombatStatisticInfo().AddTotalDamageFromMyself(curDamage);
      }
      sender.MakeDamange += curDamage;
      curDamage = curDamage * -1;
      int realDamage = curDamage;
      if (obj.Hp + curDamage < 0) {
        realDamage = 0 - obj.Hp;
      }
      obj.SetHp(Operate_Type.OT_Relative, realDamage);
      if (obj.IsDead()) {
        isKiller = true;
      }
      if (null != EventImpactLogicDamage) {
        EventImpactLogicDamage(obj, sender.GetId(), curDamage, isKiller, isCritical, isOrdinary);
      }
    }
  }
}
