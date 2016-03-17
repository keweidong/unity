﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading;

public enum ServerEventCode : int
{
  VerifyToken = 13,
  VerifyResult = 14,
  CreateHero = 19,
}

public enum LOG_TYPE
{
  DEBUG = 0,
  INFO = 1,
  ERROR = 2,
  WARN = 3,
  MONITOR = 4,
  MAX
}
public class LogSys
{
  #region
  private static LogSys s_Instance = new LogSys();
  private static LogSys Instance
  {
    get { return s_Instance; }
  }
  #endregion

  #region console color
  private static ConsoleColor[] s_default_cc_ = new ConsoleColor[]
  {
    ConsoleColor.DarkGray,
    ConsoleColor.White,
    ConsoleColor.Red,
    ConsoleColor.Yellow,
    ConsoleColor.DarkGreen,
    ConsoleColor.Yellow,
    ConsoleColor.DarkGray,
    ConsoleColor.DarkGray,
    ConsoleColor.DarkGray,
    ConsoleColor.DarkGray,
    ConsoleColor.DarkGray,
    ConsoleColor.DarkGray,
    ConsoleColor.DarkGray,
    ConsoleColor.DarkGray,
    ConsoleColor.DarkGray,
    ConsoleColor.DarkGray,
    ConsoleColor.DarkGray,
    ConsoleColor.DarkGray,
    ConsoleColor.DarkGray,
    ConsoleColor.DarkGray,
    ConsoleColor.DarkGray,
    ConsoleColor.DarkGray,
    ConsoleColor.DarkGray,
    ConsoleColor.DarkGray,
    ConsoleColor.DarkGray,
    ConsoleColor.DarkGray,
    ConsoleColor.DarkGray,
    ConsoleColor.DarkGray,
    ConsoleColor.DarkGray,
    ConsoleColor.DarkGray,
    ConsoleColor.DarkGray,
    ConsoleColor.DarkGray,
  };
  #endregion console color

  public static void Log(LOG_TYPE logtype, string format, params object[] args)
  {
    LogSys.Instance.LOG(logtype, null, format, args);
  }

  // see System.ConsoleColor for color names
  public static void Log(LOG_TYPE logtype, ConsoleColor cc, string format, params object[] args)
  {
    LogSys.Instance.LOG(logtype, cc, format, args);
  }

  public static void NormLog(string module, params object[] args)
  {
    LogSys.Instance.NORMLOG(module, args);
  }

  public static bool Init(string config)
  {
    return LogSys.Instance.InitSystem(config);
  }

  public static void FlushNormLog()
  {
    LogSys.Instance.OnFlushNormLog();
  }

