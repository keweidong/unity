﻿using System.Collections;
using System.Collections.Generic;
using DashFire;
using GfxModule.Skill;
using ScriptRuntime;

namespace DashFire
{
  internal class SwordManSkillController : SkillController
  {
    private static int MOVE_BREAK_TYPE = 1;
    public static int SKILL_PRESS_UP = 0;
    private GfxSkillSystem m_GfxSkillSystem;
    private int m_PlayerSelfId;
    private CharacterInfo m_Owner;

    internal SwordManSkillController(CharacterInfo entity, GfxSkillSystem gfxskillsystem)
    {
      m_Owner = entity;
      m_PlayerSelfId = m_Owner.GetId();
      m_GfxSkillSystem = gfxskillsystem;
    }

    public override bool IsPlayerSelf()
    {
      if (m_Owner.IsUser && WorldSystem.Instance.PlayerSelfId == m_Owner.GetId()) {
        return true;
      }
      return false;
    }

    public override void Init()
    {
      List<SkillInfo> valide_player_skills = new List<SkillInfo>();
      List<SkillInfo> player_skills = m_Owner.GetSkillStateInfo().GetAllSkill();
      foreach (SkillInfo info in player_skills) {
        if (info != null && info.Category != SkillCategory.kNone) {
          valide_player_skills.Add(info);
        }
      }
      InitSkills(valide_player_skills);
      LogSystem.Debug("-----------------init skill of " + m_Owner.GetId());
      foreach (KeyValuePair<SkillCategory,SkillNode> pair in m_SkillCategoryDict) {
        SkillCategory category = pair.Key;
        string str = "" + category;
        SkillNode head = pair.Value;
        while (head != null) {
          str += head.SkillId + " ";
          head = head.NextSkillNode;
        }
        LogSystem.Debug(str);
      }
    }

    internal void InitSkills(List<SkillInfo> skills)
    {
      m_SkillCategoryDict.Clear();
      foreach (SkillInfo ss in skills) {
        if (IsCategoryContain(ss.SkillId)) {
          continue;
        }
        SkillNode first_node = InitCategorySkillNode(skills, ss);
        m_SkillCategoryDict[ss.Category] = first_node;
      }
      foreach (int id in m_UnlockedSkills) {
        SkillNode node = GetSkillNodeById(id);
        if (node != null) {
          node.IsLocked = false;
        }
      }
    }

    internal void OnPushStrSkill(string categoryStr)
    {
      SkillCategory category = GetSkillCategoryFromStr(categoryStr);
      if (category != SkillCategory.kNone) {
        base.PushSkill(category, Vector3.Zero);
      }
    }

    public override void BeginCurSkillCD()
    {
      if (m_CurSkillNode != null && !m_CurSkillNode.IsCDChecked) {
        base.BeginSkillCategoryCD(m_CurSkillNode.Category);
        m_CurSkillNode.IsCDChecked = true;
      }
    }

    public override bool StartSkill(SkillNode node)
    {
      if (WorldSystem.Instance.IsPvpScene() || WorldSystem.Instance.IsMultiPveScene()) {
        if (m_Owner.GetId() == WorldSystem.Instance.PlayerSelfId || m_Owner.OwnerId == WorldSystem.Instance.PlayerSelfId) {
          Network.NetworkSystem.Instance.SyncPlayerSkill(m_Owner, node.SkillId);
        }
      } else {
        if (!MakeSkillCost(node)) {
          return false;
        }
      }
      m_Owner.ResetCross2StandRunTime();
      m_Owner.GetSkillStateInfo().SetCurSkillInfo(node.SkillId);
      SkillInfo cur_skill = m_Owner.GetSkillStateInfo().GetCurSkillInfo();
      if (null == cur_skill) {
        LogSystem.Error("----------SkillError: {0} set cur skill {1} failed! it's not exist", m_Owner.GetId(), node.SkillId);
        return false;
      }
      cur_skill.IsSkillActivated = true;
      cur_skill.IsInterrupted = false;
      cur_skill.StartTime = TimeUtility.GetServerMilliseconds() / 1000.0f;
      UpdateSkillCD(node);
      //LogSystem.Debug("---start skill at {0}--{1}", cur_skill.SkillId, cur_skill.StartTime);
      CharacterView view = EntityManager.Instance.GetCharacterViewById(m_Owner.GetId());
      if (view != null) {
        GfxSystem.QueueGfxAction(m_GfxSkillSystem.StartSkill, view.Actor, node.SkillId, m_Owner.GetMovementStateInfo().GetWantFaceDir());
      }
      SimulateStartSkill(m_Owner, node.SkillId);
      return true;
    }

