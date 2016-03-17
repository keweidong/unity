using System;
using System.Text;
using System.Reflection;
using System.Collections.Generic;

namespace DashFire.GMCore
{
  public class TypeConverterNotFound : ApplicationException
  {
    public TypeConverterNotFound(Type t)
      : base("No TypeConverter is found for Type " + t.FullName)
    { }
  }

  public class ExpectArrayType : ApplicationException
  {
    public ExpectArrayType(Type t)
      : base("Expect array type but instead we have " + t.FullName)
    { }
  }

  public class CommandSyntaxError : ApplicationException
  {
    public CommandSyntaxError(int index, string reason)
      : base(string.Format("Syntax Error At {0} : {1}", index, reason))
    { }
  }

  public class HandlerMustBeStatic : ApplicationException
  {
    public HandlerMustBeStatic()
      : base("Handler must be static function")
    { }
  }

  public class InvalidFQName : ApplicationException
  {
    public InvalidFQName(string n)
      : base("Invalid FQName: " + n)
    { }
  }

  public class IncompatibleDescriptor : ApplicationException
  {
    public IncompatibleDescriptor(Descriptor d1, Descriptor d2)
    { 
      StringBuilder sb = new StringBuilder(4096);
      sb.Append("Incompatible Descriptor, probably cause by different method declaration correspond to the same fully-qualified-name\n");
      sb.Append(d1.ToString())
        .Append('\n')
        .Append(d2.ToString());
      message_ = sb.ToString(); 
    }

    public override string Message { get { return message_; } }

    private string message_;
  }

  public class MissingParameters : ApplicationException
  {
    public MissingParameters(List<ParameterInfo> missing)
    { 
      StringBuilder sb = new StringBuilder(4096);
      sb.Append("Missing values for these parameters:\n");
      foreach (ParameterInfo pi in missing)
        sb.AppendFormat("  {0} {1}\n", pi.Name, pi.ParameterType.FullName);
      message_ = sb.ToString();
    }

    public override string Message { get { return message_; } }

    private string message_;
  }
}