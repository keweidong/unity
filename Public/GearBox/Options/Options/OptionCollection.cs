using System;
using System.IO;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Collections.Generic;

namespace Options
{
  /// <summary>
  /// 命令行选项集合, 收集了所有被OptionAttribute标记了的类, 并且会初始化这些类的实例.
  /// </summary>
  public sealed class OptionCollection
  {
    private static OptionCollection inst_ = new OptionCollection();
    public static OptionCollection Instance { get { return inst_; } }

    /// <summary>
    /// 显示当前的命令行选项的描述
    /// </summary>
    public string Options
    {
      get
      {
        using (StringWriter sw = new StringWriter())
        {
          os.WriteOptionDescriptions(sw);
          return sw.ToString();
        }
      }
    }

    private OptionCollection()
    {
      // 1. find all classes which marked with OptionStructureAttribute 
      // 2. instantiate all the classes found in previous step
      // 3. analyze the properties of a class and collect all the properties which marked with OptionAttribute 
      //    construct a GeneratedOption
      Dictionary<string, Opt> dup_check = new Dictionary<string, Opt>();
      foreach (Assembly ass in AppDomain.CurrentDomain.GetAssemblies())
      {
        foreach (Type t in ass.GetTypes())
        {
          if (t.GetCustomAttributes(typeof(OptionStructureAttribute), false).Length > 0)
          {
            object obj = Activator.CreateInstance(t);
            CollectOptions(obj, dup_check);
            opt_structs_.Add(t, obj);
          }
        }
      }

      os.Add("h|help", "show help message", 
             v => os.WriteOptionDescriptions(Console.Out));
    }

    /// <summary>
    /// 执行命令行解析
    /// </summary>
    /// <param name="args">命令行数组</param>
    public void Run(string[] args)
    {
      os.Parse(args);
    }

    /// <summary>
    /// 取得类型为T的实例
    /// </summary>
    /// <typeparam name="T">用户要访问的命令行选项的类的Type</typeparam>
    /// <returns></returns>
    public T Get<T>() where T : class
    {
      object obj;
      if (opt_structs_.TryGetValue(typeof(T), out obj))
        return obj as T;
      return null;
    }

    /// <summary>
    /// 搜集obj中标记了OptionAttribute的字段(property)
    /// 设置其default值
    /// 组合出命令行解析的描述
    /// </summary>
    /// <param name="obj">被检查的object</param>
    /// <param name="dup_check">重复选项的检查</param>
    private void CollectOptions(object obj, Dictionary<string, Opt> dup_check)
    {
      Type t = obj.GetType();
      foreach (PropertyInfo pi in t.GetProperties())
      {
        object[] attrs = pi.GetCustomAttributes(typeof(OptionAttribute), false);
        if (attrs.Length == 0) continue;

        OptionAttribute oa = attrs[0] as OptionAttribute;
        SetDefault(obj, pi, oa.Default);

        string prototype = Prototype(pi, null != oa.Default, dup_check);
        os.Add(new GeneratedOption(prototype, oa.Description, obj, pi));
      }
    }

    private void SetDefault(object obj, PropertyInfo pi, string default_value)
    {
      if (null != default_value)
      {
        try
        {
          object value = TypeDescriptor.GetConverter(pi.PropertyType).ConvertFromString(default_value);
          pi.SetValue(obj, value, null);
        }
        catch (Exception e)
        {
          throw new OptionTypeError(default_value, pi.PropertyType, pi.Name.ToLower(), e);
        }
      }
    }

    private string Prototype(PropertyInfo pi, bool has_default, Dictionary<string, Opt> dup_check)
    {
      StringBuilder sb = OptName(pi, dup_check);
      return (pi.PropertyType == typeof(bool)) ?
        sb.ToString() :
        sb.Append(has_default ? ':' : '=').ToString();
    }

    /// <summary>
    /// 给出当前字段可能的所有名称.
    /// </summary>
    /// <param name="pi"></param>
    /// <returns></returns>
    private List<string> GuessOptNames(PropertyInfo pi)
    {
      return new List<string>()
      {
        pi.Name.ToLower(),
        string.Format("{0}.{1}", pi.DeclaringType.Name, pi.Name.ToLower()),
        string.Format("{0}.{1}", pi.DeclaringType.FullName, pi.Name.ToLower()),
      };
    }

    /// <summary>
    /// 从PropertyInfo定义得到选项名称, 不可能所有可能的名称都重复, 因为那样等于说asssemblies
    /// 中存在FulllName相同的两个类, 编译就不会通过
    /// </summary>
    /// <param name="pi"></param>
    /// <param name="dup_check"></param>
    /// <returns></returns>
    private StringBuilder OptName(PropertyInfo pi, Dictionary<string, Opt> dup_check)
    {
      StringBuilder sb = new StringBuilder();
      foreach (string n in GuessOptNames(pi))
      {
        if (!dup_check.ContainsKey(n))
        {
          sb.Append(n + '|');
          dup_check.Add(n, new Opt(pi.DeclaringType, n));
        }
      }

      return sb.Remove(sb.Length - 1, 1);
    }

    private class Opt
    {
      public Type Type { get; private set; }
      public string Name { get; private set; }

      public Opt(Type t, string n)
      {
        Type = t;
        Name = n;
      }
    }

    private NDesk.Options.OptionSet os = new NDesk.Options.OptionSet();
    private Dictionary<Type, object> opt_structs_ = new Dictionary<Type, object>();
  }


}