    public override bool ForceStartSkill(int skillid)
    {
      m_Owner.GetSkillStateInfo().SetCurSkillInfo(skillid);
      SkillInfo cur_skill = m_Owner.GetSkillStateInfo().GetCurSkillInfo();
      if (null == cur_skill) {
        LogSystem.Error("----------ForceStartSkillError: {0} set cur skill {1} failed! it's not exist", m_Owner.GetId(), skillid);
        return false;
      }
      if (cur_skill.SkillId != skillid) {
        LogSystem.Debug("----------ForceStartSkillError: {0} set cur skill {1} failed! it's {2}", m_Owner.GetId(), skillid, cur_skill.SkillId);
        return false;
      }
      if (null != cur_skill) {
        cur_skill.IsSkillActivated = true;
        cur_skill.IsInterrupted = false;
        cur_skill.StartTime = TimeUtility.GetServerMilliseconds() / 1000.0f;
        //LogSystem.Debug("---force start skill at {0}--{1}", cur_skill.SkillId, cur_skill.StartTime);
        CharacterView view = EntityManager.Instance.GetCharacterViewById(m_Owner.GetId());
        if (view != null) {
          GfxSystem.QueueGfxAction(m_GfxSkillSystem.StartSkill, view.Actor, skillid, m_Owner.GetMovementStateInfo().GetWantFaceDir());
        }
      } else {
        List<SkillInfo> skills = m_Owner.GetSkillStateInfo().GetAllSkill();
        LogSystem.Error("Can't find skill {0}, obj has {1} skills", skillid, skills.Count);
        foreach(SkillInfo info in skills) {
          LogSystem.Error("\tskill {0}", info.SkillId);
        }
      }
      SimulateStartSkill(m_Owner, skillid);
      return true;
    }

    public override void ForceInterruptCurSkill()
    {
      //LogSystem.Debug("----forceInterruptCurskill! " + m_Owner.GetId());
      CharacterView view = EntityManager.Instance.GetCharacterViewById(m_Owner.GetId());
      if (null != view) {
        m_Owner.GetMovementStateInfo().IsSkillMoving = false;
        view.ObjectInfo.IsSkillGfxMoveControl = false;
        view.ObjectInfo.IsSkillGfxRotateControl = false;
        view.ObjectInfo.IsSkillGfxAnimation = false;
        SkillInfo skill_info = m_Owner.GetSkillStateInfo().GetCurSkillInfo();
        if (skill_info != null) {
          if (skill_info.IsSkillActivated) {
            if (WorldSystem.Instance.IsPvpScene() || WorldSystem.Instance.IsMultiPveScene()) {
              if (m_Owner.GetId() == WorldSystem.Instance.PlayerSelfId || m_Owner.OwnerId == WorldSystem.Instance.PlayerSelfId) {
                Network.NetworkSystem.Instance.SyncGfxMoveControlStop(m_Owner, skill_info.SkillId, true);
                Network.NetworkSystem.Instance.SyncPlayerStopSkill(m_Owner, skill_info.SkillId);
              }
            }
            skill_info.IsInterrupted = true;
            if (m_WaiteSkillBuffer.Count > 0) {
              SkillNode last = m_WaiteSkillBuffer[m_WaiteSkillBuffer.Count - 1];
              SkillInfo last_info = m_Owner.GetSkillStateInfo().GetSkillInfoById(last.SkillId);
              m_WaiteSkillBuffer.Clear();
              if (last_info != null && last_info.ConfigData.CanStartWhenStiffness) {
                m_WaiteSkillBuffer.Add(last);
              }
            }
          }
          skill_info.IsSkillActivated = false;
          LogSystem.Debug("skill force interrupted " + skill_info.SkillId);
        }
        GfxSystem.QueueGfxAction(m_GfxSkillSystem.StopSkill, view.Actor, true);
        SimulateStopSkill(m_Owner);
      }
    }

