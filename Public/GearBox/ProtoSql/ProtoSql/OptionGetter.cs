using System;
using System.Reflection;

class OptionGetter<OptValueType> 
{
  public OptionGetter(object opt_key)
  {
    opt_key_ = opt_key;
  }

  public OptValueType Get(object options)
  {
    MethodInfo mi = GetExtentionMethod(options.GetType(), typeof(OptValueType));
    object value = mi.Invoke(options, new object[] { opt_key_ });
    return (OptValueType)value;
  }

  private MethodInfo GetExtentionMethod(Type opt_type, Type generic_type)
  {
    foreach (MethodInfo mi in opt_type.GetMethods())
    {
      if (mi.Name == "GetExtension" && mi.GetParameters().Length == 1)
      {
        return mi.MakeGenericMethod(generic_type);
      }
    }
    return null;
  }

  private object opt_key_;
}