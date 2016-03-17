﻿using System;
using System.Collections;
using System.Collections.Generic;
using StorySystem;
using ScriptRuntime;

namespace StorySystem.CommonValues
{
  internal sealed class PropGetValue : IStoryValue<object>
  {
    public void InitFromDsl(ScriptableData.ISyntaxComponent param)
    {
      ScriptableData.CallData callData = param as ScriptableData.CallData;
      if (null != callData && callData.GetId() == "propget") {
        m_ParamNum = callData.GetParamNum();
        if (m_ParamNum > 0)
          m_VarName.InitFromDsl(callData.GetParam(0));
        if (m_ParamNum > 1)
          m_DefaultValue.InitFromDsl(callData.GetParam(1));
      }
    }
    public IStoryValue<object> Clone()
    {
      PropGetValue val = new PropGetValue();
      val.m_ParamNum = m_ParamNum;
      val.m_VarName = m_VarName.Clone();
      val.m_DefaultValue = m_DefaultValue.Clone();
      val.m_HaveValue = m_HaveValue;
      val.m_Value = m_Value;
      return val;
    }
    public void Evaluate(object iterator, object[] args)
    {
      m_Iterator = iterator;
      m_Args = args;
      if (m_ParamNum > 0)
        m_VarName.Evaluate(iterator, args);
      if (m_ParamNum > 1)
        m_DefaultValue.Evaluate(iterator, args);
    }
    public void Evaluate(StoryInstance instance)
    {
      if (m_ParamNum > 0)
        m_VarName.Evaluate(instance);
      if (m_ParamNum > 1)
        m_DefaultValue.Evaluate(instance);
      TryUpdateValue(instance);
    }
    public void Analyze(StoryInstance instance)
    {
      if (m_ParamNum > 0)
        m_VarName.Analyze(instance);
      if (m_ParamNum > 1)
        m_DefaultValue.Analyze(instance);
    }
    public bool HaveValue
    {
      get
      {
        return m_HaveValue;
      }
    }
    public object Value
    {
      get
      {
        return m_Value;
      }
    }

    private void TryUpdateValue(StoryInstance instance)
    {
      if (m_VarName.HaveValue) {
        m_HaveValue = true;
        string varName = m_VarName.Value;
        if (varName.StartsWith("@") && !varName.StartsWith("@@")) {
          object val;
          if (instance.LocalVariables.TryGetValue(varName, out val)) {
            m_Value = val;
          } else if (m_ParamNum > 1) {
            m_Value = m_DefaultValue.Value;
          } else {
            m_Value = null;
          }
        } else if (varName.StartsWith("$")) {
          if (varName.StartsWith("$$")) {
            m_Value = m_Iterator;
          } else if (null != m_Args) {
            try {
              int index = int.Parse(varName.Substring(1));
              if (index >= 0 && index < m_Args.Length) {
                m_Value = m_Args[index];
              } else if (m_ParamNum > 1) {
                m_Value = m_DefaultValue.Value;
              } else {
                m_Value = null;
              }
            } catch (Exception ex) {
              if (m_ParamNum > 1) {
                m_Value = m_DefaultValue.Value;
              } else {
                m_Value = null;
              }
            }
          }
        } else {
          object val;
          if (null != instance.GlobalVariables && instance.GlobalVariables.TryGetValue(varName, out val)) {
            m_Value = val;
          } else if (m_ParamNum > 1) {
            m_Value = m_DefaultValue.Value;
          } else {
            m_Value = null;
          }
        }        
      }
    }

    private object m_Iterator = null;
    private object[] m_Args = null;

    private int m_ParamNum = 0;
    private IStoryValue<string> m_VarName = new StoryValue<string>();
    private IStoryValue<object> m_DefaultValue = new StoryValue();
    private bool m_HaveValue;
    private object m_Value;
  }
  internal sealed class RandomIntValue : IStoryValue<object>
  {
    public void InitFromDsl(ScriptableData.ISyntaxComponent param)
    {
      ScriptableData.CallData callData = param as ScriptableData.CallData;
      if (null != callData && callData.GetId() == "rndint" && callData.GetParamNum() == 2) {
        m_Min.InitFromDsl(callData.GetParam(0));
        m_Max.InitFromDsl(callData.GetParam(1));
      }
    }
    public IStoryValue<object> Clone()
    {
      RandomIntValue val = new RandomIntValue();
      val.m_Min = m_Min.Clone();
      val.m_Max = m_Max.Clone();
      val.m_HaveValue = m_HaveValue;
      val.m_Value = m_Value;
      return val;
    }
    public void Evaluate(object iterator, object[] args)
    {
      m_Min.Evaluate(iterator, args);
      m_Max.Evaluate(iterator, args);
    }
    public void Evaluate(StoryInstance instance)
    {
      m_Min.Evaluate(instance);
      m_Max.Evaluate(instance);
      TryUpdateValue(instance);
    }
    public void Analyze(StoryInstance instance)
    {
      m_Min.Analyze(instance);
      m_Max.Analyze(instance);
    }
    public bool HaveValue
    {
      get
      {
        return m_HaveValue;
      }
    }
    public object Value
    {
      get
      {
        return m_Value;
      }
    }

    private void TryUpdateValue(StoryInstance instance)
    {
      if (m_Min.HaveValue && m_Max.HaveValue) {
        m_HaveValue = true;
        int min = m_Min.Value;
        int max = m_Max.Value;
        m_Value = DashFire.Helper.Random.Next(min, max);
      }
    }

