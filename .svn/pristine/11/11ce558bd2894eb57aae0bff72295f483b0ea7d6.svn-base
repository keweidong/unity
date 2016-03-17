using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

using Google.ProtocolBuffers.Descriptors;

/// <summary>
/// 分析message, 得到字段的名称和db使用的数据类型
/// </summary>
class Analyzer
{
  public Analyzer(AssemblyLoader al, string message_name)
  {
    al_ = al;
    TableName = message_name.Substring(3);

    Type t = al.Assembly.GetType("DashFire.DataStore." + message_name);
    MessageDescriptor md = (MessageDescriptor)t.InvokeMember(
      "Descriptor",
      BindingFlags.Static | BindingFlags.Public | BindingFlags.GetProperty,
      null, null, null);

    TablePrimaryKey = al.PrimaryKeyGetter.Get(md.Options);
    TableForeignKey = al.ForeignKeyGetter.Get(md.Options);

    bool prikey_found = false;
    TableFields = new List<Tuple<string, string>>();
    for (int i = 0; i < md.Fields.Count; i++ )
    {
      prikey_found = prikey_found || TablePrimaryKey == md.Fields[i].Name;
      TableFields.Add(Tuple.Create(md.Fields[i].Name, FieldType2DBType(md.Fields[i])));
    }
    /*
    foreach (FieldDescriptor fd in md.Fields)
    {
      prikey_found = prikey_found || TablePrimaryKey == fd.Name;
      TableFields.Add(Tuple.Create(fd.Name, FieldType2DBType(fd)));
    }*/

    if (!prikey_found)
      throw new ApplicationException(string.Format("{0}: primary key is invalid or not set", message_name));
  }

  private string FieldType2DBType(FieldDescriptor fd)
  {
    switch (fd.FieldType)
    {
      case FieldType.Double:
        return "double";
      case FieldType.Float:
        return "float";
      case FieldType.Int64:
      case FieldType.Fixed64:
      case FieldType.SFixed64:
      case FieldType.SInt64:
        return "bigint";
      case FieldType.UInt64:
        return "bigint unsigned";
      case FieldType.Int32:
      case FieldType.Fixed32:
      case FieldType.SFixed32:
      case FieldType.SInt32:
        return "int";
      case FieldType.UInt32:
        return "int unsigned";
      case FieldType.Bool:
        return "boolean";
      case FieldType.Enum:
      {
        string enum_vals = fd.EnumType.Values.Aggregate("", (val, evd) => 
            val.Length == 0 ? string.Format("'{0}'", evd.Name) : val + string.Format(",'{0}'", evd.Name) 
          );
        return string.Format("enum({0})", enum_vals);
      }
      case FieldType.String:
      {
        int max_size = al_.MaxSizeGetter.Get(fd.Options);
        if (max_size == 0)
          throw new ApplicationException(string.Format("{0}: max_size for field ({1}) is invalid or not set", fd.ContainingType.Name, fd.Name));

        if (max_size <= 255)
          return string.Format("char({0})", max_size);
        else if (255 < max_size && max_size <= 65535)         
          return string.Format("text({0})", max_size);
        else if (65535 < max_size && max_size <= 16777215)
          return "mediumtext";

        return null;
      }
      case FieldType.Bytes:
      {
        int max_size = al_.MaxSizeGetter.Get(fd.Options);
        if (max_size == 0)
          throw new ApplicationException(string.Format("{0}: max_size for field ({1}) is invalid or not set", fd.ContainingType.Name, fd.Name));

        if (max_size <= 255)
          return string.Format("binary({0})", max_size);
        else if (255 < max_size && max_size <= 4096)
          return string.Format("varbinary({0})", max_size);
        else if (4096 < max_size && max_size <= 65535)
          return string.Format("blob({0})", max_size);
        else if (65535 < max_size && max_size <= 16777215)
          return "mediumblob";

        return null;
      }
      default:
        throw new ApplicationException(string.Format("{0}: field type ({1}) is forbidden", fd.ContainingType.Name, fd.FieldType));
    }
  }

  public string TableName { get; private set; }
  public List<Tuple<string, string>> TableFields { get; private set; }
  public string TablePrimaryKey { get; private set; }
  public string TableForeignKey { get; private set; }

  private AssemblyLoader al_;
}