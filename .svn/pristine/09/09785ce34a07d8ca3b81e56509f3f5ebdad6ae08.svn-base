using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DashFire.GMCore
{
  /// <summary>
  /// 所有描述符的池, 主要功能是提供对指令的模糊查找
  /// </summary>
  public class DescriptorPool
  {
    private static DescriptorPool s_instance_ = new DescriptorPool();
    public static DescriptorPool Instance { get { return s_instance_; } }

    internal class GMCmds : System.Collections.Generic.Dictionary<string, DashFire.GMCore.GMCmd> {}
    internal class Groups : System.Collections.Generic.Dictionary<string, GMCmds> {}
    internal class Categories : System.Collections.Generic.Dictionary<string, Groups> {}

    internal void Initiate(List<Assembly> assemblies)
    {
      assemblies.Insert(0, Assembly.GetExecutingAssembly());
      foreach (GMCmd cmd in GMCollector.Run(assemblies))
        Add(cmd);
    }

    public void Foreach(Action<Descriptor> action)
    {
      foreach (Groups g in categories_.Values)
      {
        foreach (GMCmds cmds in g.Values)
        {
          foreach (GMCmd cmd in cmds.Values)
            action(cmd.Descriptor);
        }
      }
    }

    public void Add(GMCmd cmd)
    {
      GMCore.Log("Add Descriptor: {0}", cmd.Descriptor.ToString());
      Groups groups;
      if (!categories_.TryGetValue(cmd.Descriptor.Category, out groups))
      {
        groups = new Groups();
        categories_.Add(cmd.Descriptor.Category, groups);
      }

      Add(groups, cmd);
    }

    private void Add(Groups groups, GMCmd cmd)
    {
      GMCmds cmds;
      if (!groups.TryGetValue(cmd.Descriptor.Group, out cmds))
      {
        cmds = new GMCmds();
        groups.Add(cmd.Descriptor.Group, cmds);
      }

      Add(cmds, cmd);
    }

    private void Add(GMCmds cmds, GMCmd cmd)
    {
      GMCmd exist;
      if (cmds.TryGetValue(cmd.Descriptor.Name, out exist))
      {
        if (!exist.Descriptor.Equals(cmd.Descriptor))
          throw new IncompatibleDescriptor(exist.Descriptor, cmd.Descriptor);
        exist.Handlers.AddRange(cmd.Handlers);
      }
      else
      {
        cmds.Add(cmd.Descriptor.Name, cmd);
      }
    }

    public List<GMCmd> Search(FQName fqname)
    {
      List<GMCmd> cmd_list = new List<GMCmd>();
      foreach (Groups g in SelectGroups(fqname.Category))
      {
        foreach (GMCmds cmds in SelectCmds(g, fqname.Group))
        {
          cmd_list.AddRange(SelectCmd(cmds, fqname.Name));
        }
      }
      return cmd_list;
    }

    internal IEnumerable<Groups> SelectGroups(string category)
    {
      return from c in categories_ 
             where Regex.Match(c.Key, category).Success 
             select c.Value;
    }

    internal IEnumerable<GMCmds> SelectCmds(Groups groups, string g)
    {
      return from gmc in groups
             where Regex.Match(gmc.Key, g).Success
             select gmc.Value;
    }

    private IEnumerable<GMCmd> SelectCmd(GMCmds cmds, string name)
    {
      return from cmd in cmds
             where Regex.Match(cmd.Key, name).Success
             select cmd.Value;
    }

    private Categories categories_ = new Categories();
  }
}