    private IStoryValue<int> m_Min = new StoryValue<int>();
    private IStoryValue<int> m_Max = new StoryValue<int>();
    private bool m_HaveValue;
    private object m_Value;
  }
  internal sealed class RandomFloatValue : IStoryValue<object>
  {
    public void InitFromDsl(ScriptableData.ISyntaxComponent param)
    {
      ScriptableData.CallData callData = param as ScriptableData.CallData;
      if (null != callData && callData.GetId() == "rndfloat") {
      }
    }
    public IStoryValue<object> Clone()
    {
      RandomFloatValue val = new RandomFloatValue();
      val.m_HaveValue = m_HaveValue;
      val.m_Value = m_Value;
      return val;
    }
    public void Evaluate(object iterator, object[] args)
    {}
    public void Evaluate(StoryInstance instance)
    {
      TryUpdateValue(instance);
    }
    public void Analyze(StoryInstance instance)
    {}
    public bool HaveValue
    {
      get
      {
        return m_HaveValue;
      }
    }
    public object Value
    {
      get
      {
        return m_Value;
      }
    }

    private void TryUpdateValue(StoryInstance instance)
    {
      m_HaveValue = true;
      m_Value = DashFire.Helper.Random.NextFloat();
    }

    private IStoryValue<int> m_Min = new StoryValue<int>();
    private IStoryValue<int> m_Max = new StoryValue<int>();
    private bool m_HaveValue;
    private object m_Value;
  }
  internal sealed class Vector2Value : IStoryValue<object>
  {
    public void InitFromDsl(ScriptableData.ISyntaxComponent param)
    {
      ScriptableData.CallData callData = param as ScriptableData.CallData;
      if (null != callData && callData.GetId() == "vector2" && callData.GetParamNum() == 2) {
        m_X.InitFromDsl(callData.GetParam(0));
        m_Y.InitFromDsl(callData.GetParam(1));
        TryUpdateValue();
      }
    }
    public IStoryValue<object> Clone()
    {
      Vector2Value val = new Vector2Value();
      val.m_X = m_X.Clone();
      val.m_Y = m_Y.Clone();
      val.m_HaveValue = m_HaveValue;
      val.m_Value = m_Value;
      return val;
    }
    public void Evaluate(object iterator, object[] args)
    {
      m_X.Evaluate(iterator, args);
      m_Y.Evaluate(iterator, args);
      TryUpdateValue();
    }
    public void Evaluate(StoryInstance instance)
    {
      m_X.Evaluate(instance);
      m_Y.Evaluate(instance);
      TryUpdateValue();
    }
    public void Analyze(StoryInstance instance)
    {
      m_X.Analyze(instance);
      m_Y.Analyze(instance);
    }
    public bool HaveValue
    {
      get
      {
        return m_HaveValue;
      }
    }
    public object Value
    {
      get
      {
        return m_Value;
      }
    }

    private void TryUpdateValue()
    {
      if (m_X.HaveValue && m_Y.HaveValue) {
        m_HaveValue = true;
        m_Value = new Vector2(m_X.Value, m_Y.Value);
      }
    }

    private IStoryValue<float> m_X = new StoryValue<float>();
    private IStoryValue<float> m_Y = new StoryValue<float>();
    private bool m_HaveValue;
    private object m_Value;
  }
  internal sealed class Vector3Value : IStoryValue<object>
  {
    public void InitFromDsl(ScriptableData.ISyntaxComponent param)
    {
      ScriptableData.CallData callData = param as ScriptableData.CallData;
      if (null != callData && callData.GetId() == "vector3" && callData.GetParamNum() == 3) {
        m_X.InitFromDsl(callData.GetParam(0));
        m_Y.InitFromDsl(callData.GetParam(1));
        m_Z.InitFromDsl(callData.GetParam(2));
        TryUpdateValue();
      }
    }
    public IStoryValue<object> Clone()
    {
      Vector3Value val = new Vector3Value();
      val.m_X = m_X.Clone();
      val.m_Y = m_Y.Clone();
      val.m_Z = m_Z.Clone();
      val.m_HaveValue = m_HaveValue;
      val.m_Value = m_Value;
      return val;
    }
    public void Evaluate(object iterator, object[] args)
    {
      m_X.Evaluate(iterator, args);
      m_Y.Evaluate(iterator, args);
      m_Z.Evaluate(iterator, args);
      TryUpdateValue();
    }
    public void Evaluate(StoryInstance instance)
    {
      m_X.Evaluate(instance);
      m_Y.Evaluate(instance);
      m_Z.Evaluate(instance);
      TryUpdateValue();
    }
    public void Analyze(StoryInstance instance)
    {
      m_X.Analyze(instance);
      m_Y.Analyze(instance);
      m_Z.Analyze(instance);
    }
    public bool HaveValue
    {
      get
      {
        return m_HaveValue;
      }
    }
    public object Value
    {
      get
      {
        return m_Value;
      }
    }

    private void TryUpdateValue()
    {
      if (m_X.HaveValue && m_Y.HaveValue && m_Z.HaveValue) {
        m_HaveValue = true;
        m_Value = new Vector3(m_X.Value, m_Y.Value, m_Z.Value);
      }
    }

