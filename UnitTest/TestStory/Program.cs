using System;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using StorySystem;
using DashFire;

namespace TestStory
{
  class Program
  {
    static void Main(string[] args)
    {
      FileReaderProxy.RegisterReadFileHandler((string path) => {
        return File.ReadAllBytes(path);
      });
      LogSystem.OnOutput = (Log_Type type, string msg) => {
        Console.WriteLine(msg);
      };
      HomePath.InitHomePath();
      SceneConfigProvider.Instance.Load(FilePathDefine_Server.C_SceneConfig, "ScenesConfigs");
      SceneConfigProvider.Instance.LoadAllSceneConfig(FilePathDefine_Server.C_RootPath);

      TestStorySystem.Instance.Init();
      StoryConfigManager.Instance.Clear();
      TestStorySystem.Instance.ClearStoryInstancePool();
      TestStorySystem.Instance.PreloadStoryInstance(1);
      TestStorySystem.Instance.StartStory(1);

      while(TestStorySystem.Instance.ActiveStoryCount>0) {
        TestStorySystem.Instance.Tick();
        Thread.Sleep(10);
      }
      Console.WriteLine("Exit...");
      Thread.Sleep(1000);
    }
  }
}
