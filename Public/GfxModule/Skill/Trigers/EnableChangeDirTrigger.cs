using System;
using System.Collections.Generic;
using UnityEngine;
using SkillSystem;

namespace GfxModule.Skill.Trigers
{
  public class EnableChangeDirTrigger : AbstractSkillTriger
  {
    public override ISkillTriger Clone()
    {
      EnableChangeDirTrigger copy = new EnableChangeDirTrigger();
      copy.m_StartTime = m_StartTime;
      copy.m_RemainTime = m_RemainTime;
      return copy;
    }

    public override void Reset()
    {
      m_IsInited = false;
      if (m_SharedObjInfo != null) {
        m_SharedObjInfo.IsSkillGfxRotateControl = false;
      }
      m_SharedObjInfo = null;
      DashFire.LogicSystem.EventChannelForGfx.Publish("set_gesture_enable", "ui", true);
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      if (callData.GetParamNum() >= 2) {
        m_StartTime = long.Parse(callData.GetParamId(0));
        m_RemainTime = long.Parse(callData.GetParamId(1));
      }
    }

    public override bool Execute(object sender, SkillInstance instance, long delta, long curSectionTime)
    {
      if (curSectionTime < m_StartTime) {
        return true;
      }
      if (curSectionTime > (m_StartTime + m_RemainTime)) {
        DashFire.LogicSystem.EventChannelForGfx.Publish("set_gesture_enable", "ui", true);
        return false;
      }
      GameObject obj = sender as GameObject;
      if (obj == null) {
        return false;
      }

      if (!m_IsInited) {
        m_IsInited = true;
        m_SharedObjInfo = DashFire.LogicSystem.GetSharedGameObjectInfo(obj);
        if (m_SharedObjInfo == null) {
          return false;
        }
        DashFire.LogicSystem.EventChannelForGfx.Publish("set_gesture_enable", "ui", false);
        m_SharedObjInfo.IsSkillGfxRotateControl = false;
      }
      GfxSkillSystem.ChangeDir(obj, m_SharedObjInfo.WantFaceDir);
      return true;
    }

    private long m_RemainTime;

    private DashFire.SharedGameObjectInfo m_SharedObjInfo = null;
    private bool m_IsInited = false;
  }
}