    private IStoryValue<float> m_X = new StoryValue<float>();
    private IStoryValue<float> m_Y = new StoryValue<float>();
    private IStoryValue<float> m_Z = new StoryValue<float>();
    private bool m_HaveValue;
    private object m_Value;
  }
  internal sealed class Vector4Value : IStoryValue<object>
  {
    public void InitFromDsl(ScriptableData.ISyntaxComponent param)
    {
      ScriptableData.CallData callData = param as ScriptableData.CallData;
      if (null != callData && callData.GetId() == "vector4" && callData.GetParamNum() == 4) {
        m_X.InitFromDsl(callData.GetParam(0));
        m_Y.InitFromDsl(callData.GetParam(1));
        m_Z.InitFromDsl(callData.GetParam(2));
        m_W.InitFromDsl(callData.GetParam(3));
        TryUpdateValue();
      }
    }
    public IStoryValue<object> Clone()
    {
      Vector4Value val = new Vector4Value();
      val.m_X = m_X.Clone();
      val.m_Y = m_Y.Clone();
      val.m_Z = m_Z.Clone();
      val.m_W = m_W.Clone();
      val.m_HaveValue = m_HaveValue;
      val.m_Value = m_Value;
      return val;
    }
    public void Evaluate(object iterator, object[] args)
    {
      m_X.Evaluate(iterator, args);
      m_Y.Evaluate(iterator, args);
      m_Z.Evaluate(iterator, args);
      m_W.Evaluate(iterator, args);
      TryUpdateValue();
    }
    public void Evaluate(StoryInstance instance)
    {
      m_X.Evaluate(instance);
      m_Y.Evaluate(instance);
      m_Z.Evaluate(instance);
      m_W.Evaluate(instance);
      TryUpdateValue();
    }
    public void Analyze(StoryInstance instance)
    {
      m_X.Analyze(instance);
      m_Y.Analyze(instance);
      m_Z.Analyze(instance);
      m_W.Analyze(instance);
    }
    public bool HaveValue
    {
      get
      {
        return m_HaveValue;
      }
    }
    public object Value
    {
      get
      {
        return m_Value;
      }
    }

    private void TryUpdateValue()
    {
      if (m_X.HaveValue && m_Y.HaveValue && m_Z.HaveValue && m_W.HaveValue) {
        m_HaveValue = true;
        m_Value = new Vector4(m_X.Value, m_Y.Value, m_Z.Value, m_W.Value);
      }
    }

    private IStoryValue<float> m_X = new StoryValue<float>();
    private IStoryValue<float> m_Y = new StoryValue<float>();
    private IStoryValue<float> m_Z = new StoryValue<float>();
    private IStoryValue<float> m_W = new StoryValue<float>();
    private bool m_HaveValue;
    private object m_Value;
  }
  internal sealed class QuaternionValue : IStoryValue<object>
  {
    public void InitFromDsl(ScriptableData.ISyntaxComponent param)
    {
      ScriptableData.CallData callData = param as ScriptableData.CallData;
      if (null != callData && callData.GetId() == "quaternion" && callData.GetParamNum() == 4) {
        m_X.InitFromDsl(callData.GetParam(0));
        m_Y.InitFromDsl(callData.GetParam(1));
        m_Z.InitFromDsl(callData.GetParam(2));
        m_W.InitFromDsl(callData.GetParam(3));
        TryUpdateValue();
      }
    }
    public IStoryValue<object> Clone()
    {
      QuaternionValue val = new QuaternionValue();
      val.m_X = m_X.Clone();
      val.m_Y = m_Y.Clone();
      val.m_Z = m_Z.Clone();
      val.m_W = m_W.Clone();
      val.m_HaveValue = m_HaveValue;
      val.m_Value = m_Value;
      return val;
    }
    public void Evaluate(object iterator, object[] args)
    {
      m_X.Evaluate(iterator, args);
      m_Y.Evaluate(iterator, args);
      m_Z.Evaluate(iterator, args);
      m_W.Evaluate(iterator, args);
      TryUpdateValue();
    }
    public void Evaluate(StoryInstance instance)
    {
      m_X.Evaluate(instance);
      m_Y.Evaluate(instance);
      m_Z.Evaluate(instance);
      m_W.Evaluate(instance);
      TryUpdateValue();
    }
    public void Analyze(StoryInstance instance)
    {
      m_X.Analyze(instance);
      m_Y.Analyze(instance);
      m_Z.Analyze(instance);
      m_W.Analyze(instance);
    }
    public bool HaveValue
    {
      get
      {
        return m_HaveValue;
      }
    }
    public object Value
    {
      get
      {
        return m_Value;
      }
    }

    private void TryUpdateValue()
    {
      if (m_X.HaveValue && m_Y.HaveValue && m_Z.HaveValue && m_W.HaveValue) {
        m_HaveValue = true;
        m_Value = new Quaternion(m_X.Value, m_Y.Value, m_Z.Value, m_W.Value);
      }
    }

    private IStoryValue<float> m_X = new StoryValue<float>();
    private IStoryValue<float> m_Y = new StoryValue<float>();
    private IStoryValue<float> m_Z = new StoryValue<float>();
    private IStoryValue<float> m_W = new StoryValue<float>();
    private bool m_HaveValue;
    private object m_Value;
  }
  internal sealed class EularValue : IStoryValue<object>
  {
    public void InitFromDsl(ScriptableData.ISyntaxComponent param)
    {
      ScriptableData.CallData callData = param as ScriptableData.CallData;
      if (null != callData && callData.GetId() == "eular" && callData.GetParamNum() == 3) {
        m_X.InitFromDsl(callData.GetParam(0));
        m_Y.InitFromDsl(callData.GetParam(1));
        m_Z.InitFromDsl(callData.GetParam(2));
        TryUpdateValue();
      }
    }
    public IStoryValue<object> Clone()
    {
      EularValue val = new EularValue();
      val.m_X = m_X.Clone();
      val.m_Y = m_Y.Clone();
      val.m_Z = m_Z.Clone();
      val.m_HaveValue = m_HaveValue;
      val.m_Value = m_Value;
      return val;
    }
    public void Evaluate(object iterator, object[] args)
    {
      m_X.Evaluate(iterator, args);
      m_Y.Evaluate(iterator, args);
      m_Z.Evaluate(iterator, args);
      TryUpdateValue();
    }
    public void Evaluate(StoryInstance instance)
    {
      m_X.Evaluate(instance);
      m_Y.Evaluate(instance);
      m_Z.Evaluate(instance);
      TryUpdateValue();
    }
    public void Analyze(StoryInstance instance)
    {
      m_X.Analyze(instance);
      m_Y.Analyze(instance);
      m_Z.Analyze(instance);
    }
    public bool HaveValue
    {
      get
      {
        return m_HaveValue;
      }
    }
    public object Value
    {
      get
      {
        return m_Value;
      }
    }

