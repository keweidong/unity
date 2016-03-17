using System;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections.Generic;

namespace DashFire.GMCore
{
  /// <summary>
  /// 指令的描述符, 提取出指令函数包含的命令名称, 说明以及参数说明
  /// </summary>
  public class Descriptor
  {
    public class ParamInfo
    {
      public string Name { get; set; }
      public string Type { get; set; }
      public string Description { get; set; }
      public bool IsOptional { get; set; }
      public string DefaultValue { get; set; }

      public ParamInfo(ParameterInfo pi)
      {
        Name = pi.Name;
        Type = pi.ParameterType.ToString();
        object[] attrs = pi.GetCustomAttributes(typeof(GMCmdArgumentAttribute), false);
        if (attrs.Length > 0)
        {
          GMCmdArgumentAttribute arg_attr = attrs[0] as GMCmdArgumentAttribute;
          Description = arg_attr.Description;
        }
        IsOptional = pi.IsOptional;
        if (pi.IsOptional)
          DefaultValue = pi.DefaultValue == null ? "null" : pi.DefaultValue.ToString();
      }

      public ParamInfo() { }

      public override bool Equals(object obj)
      {
        ParamInfo other = obj as ParamInfo;
        GMCore.Log("Descriptor.ParamInfo.Equals");
        bool equal = Name == other.Name &&
                     Type == other.Type &&
                     Description == other.Description &&
                     IsOptional == other.IsOptional;
        if (equal && IsOptional)
          equal = (DefaultValue == other.DefaultValue);
        return equal;
      }

      public override int GetHashCode()
      {
        return base.GetHashCode();
      }
    }

    public Descriptor() { }

    public Descriptor(MethodInfo mi)
    {
      string category, group, name;
      DecomposeName(mi, out category, out group, out name);
      GMCmdHandlerAttribute attr = mi.GetCustomAttributes(typeof(GMCmdHandlerAttribute), false)[0] as GMCmdHandlerAttribute;

      Category = category;
      Group = group;
      Name = name;
      Desc = attr.Description;

      Params = new List<ParamInfo>();
      foreach (ParameterInfo pi in mi.GetParameters())
        Params.Add(new ParamInfo(pi));
    }

    // namespace
    public string Category { get; set; }
    // class name
    public string Group { get; set; }
    // handler name
    public string Name { get; set; }
    // fully-qualified-name
    public string FQName { get { return string.Format("{0}.{1}.{2}", Category, Group, Name); } }
    // description
    public string Desc { get; set; }
    // parameter descriptions
    public List<ParamInfo> Params { get; set; }

    public override bool Equals(object obj)
    {
      Descriptor other = obj as Descriptor;
      GMCore.Log("Descriptor.Equals");
      bool equal = Category == other.Category &&
                   Group == other.Group &&
                   Name == other.Name &&
                   Desc == other.Desc &&
                   Params.SequenceEqual(other.Params);

      return equal;
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    public override string ToString()
    {
      if (cached_ == null)
      {
        StringBuilder sb = new StringBuilder(4096);
        sb.AppendFormat("Name:\n  {0}.{1}.{2}", Category, Group, Name);
        FormatText(sb, Desc, 2);

        if (Params.Count > 0)
        {
          sb.Append("\nParameters:");
          foreach (ParamInfo p in Params)
          {
            sb.Append('\n');
            sb.AppendFormat("  {0} {1}", p.Name, p.Type);
            if (p.IsOptional)
              sb.AppendFormat(" optional [default = {0}]", p.DefaultValue);
            FormatText(sb, p.Description, 2);
          }
        }
        sb.Append('\n');

        cached_ = sb.ToString();
      }
      return cached_;
    }

    private void FormatText(StringBuilder sb, string text, int indent)
    {
      const int column_max_width = 80;
      if (null != text && text.Length > 0)
      {
        int indent_blanks = indent * 2;
        int column_width = indent_blanks;
        sb.Append('\n')
          .Append(' ', indent_blanks);

        string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < words.Length; ++i)
        {
          sb.Append(words[i]);
          if (i != words.Length - 1)
          {
            sb.Append(' ');
            column_width += words[i].Length + 1;
            if (column_width >= column_max_width)
            {
              sb.Append('\n')
                .Append(' ', indent_blanks);
              column_width = indent_blanks;
            }
          }
        }
      }
    }

    private void DecomposeName(MethodInfo mi, out string category, out string group, out string name)
    { 
      Type t = mi.DeclaringType;
      if (t.Namespace == null)
      {
        category = "";
        group = t.FullName;
      }
      else
      {
        category = t.Namespace;
        group = t.FullName.Substring(category.Length + 1);
      }
      name = mi.Name;
    }

    private string cached_;
  }
}