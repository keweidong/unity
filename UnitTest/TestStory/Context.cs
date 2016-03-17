using System;
using System.Collections.Generic;
using System.Text;

namespace TestStory
{
  public sealed class Context
  {
    public int GetCurSceneId()
    {
      return 4021;
    }
    public static Context Instance
    {
      get
      {
        return s_Instance;
      }
    }
    private static Context s_Instance = new Context();
  }
}
