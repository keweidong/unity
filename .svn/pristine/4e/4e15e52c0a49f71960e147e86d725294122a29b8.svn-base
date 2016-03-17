using System;
using System.IO;
using System.Text;
using System.Reflection;
using System.Collections.Generic;

using Google.ProtocolBuffers.ProtoGen;

namespace DashFireProtoGen
{
  internal class Program
  {
    public static string GeneratedDir = "Generated";
    public static string ProtoFileDir = "ProtoFiles";
    public static bool Optimize = false;

    internal static void Main(string[] args)
    {
      try 
      {
        ParseArgs(args);
        SetWorkingDirectory();

        foreach (GenerateRule rule in GenerateRuleReader.Run())
        {
          if (!rule.IsExpired)
          {
            Console.WriteLine(rule.Name + " is up to date.");
            continue;
          }

          Console.WriteLine("Generating " + rule.Name + "...");

          string[] options = GenerateCommandline.ProtoGenOptions(rule.Name, rule.ProtoFilePaths);
          Console.WriteLine("Options:");
          foreach (string opt in options)
            Console.WriteLine("  " + opt);

          ProgramPreprocess.Run(options);

          Console.WriteLine("Generate finish");
          Console.WriteLine("Inspecting message types and generate message ID Mapping code");
          string code = IDMappingCodeGenerator.IDMappingCode(rule.Name, rule.ProtoFilePaths);

          Console.WriteLine("Generating Assembly...");
          StringBuilder compile_errors, compile_warnings;
          bool build_ret = GenerateAssembly.Build(
            rule.Name,
            rule.ProtoFilePaths,
            code,
            out compile_errors,
            out compile_warnings);

          if (compile_errors.Length > 0)
          {
            Console.WriteLine("Compile Errors:");
            Console.Write(compile_errors);
          }

          if (compile_warnings.Length > 0)
          {
            Console.WriteLine("Compile Warnings:");
            Console.Write(compile_warnings);
          }

          if (build_ret)
          {
            rule.StoreTimeStamp();
            Console.WriteLine("Done");
          }
          else
          {
            Console.WriteLine("Failed");
          }          
        }
      } 
      catch (Exception e)
      {
        Console.Error.WriteLine("Error: {0}", e.Message);
      }      
    }

    private static void SetWorkingDirectory()
    {
      string loc = Assembly.GetExecutingAssembly().Location;
      Directory.SetCurrentDirectory(Path.GetDirectoryName(loc));
    }

    private static void ParseArgs(string[] args)
    {
      foreach (string p in args)
      {
        if (p.Contains("optimize"))
          Program.Optimize = true;
      }
    }
  }
}
