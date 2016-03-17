using System;
using System.Collections.Generic;
using ScriptRuntime;
using DashFireSpatial;

namespace DashFire
{
  public enum NpcTypeEnum
  {
    Normal = 0,
    Skill,
    Mecha,
    Horse,
    InteractiveNpc,
    PvpTower,
    AutoPickItem,
    Task,
    BigBoss,
    LittleBoss,
    SceneObject,
    Friend,
    Partner,
  }

  public enum NpcFigureEnum
  {
    Normal = 0,
    Big,
  }

  public enum DropNpcTypeEnum
  {
    GOLD = 110001,
    HP = 110002,
    MP = 110003,
    MUTI_GOLD = 110004,
  }

  public class NpcInfo : CharacterInfo
  {
    public int NpcType
    {
      get { return m_NpcType; }
    }
    public int NpcFigure
    {
      get { return m_NpcFigure; }
    }
    public float Scale
    {
      get { return m_Scale; }
    }
    public bool CanMove
    {
      get { return m_CanMove; }
    }

    public bool CanHitMove
    {
      get { return m_CanHitMove; }
    }
    public bool CanRotate
    {
      get { return m_CanRotate; }
    }
    public bool IsAttachControler
    {
      get { return m_IsAttachControler; }
      set { m_IsAttachControler = true; }
    }
    public string AttachNodeName
    {
      get { return m_AttachNodeName; }
    }
    public int DropMoney
    {
      get { return m_DropMoney; }
      set { m_DropMoney = value; }
    }
    public int SummonOwnerId
    {
      get { return m_SummonOwnerId; }
      set { m_SummonOwnerId = value; }
    }
    public bool IsSimulateMove
    {
      get { return m_IsSimulateMove; }
      set { m_IsSimulateMove = value; }
    }
    public long LifeEndTime
    {
      get { return m_LifeEndTime; }
      set { m_LifeEndTime = value; }
    }
    public int CreatorId
    {
      get { return m_CreatorId; }
      set { m_CreatorId = value; }
    }

    public int BornAnimTimeMs
    {
      get { return m_BornAnimTimeMs; }
    }
    public long BornTime
    {
      set { m_BornTime = value; }
      get { return m_BornTime; }
    }

    public bool IsBorning { set; get; }

    public bool IsTaunt {
      get { return m_IsTaunt; }
      set { m_IsTaunt = value; }
    }
    
    public bool NeedDelete
    {
      get { return m_NeedDelete; }
      set { m_NeedDelete = value; }
    }
    public long MeetEnemyStayTime
    {
      get { return m_MeetEnemyStayTime; }
      set { m_MeetEnemyStayTime = value; }
    }
    public long MeetEnemyWalkTime
    {
      get { return m_MeetEnemyWalkTime; }
      set { m_MeetEnemyWalkTime = value; }
    }
    public bool FollowSummonerDead
    {
      get { return m_FollowSummonerDead; }
      set { m_FollowSummonerDead = value; }
    }
    public int SignForSkill
    {
      get { return m_SignForSkill; }
      set { m_SignForSkill = value; }
    }
    public int DeadSkillId
    {
      get { return m_DeadSkillId; }
    }
    public string TauntSound
    {
      get { return m_TauntSound; }
    }
    public NpcInfo(int id)
      : base(id)
    {
      m_SpaceObject = new SpaceObjectImpl(this, SpatialObjType.kNPC);
      m_CastNpcInfo = this;
    }

    public void InitId(int id)
    {
      m_Id = id;
    }

    public void Reset()
    {
      m_NeedDelete = false;
      m_SummonOwnerId = -1;
      m_IsSimulateMove = false;
      m_LifeEndTime = -1;
      m_MakeDamage = 0;

      ResetCharacterInfo();
      GetAiStateInfo().Reset();
      GetAiStateInfo().AiDatas.Clear();
    }

