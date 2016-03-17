using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace DashFire
{
  /// <remarks>
  /// ���ַ�ʽ��Ҫ�������ݲ��治�ó���ĳ��ϣ������ҵ��Ƕ��ܹ������ݶ�����г��󣬾;�����Ҫ�����ֶ�̬�ľۺ����ݵķ�ʽ������ʹ��
  /// ��̬���͵Ĺ�����
  /// ���������ڹ������ɲ�ͬ���͵����ݣ���֮ǰC++����union������ͬ���ݵ����Σ�ʹ�����ƣ�
  /// 1�����������ÿ�����͵�����ֻ����һ��ʵ����
  /// 2������ʹ������ʱ������Ϣ����ǿ���ͼ��ϣ�����Ч�ʽϵ͡�
  /// </remarks>
  /*
  public sealed class ClientConcurrentTypedDataCollection
  {
    public void GetOrNewData<T>(out T t) where T : new()
    {
      lock (m_Lock) {
        t = GetData<T>();
        if (null == t) {
          t = new T();
          AddData(t);
        }
      }
    }
    public void AddData<T>(T data)
    {
      lock (m_Lock) {
        Type t = typeof(T);
        if (null != data) {
          if (m_AiDatas.Contains(t)) {
            m_AiDatas[t] = data;
          } else {
            m_AiDatas.Add(t, data);
          }
        }
      }
    }
    public void RemoveData<T>(T t)
    {
      lock (m_Lock) {
        RemoveData<T>();
      }
    }
    public void RemoveData<T>()
    {
      lock (m_Lock) {
        Type t = typeof(T);
        if (m_AiDatas.Contains(t)) {
          m_AiDatas.Remove(t);
        }
      }
    }
    public T GetData<T>()
    {
      T ret = default(T);
      lock (m_Lock) {
        Type t = typeof(T);
        if (m_AiDatas.Contains(t)) {
          ret = (T)m_AiDatas[t];
        }
      }
      return ret;
    }
    public void Clear()
    {
      lock (m_Lock) {
        m_AiDatas.Clear();
      }
    }
    public void Visit(MyAction<object, object> visitor)
    {
      DictionaryEntry[] dicts;
      lock (m_Lock) {
        dicts = new DictionaryEntry[m_AiDatas.Count];
        m_AiDatas.CopyTo(dicts, 0);
      }
      foreach (DictionaryEntry dict in dicts) {
        visitor(dict.Key, dict.Value);
      }
    }
    private object m_Lock = new object();
    private Hashtable m_AiDatas = new Hashtable();
  }
  */
  public sealed class ClientConcurrentTypedDataCollection
  {
    public void GetOrNewData<T>(out T t) where T : new()
    {
      t = GetData<T>();
      if (null == t) {
        t = new T();
        AddData(t);
      }
    }
    public void AddData<T>(T data)
    {
      Type t = typeof(T);
      if (null != data) {
        m_AiDatas.AddOrUpdate(t, data, data);
      }
    }
    public void RemoveData<T>(T t)
    {
      RemoveData<T>();
    }
    public void RemoveData<T>()
    {
      Type t = typeof(T);
      object o;
      m_AiDatas.TryRemove(t, out o);
    }
    public T GetData<T>()
    {
      Type t = typeof(T);
      object o;
      if (m_AiDatas.TryGetValue(t, out o)) {
        return (T)o;
      } else {
        return default(T);
      }
    }
    public void Clear()
    {
      m_AiDatas.Clear();
    }
    public void Visit(MyAction<object, object> visitor)
    {
      foreach (KeyValuePair<Type, object> dict in m_AiDatas) {
        visitor(dict.Key, dict.Value);
      }
    }
    private ClientConcurrentDictionary<Type, object> m_AiDatas = new ClientConcurrentDictionary<Type, object>();
  }
}