using System;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DashFire.GMCore
{
  /// <summary>
  /// GM函数调用器, 根据Intrepreter解析的参数, 对函数进行反射调用
  /// </summary>
  public class GMCmdHandler
  {
    protected class ParameterInfoTuple
    {
      public ParameterInfo param_info_;
      public int index_;
      public ParameterInfoTuple() { }
      public ParameterInfoTuple(ParameterInfo info, int ix)
      {
        param_info_ = info;
        index_ = ix;
      }
    }
    protected GMCmdHandler() { }

    internal GMCmdHandler(MethodInfo mi)
    { 
      if (!mi.IsStatic)
        throw new HandlerMustBeStatic();

      mi_ = mi;
      pi_ = mi.GetParameters();
    }

    public virtual string Invoke(Interpreter interp)
    {
      int index = 0;
      object[] param_objects = new object[pi_.Length];
      for (int i = 0; i < interp.InputParams.Count; i++)
      {
        IInputParam input_param = interp.InputParams[i];
        ParameterInfoTuple pi = GetParameterInfo(input_param, ref index);
        // 将输入参数转换到目标类型
        param_objects[pi.index_] = input_param.Convert(pi.param_info_.ParameterType);
      }

      ParametersCheck(param_objects);

      GMCore.Log("Invoke {0}:", interp.CmdName);
      foreach (object po in param_objects)
      {
        if (null == po)
          GMCore.Log("  null");
        else
          GMCore.Log("  {0}: {1}", po.GetType().Name, po.ToString());
      }

      try
      {
        return (string)mi_.Invoke(
            null, BindingFlags.Static | BindingFlags.InvokeMethod,
            null, param_objects, null);
      }
      catch (TargetInvocationException e)
      {
        throw e.InnerException;
      }
    }

    /* IMPORTANT NOTE:
     *  when working on .NET platform, we can supply Type.Missing/Missing.Value
     *  as the default value for optional parameters. but this method is not 
     *  working on Mono platform, we have to manually supply the default value
     *  or throw an error when a parameter is not optional and no value is 
     *  supplied.
     */
    protected void ParametersCheck(object[] parameters)
    {
      List<ParameterInfo> missing = null;
      for (int i = 0; i < parameters.Length; i++)
      {
        if (null == parameters[i])
        {
          if (pi_[i].IsOptional)
          {
            parameters[i] = pi_[i].DefaultValue;
          }
          else
          {
            if (null == missing)
              missing = new List<ParameterInfo>();
            missing.Add(pi_[i]);
          }
        }
      }

      if (null != missing)
        throw new MissingParameters(missing);
    }

    /// <summary>
    /// 从Intrepreter解析命令行得到的参数input_param, 在回调函数参数列表中查找到对应的
    /// ParameterInfo, 这个函数需要处理命名参数(Named Arguments)和普通参数的情况
    /// </summary>
    /// <param name="input_param">解析命令行得到的参数</param>
    /// <param name="index">函数的参数列表中的位置</param>
    /// <returns></returns>
    protected ParameterInfoTuple GetParameterInfo(IInputParam input_param, ref int index)
    {
      int p_index = -1;
      if (null != input_param.Name)
      {
        // 查找Named Argument在参数列表中的下标
        p_index = Array.FindIndex(pi_, p => p.Name == input_param.Name);
        if (p_index == -1)
          throw new ArgumentException("Named parameter doesn't exist", input_param.Name);
      }
      else
      {
        // 当参数是普通参数的时候, 递增位置下标
        p_index = index++; 
      }

      if (p_index >= pi_.Length)
        throw new ArgumentException("Too many arguments");

      return new ParameterInfoTuple(pi_[p_index], p_index);
    }

    protected MethodInfo mi_;
    protected readonly ParameterInfo[] pi_;
  }
}