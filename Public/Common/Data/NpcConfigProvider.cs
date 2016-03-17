﻿using System;
using System.Collections.Generic;
using System.Text;
using ScriptRuntime;
using DashFireSpatial;

namespace DashFire
{
  public class Data_NpcConfig : IData
  {
    // 基础属性
    public int m_Id;
    public string m_Name;
    public bool m_ShowName;
    public int m_NpcType;
    public int m_NpcFigure;
    public float m_ParticleScale;
    public int m_Level;
    public string m_Portrait;
    public float m_Scale = 1.0f;
    public bool m_CanMove;
    public bool m_CanHitMove;
    public bool m_CanRotate;

    // 战斗属性
    public AttrDataConfig m_AttrData = new AttrDataConfig();
    public bool m_CauseStiff = true;
    public bool m_AcceptStiff = true;
    public bool m_AcceptStiffEffect = true;

    public bool m_SuperArmor = false;
    public float m_ViewRange = 10;
    public float m_GohomeRange = 10;
    public long m_ReleaseTime = 1000;
    // 技能列表
    public List<int> m_SkillList = new List<int>();
    public int m_DeadSkill;
    public List<int> m_ActionList = new List<int>();

    // 声音
    public string m_TauntSound;
    public List<string> m_HitSounds;
    // 动画
    public string m_Model;
    // 特效
    public string m_BornEffect;
    public float m_BornEffectTime;
    public int m_BornAnimTime;
    public string m_DeadSound;
    public int m_MeetEnemyImpact;
    public long m_MeetEnemyStayTime;
    public long m_MeetEnemyWalkTime;

    public bool m_IsAttachControler;
    public string m_AttachNodeName;

    public int m_AvoidanceRadius;
    public Shape m_Shape = null;

    public float m_Cross2StandTime;
    public float m_Cross2Runtime;
    public float m_DeadAnimTime;

