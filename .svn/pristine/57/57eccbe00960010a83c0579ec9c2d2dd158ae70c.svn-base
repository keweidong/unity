using System;
using System.Linq;
using System.Collections.Generic;

namespace DashFire.GMCore
{
  internal static partial class InternalCmds
  {
    [GMCmdHandler("set default category and group to use")]
    public static string use(string category = "*", string group = "*")
    {
      FQName fqname = new FQName(category, group, "*");
      IEnumerable<DescriptorPool.Groups> groups = DescriptorPool.Instance.SelectGroups(fqname.Category);
      if (groups.Count() == 0)
        return string.Format("No category is matched for '{0}'", category);

      bool group_exist = false;
      foreach (DescriptorPool.Groups g in groups)
      {
        if (DescriptorPool.Instance.SelectCmds(g, fqname.Group).Count() > 0)
        {
          group_exist = true;
          break;
        }
      }

      if (!group_exist)
        return string.Format("No group is matched for '{0}'", group);

      GMCore.Instance.DefaultCategory = fqname.Category;
      GMCore.Instance.DefaultGroup = fqname.Group;
      return "done";
    }
  }
}