    public void LoadData(Data_Unit unit)
    {
      SetUnitId(unit.m_Id);
      SetCampId(unit.m_CampId);
      GetAiStateInfo().AiLogic = unit.m_AiLogic;
      for (int i = 0; i < Data_Unit.c_MaxAiParamNum; ++i) {
        GetAiStateInfo().AiParam[i] = unit.m_AiParam[i];
      }
      GetMovementStateInfo().SetPosition(unit.m_Pos);
      GetMovementStateInfo().SetFaceDir(unit.m_RotAngle);
      LoadData(unit.m_LinkId);
    }

    public void LoadData(int resId)
    {
      SetLinkId(resId);
      m_LevelupConfig = NpcConfigProvider.Instance.GetNpcLevelupConfigById(resId);
      Data_NpcConfig npcCfg = NpcConfigProvider.Instance.GetNpcConfigById(resId);
      if (null != npcCfg) {
        m_NpcType = npcCfg.m_NpcType;
        switch (m_NpcType) {
          case (int)NpcTypeEnum.Mecha:
            m_IsMecha = true;
            break;
          case (int)NpcTypeEnum.Horse:
            m_IsHorse = true;
            break;
          case (int)NpcTypeEnum.Task:
            m_IsTask = true;
            break;
          case (int)NpcTypeEnum.PvpTower:
            m_IsPvpTower = true;
            break;
        }
        m_NpcFigure = npcCfg.m_NpcFigure;
        m_CanMove = npcCfg.m_CanMove;
        m_CanHitMove = npcCfg.m_CanHitMove;
        m_CanRotate = npcCfg.m_CanRotate;
        m_Scale = npcCfg.m_Scale;
        m_ParticleScale = npcCfg.m_ParticleScale;
        m_CauseStiff = npcCfg.m_CauseStiff;
        m_AcceptStiff = npcCfg.m_AcceptStiff;
        m_AcceptStiffEffect = npcCfg.m_AcceptStiffEffect;

        m_IsAttachControler = npcCfg.m_IsAttachControler;
        m_AttachNodeName = npcCfg.m_AttachNodeName;
        m_BornAnimTimeMs = npcCfg.m_BornAnimTime;

        SetName(npcCfg.m_Name);
        SetLevel(npcCfg.m_Level);
        SetModel(npcCfg.m_Model);
        SetBornEffect(npcCfg.m_BornEffect);
        SetBornEffectTime(npcCfg.m_BornEffectTime);
        SetDeadSound(npcCfg.m_DeadSound);
        SetActionList(npcCfg.m_ActionList);
                
        AvoidanceRadius = npcCfg.m_AvoidanceRadius;
        if (null != npcCfg.m_Shape)
          Shape = (Shape)npcCfg.m_Shape.Clone();
        else
          Shape = new Circle(new Vector3(0, 0, 0), 1);

        ViewRange = npcCfg.m_ViewRange;
        GohomeRange = npcCfg.m_GohomeRange;
        ReleaseTime = npcCfg.m_ReleaseTime;
        SuperArmor = npcCfg.m_SuperArmor;
        m_MeetEnemyImpact = npcCfg.m_MeetEnemyImpact;
        m_MeetEnemyStayTime = npcCfg.m_MeetEnemyStayTime;
        m_MeetEnemyWalkTime = npcCfg.m_MeetEnemyWalkTime;

        int hp = (int)npcCfg.m_AttrData.GetAddHpMax(0, npcCfg.m_Level);
        int energy = (int)npcCfg.m_AttrData.GetAddEpMax(0, npcCfg.m_Level);
        float moveSpeed = npcCfg.m_AttrData.GetAddSpd(0, npcCfg.m_Level);
        float walkSpeed = npcCfg.m_AttrData.GetAddWalkSpd(0, npcCfg.m_Level);
        float runSpeed = npcCfg.m_AttrData.GetAddRunSpd(0, npcCfg.m_Level);
        int hpMax = (int)npcCfg.m_AttrData.GetAddHpMax(0, npcCfg.m_Level);
        int energyMax = (int)npcCfg.m_AttrData.GetAddEpMax(0, npcCfg.m_Level);
        float hpRecover = npcCfg.m_AttrData.GetAddHpRecover(0, npcCfg.m_Level);
        float energyRecover = npcCfg.m_AttrData.GetAddEpRecover(0, npcCfg.m_Level);
        int attackBase = (int)npcCfg.m_AttrData.GetAddAd(0, npcCfg.m_Level);
        int aDefenceBase = (int)npcCfg.m_AttrData.GetAddADp(0, npcCfg.m_Level);
        int mDefenceBase = (int)npcCfg.m_AttrData.GetAddMDp(0, npcCfg.m_Level);
        float critical = npcCfg.m_AttrData.GetAddCri(0, npcCfg.m_Level);
        float criticalPow = npcCfg.m_AttrData.GetAddPow(0, npcCfg.m_Level);
        float criticalBackHitPow = npcCfg.m_AttrData.GetAddBackHitPow(0, npcCfg.m_Level);
        float criticalCrackPow = npcCfg.m_AttrData.GetAddCrackPow(0, npcCfg.m_Level);
        float fireDam = npcCfg.m_AttrData.GetAddFireDam(0, npcCfg.m_Level);
        float fireErd = npcCfg.m_AttrData.GetAddFireErd(0, npcCfg.m_Level);
        float iceDam = npcCfg.m_AttrData.GetAddIceDam(0, npcCfg.m_Level);
        float iceErd = npcCfg.m_AttrData.GetAddIceErd(0, npcCfg.m_Level);
        float poisonDam = npcCfg.m_AttrData.GetAddPoisonDam(0, npcCfg.m_Level);
        float poisonErd = npcCfg.m_AttrData.GetAddPoisonErd(0, npcCfg.m_Level);
        float weight = npcCfg.m_AttrData.GetAddWeight(0, npcCfg.m_Level);
        float rps = npcCfg.m_AttrData.GetAddRps(0, npcCfg.m_Level);
        float attackRange = npcCfg.m_AttrData.GetAddAttackRange(0, npcCfg.m_Level);

        GetBaseProperty().SetMoveSpeed(Operate_Type.OT_Absolute, moveSpeed);
        GetBaseProperty().SetWalkSpeed(Operate_Type.OT_Absolute, walkSpeed);
        GetBaseProperty().SetRunSpeed(Operate_Type.OT_Absolute, runSpeed);
        GetBaseProperty().SetHpMax(Operate_Type.OT_Absolute, hpMax);
        GetBaseProperty().SetEnergyMax(Operate_Type.OT_Absolute, energyMax);
        GetBaseProperty().SetHpRecover(Operate_Type.OT_Absolute, hpRecover);
        GetBaseProperty().SetEnergyRecover(Operate_Type.OT_Absolute, energyRecover);
        GetBaseProperty().SetAttackBase(Operate_Type.OT_Absolute, attackBase);
        GetBaseProperty().SetADefenceBase(Operate_Type.OT_Absolute, aDefenceBase);
        GetBaseProperty().SetMDefenceBase(Operate_Type.OT_Absolute, mDefenceBase);
        GetBaseProperty().SetCritical(Operate_Type.OT_Absolute, critical);
        GetBaseProperty().SetCriticalPow(Operate_Type.OT_Absolute, criticalPow);
        GetBaseProperty().SetCriticalBackHitPow(Operate_Type.OT_Absolute, criticalBackHitPow);
        GetBaseProperty().SetCriticalCrackPow(Operate_Type.OT_Absolute, criticalCrackPow);
        GetBaseProperty().SetFireDamage(Operate_Type.OT_Absolute, fireDam);
        GetBaseProperty().SetFireERD(Operate_Type.OT_Absolute, fireErd);
        GetBaseProperty().SetIceDamage(Operate_Type.OT_Absolute, iceDam);
        GetBaseProperty().SetIceERD(Operate_Type.OT_Absolute, iceErd);
        GetBaseProperty().SetPoisonDamage(Operate_Type.OT_Absolute, poisonDam);
        GetBaseProperty().SetPoisonERD(Operate_Type.OT_Absolute, poisonErd);
        GetBaseProperty().SetWeight(Operate_Type.OT_Absolute, weight);
        GetBaseProperty().SetRps(Operate_Type.OT_Absolute, rps);
        GetBaseProperty().SetAttackRange(Operate_Type.OT_Absolute, attackRange);

        // ��������
        for (int i=0; i<npcCfg.m_SkillList.Count; i++) {
          SkillInfo skillInfo = new SkillInfo(npcCfg.m_SkillList[i]);
          GetSkillStateInfo().AddSkill(skillInfo);
        }
        if (npcCfg.m_DeadSkill > 0) {
          if (null == GetSkillStateInfo().GetSkillInfoById(npcCfg.m_DeadSkill)) {
            SkillInfo deadSkillInfo = new SkillInfo(npcCfg.m_DeadSkill);
            GetSkillStateInfo().AddSkill(deadSkillInfo);
          }
          m_DeadSkillId = npcCfg.m_DeadSkill;
        }

        NpcAttrCalculator.Calc(this);
        SetHp(Operate_Type.OT_Absolute, GetActualProperty().HpMax);
        SetEnergy(Operate_Type.OT_Absolute, GetActualProperty().EnergyMax);
        m_Cross2StandTime = npcCfg.m_Cross2StandTime;
        m_Cross2RunTime = npcCfg.m_Cross2Runtime;
        m_DeadAnimTime = npcCfg.m_DeadAnimTime;
        m_TauntSound = npcCfg.m_TauntSound;
        for (int i = 0; i < npcCfg.m_HitSounds.Count; ++i) {
          m_HitSounds.Add(npcCfg.m_HitSounds[i]);
        }
      }
    }

