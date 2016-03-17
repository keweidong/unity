using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DashFire.GMCore 
{
  /// <summary>
  /// 指令输入解析, 指令的语法参考GMCore.mkd的说明
  /// </summary>
  public class Interpreter
  {
    private class TokenInfo
    {
      public TokenType token_type_;
      public string name_;
      public TokenInfo() { }
      public TokenInfo(TokenType t, string n)
      {
        token_type_ = t;
        name_ = n;
      }
    }
    internal Interpreter(string input_line)
    {
      InputLine = input_line;
      CmdName = CommandName(InputLine, ref parse_index_);
    }

    public string InputLine { get; private set; }
    public string CmdName { get; private set; }
    public List<IInputParam> InputParams
    {
      get
      {
        if (null == input_params_)
          input_params_ = Parse(InputLine, ref parse_index_);
        return input_params_;      
      }
    }

    private enum TokenType 
    {
      LeftParenthesis,
      RightParenthesis,
      NamedKey,
      Value,
    }

    private string CommandName(string line, ref int i)
    {
      Match m = Regex.Match(line, @"^\s*(\S+)");
      if (!m.Success)
        throw new CommandSyntaxError(0, "command name incorrect");
      i = m.Length;
      return m.Groups[1].Value;
    }

    private List<IInputParam> Parse(string line, ref int i)
    {
      TokenInfo token = null;
      List<IInputParam> input_params = new List<IInputParam>();

      string named_key = null;
      token = NextToken(line, ref i);
      while (null != token)
      {
        switch (token.token_type_)
        {
          case TokenType.LeftParenthesis:
          {
            ++parenthesis_stack_;
            List<IInputParam> plist = Parse(line, ref i);
            InputArrayParam p = new InputArrayParam(plist, named_key);
            input_params.Add(p);
            named_key = null;
            break; 
          }
          case TokenType.RightParenthesis:
          {
            --parenthesis_stack_;
            return input_params;
          }
          case TokenType.NamedKey:
          {
            named_key = token.name_;
            break;
          }
          case TokenType.Value:
          {
            InputScatteredParam p = new InputScatteredParam(token.name_, named_key);
            named_key = null;
            input_params.Add(p);
            break;
          }
        }
        token = NextToken(line, ref i);
      }

      if (parenthesis_stack_ != 0)
        throw new CommandSyntaxError(i, "parentheses is not matched");

      return input_params;
    }

    private TokenInfo NextToken(string line, ref int i)
    {
      Match m = null;
      line = line.Substring(i);

      m = parenthesis_token_.Match(line);
      if (m.Success)
      {
        // token是括号
        i += m.Length;
        string token = m.Groups[1].Value;
        TokenType tt = token == "(" ? TokenType.LeftParenthesis : TokenType.RightParenthesis;
        return new TokenInfo(tt, token);
      }

      m = namedkey_token_.Match(line);
      if (m.Success)
      {
        // token是命名参数的名称
        i += m.Length;
        return new TokenInfo(TokenType.NamedKey, m.Groups[1].Value);
      }

      m = value_token_.Match(line);
      if (m.Success)
      {
        // token是参数值
        // 跳过结尾的空格或者)
        i += m.Value.Length - m.Groups[2].Value.Length;
        string val = m.Groups[1].Value;
        // 删除""
        m = strip_quote_.Match(val);
        if (m.Success)
          val = m.Groups[1].Value;
        return new TokenInfo(TokenType.Value, val);
      }

      return null;
    }

    private int parenthesis_stack_ = 0;
    private int parse_index_ = 0;
    private List<IInputParam> input_params_;

    // 匹配开始是0个或多个空字符, 
    // 接着是括号字符
    private static Regex parenthesis_token_ = new Regex(@"^\s*([()])", RegexOptions.Compiled);
    // 匹配开始是0个或多个空字符, 
    // 接着是以变量规则命名的名称紧接着:字符,
    // 接着是0个或多个空字符
    private static Regex namedkey_token_ = new Regex(@"^\s+([\w-[0-9]]\w*):\s*", RegexOptions.Compiled);
    // 匹配开始是0个或多个空字符,
    // 接着是 以"包括起来的字符串 或 非括号非空字符的字符串且这个字符串长度不为0,
    // 接着是 一个或多个空字符或) 或 字符串结尾
    private static Regex value_token_ = new Regex(@"^\s*(""[^""]*""|[^()\s]+)([\s)]+|$)", RegexOptions.Compiled);
    // 匹配一个以"开头和"结尾的字符串
    private static Regex strip_quote_ = new Regex(@"^""(.*)""$", RegexOptions.Compiled);

    // regex描述起来还不如直接看定义 -.-
  }
}