    public override void AddBreakSection(int skillid, int breaktpye, int starttime, int endtime, bool isinterrupt, string skillmessage)
    {
      SkillInfo cur_skill = m_Owner.GetSkillStateInfo().GetSkillInfoById(skillid);
      if (cur_skill != null) {
        cur_skill.AddBreakSection(breaktpye, starttime, endtime, isinterrupt, skillmessage);
      }
    }

    public override void RemoveBreakSectionByType(int skillid, int breaktype)
    {
      SkillInfo cur_skill = m_Owner.GetSkillStateInfo().GetSkillInfoById(skillid);
      if (cur_skill != null) {
        cur_skill.RemoveBreakSectionByType(breaktype);
      }
    }

    public override bool StopSkill(SkillNode node, SkillNode nextnode)
    {
      return StopSkill(node, GetSkillNodeBreakType(nextnode));
    }

    public override bool BreakCurSkill(int breaktype, DashFire.SkillCategory category)
    {
      if (category == m_CurSkillNode.Category) {
        bool result = StopSkill(m_CurSkillNode, breaktype);
        if (!result) {
          m_CurSkillNode.IsAlreadyPressUp = true;
          SkillInfo skillInfo = m_Owner.GetSkillStateInfo().GetSkillInfoById(m_CurSkillNode.SkillId);
          if (skillInfo != null) {
            skillInfo.CalcuteCastTime(TimeUtility.GetServerMilliseconds() / 1000f);
          }
        }
        return result;
      }
      return false;
    }

    private void SimulateStartSkill(CharacterInfo owner, int skillid)
    {
      SkillNode node = GetSkillNodeById(skillid);
      if (node != null && node.Category == SkillCategory.kEx) {
        return;
      }
      List<NpcInfo> summons = owner.GetSkillStateInfo().GetSummonObject();
      foreach (NpcInfo npc in summons) {
        if (npc.IsSimulateMove) {
          npc.SkillController.ForceStartSkill(skillid);
        }
      }
    }

    private void SimulateStopSkill(CharacterInfo owner)
    {
      List<NpcInfo> summons = owner.GetSkillStateInfo().GetSummonObject();
      foreach (NpcInfo npc in summons) {
        if (npc.IsSimulateMove) {
          npc.SkillController.ForceInterruptCurSkill();
        }
      }
    }

    private void UpdateSkillCD(SkillNode node)
    {
      if (node == null) { 
        return;
      }
      SkillNode head = GetHead(node.Category);
      SkillInfo head_info = m_Owner.GetSkillStateInfo().GetSkillInfoById(head.SkillId);
      if (head.SkillId == node.SkillId) {
        head_info.BeginCD();
      } else {
        SkillInfo node_info = m_Owner.GetSkillStateInfo().GetSkillInfoById(node.SkillId);
        head_info.AddCD(node_info.ConfigData.CoolDownTime);
      }
    }

    public override float GetSkillCD(SkillNode node)
    {
      if (node == null) {
        return 0;
      }
      SkillNode head = GetHead(node.Category);
      if (head == null) {
        return 0;
      }
      SkillInfo head_info = m_Owner.GetSkillStateInfo().GetSkillInfoById(head.SkillId);
      return head_info.GetCD(TimeUtility.GetServerMilliseconds() / 1000.0f);
    }    

    public override bool IsSkillInCD(SkillNode node)
    {
      if (node == null) { 
        return false;
      }
      SkillNode head = GetHead(node.Category);
      if (node.SkillId != head.SkillId) {
        return false;
      }
      SkillInfo head_info = m_Owner.GetSkillStateInfo().GetSkillInfoById(head.SkillId);
      return head_info.IsInCd(TimeUtility.GetServerMilliseconds() / 1000.0f);
    }

    private bool IsCostEnough(SkillNode node)
    {
      SkillInfo info = m_Owner.GetSkillStateInfo().GetSkillInfoById(node.SkillId);
      if (info == null) {
        return false;
      }
      if (m_Owner.Energy >= info.ConfigData.CostEnergy 
        && m_Owner.Rage >= info.ConfigData.CostRage) {
        return true;
      }
      return false;
    }