    public NpcAiStateInfo GetAiStateInfo()
    {
      return m_AiStateInfo;
    }
    public bool IsCombatNpc()
    {
      if ((int)NpcTypeEnum.BigBoss == m_NpcType || (int)NpcTypeEnum.LittleBoss == m_NpcType || (int)NpcTypeEnum.Normal == m_NpcType)
      {
        return true;
      }
      return false;
    }
    public override bool CanPlayDeadAnim()
    {
      if ((int)NpcTypeEnum.Partner == m_NpcType && !m_IsArenaPartner) {
        return false;
      }
      return base.CanPlayDeadAnim();
    }

    public bool IsArenaPartner
    {
      set { m_IsArenaPartner = value; }
      get { return m_IsArenaPartner; }
    }

    private int m_NpcType = 0;
    private int m_NpcFigure = 0;
    private float m_Scale = 1.0f;
    private bool m_CanMove = true;
    private bool m_CanRotate = true;
    private bool m_CanHitMove = true;

    private bool m_NeedDelete = false;
    private bool m_IsArenaPartner = false;

    private int m_DropMoney = 0;
    private int m_SummonOwnerId = -1;
    private bool m_IsSimulateMove = false;
    private int m_CreatorId = 0;

    private long m_LifeEndTime = -1;
    private long m_BornTime = 0;
    private int m_BornAnimTimeMs = 0;
    private bool m_IsAttachControler = false;
    private string m_AttachNodeName = "";
    private bool m_IsTaunt = false;
    private long m_MeetEnemyStayTime = 0;
    private long m_MeetEnemyWalkTime = 0;
    private NpcAiStateInfo m_AiStateInfo = new NpcAiStateInfo();
    private int m_DeadSkillId = 0;
    private bool m_FollowSummonerDead = true;
    private string m_TauntSound = "";
    private int m_SignForSkill = 0;
  }
}
