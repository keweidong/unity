using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SharpHamster;

class TestValue
{
  public string Key { get; private set; }
  public HamsterValue Value { get; private set; }
  public string StrValue { get; private set; }

  public TestValue(string key, string value, UInt32 max_size)
  {
    Key = key;
    byte[] bytes = Encoding.UTF8.GetBytes(value);
    Value = new HamsterValue(bytes, max_size);
    StrValue = value;
  }
}

class Program
{
  static void Main(string[] args)
  {
    try
    {
      Console.WriteLine("pid: " + Process.GetCurrentProcess().Id);
      Console.Read();

      TestValue[] test_vals = new TestValue[]
      {
        new TestValue("key1", "hello world", 256),
        new TestValue("key2", "fuck the world", 256),
      };

      Hamster.Instance.Init();
      Console.WriteLine("Init");
      foreach (var tv in test_vals)
      {
        Console.WriteLine("Set {0} -> {1}", tv.Key, tv.StrValue);
        Hamster.Instance.Set(tv.Key, tv.Value);
        string str = Encoding.UTF8.GetString(Hamster.Instance.Get(tv.Key).Bytes);
        System.Diagnostics.Debug.Assert(str == tv.StrValue);
      }
      Hamster.Instance.Dispose();
    }
    catch (Exception e)
    {
      Console.Error.WriteLine(e.Message);
    }
  }
}
