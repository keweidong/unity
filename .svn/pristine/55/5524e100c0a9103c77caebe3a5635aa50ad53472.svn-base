using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;

using Google.ProtocolBuffers.ProtoGen;
using Google.ProtocolBuffers.DescriptorProtos;

namespace DashFireProtoGen
{
  internal static class IDMappingCodeGenerator
  {
    private const string ProtocExecutable = "protoc.exe";

    public static string IDMappingCode(string ns, List<string> proto_file_paths)
    {
      string descriptor_set_file = Path.GetTempFileName();
      string[] opts = GenerateCommandline.ProtocDescSetOptions(descriptor_set_file, proto_file_paths);
      int ret = RunProtoc(opts);
      if (0 != ret)
        throw new Exception("run protoc failed: " + ret);

      return GenerateCode(ns, CollectMessageTypes(descriptor_set_file));
    }

    // these code is copied directly from ProtoGen project with slightly changes
    // which are:
    //   1. assume protoc.exe is in the same directory which this executable is placed or in PATH
    //   2. set WorkingDirectory to use Directory.GetCurrentDirectory()
    // i try not to modify any code in ProtoGen
    private static int RunProtoc(params string[] args)
    {
      ProcessStartInfo psi = new ProcessStartInfo(ProtocExecutable);
      psi.Arguments = ProgramPreprocess.EscapeArguments(args);
      psi.RedirectStandardError = true;
      psi.RedirectStandardInput = false;
      psi.RedirectStandardOutput = true;
      psi.ErrorDialog = false;
      psi.CreateNoWindow = true;
      psi.UseShellExecute = false;
      psi.WorkingDirectory = Directory.GetCurrentDirectory();

      Process process = Process.Start(psi);
      if (process == null)
      {
        return 1;
      }

      process.WaitForExit();

      string tmp = process.StandardOutput.ReadToEnd();
      if (tmp.Trim().Length > 0)
      {
        Console.Out.WriteLine(tmp);
      }
      tmp = process.StandardError.ReadToEnd();
      if (tmp.Trim().Length > 0)
      {
        Console.Error.WriteLine(tmp);
      }
      return process.ExitCode;
    }

    private static List<string> CollectMessageTypes(string descriptor_set_file)
    {
      List<string> result = new List<string>();
      using (FileStream fs = File.OpenRead(descriptor_set_file))
      {
        FileDescriptorSet fds = FileDescriptorSet.ParseFrom(fs);
        foreach (FileDescriptorProto fdp in fds.FileList)
        {
          if (!fdp.Name.Contains("descriptor.proto"))
          {
            foreach (DescriptorProto dp in fdp.MessageTypeList)
              result.Add(dp.Name);
          }
        }
      }
      return result;
    }

    private const string IDEnumHeader = @"
#region generated message ID definition
namespace {0}
{{
  public enum MessageID : uint
  {{
";
    
    private const string IDEnumFooter = @"
  } 
}
#endregion generated message ID definition
";

    private const string MessageMappingUpperPart = @"
#region generated message mapping from System.Type to uint    
namespace {0}
{{
  public static class MessageMapping
  {{
    static MessageMapping()
    {{
      type2id_ = new System.Collections.Generic.Dictionary<System.Type, uint>();
      id2type_ = new System.Collections.Generic.Dictionary<uint, System.Type>();
";

    private const string MessageMappingLowerPart = @"
    }
    public static uint Query(System.Type t)
    {
      uint id;
      return type2id_.TryGetValue(t, out id) ? id : 0xffffffff;
    }
    public static System.Type Query(uint id)
    {
      System.Type t;
      id2type_.TryGetValue(id, out t);
      return t;
    }
    public static int Count { get { return type2id_.Count; } }
    private static System.Collections.Generic.Dictionary<System.Type, uint> type2id_;
    private static System.Collections.Generic.Dictionary<uint, System.Type> id2type_;
  }
}
#endregion generated message mapping from System.Type to uint    
";

    private static string GenerateCode(string ns, List<string> message_types)
    {
      StringBuilder sb = new StringBuilder();
      sb.AppendFormat(IDEnumHeader, ns);
      uint id = 0;
      foreach (string mt in message_types)
        sb.AppendFormat("    {0} = {1},\n", mt, id++);
      sb.Append(IDEnumFooter);

      sb.AppendFormat(MessageMappingUpperPart, ns);
      foreach (string mt in message_types)
      {
        sb.AppendFormat("      type2id_[typeof({0})] = (uint)MessageID.{0};\n", mt);
        sb.AppendFormat("      id2type_[(uint)MessageID.{0}] = typeof({0});\n", mt);
      }
      sb.Append(MessageMappingLowerPart);
      return sb.ToString();
    }
  }
}