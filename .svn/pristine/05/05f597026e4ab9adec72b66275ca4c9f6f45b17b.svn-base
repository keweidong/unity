using System.Text;
using System.Collections.Generic;
using System.IO;

namespace DashFireProtoGen
{
  internal static class GenerateCommandline
  {
    public static string[] ProtoGenOptions(string rule_name, List<string> proto_file_paths)
    {
      List<string> args = new List<string>();
      ProtoGenOpt(args, rule_name);
      ProtoPath(args, proto_file_paths);
      ProtoFiles(args, proto_file_paths);
      return args.ToArray();
    }

    public static string[] ProtocDescSetOptions(string tmp_file, List<string> proto_file_paths)
    {
      List<string> args = new List<string>();
      args.Add("--descriptor_set_out=" + tmp_file); // TODO: get a tmp file
      args.Add("--include_imports");
      ProtoPath(args, proto_file_paths);
      ProtoFiles(args, proto_file_paths);
      return args.ToArray();
    }

    private static void ProtoGenOpt(List<string> args, string rule_name)
    {
      string dir = Path.Combine(Program.GeneratedDir, rule_name);
      if (!Directory.Exists(dir))
        Directory.CreateDirectory(dir);
      args.Add("-output_directory=" + dir);
      args.Add("-namespace=" + rule_name);
      args.Add("-cls_compliance=false");
    }

    private static void ProtoPath(List<string> args, List<string> proto_file_paths)
    {
      args.Add("--proto_path=" + Program.ProtoFileDir);
      foreach (string p in proto_file_paths)
        args.Add("--proto_path=" + Path.GetDirectoryName(p));
    }

    private static void ProtoFiles(List<string> args, List<string> proto_file_paths)
    {
      foreach (string p in proto_file_paths)
        args.Add(p);
    }
  }
}