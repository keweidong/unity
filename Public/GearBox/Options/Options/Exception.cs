using System;
using System.Text;
using System.Reflection;
using System.Collections.Generic;

namespace Options
{
  public sealed class OptionTypeError : ApplicationException
  {
    public OptionTypeError(string value, Type t, String opt_name, Exception e)
      : base(string.Format(
          "Could not convert string `{0}' to type {1} for option `{2}'.",
          value, t.FullName, opt_name), e)
    { }
  }
}