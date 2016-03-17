using System;
using System.Collections.Generic;

namespace DashFire
{
  public enum SlotPosition : int {
    SP_None = 0,
    SP_A,
    SP_B,
    SP_C,
    SP_D,
  }
  public class SkillTransmitArg 
  {
    public SkillTransmitArg()
    {
      SkillId = 0;
      SkillLevel = 0;
    }
    public int SkillId;
    public int SkillLevel;
  }
  public class PresetInfo 
  {
    public PresetInfo()
    {
      for (int i = 0; i < PresetNum; i++) {
        Presets[i] = SlotPosition.SP_None;
      }
    }
    public void Reset()
    {
      for (int i = 0; i < PresetNum; i++) {
        Presets[i] = SlotPosition.SP_None;
      }
    }
    public void SetCurSkillSlotPos(int preset, SlotPosition pos)
    {
      if (preset >=0 && preset < PresetNum) {
        Presets[preset] = pos;
      }
    }
    public const int PresetNum = 4;
    public SlotPosition[] Presets = new SlotPosition[PresetNum];
  }
  public class BreakSection
  {
    public BreakSection(int breaktype, int starttime, int endtime, bool isinterrupt, string skillmessage)
    {
      BreakType = breaktype;
      StartTime = starttime;
      EndTime = endtime;
      IsInterrupt = isinterrupt;
      SkillMessage = skillmessage;
    }
    public int BreakType;
    public int StartTime;
    public int EndTime;
    public bool IsInterrupt;
    public string SkillMessage;
  }

  public class SkillInfo
  {
    public int SkillId;                // 技能Id
    public int SkillLevel;             // 技能等级
    public bool IsSkillActivated;      // 是否正在释放技能    
    public bool IsItemSkill;
    public bool IsMarkToRemove;
    public bool IsForbidNextSkill;       //是否不释放下一个技能
    public PresetInfo Postions;         // 技能挂载位置信息
    public int NextSkillId;
    public int QSkillId;
    public int ESkillId;
    public SkillCategory Category = SkillCategory.kNone;
    public SkillLogicData ConfigData = null;

    public float StartTime;
    public float CastTime;
    public bool IsInterrupted;
    private List<BreakSection> BreakSections = new List<BreakSection>();
	//Note: 因Release版本的编译需要，MyDictionary不支持枚举类型，替换为int，by lixiaojiang
    private MyDictionary<int, float> m_CategoryLockinputTime = new MyDictionary<int, float>();
    private float m_CDEndTime;

    //校验数据
    public int m_LeftEnableMoveCount = 0;
    public Dictionary<int, List<int>> m_LeftEnableImpactsToOther = new Dictionary<int, List<int>>();
    public List<int> m_LeftEnableImpactsToMyself = new List<int>();
    public int m_EnableMoveCount = 0;
    public float m_MaxMoveDistance = 0.0f;
    public List<int> m_EnableImpactsToOther = null;
    public List<int> m_EnableImpactsToMyself = null;
    public List<int> m_EnableSummonNpcs = null;

    public SkillInfo (int skillId, int level = 0)
    {
      CastTime = 0f;
      SkillId = skillId;
      SkillLevel = level;
      IsSkillActivated = false;
      IsItemSkill = false;
      IsMarkToRemove = false;
      IsInterrupted = false;
      IsForbidNextSkill = false;
      Postions = new PresetInfo();
      ConfigData = SkillConfigProvider.Instance.ExtractData(SkillConfigType.SCT_SKILL, skillId) as SkillLogicData;
      if (ConfigData != null) {
        NextSkillId = ConfigData.NextSkillId;
        QSkillId = ConfigData.QSkillId;
        ESkillId = ConfigData.ESkillId;
        Category = ConfigData.Category;
      }
    }
    
    public virtual void Reset()
    {
      CastTime = 0f;
      IsSkillActivated = false;
      IsItemSkill = false;
      IsMarkToRemove = false;
      IsInterrupted = false;
      IsForbidNextSkill = false;
      BreakSections.Clear();
      m_CategoryLockinputTime.Clear();
    }

    public void CalcuteCastTime(float now)
    {
      float gap = now - StartTime;
      SkillLogicData skill_data = SkillConfigProvider.Instance.ExtractData(SkillConfigType.SCT_SKILL, SkillId) as SkillLogicData;
      if (skill_data != null && gap < skill_data.CastTime) {
        m_CDEndTime -= (skill_data.CastTime - gap);
        CastTime = gap;
      }
    }

    public void BeginCD()
    {
      SkillLogicData skill_data = SkillConfigProvider.Instance.ExtractData(SkillConfigType.SCT_SKILL, SkillId) as SkillLogicData;
      if (skill_data != null) {
        CastTime = skill_data.CastTime;
      }
      m_CDEndTime = StartTime + ConfigData.CoolDownTime + CastTime;
    }

    public void AddCD(float time)
    {
      m_CDEndTime += time;
    }

    public float GetCD(float now)
    {
      return m_CDEndTime - now;
    }

    public bool IsInCd(float now)
    {
      if (now < m_CDEndTime) {
        return true;
      } else {
        return false;
      }
    }

    public void AddBreakSection(int breaktype, int starttime, int endtime, bool isinterrupt, string skillmessage)
    {
      BreakSection section = new BreakSection(breaktype, starttime, endtime, isinterrupt, skillmessage);
      BreakSections.Add(section);
    }

    public void RemoveBreakSectionByType(int breaktype)
    {
      BreakSections.RemoveAll(info => info.BreakType == breaktype);
    }

    public void AddLockInputTime(SkillCategory category, float lockinputtime)
    {
      if (m_CategoryLockinputTime.ContainsKey((int)category)) {
        m_CategoryLockinputTime[(int)category] = lockinputtime;
      } else {
        m_CategoryLockinputTime.Add((int)category, lockinputtime);
      }
    }

    public float GetLockInputTime(SkillCategory category)
    {
      float v;
      if (!m_CategoryLockinputTime.TryGetValue((int)category, out v)) {
        v = ConfigData.LockInputTime;
      }
      return v;
    }

    public bool CanBreak(int breaktype, long time, out bool isInterrupt,out string skillMessage)
    {
      isInterrupt = false;
      skillMessage = "";
      if (!IsSkillActivated) {
        return true;
      }
      for (int i = 0; i < BreakSections.Count; i++ )
      {
        if (BreakSections[i].BreakType == breaktype &&
            (StartTime * 1000 + BreakSections[i].StartTime) <= time
            && time <= (StartTime * 1000 + BreakSections[i].EndTime))
        {
          isInterrupt = BreakSections[i].IsInterrupt;
          skillMessage = BreakSections[i].SkillMessage;
          return true;
        }
      }
      /*
      foreach (BreakSection section in BreakSections) {
        if (section.BreakType == breaktype &&
            (StartTime * 1000 + section.StartTime) <= time
            && time <= (StartTime * 1000 + section.EndTime)) {
          isInterrupt = section.IsInterrupt;
          return true;
        }
      }*/
      return false;
    }

    public virtual bool IsNull()
    {
      return false;
    }
  }

  public class NullSkillInfo : SkillInfo
  {
    public NullSkillInfo():base(-1)
    {
      SkillLevel = 0;
    }
    public override bool IsNull()
    {
      return true;
    }
  }
}
