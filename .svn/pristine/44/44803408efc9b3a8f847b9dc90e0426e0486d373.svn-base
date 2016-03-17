using System;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DashFire.GMCore
{ 
  public class GMCore
  { 
    private static GMCore s_instance = new GMCore();
    public static GMCore Instance { get { return s_instance; } }

    public delegate void DebugLogF(string log);
    public static event DebugLogF Debuglog;

    internal static void Log(string fmt, params object[] objs)
    {
      if (null != Debuglog)
        Debuglog(string.Format("[GMCore] " + fmt, objs));
    }

    public void Initiate(params Assembly[] assemblies)
    {
      DescriptorPool.Instance.Initiate(new List<Assembly>(assemblies));
      DefaultCategory = ".*";
      DefaultGroup = ".*";
    }

    public string Execute(string cmd_line)
    {
      // 解析命令行
      Interpreter interp = new Interpreter(cmd_line);
      // 使用fulll-qualified-name匹配GM指令
      FQName fqname = new FQName(interp.CmdName);
      List<GMCmd> cmds = DescriptorPool.Instance.Search(fqname);
      if (cmds.Count == 0)
        return GMCmdNotFound(interp.CmdName, fqname.ToString());
      else if (cmds.Count > 1)
        return AmbiguousMatch(interp.CmdName, fqname.ToString(), cmds);

      // 调用GM指令的处理器
      return cmds[0].Invoke(interp);
    }

    private string GMCmdNotFound(string full_name, string fqname)
    { 
      return string.Format("No GM command is found for '{0}', fully-qualified-name of which is derived to '{1}'", full_name, fqname);
    }

    private string AmbiguousMatch(string full_name, string fqname, IEnumerable<GMCmd> cmds)
    {
      StringBuilder sb = new StringBuilder(4096);
      sb.AppendFormat("Ambiguous GM commands are matched for name {0}({1}):\n", full_name, fqname);
      foreach (GMCmd cmd in cmds)
      {
        sb.AppendFormat("  {0}\n", cmd.Descriptor.FQName);
      }
      return sb.ToString();
    }

    internal string DefaultCategory { get; set; }
    internal string DefaultGroup { get; set; }
  }
}