    private void TryUpdateValue()
    {
      if (m_X.HaveValue && m_Y.HaveValue && m_Z.HaveValue) {
        m_HaveValue = true;
        m_Value = Quaternion.CreateFromYawPitchRoll(m_X.Value, m_Y.Value, m_Z.Value);
      }
    }

    private IStoryValue<float> m_X = new StoryValue<float>();
    private IStoryValue<float> m_Y = new StoryValue<float>();
    private IStoryValue<float> m_Z = new StoryValue<float>();
    private bool m_HaveValue;
    private object m_Value;
  }
  internal sealed class Vector2DistanceValue : IStoryValue<object>
  {
    public void InitFromDsl(ScriptableData.ISyntaxComponent param)
    {
      ScriptableData.CallData callData = param as ScriptableData.CallData;
      if (null != callData && callData.GetId() == "vector2dist" && callData.GetParamNum() == 2) {
        m_Pt1.InitFromDsl(callData.GetParam(0));
        m_Pt2.InitFromDsl(callData.GetParam(1));
        TryUpdateValue();
      }
    }
    public IStoryValue<object> Clone()
    {
      Vector2DistanceValue val = new Vector2DistanceValue();
      val.m_Pt1 = m_Pt1.Clone();
      val.m_Pt2 = m_Pt2.Clone();
      val.m_HaveValue = m_HaveValue;
      val.m_Value = m_Value;
      return val;
    }
    public void Evaluate(object iterator, object[] args)
    {
      m_Pt1.Evaluate(iterator, args);
      m_Pt2.Evaluate(iterator, args);
      TryUpdateValue();
    }
    public void Evaluate(StoryInstance instance)
    {
      m_Pt1.Evaluate(instance);
      m_Pt2.Evaluate(instance);
      TryUpdateValue();
    }
    public void Analyze(StoryInstance instance)
    {
      m_Pt1.Analyze(instance);
      m_Pt2.Analyze(instance);
    }
    public bool HaveValue
    {
      get
      {
        return m_HaveValue;
      }
    }
    public object Value
    {
      get
      {
        return m_Value;
      }
    }

    private void TryUpdateValue()
    {
      if (m_Pt1.HaveValue && m_Pt2.HaveValue) {
        m_HaveValue = true;
        m_Value = (m_Pt1.Value - m_Pt2.Value).Length();
      }
    }

    private IStoryValue<Vector2> m_Pt1 = new StoryValue<Vector2>();
    private IStoryValue<Vector2> m_Pt2 = new StoryValue<Vector2>();
    private bool m_HaveValue;
    private object m_Value;
  }
  internal sealed class Vector3DistanceValue : IStoryValue<object>
  {
    public void InitFromDsl(ScriptableData.ISyntaxComponent param)
    {
      ScriptableData.CallData callData = param as ScriptableData.CallData;
      if (null != callData && callData.GetId() == "vector3dist" && callData.GetParamNum() == 2) {
        m_Pt1.InitFromDsl(callData.GetParam(0));
        m_Pt2.InitFromDsl(callData.GetParam(1));
        TryUpdateValue();
      }
    }
    public IStoryValue<object> Clone()
    {
      Vector3DistanceValue val = new Vector3DistanceValue();
      val.m_Pt1 = m_Pt1.Clone();
      val.m_Pt2 = m_Pt2.Clone();
      val.m_HaveValue = m_HaveValue;
      val.m_Value = m_Value;
      return val;
    }
    public void Evaluate(object iterator, object[] args)
    {
      m_Pt1.Evaluate(iterator, args);
      m_Pt2.Evaluate(iterator, args);
      TryUpdateValue();
    }
    public void Evaluate(StoryInstance instance)
    {
      m_Pt1.Evaluate(instance);
      m_Pt2.Evaluate(instance);
      TryUpdateValue();
    }
    public void Analyze(StoryInstance instance)
    {
      m_Pt1.Analyze(instance);
      m_Pt2.Analyze(instance);
    }
    public bool HaveValue
    {
      get
      {
        return m_HaveValue;
      }
    }
    public object Value
    {
      get
      {
        return m_Value;
      }
    }

    private void TryUpdateValue()
    {
      if (m_Pt1.HaveValue && m_Pt2.HaveValue) {
        m_HaveValue = true;
        m_Value = DashFire.Geometry.Distance(m_Pt1.Value, m_Pt2.Value);
      }
    }

