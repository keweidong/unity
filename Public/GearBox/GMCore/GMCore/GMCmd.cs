using System.Text;
using System.Collections.Generic;

namespace DashFire.GMCore
{ 
  /// <summary>
  /// GM指令的回调函数, 一个GMCmd代表了一个描述符与一组GM处理函数调用器的对应
  /// </summary>
  public class GMCmd
  {
    public GMCmd(Descriptor d)
    {
      descriptor_ = d;
    }

    public void AddGMHandler(GMCmdHandler h)
    {
      handlers_.Add(h);
    }

    internal string Invoke(Interpreter interp)
    {
      StringBuilder sb = null;
      foreach (GMCmdHandler h in handlers_)
      {
        string result = h.Invoke(interp);
        if (null != result)
        {
          if (null == sb)
            sb = new StringBuilder(4096);
          sb.Append(result).Append('\n');
        }
      }
      return null != sb ? sb.ToString() : null;
    }

    public Descriptor Descriptor { get { return descriptor_; } }
    internal List<GMCmdHandler> Handlers { get { return handlers_; } }

    private readonly Descriptor descriptor_;
    private List<GMCmdHandler> handlers_ = new List<GMCmdHandler>();
  }
}