    private bool MakeSkillCost(SkillNode node)
    {
      SkillInfo info = m_Owner.GetSkillStateInfo().GetSkillInfoById(node.SkillId);
      if (info == null) {
        return false;
      }
      if (m_Owner.Energy < info.ConfigData.CostEnergy) {
        return false;
      }
      if (m_Owner.Rage < info.ConfigData.CostRage) {
        return false;
      }
      m_Owner.SetEnergy(Operate_Type.OT_Relative, -info.ConfigData.CostEnergy);
      m_Owner.SetRage(Operate_Type.OT_Relative, -info.ConfigData.CostRage);
      return true;
    }

    public override bool StopSkill(SkillNode node, int breaktype)
    {
      if (!IsSkillActive(node)) {
        return true;
      }
      bool isinterrupt;
      string skillmessage;
      if (!IsSkillCanBreak(node, breaktype, out isinterrupt,out skillmessage)) {
        return false;
      }
      CharacterView view = EntityManager.Instance.GetCharacterViewById(m_Owner.GetId());
      if (view != null) {
        if (!string.IsNullOrEmpty(skillmessage)) {
          GfxSystem.QueueGfxAction(m_GfxSkillSystem.SendMessage, view.Actor, node.SkillId, skillmessage);
          return false;
        }
        //技能打断时逻辑层处理状态（包括技能激活状态与移动控制状态）并通知服务器，Gfx层不再处理状态
        if (isinterrupt) {
          m_Owner.GetMovementStateInfo().IsSkillMoving = false;
          view.ObjectInfo.IsSkillGfxMoveControl = false;
          view.ObjectInfo.IsSkillGfxRotateControl = false;
          view.ObjectInfo.IsSkillGfxAnimation = false;
          SkillInfo skillInfo = m_Owner.GetSkillStateInfo().GetSkillInfoById(node.SkillId);
          if (null != skillInfo) {
            skillInfo.IsSkillActivated = false;
            //LogSystem.Debug("---------StopSkill " + node.SkillId);
          }
          if (WorldSystem.Instance.IsPvpScene() || WorldSystem.Instance.IsMultiPveScene()) {
            if (m_Owner.GetId() == WorldSystem.Instance.PlayerSelfId || m_Owner.OwnerId == WorldSystem.Instance.PlayerSelfId) {
              Network.NetworkSystem.Instance.SyncGfxMoveControlStop(m_Owner, node.SkillId, true);
              Network.NetworkSystem.Instance.SyncPlayerStopSkill(m_Owner, node.SkillId);
            }
          }
        }
        //通知Gfx停止技能
        GfxSystem.QueueGfxAction(m_GfxSkillSystem.StopSkill, view.Actor, isinterrupt);
        SimulateStopSkill(m_Owner);
      }
      return true;
    }

    public override bool IsSkillActive(SkillNode node)
    {
      SkillInfo cur_skill = GetSkillInfoByNode(node);
      if (cur_skill == null) {
        return false;
      }
      return cur_skill.IsSkillActivated;
    }

    public override bool IsSkillCanBreak(SkillNode node, SkillNode nextnode = null)
    {
      bool IsInterrupt;
      string skillmessage;
      return IsSkillCanBreak(node, GetSkillNodeBreakType(nextnode), out IsInterrupt, out skillmessage);
    }

    public override bool IsSkillCanBreak(SkillNode node, int breaktype, out bool isinterrupt,out string skillmessage)
    {
      isinterrupt = false;
      skillmessage = "";
      SkillInfo cur_skill = GetSkillInfoByNode(node);
      if (cur_skill == null) {
        return true;
      }
      return cur_skill.CanBreak(breaktype, TimeUtility.GetServerMilliseconds(), out isinterrupt, out skillmessage);
    }

    private int GetSkillNodeBreakType(SkillNode node)
    {
      int breaktype = MOVE_BREAK_TYPE;
      SkillInfo next_skill = GetSkillInfoByNode(node);
      if (next_skill != null) {
        breaktype = next_skill.ConfigData.BreakType;
      }
      return breaktype;
    }