    private IStoryValue<Vector3> m_Pt1 = new StoryValue<Vector3>();
    private IStoryValue<Vector3> m_Pt2 = new StoryValue<Vector3>();
    private bool m_HaveValue;
    private object m_Value;
  }
  internal sealed class Vector2To3Value : IStoryValue<object>
  {
    public void InitFromDsl(ScriptableData.ISyntaxComponent param)
    {
      ScriptableData.CallData callData = param as ScriptableData.CallData;
      if (null != callData && callData.GetId() == "vector2to3" && callData.GetParamNum() == 1) {
        m_Pt.InitFromDsl(callData.GetParam(0));
        TryUpdateValue();
      }
    }
    public IStoryValue<object> Clone()
    {
      Vector2To3Value val = new Vector2To3Value();
      val.m_Pt = m_Pt.Clone();
      val.m_HaveValue = m_HaveValue;
      val.m_Value = m_Value;
      return val;
    }
    public void Evaluate(object iterator, object[] args)
    {
      m_Pt.Evaluate(iterator, args);
      TryUpdateValue();
    }
    public void Evaluate(StoryInstance instance)
    {
      m_Pt.Evaluate(instance);
      TryUpdateValue();
    }
    public void Analyze(StoryInstance instance)
    {
      m_Pt.Analyze(instance);
    }
    public bool HaveValue
    {
      get
      {
        return m_HaveValue;
      }
    }
    public object Value
    {
      get
      {
        return m_Value;
      }
    }

    private void TryUpdateValue()
    {
      if (m_Pt.HaveValue) {
        m_HaveValue = true;
        m_Value = new Vector3(m_Pt.Value.X, 0, m_Pt.Value.Y);
      }
    }

    private IStoryValue<Vector2> m_Pt = new StoryValue<Vector2>();
    private bool m_HaveValue;
    private object m_Value;
  }
  internal sealed class Vector3To2Value : IStoryValue<object>
  {
    public void InitFromDsl(ScriptableData.ISyntaxComponent param)
    {
      ScriptableData.CallData callData = param as ScriptableData.CallData;
      if (null != callData && callData.GetId() == "vector3to2" && callData.GetParamNum() == 1) {
        m_Pt.InitFromDsl(callData.GetParam(0));
        TryUpdateValue();
      }
    }
    public IStoryValue<object> Clone()
    {
      Vector3To2Value val = new Vector3To2Value();
      val.m_Pt = m_Pt.Clone();
      val.m_HaveValue = m_HaveValue;
      val.m_Value = m_Value;
      return val;
    }
    public void Evaluate(object iterator, object[] args)
    {
      m_Pt.Evaluate(iterator, args);
      TryUpdateValue();
    }
    public void Evaluate(StoryInstance instance)
    {
      m_Pt.Evaluate(instance);
      TryUpdateValue();
    }
    public void Analyze(StoryInstance instance)
    {
      m_Pt.Analyze(instance);
    }
    public bool HaveValue
    {
      get
      {
        return m_HaveValue;
      }
    }
    public object Value
    {
      get
      {
        return m_Value;
      }
    }

    private void TryUpdateValue()
    {
      if (m_Pt.HaveValue) {
        m_HaveValue = true;
        m_Value = new Vector2(m_Pt.Value.X, m_Pt.Value.Z);
      }
    }

    private IStoryValue<Vector3> m_Pt = new StoryValue<Vector3>();
    private bool m_HaveValue;
    private object m_Value;
  }
  internal sealed class StringListValue : IStoryValue<object>
  {
    public void InitFromDsl(ScriptableData.ISyntaxComponent param)
    {
      ScriptableData.CallData callData = param as ScriptableData.CallData;
      if (null != callData && callData.GetId() == "stringlist" && callData.GetParamNum() == 1) {
        m_ListString.InitFromDsl(callData.GetParam(0));
        TryUpdateValue();
      }
    }
    public IStoryValue<object> Clone()
    {
      StringListValue val = new StringListValue();
      val.m_ListString = m_ListString.Clone();
      val.m_HaveValue = m_HaveValue;
      val.m_Value = m_Value;
      return val;
    }
    public void Evaluate(object iterator, object[] args)
    {
      m_ListString.Evaluate(iterator, args);
      TryUpdateValue();
    }
    public void Evaluate(StoryInstance instance)
    {
      m_ListString.Evaluate(instance);
      TryUpdateValue();
    }
    public void Analyze(StoryInstance instance)
    {
      m_ListString.Analyze(instance);
    }
    public bool HaveValue
    {
      get
      {
        return m_HaveValue;
      }
    }
    public object Value
    {
      get
      {
        return m_Value;
      }
    }

    private void TryUpdateValue()
    {
      if (m_ListString.HaveValue) {
        m_HaveValue = true;
        List<string> list = DashFire.Converter.ConvertStringList(m_ListString.Value);
        m_Value = new List<object>();
        for (int i = 0; i < list.Count; ++i) {
          m_Value.Add(list[i]);
        }
      }
    }

    private IStoryValue<string> m_ListString = new StoryValue<string>();
    private bool m_HaveValue;
    private List<object> m_Value;
  }
  internal sealed class IntListValue : IStoryValue<object>
  {
    public void InitFromDsl(ScriptableData.ISyntaxComponent param)
    {
      ScriptableData.CallData callData = param as ScriptableData.CallData;
      if (null != callData && callData.GetId() == "intlist" && callData.GetParamNum() == 1) {
        m_ListString.InitFromDsl(callData.GetParam(0));
        TryUpdateValue();
      }
    }
    public IStoryValue<object> Clone()
    {
      IntListValue val = new IntListValue();
      val.m_ListString = m_ListString.Clone();
      val.m_HaveValue = m_HaveValue;
      val.m_Value = m_Value;
      return val;
    }
    public void Evaluate(object iterator, object[] args)
    {
      m_ListString.Evaluate(iterator, args);
      TryUpdateValue();
    }
    public void Evaluate(StoryInstance instance)
    {
      m_ListString.Evaluate(instance);
      TryUpdateValue();
    }
    public void Analyze(StoryInstance instance)
    {
      m_ListString.Analyze(instance);
    }
    public bool HaveValue
    {
      get
      {
        return m_HaveValue;
      }
    }
    public object Value
    {
      get
      {
        return m_Value;
      }
    }

