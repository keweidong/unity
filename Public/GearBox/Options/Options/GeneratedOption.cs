using System;
using System.Reflection;
using System.ComponentModel;

namespace Options
{
  /// <summary>
  /// NDesk.Options.Option的子类, 用于被设置到OptionSet中
  /// </summary>
  internal sealed class GeneratedOption : NDesk.Options.Option
  {
    public GeneratedOption(string prototype, string description, 
                           object obj, PropertyInfo prop_info)
      : base(prototype, description)
    {
      obj_ = obj;
      prop_info_ = prop_info;
    }

    /// <summary>
    /// 解析完成, 将结果设置到目标的字段(property)上
    /// </summary>
    /// <param name="c"></param>
    protected override void OnParseComplete(NDesk.Options.OptionContext c)
    {
      try
      {
        // 如果选项的类型是bool, 那么!null就是true, 否则false
        // 不是bool, 需要做Convert
        object prop_value = (prop_info_.PropertyType == typeof(bool)) ?
          c.OptionValues[0] != null :
          TypeDescriptor.GetConverter(prop_info_.PropertyType).ConvertFromString(c.OptionValues[0]);

        prop_info_.SetValue(obj_, prop_value, null);
      }
      catch (NotSupportedException e)
      {
        throw new OptionTypeError(c.OptionValues[0], prop_info_.PropertyType, c.OptionName, e);
      }
    }

    private object obj_;
    private PropertyInfo prop_info_;
  }
}