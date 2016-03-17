using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

public class CommonLog : Log
{
  public CommonLog(int id, string name)
  {
    m_ID = id;
    m_Name = name;
    m_CacheLog = new byte[m_CacheSize];
  }
  public CommonLog(int id, string name, int cachesize)
  {
    m_ID = id;
    m_Name = name;
    m_CacheSize = cachesize;
    m_CacheLog = new byte[m_CacheSize];
  }
  public override string GenLogName(string module_name = "")
  {
    if (m_ID < 0 || m_Name == null || m_Type < 0)
      return "";
    bool needRename = false;
    if (m_CurDay != DateTime.Today) {
      m_CurDay = DateTime.Today;
      m_WritePos = 0;
      needRename = true;
    }
    if (m_WritePos >= m_MaxLogSize) {
      m_LogSer++;
      m_WritePos = 0;
      needRename = true;
    }
    if (null == m_FileName || needRename) {
      string tm = DateTime.Today.ToString("yyyy-MM-dd");
      string name = "./log/";
      if (m_LogSer > 0)
        name += m_Name + "-" + tm + "-" + m_LogSer;
      else
        name += m_Name + "-" + tm;
      name += "_" + GetServiceName();
      name += ".log";
      m_FileName = name;
    }
    return m_FileName;
  }
}