    private void TryUpdateValue()
    {
      if (m_ListString.HaveValue) {
        m_HaveValue = true;
        List<int> list = DashFire.Converter.ConvertNumericList<int>(m_ListString.Value);
        m_Value = new List<object>();
        for (int i = 0; i < list.Count; ++i) {
          m_Value.Add(list[i]);
        }
      }
    }

    private IStoryValue<string> m_ListString = new StoryValue<string>();
    private bool m_HaveValue;
    private List<object> m_Value;
  }
  internal sealed class FloatListValue : IStoryValue<object>
  {
    public void InitFromDsl(ScriptableData.ISyntaxComponent param)
    {
      ScriptableData.CallData callData = param as ScriptableData.CallData;
      if (null != callData && callData.GetId() == "floatlist" && callData.GetParamNum() == 1) {
        m_ListString.InitFromDsl(callData.GetParam(0));
        TryUpdateValue();
      }
    }
    public IStoryValue<object> Clone()
    {
      FloatListValue val = new FloatListValue();
      val.m_ListString = m_ListString.Clone();
      val.m_HaveValue = m_HaveValue;
      val.m_Value = m_Value;
      return val;
    }
    public void Evaluate(object iterator, object[] args)
    {
      m_ListString.Evaluate(iterator, args);
      TryUpdateValue();
    }
    public void Evaluate(StoryInstance instance)
    {
      m_ListString.Evaluate(instance);
      TryUpdateValue();
    }
    public void Analyze(StoryInstance instance)
    {
      m_ListString.Analyze(instance);
    }
    public bool HaveValue
    {
      get
      {
        return m_HaveValue;
      }
    }
    public object Value
    {
      get
      {
        return m_Value;
      }
    }

    private void TryUpdateValue()
    {
      if (m_ListString.HaveValue) {
        m_HaveValue = true;
        List<float> list = DashFire.Converter.ConvertNumericList<float>(m_ListString.Value);
        m_Value = new List<object>();
        for (int i = 0; i < list.Count; ++i) {
          m_Value.Add(list[i]);
        }
      }
    }

    private IStoryValue<string> m_ListString = new StoryValue<string>();
    private bool m_HaveValue;
    private List<object> m_Value;
  }
  internal sealed class Vector2ListValue : IStoryValue<object>
  {
    public void InitFromDsl(ScriptableData.ISyntaxComponent param)
    {
      ScriptableData.CallData callData = param as ScriptableData.CallData;
      if (null != callData && callData.GetId() == "vector2list" && callData.GetParamNum() == 1) {
        m_ListString.InitFromDsl(callData.GetParam(0));
        TryUpdateValue();
      }
    }
    public IStoryValue<object> Clone()
    {
      Vector2ListValue val = new Vector2ListValue();
      val.m_ListString = m_ListString.Clone();
      val.m_HaveValue = m_HaveValue;
      val.m_Value = m_Value;
      return val;
    }
    public void Evaluate(object iterator, object[] args)
    {
      m_ListString.Evaluate(iterator, args);
      TryUpdateValue();
    }
    public void Evaluate(StoryInstance instance)
    {
      m_ListString.Evaluate(instance);
      TryUpdateValue();
    }
    public void Analyze(StoryInstance instance)
    {
      m_ListString.Analyze(instance);
    }
    public bool HaveValue
    {
      get
      {
        return m_HaveValue;
      }
    }
    public object Value
    {
      get
      {
        return m_Value;
      }
    }

    private void TryUpdateValue()
    {
      if (m_ListString.HaveValue) {
        m_HaveValue = true;
        List<Vector2> list = DashFire.Converter.ConvertVector2DList(m_ListString.Value);
        m_Value = new List<object>();
        for (int i = 0; i < list.Count; ++i) {
          m_Value.Add(list[i]);
        }
      }
    }

    private IStoryValue<string> m_ListString = new StoryValue<string>();
    private bool m_HaveValue;
    private List<object> m_Value;
  }
  internal sealed class Vector3ListValue : IStoryValue<object>
  {
    public void InitFromDsl(ScriptableData.ISyntaxComponent param)
    {
      ScriptableData.CallData callData = param as ScriptableData.CallData;
      if (null != callData && callData.GetId() == "vector3list" && callData.GetParamNum() == 1) {
        m_ListString.InitFromDsl(callData.GetParam(0));
        TryUpdateValue();
      }
    }
    public IStoryValue<object> Clone()
    {
      Vector3ListValue val = new Vector3ListValue();
      val.m_ListString = m_ListString.Clone();
      val.m_HaveValue = m_HaveValue;
      val.m_Value = m_Value;
      return val;
    }
    public void Evaluate(object iterator, object[] args)
    {
      m_ListString.Evaluate(iterator, args);
      TryUpdateValue();
    }
    public void Evaluate(StoryInstance instance)
    {
      m_ListString.Evaluate(instance);
      TryUpdateValue();
    }
    public void Analyze(StoryInstance instance)
    {
      m_ListString.Analyze(instance);
    }
    public bool HaveValue
    {
      get
      {
        return m_HaveValue;
      }
    }
    public object Value
    {
      get
      {
        return m_Value;
      }
    }

