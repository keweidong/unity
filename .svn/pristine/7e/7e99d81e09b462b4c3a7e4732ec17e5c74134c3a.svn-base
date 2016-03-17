using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DashFire.GMCore;

namespace GMCoreTest
{
  class Program
  {
    static void Shell()
    {
      while (true)
      {
        Console.Write("llisper's GM shell $ ");
        string input = Console.ReadLine();
        if (input == "quit")
          break;

        try
        {
          Console.WriteLine(GMCore.Instance.Execute(input));
        }
        catch (Exception e)
        {
          string exception = e.ToString();
          foreach (string str in exception.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
            Console.WriteLine(str);
        }
      }
    }
    static void Main(string[] args)
    {
      GMCore.Instance.Initiate(Assembly.GetExecutingAssembly());
      Shell();
      
    }
  }
}
