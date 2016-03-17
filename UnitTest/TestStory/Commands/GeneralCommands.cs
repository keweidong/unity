using System;
using System.Collections;
using System.Collections.Generic;
using StorySystem;
using DashFire;

namespace TestStory.Commands
{
  /// <summary>
  /// startstory(story_id);
  /// </summary>
  internal class StartStoryCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      StartStoryCommand cmd = new StartStoryCommand();
      cmd.m_StoryId = m_StoryId.Clone();
      return cmd;
    }

    protected override void ResetState()
    { }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_StoryId.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_StoryId.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      TestStorySystem.Instance.StartStory(m_StoryId.Value);
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 0) {
        m_StoryId.InitFromDsl(callData.GetParam(0));
      }
    }

    private IStoryValue<int> m_StoryId = new StoryValue<int>();
  }
  /// <summary>
  /// stopstory(story_id);
  /// </summary>
  internal class StopStoryCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      StopStoryCommand cmd = new StopStoryCommand();
      cmd.m_StoryId = m_StoryId.Clone();
      return cmd;
    }

    protected override void ResetState()
    { }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_StoryId.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_StoryId.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      TestStorySystem.Instance.StopStory(m_StoryId.Value);
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 0) {
        m_StoryId.InitFromDsl(callData.GetParam(0));
      }
    }

    private IStoryValue<int> m_StoryId = new StoryValue<int>();
  }
  /// <summary>
  /// firemessage(msgid,arg1,arg2,...);
  /// </summary>
  internal class FireMessageCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      FireMessageCommand cmd = new FireMessageCommand();
      cmd.m_MsgId = m_MsgId.Clone();
      foreach (IStoryValue<object> val in m_MsgArgs) {
        cmd.m_MsgArgs.Add(val.Clone());
      }
      return cmd;
    }

    protected override void ResetState()
    { }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_MsgId.Evaluate(iterator, args);
      foreach (StoryValue val in m_MsgArgs) {
        val.Evaluate(iterator, args);
      }
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_MsgId.Evaluate(instance);
      foreach (StoryValue val in m_MsgArgs) {
        val.Evaluate(instance);
      }
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      string msgId = m_MsgId.Value;
      ArrayList arglist = new ArrayList();
      foreach (StoryValue val in m_MsgArgs) {
        arglist.Add(val.Value);
      }
      object[] args = arglist.ToArray();
      TestStorySystem.Instance.SendMessage(msgId, args);
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 0) {
        m_MsgId.InitFromDsl(callData.GetParam(0));
      }
      for (int i = 1; i < callData.GetParamNum(); ++i) {
        StoryValue val = new StoryValue();
        val.InitFromDsl(callData.GetParam(i));
        m_MsgArgs.Add(val);
      }
    }

    private IStoryValue<string> m_MsgId = new StoryValue<string>();
    private List<IStoryValue<object>> m_MsgArgs = new List<IStoryValue<object>>();
  }
  /// <summary>
  /// missioncompleted(scene_id);
  /// </summary>
  internal class MissionCompletedCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      MissionCompletedCommand cmd = new MissionCompletedCommand();
      cmd.m_MainSceneId = m_MainSceneId.Clone();
      return cmd;
    }

    protected override void ResetState()
    { }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_MainSceneId.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_MainSceneId.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      LogSystem.Info("missioncompleted, goto {0}", m_MainSceneId.Value);
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 0) {
        m_MainSceneId.InitFromDsl(callData.GetParam(0));
      }
    }

    private IStoryValue<int> m_MainSceneId = new StoryValue<int>();
  }
  /// <summary>
  /// changescene(scene_id);
  /// </summary>
  internal class ChangeSceneCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      ChangeSceneCommand cmd = new ChangeSceneCommand();
      cmd.m_MainSceneId = m_MainSceneId.Clone();
      return cmd;
    }

    protected override void ResetState()
    { }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_MainSceneId.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_MainSceneId.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      LogSystem.Info("changescene, goto {0}", m_MainSceneId.Value);
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 0) {
        m_MainSceneId.InitFromDsl(callData.GetParam(0));
      }
    }

    private IStoryValue<int> m_MainSceneId = new StoryValue<int>();
  }
  /// <summary>
  /// updatecoefficient();
  /// </summary>
  internal class UpdateCoefficientCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      UpdateCoefficientCommand cmd = new UpdateCoefficientCommand();
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
      LogSystem.Info("updatecoefficient");
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
    }
  }
  /// <summary>
  /// pausescenelogic(scene_logic_config_id,true_or_false);
  /// </summary>
  internal class PauseSceneLogicCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      PauseSceneLogicCommand cmd = new PauseSceneLogicCommand();
      cmd.m_SceneLogicConfigId = m_SceneLogicConfigId.Clone();
      cmd.m_Enabled = m_Enabled.Clone();
      return cmd;
    }

    protected override void ResetState()
    { }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_SceneLogicConfigId.Evaluate(iterator, args);
      m_Enabled.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_SceneLogicConfigId.Evaluate(instance);
      m_Enabled.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      int cfgId = m_SceneLogicConfigId.Value;
      string enabled = m_Enabled.Value;

      LogSystem.Info("pausescenelogic {0} {1}", cfgId, enabled);
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 1) {
        m_SceneLogicConfigId.InitFromDsl(callData.GetParam(0));
        m_Enabled.InitFromDsl(callData.GetParam(1));
      }
    }

    private IStoryValue<int> m_SceneLogicConfigId = new StoryValue<int>();
    private IStoryValue<string> m_Enabled = new StoryValue<string>();
  }
  /// <summary>
  /// restartareamonitor(scene_logic_id);
  /// </summary>
  internal class RestartAreaMonitorCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      RestartAreaMonitorCommand cmd = new RestartAreaMonitorCommand();
      cmd.m_SceneLogicId = m_SceneLogicId.Clone();
      return cmd;
    }

    protected override void ResetState()
    { }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_SceneLogicId.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_SceneLogicId.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      LogSystem.Info("restartareamonitor {0}", m_SceneLogicId.Value);
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 0) {
        m_SceneLogicId.InitFromDsl(callData.GetParam(0));
      }
    }

    private IStoryValue<int> m_SceneLogicId = new StoryValue<int>();
  }
  /// <summary>
  /// restarttimeout(scene_logic_config_id[,timeout]);
  /// </summary>
  internal class RestartTimeoutCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      RestartTimeoutCommand cmd = new RestartTimeoutCommand();
      cmd.m_ParamNum = m_ParamNum;
      cmd.m_SceneLogicConfigId = m_SceneLogicConfigId.Clone();
      cmd.m_Timeout = m_Timeout.Clone();
      return cmd;
    }

    protected override void ResetState()
    {
    }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_SceneLogicConfigId.Evaluate(iterator, args);
      if (m_ParamNum > 1)
        m_Timeout.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_SceneLogicConfigId.Evaluate(instance);
      if (m_ParamNum > 1)
        m_Timeout.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      int cfgId = m_SceneLogicConfigId.Value;
      if (m_ParamNum == 1)
        LogSystem.Info("restarttimeout:{0}", cfgId);
      else
        LogSystem.Info("restarttimeout:{0} {1}", cfgId, m_Timeout.Value);
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      m_ParamNum = callData.GetParamNum();
      if (m_ParamNum > 0) {
        m_SceneLogicConfigId.InitFromDsl(callData.GetParam(0));
      }
      if (m_ParamNum > 1) {
        m_Timeout.InitFromDsl(callData.GetParam(1));
      }
    }

    private int m_ParamNum = 0;
    private IStoryValue<int> m_SceneLogicConfigId = new StoryValue<int>();
    private IStoryValue<int> m_Timeout = new StoryValue<int>();
  }
  /// <summary>
  /// restartareadetect(scene_logic_config_id[,timeout]);
  /// </summary>
  internal class RestartAreaDetectCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      RestartAreaDetectCommand cmd = new RestartAreaDetectCommand();
      cmd.m_ParamNum = m_ParamNum;
      cmd.m_SceneLogicConfigId = m_SceneLogicConfigId.Clone();
      cmd.m_Timeout = m_Timeout.Clone();
      return cmd;
    }

    protected override void ResetState()
    {
    }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_SceneLogicConfigId.Evaluate(iterator, args);
      if (m_ParamNum > 1)
        m_Timeout.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_SceneLogicConfigId.Evaluate(instance);
      if (m_ParamNum > 1)
        m_Timeout.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      int cfgId = m_SceneLogicConfigId.Value;
      if (m_ParamNum == 1)
        LogSystem.Info("restartareadetect:{0}", cfgId);
      else
        LogSystem.Info("restartareadetect:{0} {1}", cfgId, m_Timeout.Value);
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      m_ParamNum = callData.GetParamNum();
      if (m_ParamNum > 0) {
        m_SceneLogicConfigId.InitFromDsl(callData.GetParam(0));
      }
      if (m_ParamNum > 1) {
        m_Timeout.InitFromDsl(callData.GetParam(1));
      }
    }

    private int m_ParamNum = 0;
    private IStoryValue<int> m_SceneLogicConfigId = new StoryValue<int>();
    private IStoryValue<int> m_Timeout = new StoryValue<int>();
  }
}
