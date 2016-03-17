using System;
using System.Text;

namespace DashFire.GMCore
{
  internal static partial class InternalCmds
  {
    [GMCmdHandler("show help for GM command(s)")]
    public static string help(
        [GMCmdArgument("command full-name.")]string full_name = null,
        [GMCmdArgument("command category.")]string category = "*",
        [GMCmdArgument("command group.")]string group = "*",
        [GMCmdArgument("command name.")]string name = "*")
    {
      FQName fqname = new FQName(category, group, name);
      if (full_name != null)
        fqname = new FQName(full_name);
      else
        fqname = new FQName(category, group, name);

      StringBuilder sb = new StringBuilder(4096);
      foreach (GMCmd cmd in DescriptorPool.Instance.Search(fqname))
      {
        sb.Append(cmd.Descriptor.ToString())
          .Append('\n');
      }
      return sb.ToString();
    }
  }
}