    private void TryUpdateValue()
    {
      if (m_ListString.HaveValue) {
        m_HaveValue = true;
        List<Vector3> list = DashFire.Converter.ConvertVector3DList(m_ListString.Value);
        m_Value = new List<object>();
        for (int i = 0; i < list.Count; ++i) {
          m_Value.Add(list[i]);
        }
      }
    }

    private IStoryValue<string> m_ListString = new StoryValue<string>();
    private bool m_HaveValue;
    private List<object> m_Value;
  }
  internal sealed class ListValue : IStoryValue<object>
  {
    public void InitFromDsl(ScriptableData.ISyntaxComponent param)
    {
      ScriptableData.CallData callData = param as ScriptableData.CallData;
      if (null != callData && callData.GetId() == "list") {
        for (int i = 0; i < callData.GetParamNum(); ++i) {
          ScriptableData.ISyntaxComponent arg = callData.GetParam(i);
          StoryValue val = new StoryValue();
          val.InitFromDsl(arg);
          m_List.Add(val);
        }
        TryUpdateValue();
      }
    }
    public IStoryValue<object> Clone()
    {
      ListValue val = new ListValue();
      for (int i = 0; i < m_List.Count; i++ )
      {
        val.m_List.Add(m_List[i]);
      }
      /*
      foreach (IStoryValue<object> v in m_List) {
        val.m_List.Add(v);
      }*/
      val.m_HaveValue = m_HaveValue;
      val.m_Value = m_Value;
      return val;
    }
    public void Evaluate(object iterator, object[] args)
    {
      for (int i = 0; i < m_List.Count; i++)
      {
        m_List[i].Evaluate(iterator, args);
      }
      /*
      foreach (IStoryValue<object> v in m_List) {
        v.Evaluate(iterator, args);
      }*/
      TryUpdateValue();
    }
    public void Evaluate(StoryInstance instance)
    {
      for (int i = 0; i < m_List.Count; i++)
      {
        m_List[i].Evaluate(instance);
      }
      /*
      foreach (IStoryValue<object> v in m_List) {
        v.Evaluate(instance);
      }*/
      TryUpdateValue();
    }
    public void Analyze(StoryInstance instance)
    {
      for (int i = 0; i < m_List.Count; i++)
      {
        m_List[i].Analyze(instance);
      }
      /*
      foreach (IStoryValue<object> v in m_List) {
        v.Analyze(instance);
      }*/
    }
    public bool HaveValue
    {
      get
      {
        return m_HaveValue;
      }
    }
    public object Value
    {
      get
      {
        return m_Value;
      }
    }

    private void TryUpdateValue()
    {
      bool canCalc = true;
      for (int i = 0; i < m_List.Count; i++)
      {
        if (!m_List[i].HaveValue)
        {
          canCalc = false;
          break;
        }
      }
      /*
      foreach (IStoryValue<object> v in m_List) {
        if (!v.HaveValue) {
          canCalc = false;
          break;
        }
      }*/
      if (canCalc) {
        m_HaveValue = true;
        m_Value = new List<object>();
        for (int i = 0; i < m_List.Count; i++)
        {
          m_Value.Add(m_List[i].Value);
        }
        /*
        foreach (IStoryValue<object> v in m_List) {
          m_Value.Add(v.Value);
        }*/
      }
    }
    
    private List<IStoryValue<object>> m_List = new List<IStoryValue<object>>();
    private bool m_HaveValue;
    private List<object> m_Value;
  }
  internal sealed class RandomFromListValue : IStoryValue<object>
  {
    public void InitFromDsl(ScriptableData.ISyntaxComponent param)
    {
      ScriptableData.CallData callData = param as ScriptableData.CallData;
      if (null != callData && callData.GetId() == "rndfromlist") {
        m_ParamNum = callData.GetParamNum();
        if (m_ParamNum > 0)
          m_ListValue.InitFromDsl(callData.GetParam(0));
        if (m_ParamNum > 1)
          m_DefaultValue.InitFromDsl(callData.GetParam(1));
      }
    }
    public IStoryValue<object> Clone()
    {
      RandomFromListValue val = new RandomFromListValue();
      val.m_ParamNum = m_ParamNum;
      val.m_ListValue = m_ListValue.Clone();
      val.m_DefaultValue = m_DefaultValue.Clone();
      val.m_HaveValue = m_HaveValue;
      val.m_Value = m_Value;
      return val;
    }
    public void Evaluate(object iterator, object[] args)
    {
      if (m_ParamNum > 0)
        m_ListValue.Evaluate(iterator, args);
      if (m_ParamNum > 1)
        m_DefaultValue.Evaluate(iterator, args);
    }
    public void Evaluate(StoryInstance instance)
    {
      if (m_ParamNum > 0)
        m_ListValue.Evaluate(instance);
      if (m_ParamNum > 1)
        m_DefaultValue.Evaluate(instance);
      TryUpdateValue();
    }
    public void Analyze(StoryInstance instance)
    {
      if (m_ParamNum > 0)
        m_ListValue.Analyze(instance);
      if (m_ParamNum > 1)
        m_DefaultValue.Analyze(instance);
    }
    public bool HaveValue
    {
      get
      {
        return m_HaveValue;
      }
    }
    public object Value
    {
      get
      {
        return m_Value;
      }
    }

