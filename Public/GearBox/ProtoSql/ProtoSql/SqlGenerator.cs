using System.Text;

/// <summary>
/// 生成sql语句
/// </summary>
static class SqlGenerator
{
  public static void Generate(Analyzer analyzer, StringBuilder sb)
  {
    sb.AppendFormat("\ncreate table {0}\n", analyzer.TableName)
      .Append("(\n");

    foreach (var field in analyzer.TableFields)
      sb.AppendFormat("  {0} {1} not null,\n", field.Item1, field.Item2);

    sb.AppendFormat("  primary key ({0})\n", analyzer.TablePrimaryKey)
      .Append(") ENGINE=MyISAM;\n");

    //有ForeignKey标识的的表创建索引
    if (analyzer.TableForeignKey != null && analyzer.TableForeignKey != string.Empty) {
      sb.AppendFormat("create index {0}Index on {1} ({2});", analyzer.TableName, analyzer.TableName, analyzer.TableForeignKey)
      .Append("\n");
    }
  }

  public static void GenerateClearSql(Analyzer analyzer, StringBuilder sb)
  {
    sb.AppendFormat("truncate table {0} ;\n", analyzer.TableName);
  }
}