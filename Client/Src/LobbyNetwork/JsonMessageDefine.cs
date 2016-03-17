using System;
using LitJson;

namespace DashFire.Network
{
  internal enum AccountLoginResult
  {
    Success = 0,    //��¼�ɹ�
    FirstLogin,     //�˺��״ε�¼
    Error,          //��¼ʧ��
    Wait,           //��¼��̫�࣬�ȴ�
    Banned,         //�˺��ѱ���ͣ
    AlreadyOnline,  //�˺��ڱ��ѵ�¼
    Queueing,       //�Ŷ�
  }
  internal enum ActivateAccountResult : int
  {
    Success = 0,    //����ɹ�
    InvalidCode,    //ʧЧ�ļ����루�ü������Ѿ���ʹ�ã�
    MistakenCode,   //����ļ����루�ü����벻���ڣ�
    Error,          //����ʧ��(ϵͳ����)
  }
  internal enum RoleListResult : int
  {
    Success = 0,      //���ؽ�ɫ�б�ɹ�
    AccountNotLogin,  //�˺�δ��¼�򲻴���
    UnknownError,     //δ֪����
  }

  internal enum CreateRoleResult
  {
    Success = 0,
    NicknameError,
    UnknownError,
  }

  internal enum RoleEnterResult
  {
    Success = 0,
    Wait,
    UnknownError,
  }
  internal enum QueryInfoResult
  {
    Success = 0,
    UnknownError,
  }

  internal sealed class JsonMessage
  {
    internal int m_ID = -1;
    internal JsonData m_JsonData = null;
    internal object m_ProtoData = null;

    internal JsonMessage(int id)
    {
      m_ID = id;
    }
    internal JsonMessage(JsonMessageID id)
    {
      m_ID = (int)id;
      m_JsonData = new JsonData();
    }
  }

  internal delegate void JsonMessageHandlerDelegate(JsonMessage msg);

