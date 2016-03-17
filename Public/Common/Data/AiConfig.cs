using System;
using System.Collections.Generic;
using System.Text;

namespace DashFire
{
  public class AiConfig : IData
  {
    public int Id;
    public string Describe;
    public List<int> ActionList;
    public long MaxControlTime;
    public List<int> MaxControlEvent;

    public bool CollectDataFromDBC(DBC_Row node)
    {
      Id = DBCUtil.ExtractNumeric<int>(node, "Id", 0, true);
      Describe = DBCUtil.ExtractString(node, "Describe", "", false);
      ActionList = DBCUtil.ExtractNumericList<int>(node, "ActionList", 0, false);
      MaxControlTime = DBCUtil.ExtractNumeric<int>(node, "MaxControlTime", -1, false);
      MaxControlEvent = DBCUtil.ExtractNumericList<int>(node, "MaxControlEvent", 0, false);

      return true;
    }
    public int GetId()
    {
      return Id;
    }
  }

  public class AiConfigProvider
  {
    public AiConfig GetDataById(int id)
    {
      return m_AiConfigMgr.GetDataById(id);
    }

    public int GetDataCount()
    {
      return m_AiConfigMgr.GetDataCount();
    }

    public void Load(string file, string root)
    {
      m_AiConfigMgr.CollectDataFromDBC(file, root);
    }

    public static AiConfigProvider Instance
    {
      get { return s_Instance; }
    }
    private DataDictionaryMgr<AiConfig> m_AiConfigMgr = new DataDictionaryMgr<AiConfig>();
    private static AiConfigProvider s_Instance = new AiConfigProvider();
  }
}
