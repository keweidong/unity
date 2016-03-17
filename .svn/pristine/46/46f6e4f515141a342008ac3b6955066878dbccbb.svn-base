using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace DashFire.GMCore 
{
  /// <summary>
  /// 输入参数
  /// </summary>
  public interface IInputParam
  {
    /// <summary>
    /// 参数名称
    /// </summary>
    string Name { get; }

    /// <summary>
    /// 将参数转换成type类型
    /// </summary>
    /// <param name="type">目标类型</param>
    /// <returns></returns>
    object Convert(Type type);
  }

  /// <summary>
  /// 单个参数
  /// </summary>
  internal class InputScatteredParam : IInputParam
  {
    public string Name { get; private set; }

    public InputScatteredParam(string value, string name = null)
    {
      Name = name;
      value_ = value;
    }

    public object Convert(Type type)
    {
      TypeConverter converter = TypeDescriptor.GetConverter(type);
      if (null == converter)
        throw new TypeConverterNotFound(type);
      return converter.ConvertFromString(value_);
    }

    private string value_;
  }

  /// <summary>
  /// 数组参数, 表示IInputParam的集合
  /// </summary>
  internal class InputArrayParam : IInputParam
  { 
    public string Name { get; private set; }

    public InputArrayParam(List<IInputParam> p, string name = null)
    {
      Name = name;
      params_ = p;
    }

    /// <summary>
    /// 将集合中的参数转换成目标类型的数组
    /// </summary>
    /// <param name="type">目标类型, 必须是arary类型</param>
    /// <returns></returns>
    public object Convert(Type type)
    {
      if (!type.IsArray)
        throw new ExpectArrayType(type);

      Type ele_type = type.GetElementType();
      Array array = Array.CreateInstance(ele_type, params_.Count);
      for (int i = 0; i < params_.Count; ++i)
        array.SetValue(params_[i].Convert(ele_type), i);

      return array;
    }

    private List<IInputParam> params_ = new List<IInputParam>();
  }
}