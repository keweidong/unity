using System;
using System.IO;
using System.Text;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace DashFireProtoGen
{
  internal static class GenerateAssembly
  {
    public static bool Build(string rule_name, 
                             List<string> proto_file_paths,
                             string id_mapping_code,
                             out StringBuilder compile_errors,
                             out StringBuilder compile_warnings)
    {
      List<string> sources = new List<string>();
      string dir = Path.Combine(Program.GeneratedDir, rule_name);
      foreach (string proto in proto_file_paths)
      {
        if (!proto.Contains("descriptor.proto"))
        {
          string p = Path.Combine(dir, Path.GetFileNameWithoutExtension(proto) + ".cs");
          sources.Add(File.ReadAllText(p, Encoding.UTF8));
        }
      }
      sources.Add(id_mapping_code);

      CompilerParameters cp = new CompilerParameters() 
      { 
        CompilerOptions = Program.Optimize ? "/optimize" : "",
        GenerateInMemory = false,
        OutputAssembly = Path.Combine(Program.GeneratedDir, rule_name + ".dll"),
        TreatWarningsAsErrors = false,
        IncludeDebugInformation = true,
        WarningLevel = 3,
      };

      cp.ReferencedAssemblies.AddRange(new string[] {
        "System.dll",
        "Google.ProtocolBuffers.dll",
      });

      CSharpCodeProvider provider = new CSharpCodeProvider();
      CompilerResults cr = provider.CompileAssemblyFromSource(cp, sources.ToArray());

      compile_errors = new StringBuilder();
      compile_warnings = new StringBuilder();
      foreach (CompilerError ce in cr.Errors)
      {
        if (ce.IsWarning)
          compile_warnings.AppendLine(ce.ToString());
        else
          compile_errors.AppendLine(ce.ToString());
      }

      return !cr.Errors.HasErrors;
    }
  }
}