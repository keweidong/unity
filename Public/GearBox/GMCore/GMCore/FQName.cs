using System.Text.RegularExpressions;

namespace DashFire.GMCore
{
  /// <summary>
  /// fully-qualified-name, 完全修饰的名称
  /// 例如: Category.Group.CommandX
  /// </summary>
  public class FQName
  {
    public FQName(string full_name)
    {
      Cut(full_name, @"\.");
      Init();
    }

    public FQName(string c, string g, string n)
    {
      value_[0] = n;
      value_[1] = g;
      value_[2] = c;
      Init();
    }

    public override string ToString()
    {
      return string.Format("C:{0} G:{1} N:{2}", Category, Group, Name);
    }

    /// <summary>
    /// 按照delimiter来切分名称, 必须从右向左切, 因为fulll_name可能是:
    /// C1.C2.C3.G.N
    /// Category有很多级, 但是Group和Name只有一级, 切出来是:
    /// Category: C1.C2.C3
    /// Group: G
    /// Name: N
    /// </summary>
    /// <param name="full_name"></param>
    /// <param name="delimiter"></param>
    private void Cut(string full_name, string delimiter)
    {
      string pattern = string.Format(@".*({0})(.+)", delimiter);
      for (int i = 0; i < 3; ++i)
      {
        if (i == 2)
        {
          value_[i] = full_name;
        }
        else
        {
          Match m = Regex.Match(full_name, pattern);
          if (m.Success)
          {
            value_[i] = m.Groups[2].Value;
            int len = full_name.Length - (m.Groups[1].Length + m.Groups[2].Length);
            full_name = full_name.Substring(0, len);
          }
          else
          {
            value_[i] = full_name;
            break;
          }
        }
      }
    }

    private void Init()
    {
      // 将wildcard表示的匹配字符串替换成regex的表示
      for (int i = 0; i < value_.Length; ++i)
        value_[i] = Regex.Replace(value_[i], @"\*|\?", m => m.Value == "*" ? ".*" : ".");

      value_[2] = string.Format("^{0}$", Category);
      value_[1] = string.Format("^{0}$", Group);
      value_[0] = string.Format("^{0}$", Name);
    }

    public string Category { get { return value_[2].Length == 0 ? GMCore.Instance.DefaultCategory : value_[2]; } }
    public string Group { get { return value_[1].Length == 0 ? GMCore.Instance.DefaultGroup : value_[1]; } }
    public string Name { get { return value_[0].Length == 0 ? ".*" : value_[0]; } }

    private string[] value_ = new string[] { "", "", "" };
  }
}