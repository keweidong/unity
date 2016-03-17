using System;
using System.Reflection;
using System.Text.RegularExpressions;

using Google.ProtocolBuffers.Descriptors;

/// <summary>
/// 载入定义存储数据的proto dll
/// </summary>
class AssemblyLoader
{
  public AssemblyLoader(string assembly_path)
  {
    // 载入dll, 查找里面定义了option的静态类, 这里静态类的名字写死了, 这个应该可以改进
    Assembly = Assembly.LoadFile(assembly_path);
    Type DataT = Assembly.GetType("DashFire.DataStore.Data");
    BindingFlags flags = BindingFlags.Static | BindingFlags.Public | BindingFlags.GetField;

    // 取得文件的版本
    object version = DataT.InvokeMember("Version", flags, null, null, null);
    FileDescriptor fd = (FileDescriptor)DataT.InvokeMember("Descriptor",
      BindingFlags.Static | BindingFlags.Public | BindingFlags.GetProperty,
      null, null, null);
    FileVersion = (new OptionGetter<string>(version)).Get(fd.Options);
    Match m = Regex.Match(FileVersion, @"^\d+\.\d+\.\d+$");
    if (!m.Success)
      throw new ApplicationException("invalid file version: " + FileVersion);

    // 初始化DsPrimaryKey、DsForeignKey和MaxSize这两个option的Gettter, 方便后续的option读取调用
    object dsPrimaryKey = DataT.InvokeMember("DsPrimaryKey", flags, null, null, null);
    PrimaryKeyGetter = new OptionGetter<string>(dsPrimaryKey);
    object dsForeignKey = DataT.InvokeMember("DsForeignKey", flags, null, null, null);
    ForeignKeyGetter = new OptionGetter<string>(dsForeignKey);
    object max_size = DataT.InvokeMember("MaxSize", flags, null, null, null);
    MaxSizeGetter = new OptionGetter<int>(max_size);
  }

  public Assembly Assembly { get; private set; }
  public string FileVersion { get; private set; }
  public OptionGetter<string> PrimaryKeyGetter { get; private set; }
  public OptionGetter<string> ForeignKeyGetter { get; private set; }
  public OptionGetter<int> MaxSizeGetter { get; private set; }
}