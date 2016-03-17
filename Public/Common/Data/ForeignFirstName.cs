﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DashFire
{
  public class ForeignFirstName : IData
  {
    public int m_Id = 0;
    public string m_FirstName = "";
    public bool CollectDataFromDBC(DBC_Row node)
    {
      m_Id = DBCUtil.ExtractNumeric<int>(node, "Id", 0, true);
      m_FirstName = DBCUtil.ExtractString(node, "FirstName", "", true);
      return true;
    }
    public int GetId()
    {
      return m_Id;
    }
  }

  public class ForeignFirstNameProvider
  {
    public FirstName GetDataById(int id)
    {
      return m_FirstNameMgr.GetDataById(id);
    }
    public int GetDataCount()
    {
      return m_FirstNameMgr.GetDataCount();
    }
    public void Load(string file, string root)
    {
      m_FirstNameMgr.CollectDataFromDBC(file, root);
    }

    private DataDictionaryMgr<FirstName> m_FirstNameMgr = new DataDictionaryMgr<FirstName>();

    public static ForeignFirstNameProvider Instance
    {
      get { return s_Instance; }
    }
    private static ForeignFirstNameProvider s_Instance = new ForeignFirstNameProvider();
  }
}