    internal SkillInfo GetSkillInfoByNode(SkillNode node)
    {
      SkillInfo result = null;
      if (node != null) {
        SkillStateInfo state = m_Owner.GetSkillStateInfo();
        if (state != null) {
          result = state.GetSkillInfoById(node.SkillId);
        }
      }
      return result;
    }

    public override bool IsSkillCanStart(SkillNode node, out SkillCannotCastType reason)
    {
      SkillStateInfo state = m_Owner.GetSkillStateInfo();
      SkillInfo info = state.GetSkillInfoById(node.SkillId);
      reason = SkillCannotCastType.kUnknow;
      if (info == null) {
        reason = SkillCannotCastType.kNotFindSkill;
        return false;
      }
      if (m_Owner.IsDead()) {
        reason = SkillCannotCastType.kOwnerDead;
        return false;
      }
      if (state != null && m_Owner.IsUnderControl() && !CanStartWhenImpactControl(info)) {
        reason = SkillCannotCastType.kCannotCtrol;
        return false;
      }
      if (IsSkillInCD(node)) {
        reason = SkillCannotCastType.kInCD;
        return false;
      }
      if (!IsCostEnough(node)) {
        reason = SkillCannotCastType.kCostNotEnough;
        return false;
      }
      SkillInfo skillinfo = m_Owner.GetSkillStateInfo().GetCurSkillInfo();
      if (skillinfo != null && skillinfo.IsForbidNextSkill 
        && skillinfo.ConfigData != null && skillinfo.ConfigData.NextSkillId == node.SkillId) {
        reason = SkillCannotCastType.kUnknow;
        return false;
      }
      return true;
    }

    public override float GetWaitInputTime(SkillNode node)
    {
      if (node == null) {
        return 0;
      }
      SkillInfo skill = m_Owner.GetSkillStateInfo().GetSkillInfoById(node.SkillId);
      if (skill == null) {
        return 0;
      }
      if (skill.IsInterrupted) {
        return 0;
      }
      return skill.StartTime + skill.CastTime + skill.ConfigData.NextInputTime;
    }

    public override float GetLockInputTime(SkillNode node, SkillCategory next_category)
    {
      if (node == null) {
        return 0;
      }
      SkillInfo skill = m_Owner.GetSkillStateInfo().GetSkillInfoById(node.SkillId);
      if (skill == null) {
        return 0;
      }
      return skill.StartTime + skill.GetLockInputTime(next_category);
    }


    private bool CanStartWhenImpactControl(SkillInfo skillinfo)
    {
      switch (m_Owner.GfxStateFlag) {
        case (int)GfxCharacterState_Type.Stiffness:
          return skillinfo.ConfigData.CanStartWhenStiffness;
        case (int)GfxCharacterState_Type.HitFly:
          return skillinfo.ConfigData.CanStartWhenHitFly;
        case (int)GfxCharacterState_Type.KnockDown:
          return skillinfo.ConfigData.CanStartWhenKnockDown;
        default:
          return false;
      }
    }

    private bool IsCategoryContain(int skillid)
    {
      foreach (SkillNode head in m_SkillCategoryDict.Values) {
        if (FindSkillNodeInChildren(head, skillid) != null) {
          return true;
        }
      }
      return false;
    }

    private SkillCategory GetSkillCategoryFromStr(string categoryStr)
    {
      if (categoryStr.Equals("SkillA")) {
        return SkillCategory.kSkillA;
      }
      if (categoryStr.Equals("SkillB")) {
        return SkillCategory.kSkillB;
      }
      if (categoryStr.Equals("SkillC")) {
        return SkillCategory.kSkillC;
      }
      if (categoryStr.Equals("SkillD")) {
        return SkillCategory.kSkillD;
      }
      if (categoryStr.Equals("SkillEx")) {
        return SkillCategory.kEx;
      }
      return SkillCategory.kNone;
    }

    protected override void BeginSkillCategoryCD(SkillCategory category)
    {
      if (null != m_Owner && WorldSystem.Instance.PlayerSelfId == m_Owner.GetId()) {
        SkillNode head = null;
        if (m_SkillCategoryDict.TryGetValue(category, out head)) {
          GfxSystem.PublishGfxEvent("ge_cast_skill_cd", "ui",
                                     GetCategoryName(head.Category),
                                     GetSkillCD(head));
        }
      }
    }
  }
}