    private void TryUpdateValue()
    {
      if (m_ListValue.HaveValue) {
        m_HaveValue = true;
        IList listValue = m_ListValue.Value;
        int ct = listValue.Count;
        int ix = DashFire.Helper.Random.Next(ct);
        if (ix >= 0 && ix < ct) {
          m_Value = listValue[ix];
        } else if (ct > 0) {
          m_Value = listValue[0];
        } else if (m_ParamNum > 1) {
          m_Value = m_DefaultValue.Value;
        } else {
          m_Value = null;
        }
      }
    }

    private int m_ParamNum = 0;
    private IStoryValue<IList> m_ListValue = new StoryValue<IList>();
    private IStoryValue<object> m_DefaultValue = new StoryValue();
    private bool m_HaveValue;
    private object m_Value;
  }
  internal sealed class ListGetValue : IStoryValue<object>
  {
    public void InitFromDsl(ScriptableData.ISyntaxComponent param)
    {
      ScriptableData.CallData callData = param as ScriptableData.CallData;
      if (null != callData && callData.GetId() == "listget") {
        m_ParamNum = callData.GetParamNum();
        if (m_ParamNum > 1) {
          m_ListValue.InitFromDsl(callData.GetParam(0));
          m_IndexValue.InitFromDsl(callData.GetParam(1));
          if (m_ParamNum > 2) {
            m_DefaultValue.InitFromDsl(callData.GetParam(2));
          }
          TryUpdateValue();
        }
      }
    }
    public IStoryValue<object> Clone()
    {
      ListGetValue val = new ListGetValue();
      val.m_ParamNum = m_ParamNum;
      val.m_ListValue = m_ListValue.Clone();
      val.m_IndexValue = m_IndexValue.Clone();
      val.m_DefaultValue = m_DefaultValue.Clone();
      val.m_HaveValue = m_HaveValue;
      val.m_Value = m_Value;
      return val;
    }
    public void Evaluate(object iterator, object[] args)
    {
      if (m_ParamNum > 1) {
        m_ListValue.Evaluate(iterator, args);
        m_IndexValue.Evaluate(iterator, args);
      }
      if (m_ParamNum > 2) {
        m_DefaultValue.Evaluate(iterator, args);
      }
      TryUpdateValue();
    }
    public void Evaluate(StoryInstance instance)
    {
      if (m_ParamNum > 1) {
        m_ListValue.Evaluate(instance);
        m_IndexValue.Evaluate(instance);
      }
      if (m_ParamNum > 2) {
        m_DefaultValue.Evaluate(instance);
      }
      TryUpdateValue();
    }
    public void Analyze(StoryInstance instance)
    {
      if (m_ParamNum > 1) {
        m_ListValue.Analyze(instance);
        m_IndexValue.Analyze(instance);
      }
      if (m_ParamNum > 2) {
        m_DefaultValue.Analyze(instance);
      }
    }
    public bool HaveValue
    {
      get
      {
        return m_HaveValue;
      }
    }
    public object Value
    {
      get
      {
        return m_Value;
      }
    }

    private void TryUpdateValue()
    {
      if (m_ListValue.HaveValue && m_IndexValue.HaveValue) {
        m_HaveValue = true;
        IList listValue = m_ListValue.Value;
        int ix = m_IndexValue.Value;
        int ct = listValue.Count;
        if (ix >= 0 && ix < ct) {
          m_Value = listValue[ix];
        } else if (ct > 0) {
          m_Value = listValue[ct - 1];
        } else if (m_ParamNum > 2) {
          m_Value = m_DefaultValue.Value;
        } else {
          m_Value = null;
        }
      }
    }

    private int m_ParamNum = 0;
    private IStoryValue<IList> m_ListValue = new StoryValue<IList>();
    private IStoryValue<int> m_IndexValue = new StoryValue<int>();
    private IStoryValue<object> m_DefaultValue = new StoryValue();
    private bool m_HaveValue;
    private object m_Value;
  }
  internal sealed class ListSizeValue : IStoryValue<object>
  {
    public void InitFromDsl(ScriptableData.ISyntaxComponent param)
    {
      ScriptableData.CallData callData = param as ScriptableData.CallData;
      if (null != callData && callData.GetId() == "listsize" && callData.GetParamNum() == 1) {
        m_ListValue.InitFromDsl(callData.GetParam(0));
        TryUpdateValue();
      }
    }
    public IStoryValue<object> Clone()
    {
      ListSizeValue val = new ListSizeValue();
      val.m_ListValue = m_ListValue.Clone();
      val.m_HaveValue = m_HaveValue;
      val.m_Value = m_Value;
      return val;
    }
    public void Evaluate(object iterator, object[] args)
    {
      m_ListValue.Evaluate(iterator, args);
      TryUpdateValue();
    }
    public void Evaluate(StoryInstance instance)
    {
      m_ListValue.Evaluate(instance);
      TryUpdateValue();
    }
    public void Analyze(StoryInstance instance)
    {
      m_ListValue.Analyze(instance);
    }
    public bool HaveValue
    {
      get
      {
        return m_HaveValue;
      }
    }
    public object Value
    {
      get
      {
        return m_Value;
      }
    }

    private void TryUpdateValue()
    {
      if (m_ListValue.HaveValue) {
        m_HaveValue = true;
        IList listValue = m_ListValue.Value;
        int ct = listValue.Count;
        m_Value=ct;
      }
    }

    private IStoryValue<IList> m_ListValue = new StoryValue<IList>();
    private bool m_HaveValue;
    private object m_Value;
  }
}