  private Dictionary<int, Log> m_DicLogs = new Dictionary<int, Log>();
  private Dictionary<string, Log> m_NormDicLogs = new Dictionary<string, Log>();
  private Thread m_Thread = null;
  private Thread m_NormThread = null;
  private object m_ConsoleLock = new object();
  public byte[] m_LogCache = null;
  public int m_CacheSize = 4 * 1024 * 1024;
  private LogSys()
  {
    m_LogCache = new byte[m_CacheSize];
  }
  private bool InitSystem(string config)
  {
    bool bret = false;
    bret = InitConfig(config);
    if (bret) {
      LOG(LOG_TYPE.DEBUG, null, "{0}", "Init Succ!");
    }
    return bret;
  }
  private int Swap(Log log)
  {
    int iret = 0;
    byte[] ptr = m_LogCache;
    m_LogCache = log.m_CacheLog;
    log.m_CacheLog = ptr;
    iret = log.m_WritePos;
    log.m_WritePos = 0;
    return iret;
  }
  private bool InitConfig(string config)
  {
    /// norm log
    RegisterNormModuleLogByName("login", "rolebuild", "rolelogin", "logout", "PVEfight", "gettask", "finishtask", "acquire", "customacquire", "moneycost", "customcost", "getitem", "removeitem", "heart", "levelup", "newstages", "activity", "partner", "pvp", "arena", "serverevent");
    /// common log
    m_DicLogs.Clear();
    XmlDocument xmldoc = new XmlDocument();
    xmldoc.Load(config);
    XmlNodeList list = xmldoc.SelectNodes("LOGS");
    foreach (XmlNode nd in list) {
      XmlNodeList ls = nd.SelectNodes("item");
      foreach (XmlNode node in ls) {
        XmlNode id = node.SelectSingleNode("id");
        XmlElement element = (XmlElement)id;
        int logid = Convert.ToInt32(element.InnerText);
        XmlNode name = node.SelectSingleNode("name");
        element = (XmlElement)name;
        string logname = element.InnerText;
        XmlNode type = node.SelectSingleNode("type");
        element = (XmlElement)type;
        int ntype = Convert.ToInt32(element.InnerText);
        XmlNode cache = node.SelectSingleNode("cache");
        int cachesize = 4 * 1024 * 1024;
        if (cache != null) {
          element = (XmlElement)cache;
          cachesize = Convert.ToInt32(element.InnerText);
        }
        CommonLog log = new CommonLog(logid, logname, cachesize);
        log.m_Type = ntype;
        m_DicLogs.Add(logid, log);
      }
    }
    if (m_DicLogs.Count <= 0)
      return false;
    m_Thread = new Thread(new ThreadStart(FlushAll));
    if (m_Thread != null) {
      m_Thread.Start();
    }
    return true;
  }
  private void LOG(LOG_TYPE logtype, ConsoleColor? fg_color, string format, params object[] args)
  {
    Log log;
    if (m_DicLogs.TryGetValue((int)logtype, out log)) {
      string str;
      if (args.Length > 0) {
        str = string.Format(format, args);
      } else {
        str = format;
      }
      log.LOG(str);
      lock (m_ConsoleLock)
      {
        Console.ForegroundColor = null != fg_color ? (ConsoleColor)fg_color : s_default_cc_[(int)logtype];
        Console.WriteLine(str);
        Console.ResetColor();
      }
    } else {
      throw (new Exception("LOG error!!!!!"));
    }
  }
  private void RegisterNormModuleLogByName(params object[] args)
  {
    m_NormDicLogs.Clear();
    for (int i = 0; i < args.Length; i++) {
      string module_name = (string)args[i];
      int cachesize = 4 * 1024 * 1024;
      NormLog log = new NormLog(module_name, cachesize);
      log.m_Type = 0;
      m_NormDicLogs.Add(module_name, log);
    }
  }
  private void NORMLOG(string module_name, params object[] args)
  {
    Log log;
    if (m_NormDicLogs.TryGetValue(module_name, out log)) {
      string str;
      char split_sign = Convert.ToChar(0x01);
      if (args.Length > 0) {
        str = "";
        for (int i = 0; i < args.Length; i++) {
          str += args[i];
          if (i != args.Length - 1) {
            str += split_sign;
          }
        }
      } else {
        str = "null";
      }
      log.LOG(str, module_name);
    } else {
      throw (new Exception("NORMLOG error!!!!!"));
    }
  }
  private void OnFlushNormLog()
  {
    try {
      foreach (Log log in m_NormDicLogs.Values) {
        if (log.m_Type >= 0 && log.m_WritePos > 0) {
          int iret = 0;
          lock (log.m_CacheLock) {
            iret = Swap(log);
          }
          unsafe {
            log.FlushLog(m_LogCache, iret, log.m_ModuleName);
          }
        }
      }
    } catch (Exception ex) {
      Console.WriteLine("LogSys::OnFlushNormLog exception:{0}\n{1}", ex.Message, ex.StackTrace);
    }
  }
  private void FlushAll()
  {
    try {
      while (true) {
        foreach (Log log in m_DicLogs.Values) {
          if (log.m_Type >= 0 && log.m_WritePos > 0) {
            int iret = 0;
            lock (log.m_CacheLock) {
              iret = Swap(log);
            }
            unsafe {
              log.FlushLog(m_LogCache, iret);
            }
          }
        }
        foreach (Log log in m_NormDicLogs.Values) {
          if (log.m_Type >= 0 && log.m_WritePos > 0/* && log.m_WritePos > 1 * 1024 * 1024*/) {
            int iret = 0;
            lock (log.m_CacheLock) {
              iret = Swap(log);
            }
            unsafe {
              log.FlushLog(m_LogCache, iret, log.m_ModuleName);
            }
          }
        }
        Thread.Sleep(60000);
      }
    } catch (Exception ex) {
      Console.WriteLine("LogSys::FlushAll exception:{0}\n{1}", ex.Message, ex.StackTrace);
    }
  }
}

