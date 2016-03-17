﻿using System;
using System.Collections.Generic;

namespace StorySystem
{
  public interface IStoryCommandFactory
  {
    IStoryCommand Create(ScriptableData.ISyntaxComponent commandConfig);
  }
  public class StoryCommandFactoryHelper<T> : IStoryCommandFactory where T : IStoryCommand, new()
  {
    public IStoryCommand Create(ScriptableData.ISyntaxComponent commandConfig)
    {
      T t = new T();
      t.Init(commandConfig);
      return t;
    }
  }
}
