using System;
using System.Collections.Generic;
using StorySystem;
using ScriptRuntime;
using DashFire;

namespace TestStory.Commands
{
  /// <summary>
  /// playerselfface(dir);
  /// </summary>
  internal class PlayerselfFaceCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      PlayerselfFaceCommand cmd = new PlayerselfFaceCommand();
      cmd.m_Dir = m_Dir.Clone();
      return cmd;
    }

    protected override void ResetState()
    {
    }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_Dir.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_Dir.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      float dir = m_Dir.Value;
      LogSystem.Info("playerselfface:{0}", dir);
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 0) {
        m_Dir.InitFromDsl(callData.GetParam(0));
      }
    }

    private IStoryValue<float> m_Dir = new StoryValue<float>();
  }
  /// <summary>
  /// playerselfmove(vector3(x,y,z));
  /// </summary>
  internal class PlayerselfMoveCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      PlayerselfMoveCommand cmd = new PlayerselfMoveCommand();
      cmd.m_Pos = m_Pos.Clone();
      return cmd;
    }

    protected override void ResetState()
    {
    }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_Pos.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_Pos.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      Vector3 pos = m_Pos.Value;
      LogSystem.Info("playerselfmove:{0} {1} {2}", pos.X, pos.Y, pos.Z);
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 0) {
        m_Pos.InitFromDsl(callData.GetParam(0));
      }
    }

    private IStoryValue<Vector3> m_Pos = new StoryValue<Vector3>();
  }
  /// <summary>
  /// playerselfmovewithwaypoints(vector2list("1 2 3 4 5 6 7"));
  /// </summary>
  internal class PlayerselfMoveWithWaypointsCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      PlayerselfMoveWithWaypointsCommand cmd = new PlayerselfMoveWithWaypointsCommand();
      cmd.m_WayPoints = m_WayPoints.Clone();
      return cmd;
    }

    protected override void ResetState()
    {
    }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_WayPoints.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_WayPoints.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      List<object> poses = m_WayPoints.Value;
      LogSystem.Info("playerselfmovewithwaypoints:{0} points", poses.Count);
      foreach (Vector2 pt in poses) {
        LogSystem.Info("=>({0},{1})", pt.X, pt.Y);
      }
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 0) {
        m_WayPoints.InitFromDsl(callData.GetParam(0));
      }
    }

    private IStoryValue<List<object>> m_WayPoints = new StoryValue<List<object>>();
  }
  /// <summary>
  /// playerselfpursuit(target_obj_id);
  /// </summary>
  internal class PlayerselfPursuitCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      PlayerselfPursuitCommand cmd = new PlayerselfPursuitCommand();
      cmd.m_TargetId = m_TargetId.Clone();
      return cmd;
    }

    protected override void ResetState()
    {
    }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_TargetId.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_TargetId.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      int targetId = m_TargetId.Value;
      LogSystem.Info("playerselfpursuit:{0}", targetId);
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 0) {
        m_TargetId.InitFromDsl(callData.GetParam(0));
      }
    }

    private IStoryValue<int> m_TargetId = new StoryValue<int>();
  }
  /// <summary>
  /// playerselfstop();
  /// </summary>
  internal class PlayerselfStopCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      PlayerselfStopCommand cmd = new PlayerselfStopCommand();
      return cmd;
    }

    protected override void ResetState()
    {
    }

    protected override void UpdateArguments(object iterator, object[] args)
    {
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      LogSystem.Info("playerselfstop");
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 0) {
      }
    }
  }
  /// <summary>
  /// playerselflisten(消息类别, true_or_false);
  /// </summary>
  internal class PlayerselfListenCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      PlayerselfListenCommand cmd = new PlayerselfListenCommand();
      cmd.m_Event = m_Event.Clone();
      cmd.m_Enable = m_Enable.Clone();
      return cmd;
    }

    protected override void ResetState()
    {
    }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_Event.Evaluate(iterator, args);
      m_Enable.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_Event.Evaluate(instance);
      m_Enable.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      string eventName = m_Event.Value;
      string enable = m_Enable.Value;
      LogSystem.Info("playerselflisten:{0} {1}", eventName, enable);
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 1) {
        m_Event.InitFromDsl(callData.GetParam(0));
        m_Enable.InitFromDsl(callData.GetParam(1));
      }
    }

    private IStoryValue<string> m_Event = new StoryValue<string>();
    private IStoryValue<string> m_Enable = new StoryValue<string>();
  }
}
