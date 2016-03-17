using System;

namespace Options
{
  /// <summary>
  /// 使用这个attr标记用于指定的类, 该类定义了可被命令修改的字段
  /// </summary>
  [AttributeUsage(AttributeTargets.Class, Inherited = false)]
  public sealed class OptionStructureAttribute : Attribute { }

  /// <summary>
  /// 使用这个attr标记被命令行修改的字段(property)
  /// </summary>
  [AttributeUsage(AttributeTargets.Property, Inherited = false)]
  public sealed class OptionAttribute : Attribute
  {
    public string Default { get; set; }
    public string Description { get; set; }
  }
}