    /**
     * @brief 提取数据
     *
     * @param node
     *
     * @return 
     */
    public bool CollectDataFromDBC(DBC_Row node)
    {
      m_Id = DBCUtil.ExtractNumeric<int>(node, "Id", 0, true);
      m_Name = DBCUtil.ExtractString(node, "Name", "", true);
      m_ShowName = DBCUtil.ExtractBool(node, "ShowName", false, false);
      m_NpcType = DBCUtil.ExtractNumeric<int>(node, "NpcType", 0, true);
      m_NpcFigure = DBCUtil.ExtractNumeric<int>(node, "NpcFigure", 0, false);
      m_Level = DBCUtil.ExtractNumeric<int>(node, "Level", 0, true);
      m_Scale = DBCUtil.ExtractNumeric<float>(node, "Scale", 1.0f, false);
      m_ParticleScale = DBCUtil.ExtractNumeric<float>(node, "ParticleScale", 1.0f, false);
      m_Portrait = DBCUtil.ExtractString(node,"Portrait","",false);

      m_AttrData.CollectDataFromDBC(node);
      m_CauseStiff = DBCUtil.ExtractBool(node, "CauseStiff", true, false);
      m_AcceptStiff = DBCUtil.ExtractBool(node, "AcceptStiff", true, false);
      m_AcceptStiffEffect = DBCUtil.ExtractBool(node, "AcceptStiffEffect", true, false);
      //m_SuperArmor = DBCUtil.ExtractNumeric<bool>(node, "SuperArmor", false, false);
      m_ViewRange = DBCUtil.ExtractNumeric<float>(node, "ViewRange", -1, true);
      m_GohomeRange = DBCUtil.ExtractNumeric<float>(node, "GohomeRange", -1, true);
      m_ReleaseTime = DBCUtil.ExtractNumeric<long>(node, "ReleaseTime", 0, true);

      m_SkillList = DBCUtil.ExtractNumericList<int>(node, "SkillList", 0, false);
      m_DeadSkill = DBCUtil.ExtractNumeric<int>(node, "DeadSkill", -1, false);
      m_ActionList = DBCUtil.ExtractNumericList<int>(node, "ActionId", 0, false);

      m_Model = DBCUtil.ExtractString(node, "Model", "", false);

      m_BornEffect = DBCUtil.ExtractString(node, "BornEffect", "", false);
      m_BornEffectTime = DBCUtil.ExtractNumeric<float>(node, "BornEffectTime", -1, false);
      m_DeadSound = DBCUtil.ExtractString(node, "DeadSound", "", false);
      m_MeetEnemyImpact = DBCUtil.ExtractNumeric<int>(node, "MeetEnemyImpact", 0, false);
      m_BornAnimTime = DBCUtil.ExtractNumeric<int>(node, "BornAnimTime", 400, false);

      m_AvoidanceRadius = DBCUtil.ExtractNumeric<int>(node, "AvoidanceRadius", 1, false);
      m_CanMove = DBCUtil.ExtractBool(node, "CanMove", false, false);
      m_CanHitMove = DBCUtil.ExtractBool(node, "CanHitMove", true, false);
      m_CanRotate = DBCUtil.ExtractBool(node, "CanRotate", true, false);

      m_IsAttachControler = DBCUtil.ExtractBool(node, "IsAttachControler", false, false);
      m_AttachNodeName = DBCUtil.ExtractString(node, "AttachNodeName", "", false);

      m_Cross2StandTime = DBCUtil.ExtractNumeric<float>(node, "Cross2StandTime", 0.5f, false);
      m_Cross2Runtime = DBCUtil.ExtractNumeric<float>(node, "Cross2RunTime", 0.3f, false);
      m_DeadAnimTime = DBCUtil.ExtractNumeric<float>(node, "DeadAnimTime", 1.4f, false);

      m_TauntSound = DBCUtil.ExtractString(node, "TauntSound", "", false);
      m_HitSounds = Converter.ConvertStringList(DBCUtil.ExtractString(node, "HitSound", "", false));

      string shapeType = DBCUtil.ExtractString(node, "ShapeType", "", true);
      int shapeParamNum = DBCUtil.ExtractNumeric<int>(node, "ShapeParamNum", 0, true);
      if (shapeParamNum > 0) {
        string[] shapeParams = new string[shapeParamNum];
        for (int i = 0; i < shapeParamNum; ++i) {
          shapeParams[i] = DBCUtil.ExtractString(node, "ShapeParam" + i, "", false);
        }

        if (0 == string.Compare("Circle", shapeType, true)) {
          m_Shape = new Circle(new Vector3(0, 0, 0), float.Parse(shapeParams[0]));
        } else if (0 == string.Compare("Line", shapeType, true)) {
          Vector3 start=Converter.ConvertVector3D(shapeParams[0]);
          Vector3 end = Converter.ConvertVector3D(shapeParams[1]);
          m_Shape = new Line(start, end);
        } else if (0 == string.Compare("Rect", shapeType, true)) {
          float width=float.Parse(shapeParams[0]);
          float height = float.Parse(shapeParams[1]);
          m_Shape = new Rect(width, height);
        } else if (0 == string.Compare("Polygon", shapeType, true)) {
          Polygon polygon = new Polygon();
          foreach (string s in shapeParams) {
            Vector3 pt = Converter.ConvertVector3D(s);
            polygon.AddVertex(pt);
          }
          m_Shape = polygon;
        }
      }

      return true;
    }

    /**
     * @brief 获取数据ID
     *
     * @return 
     */
    public int GetId()
    {
      return m_Id;
    }

    private int findFromList(List<int> l, int id)
    {
      return l.FindIndex(
        delegate(int v)
        {
          return v == id;
        }
        );
    }
  }
  
  public class NpcConfigProvider
  {
    public DataDictionaryMgr<Data_NpcConfig> NpcConfigMgr
    {
      get { return m_NpcConfigMgr; }
    }
    public Data_NpcConfig GetNpcConfigById(int id)
    {
      return m_NpcConfigMgr.GetDataById(id);
    }
    public void LoadNpcConfig(string file, string root)
    {
      m_NpcConfigMgr.CollectDataFromDBC(file, root);
    }

    private DataDictionaryMgr<Data_NpcConfig> m_NpcConfigMgr = new DataDictionaryMgr<Data_NpcConfig>();

    public DataDictionaryMgr<LevelupConfig> NpcLevelupConfigMgr
    {
      get { return m_NpcLevelupConfigMgr; }
    }
    public LevelupConfig GetNpcLevelupConfigById(int id)
    {
      return m_NpcLevelupConfigMgr.GetDataById(id);
    }
    public void LoadNpcLevelupConfig(string file, string root)
    {
      m_NpcLevelupConfigMgr.CollectDataFromDBC(file, root);
    }
    public void Clear()
    {
      m_NpcLevelupConfigMgr.Clear();
      m_NpcConfigMgr.Clear();
    }

    private DataDictionaryMgr<LevelupConfig> m_NpcLevelupConfigMgr = new DataDictionaryMgr<LevelupConfig>();

    public static NpcConfigProvider Instance
    {
      get { return s_Instance; }
    }
    private static NpcConfigProvider s_Instance = new NpcConfigProvider();
  }
}
