using System;
using System.Reflection;
using System.Collections.Generic;

namespace DashFire.GMCore
{ 
  internal static class GMCollector
  {
    internal static List<GMCmd> Run(List<Assembly> assemblies)
    {
      Type gmmark = typeof(GMCmdAttribute);
      List<GMCmd> cmds = new List<GMCmd>();
      foreach (Assembly ass in assemblies)
      {
        foreach (Type t in ass.GetTypes())
        {
          object[] attrs = t.GetCustomAttributes(gmmark, false);
          if (attrs.Length == 0)
            continue;

          cmds.AddRange(GMCmdList(t));
        }
      }
      return cmds;
    }

    private static List<GMCmd> GMCmdList(Type t)
    {
      Type gmhmark = typeof(GMCmdHandlerAttribute);
      List<GMCmd> cmds = new List<GMCmd>();
      foreach (MethodInfo mi in t.GetMethods())
      {
        object[] attrs = mi.GetCustomAttributes(gmhmark, false);
        if (attrs.Length == 0)
          continue;

        GMCmd cmd = new GMCmd(new Descriptor(mi));
        cmd.AddGMHandler(new GMCmdHandler(mi));
        cmds.Add(cmd);
      }
      return cmds; 
    }
  }
}