  internal static class JsonDataExtensions
  {
    //--------------------------------------------------------------------------
    internal static bool AsBoolean(this JsonData data)
    {
      bool ret = false;
      if (data.IsInt) {
        ret = (int)data != 0;
      } else if (data.IsLong) {
        ret = (long)data != 0;
      } else if (data.IsDouble) {
        ret = (float)data != 0;
      } else if (data.IsBoolean) {
        ret = (bool)data;
      } else if (data.IsString) {
        ret = long.Parse((string)data) != 0;
      }
      return ret;
    }
    internal static int AsInt(this JsonData data)
    {
      int ret = 0;
      if (data.IsInt) {
        ret = (int)data;
      } else if (data.IsLong) {
        ret = (int)(long)data;
      } else if (data.IsDouble) {
        ret = (int)(float)(float)data;
      } else if (data.IsBoolean) {
        ret = ((bool)data ? 1 : 0);
      } else if (data.IsString) {
        ret = int.Parse((string)data);
      }
      return ret;
    }
    internal static long AsLong(this JsonData data)
    {
      long ret = 0;
      if (data.IsInt) {
        ret = (int)data;
      } else if (data.IsLong) {
        ret = (long)data;
      } else if (data.IsDouble) {
        ret = (int)(float)(float)data;
      } else if (data.IsBoolean) {
        ret = ((bool)data ? 1 : 0);
      } else if (data.IsString) {
        ret = long.Parse((string)data);
      }
      return ret;
    }
    internal static float AsDouble(this JsonData data)
    {
      float ret = 0;
      if (data.IsInt) {
        ret = (int)data;
      } else if (data.IsLong) {
        ret = (long)data;
      } else if (data.IsDouble) {
        ret = (float)data;
      } else if (data.IsBoolean) {
        ret = ((bool)data ? 1 : 0);
      } else if (data.IsString) {
        ret = float.Parse((string)data);
      }
      return ret;
    }
    internal static string AsString(this JsonData data)
    {
      string ret = null;
      if (data.IsInt) {
        ret = ((int)data).ToString();
      } else if (data.IsLong) {
        ret = ((long)data).ToString();
      } else if (data.IsDouble) {
        ret = ((int)(float)(float)data).ToString();
      } else if (data.IsBoolean) {
        ret = ((bool)data ? 1 : 0).ToString();
      } else if (data.IsString) {
        ret = (string)data;
      }
      return ret;
    }
    internal static uint AsUint(this JsonData data)
    {
      return (uint)data.AsInt();
    }
    internal static ulong AsUlong(this JsonData data)
    {
      return (ulong)data.AsLong();
    }
    internal static float AsFloat(this JsonData data)
    {
      return (float)data.AsDouble();
    }
    //--------------------------------------------------------------------------
    internal static bool Get(this JsonData data, ref bool val)
    {
      bool ret = false;
      if (data.IsBoolean) {
        ret = true;
        val = (bool)data;
      }
      return ret;
    }
    internal static bool Get(this JsonData data, ref int val)
    {
      bool ret = false;
      if (data.IsDouble || data.IsInt || data.IsLong) {
        ret = true;
        val = data.AsInt();
      }
      return ret;
    }
    internal static bool Get(this JsonData data, ref long val)
    {
      bool ret = false;
      if (data.IsDouble || data.IsInt || data.IsLong) {
        ret = true;
        val = data.AsLong();
      }
      return ret;
    }
    internal static bool Get(this JsonData data, ref double val)
    {
      bool ret = false;
      if (data.IsDouble || data.IsInt || data.IsLong) {
        ret = true;
        val = data.AsDouble();
      }
      return ret;
    }
    internal static bool Get(this JsonData data, ref string val)
    {
      bool ret = false;
      if (data.IsString) {
        ret = true;
        val = (string)data;
      }
      return ret;
    }
    internal static bool Get(this JsonData data, ref uint val)
    {
      int temp = 0;
      bool ret = Get(data, ref temp);
      if (ret) {
        val = (uint)temp;
      }
      return ret;
    }
    internal static bool Get(this JsonData data, ref ulong val)
    {
      long temp = 0;
      bool ret = Get(data, ref temp);
      if (ret) {
        val = (ulong)temp;
      }
      return ret;
    }
    internal static bool Get(this JsonData data, ref float val)
    {
      double temp = 0;
      bool ret = Get(data, ref temp);
      if (ret) {
        val = (float)temp;
      }
      return ret;
    }
    //--------------------------------------------------------------------------
    internal static bool Get(this JsonData data, string key, ref bool val)
    {
      bool ret = false;
      if (data.IsObject) {
        ret = data[key].Get(ref val);
      }
      return ret;
    }
    internal static bool Get(this JsonData data, string key, ref int val)
    {
      bool ret = false;
      if (data.IsObject) {
        ret = data[key].Get(ref val);
      }
      return ret;
    }
    internal static bool Get(this JsonData data, string key, ref long val)
    {
      bool ret = false;
      if (data.IsObject) {
        ret = data[key].Get(ref val);
      }
      return ret;
    }
    internal static bool Get(this JsonData data, string key, ref double val)
    {
      bool ret = false;
      if (data.IsObject) {
        ret = data[key].Get(ref val);
      }
      return ret;
    }
    internal static bool Get(this JsonData data, string key, ref string val)
    {
      bool ret = false;
      if (data.IsObject) {
        ret = data[key].Get(ref val);
      }
      return ret;
    }
    internal static bool Get(this JsonData data, string key, ref uint val)
    {
      bool ret = false;
      if (data.IsObject) {
        ret = data[key].Get(ref val);
      }
      return ret;
    }
    internal static bool Get(this JsonData data, string key, ref ulong val)
    {
      long temp = 0;
      bool ret = Get(data, key, ref temp);
      if (ret) {
        val = (ulong)temp;
      }
      return ret;
    }
    internal static bool Get(this JsonData data, string key, ref float val)
    {
      double temp = 0;
      bool ret = Get(data, key, ref temp);
      if (ret) {
        val = (float)temp;
      }
      return ret;
    }
    //--------------------------------------------------------------------------
    internal static void Set(this JsonData data, string key, bool val)
    {
      data[key] = val;
    }
    internal static void Set(this JsonData data, string key, int val)
    {
      data[key] = val;
    }
    internal static void Set(this JsonData data, string key, long val)
    {
      data[key] = val;
    }
    internal static void Set(this JsonData data, string key, double val)
    {
      data[key] = val;
    }
    internal static void Set(this JsonData data, string key, string val)
    {
      data[key] = val;
    }
    internal static void Set(this JsonData data, string key, uint val)
    {
      data[key] = (int)val;
    }
    internal static void Set(this JsonData data, string key, ulong val)
    {
      data[key] = (long)val;
    }
    internal static void Set(this JsonData data, string key, float val)
    {
      data[key] = (float)val;
    }
    internal static void Set(this JsonData data, string key, int[] val)
    {
      string json_string = "";
      for (int i = 0; i < val.Length; i++) {
        json_string += val[i].ToString();
        if (val.Length - 1 != i) {
          json_string += "|";
        }
      }
      data[key] = (string)json_string;
    }
    //--------------------------------------------------------------------------
    internal static bool Get(this JsonData data, int index, ref bool val)
    {
      bool ret = false;
      if ((data.IsObject || data.IsArray) && data.Count > index) {
        ret = data[index].Get(ref val);
      }
      return ret;
    }
    internal static bool Get(this JsonData data, int index, ref int val)
    {
      bool ret = false;
      if ((data.IsObject || data.IsArray) && data.Count > index) {
        ret = data[index].Get(ref val);
      }
      return ret;
    }
    internal static bool Get(this JsonData data, int index, ref long val)
    {
      bool ret = false;
      if ((data.IsObject || data.IsArray) && data.Count > index) {
        ret = data[index].Get(ref val);
      }
      return ret;
    }
    internal static bool Get(this JsonData data, int index, ref double val)
    {
      bool ret = false;
      if ((data.IsObject || data.IsArray) && data.Count > index) {
        ret = data[index].Get(ref val);
      }
      return ret;
    }
    internal static bool Get(this JsonData data, int index, ref string val)
    {
      bool ret = false;
      if ((data.IsObject || data.IsArray) && data.Count > index) {
        ret = data[index].Get(ref val);
      }
      return ret;
    }
    internal static bool Get(this JsonData data, int index, ref uint val)
    {
      bool ret = false;
      if ((data.IsObject || data.IsArray) && data.Count > index) {
        ret = data[index].Get(ref val);
      }
      return ret;
    }
    internal static bool Get(this JsonData data, int index, ref ulong val)
    {
      long temp = 0;
      bool ret = Get(data, index, ref temp);
      if (ret) {
        val = (ulong)temp;
      }
      return ret;
    }
    internal static bool Get(this JsonData data, int index, ref float val)
    {
      float temp = 0;
      bool ret = Get(data, index, ref temp);
      if (ret) {
        val = (float)temp;
      }
      return ret;
    }
    //--------------------------------------------------------------------------
    internal static void Set(this JsonData data, int index, bool val)
    {
      data[index] = val;
    }
    internal static void Set(this JsonData data, int index, int val)
    {
      data[index] = val;
    }
    internal static void Set(this JsonData data, int index, long val)
    {
      data[index] = val;
    }
    internal static void Set(this JsonData data, int index, double val)
    {
      data[index] = val;
    }
    internal static void Set(this JsonData data, int index, string val)
    {
      data[index] = val;
    }
    internal static void Set(this JsonData data, int index, uint val)
    {
      data[index] = (int)val;
    }
    internal static void Set(this JsonData data, int index, ulong val)
    {
      data[index] = (long)val;
    }
    internal static void Set(this JsonData data, int index, float val)
    {
      data[index] = (float)val;
    }
    //--------------------------------------------------------------------------
    internal static bool GetBoolean(this JsonData data)
    {
      bool ret = false;
      data.Get(ref ret);
      return ret;
    }
    internal static int GetInt(this JsonData data)
    {
      int ret = 0;
      data.Get(ref ret);
      return ret;
    }
    internal static long GetLong(this JsonData data)
    {
      long ret = 0;
      data.Get(ref ret);
      return ret;
    }
    internal static float GetDouble(this JsonData data)
    {
      float ret = 0;
      data.Get(ref ret);
      return ret;
    }
    internal static string GetString(this JsonData data)
    {
      string ret = null;
      data.Get(ref ret);
      return ret;
    }
    internal static uint GetUint(this JsonData data)
    {
      uint ret = 0;
      data.Get(ref ret);
      return ret;
    }
    internal static ulong GetUlong(this JsonData data)
    {
      ulong ret = 0;
      data.Get(ref ret);
      return ret;
    }
    internal static float GetFloat(this JsonData data)
    {
      float ret = 0;
      data.Get(ref ret);
      return ret;
    }
    //--------------------------------------------------------------------------
    internal static bool GetBoolean(this JsonData data, string key)
    {
      bool ret = false;
      data.Get(key, ref ret);
      return ret;
    }
    internal static int GetInt(this JsonData data, string key)
    {
      int ret = 0;
      data.Get(key, ref ret);
      return ret;
    }
    internal static long GetLong(this JsonData data, string key)
    {
      long ret = 0;
      data.Get(key, ref ret);
      return ret;
    }
    internal static float GetDouble(this JsonData data, string key)
    {
      float ret = 0;
      data.Get(key, ref ret);
      return ret;
    }
    internal static string GetString(this JsonData data, string key)
    {
      string ret = null;
      data.Get(key, ref ret);
      return ret;
    }
    internal static uint GetUint(this JsonData data, string key)
    {
      uint ret = 0;
      data.Get(key, ref ret);
      return ret;
    }
    internal static ulong GetUlong(this JsonData data, string key)
    {
      ulong ret = 0;
      data.Get(key, ref ret);
      return ret;
    }
    internal static float GetFloat(this JsonData data, string key)
    {
      float ret = 0;
      data.Get(key, ref ret);
      return ret;
    }
    //--------------------------------------------------------------------------
    internal static bool GetBoolean(this JsonData data, int index)
    {
      bool ret = false;
      data.Get(index, ref ret);
      return ret;
    }
    internal static int GetInt(this JsonData data, int index)
    {
      int ret = 0;
      data.Get(index, ref ret);
      return ret;
    }
    internal static long GetLong(this JsonData data, int index)
    {
      long ret = 0;
      data.Get(index, ref ret);
      return ret;
    }
    internal static float GetDouble(this JsonData data, int index)
    {
      float ret = 0;
      data.Get(index, ref ret);
      return ret;
    }
    internal static string GetString(this JsonData data, int index)
    {
      string ret = null;
      data.Get(index, ref ret);
      return ret;
    }
    internal static uint GetUint(this JsonData data, int index)
    {
      uint ret = 0;
      data.Get(index, ref ret);
      return ret;
    }
    internal static ulong GetUlong(this JsonData data, int index)
    {
      ulong ret = 0;
      data.Get(index, ref ret);
      return ret;
    }
    internal static float GetFloat(this JsonData data, int index)
    {
      float ret = 0;
      data.Get(index, ref ret);
      return ret;
    }
  }
}