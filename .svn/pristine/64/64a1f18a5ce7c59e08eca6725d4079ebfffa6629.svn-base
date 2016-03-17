using System;

namespace DashFire.GMCore
{
  /// <summary>
  /// 用于实现GM指令的类用这个属性标记, 使得GMCore能够把它们找出来
  /// </summary>
  [AttributeUsage(AttributeTargets.Class, Inherited = false)]
  public class GMCmdAttribute : Attribute { }

  /// <summary>
  /// 用于实现GM指令的函数用这个属性标记, description是对于这个指令的描述, 这个描述将会
  /// 被help指令用于显示指令说明
  /// </summary>
  [AttributeUsage(AttributeTargets.Method, Inherited=false)]
  public class GMCmdHandlerAttribute : Attribute
  {
    public GMCmdHandlerAttribute(string description)
    {
      Description = description;
    }

    public string Description { get; private set; }
  }

  /// <summary>
  /// 在实现GM指令的函数的参数上使用这个属性, description是对于这个参数的描述, 这个描述将
  /// 会被help指令用于显示参数说明
  /// </summary>
  [AttributeUsage(AttributeTargets.Parameter, Inherited=false)]
  public class GMCmdArgumentAttribute : Attribute
  {
    public GMCmdArgumentAttribute(string description)
    {
      Description = description; 
    }

    public string Description { get; private set; }
  }
}