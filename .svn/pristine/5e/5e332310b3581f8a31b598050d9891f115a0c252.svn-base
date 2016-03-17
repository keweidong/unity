using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Options;
using NDesk.Options;

namespace TestOptions
{
  [OptionStructure]
  class Option1
  {
    [Option(Description="Option1 .................................................................................................\nNewLine")]
    public bool Flag1 { get; private set; }

    [Option]
    public double Value1 { get; private set; }
  }

  [OptionStructure]
  class Option2
  {
    [Option]
    public bool Flag1 { get; private set; }

    [Option]
    public double Value2 { get; private set; }
  }

  class Program
  {
    [OptionStructure]
    internal class NestOption
    {
      [Option]
      public string Opt { get; private set; }
    }

    static void CheckFeatures()
    {
      OptionSet os = new OptionSet();
      string mandatory = "";
      string optional = "default";
      double tparam;
      bool fflag, vflag;

      // 1. assignment, optional asseignment
      // 2. boolean flag
      // 3. bundle flags
      os.Add("m|mandatory=", v => mandatory = v)
        .Add("optional:", v => optional = v)
        .Add<double>("tparam:", v => tparam = v)
        .Add("fflag|f", v => fflag = null != v)
        .Add("vflag|v", v => vflag = null != v);

      os.Parse("--optional:llisper --tparam:12.345 -f+".Split(' '));
      return;
    }

    static void TestOptions()
    {
      OptionCollection.Instance.Run("--Option1.flag1 --Option2.Flag1- --value1=12.34 --opt=hello-world".Split(' '));
      var opt1 = OptionCollection.Instance.Get<Option1>();
      Console.WriteLine("Option1: ");
      Console.WriteLine("  Flag1: " + opt1.Flag1);
      Console.WriteLine("  Value1: " + opt1.Value1);
    }
  
    static void Main(string[] args)
    {
      // TestOptions();
      // CheckFeatures();
      OptionCollection.Instance.Run(args);
    }
  }
}
