using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace DashFireProtoGen
{
  internal static class GenerateRuleReader
  {
    public static string RuleFile { get { return "generate.rules"; } }

    public static List<GenerateRule> Run()
    {
      string rule_file = Path.Combine(Program.ProtoFileDir, RuleFile);
      XmlDocument doc = new XmlDocument();
      doc.Load(rule_file);
      XmlNode entry = doc.SelectSingleNode("GenerateRules");

      HashSet<string> rule_names = new HashSet<string>();
      List<GenerateRule> rules = new List<GenerateRule>();

      foreach (XmlNode node in entry.ChildNodes)
      {
        // TODO: exception
        if (rule_names.Contains(node.Name))
          throw new Exception("Generate Rule: " + node.Name + " is already exists.");

        rule_names.Add(node.Name);
        rules.Add(new GenerateRule(node.Name, ProtoFiles(node)));
      }

      return rules;
    }

    private static List<string> ProtoFiles(XmlNode node)
    {
      List<string> proto_list = new List<string>();
      foreach (XmlNode proto_node in node.ChildNodes)
      {
        if (proto_node.Name == "proto")
          proto_list.Add(Path.Combine(Program.ProtoFileDir, proto_node.InnerText));
      }

      // TODO: exception
      if (proto_list.Count == 0)
        throw new Exception("Generate Rule: " + node.Name + " has not proto definitions.");

      return proto_list;
    }
  }
}