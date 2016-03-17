using System;

namespace DashFire.GMCore
{
  [GMCmd]
  internal static partial class InternalCmds
  { 
    [GMCmdHandler("hello world.")]
    public static void hello_world(
        [GMCmdArgument("p1 description.")]int p1,
        [GMCmdArgument("p2 description.")]string[] p2,
        [GMCmdArgument("p3 description, a very very very very " + 
                       "very very very very very very very very " + 
                       "very very very very very very very very " + 
                       "very very very very very very very very " + 
                       "very very very very very very very very " + 
                       "long text")]float p3 = 3.3f)
    {
      //Console.WriteLine("p1: {0}", p1);
      //Console.WriteLine("p2: {0}", string.Join(", ", p2));
      //Console.WriteLine("p3: {0}", p3);
    }
  
  }
}