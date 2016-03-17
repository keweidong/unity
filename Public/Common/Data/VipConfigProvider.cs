﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DashFire
{
  [Serializable]
  public class VipConfig : IData
  {
    public int m_VipLevel = 0;
    public int m_Stamina = 0;
    public int m_BuyMoney = 0;
    public bool CollectDataFromDBC(DBC_Row node)
    {
      m_VipLevel = DBCUtil.ExtractNumeric<int>(node, "VipLevel", 0, true);
      m_Stamina = DBCUtil.ExtractNumeric<int>(node, "StaminaCount", 0, true);
      m_BuyMoney = DBCUtil.ExtractNumeric<int>(node, "BuyMoneyCount", 0, true);
      return true;
    }
    public int GetId()
    {
      return m_VipLevel;
    }
  }
  public class VipConfigProvider
  {
    public DataDictionaryMgr<VipConfig> VipConfigMgr
    {
      get { return m_VipConfigMgr; }
    }
    public VipConfig GetDataById(int id)
    {
      return m_VipConfigMgr.GetDataById(id);
    }
    public int GetDataCount()
    {
      return m_VipConfigMgr.GetDataCount();
    }
    public void Load(string file, string root)
    {
      m_VipConfigMgr.CollectDataFromDBC(file, root);
    }
    private DataDictionaryMgr<VipConfig> m_VipConfigMgr = new DataDictionaryMgr<VipConfig>();
    public static VipConfigProvider Instance
    {
      get { return s_Instance; }
    }
    private static VipConfigProvider s_Instance = new VipConfigProvider();
  }
}
