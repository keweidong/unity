using System;
using System.Collections;
using System.Collections.Generic;
using StorySystem;
using ScriptRuntime;
using DashFire;

namespace TestStory.Commands
{
  /// <summary>
  /// objface(obj_id, dir);
  /// </summary>
  internal class ObjFaceCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      ObjFaceCommand cmd = new ObjFaceCommand();
      cmd.m_ObjId = m_ObjId.Clone();
      cmd.m_Dir = m_Dir.Clone();
      return cmd;
    }

    protected override void ResetState()
    {
    }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_ObjId.Evaluate(iterator, args);
      m_Dir.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_ObjId.Evaluate(instance);
      m_Dir.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      int objId = m_ObjId.Value;
      float dir = m_Dir.Value;
      LogSystem.Info("playerselfface:{0} {1}", objId, dir);
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 1) {
        m_ObjId.InitFromDsl(callData.GetParam(0));
        m_Dir.InitFromDsl(callData.GetParam(1));
      }
    }

    private IStoryValue<int> m_ObjId = new StoryValue<int>();
    private IStoryValue<float> m_Dir = new StoryValue<float>();
  }
  /// <summary>
  /// objmove(obj_id, vector3(x,y,z));
  /// </summary>
  internal class ObjMoveCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      ObjMoveCommand cmd = new ObjMoveCommand();
      cmd.m_ObjId = m_ObjId.Clone();
      cmd.m_Pos = m_Pos.Clone();
      return cmd;
    }

    protected override void ResetState()
    {
    }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_ObjId.Evaluate(iterator, args);
      m_Pos.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_ObjId.Evaluate(instance);
      m_Pos.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      int objId = m_ObjId.Value;
      Vector3 pos = m_Pos.Value;
      LogSystem.Info("objmove:{0} ({1} {2} {3})", objId, pos.X, pos.Y, pos.Z);
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 0) {
        m_ObjId.InitFromDsl(callData.GetParam(0));
        m_Pos.InitFromDsl(callData.GetParam(1));
      }
    }

    private IStoryValue<int> m_ObjId = new StoryValue<int>();
    private IStoryValue<Vector3> m_Pos = new StoryValue<Vector3>();
  }
  /// <summary>
  /// objmovewithwaypoints(obj_id, vector2list("1 2 3 4 5 6 7"));
  /// </summary>
  internal class ObjMoveWithWaypointsCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      ObjMoveWithWaypointsCommand cmd = new ObjMoveWithWaypointsCommand();
      cmd.m_ObjId = m_ObjId.Clone();
      cmd.m_WayPoints = m_WayPoints.Clone();
      return cmd;
    }

    protected override void ResetState()
    {
    }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_ObjId.Evaluate(iterator, args);
      m_WayPoints.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_ObjId.Evaluate(instance);
      m_WayPoints.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      int objId = m_ObjId.Value;
      List<object> poses = m_WayPoints.Value;
      LogSystem.Info("objmovewithwaypoints:{0} {1} points", objId, poses.Count);
      foreach (Vector2 pt in poses) {
        LogSystem.Info("=>({0},{1})", pt.X, pt.Y);
      }
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 0) {
        m_ObjId.InitFromDsl(callData.GetParam(0));
        m_WayPoints.InitFromDsl(callData.GetParam(1));
      }
    }

    private IStoryValue<int> m_ObjId = new StoryValue<int>();
    private IStoryValue<List<object>> m_WayPoints = new StoryValue<List<object>>();
  }
  /// <summary>
  /// objstop(obj_id);
  /// </summary>
  internal class ObjStopCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      ObjStopCommand cmd = new ObjStopCommand();
      cmd.m_ObjId = m_ObjId.Clone();
      return cmd;
    }

    protected override void ResetState()
    {
    }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_ObjId.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_ObjId.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      int objId = m_ObjId.Value;
      LogSystem.Info("objstop:{0}", objId);
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 0) {
        m_ObjId.InitFromDsl(callData.GetParam(0));
      }
    }

    private IStoryValue<int> m_ObjId = new StoryValue<int>();
  }
  /// <summary>
  /// objanimation(obj_id, anim_type[, anim_time=2000[, isqueued]]);
  /// </summary>
  internal class ObjAnimationCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      ObjAnimationCommand cmd = new ObjAnimationCommand();
      cmd.m_ObjId = m_ObjId.Clone();
      cmd.m_AnimType = m_AnimType.Clone();
      cmd.m_AnimTime = m_AnimTime.Clone();
      cmd.m_IsQueued = m_IsQueued.Clone();
      cmd.m_ParamNum = m_ParamNum;
      return cmd;
    }

    protected override void ResetState()
    {
    }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_ObjId.Evaluate(iterator, args);
      m_AnimType.Evaluate(iterator, args);
      if (m_ParamNum > 2)
        m_AnimTime.Evaluate(iterator, args);
      if (m_ParamNum > 3)
        m_IsQueued.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_ObjId.Evaluate(instance);
      m_AnimType.Evaluate(instance);
      if (m_ParamNum > 2)
        m_AnimTime.Evaluate(instance);
      if (m_ParamNum > 3)
        m_IsQueued.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      int objId = m_ObjId.Value;
      int animType = m_AnimType.Value;
      int animTime = 2000;
      bool isQueued = false;
      if (m_ParamNum > 2) {
        animTime = m_AnimTime.Value;
      }
      if (m_ParamNum > 3) {
        isQueued = (0 == m_IsQueued.Value.CompareTo("isqueued"));
      }
      LogSystem.Info("objanimation:{0} {1} {2} {3}", objId, animType, animTime, isQueued);
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 1) {
        m_ObjId.InitFromDsl(callData.GetParam(0));
        m_AnimType.InitFromDsl(callData.GetParam(1));
      }
      if (num > 2) {
        m_AnimTime.InitFromDsl(callData.GetParam(2));
      }
      if (num > 3) {
        m_IsQueued.InitFromDsl(callData.GetParam(3));
      }
      m_ParamNum = num;
    }

    private int m_ParamNum = 0;
    private IStoryValue<int> m_ObjId = new StoryValue<int>();
    private IStoryValue<int> m_AnimType = new StoryValue<int>();
    private IStoryValue<int> m_AnimTime = new StoryValue<int>();
    private IStoryValue<string> m_IsQueued = new StoryValue<string>();
  }
  /// <summary>
  /// objpursuit(obj_id, target_obj_id);
  /// </summary>
  internal class ObjPursuitCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      ObjPursuitCommand cmd = new ObjPursuitCommand();
      cmd.m_ObjId = m_ObjId.Clone();
      cmd.m_TargetId = m_TargetId.Clone();
      return cmd;
    }

    protected override void ResetState()
    {
    }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_ObjId.Evaluate(iterator, args);
      m_TargetId.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_ObjId.Evaluate(instance);
      m_TargetId.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      int objId = m_ObjId.Value;
      int targetId = m_TargetId.Value;
      LogSystem.Info("objpursuit:{0} {1}", objId, targetId);
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 1) {
        m_ObjId.InitFromDsl(callData.GetParam(0));
        m_TargetId.InitFromDsl(callData.GetParam(1));
      }
    }

    private IStoryValue<int> m_ObjId = new StoryValue<int>();
    private IStoryValue<int> m_TargetId = new StoryValue<int>();
  }
  /// <summary>
  /// objenableai(obj_id, true_or_false);
  /// </summary>
  internal class ObjEnableAiCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      ObjEnableAiCommand cmd = new ObjEnableAiCommand();
      cmd.m_ObjId = m_ObjId.Clone();
      cmd.m_Enable = m_Enable.Clone();
      return cmd;
    }

    protected override void ResetState()
    {
    }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_ObjId.Evaluate(iterator, args);
      m_Enable.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_ObjId.Evaluate(instance);
      m_Enable.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      int objId = m_ObjId.Value;
      string enable = m_Enable.Value;
      LogSystem.Info("objenableai:{0} {1}", objId, enable);
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 1) {
        m_ObjId.InitFromDsl(callData.GetParam(0));
        m_Enable.InitFromDsl(callData.GetParam(1));
      }
    }

    private IStoryValue<int> m_ObjId = new StoryValue<int>();
    private IStoryValue<string> m_Enable = new StoryValue<string>();
  }
  /// <summary>
  /// objsetai(objid,ai_logic_id,stringlist("param1 param2 param3 ..."));
  /// </summary>
  internal class ObjSetAiCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      ObjSetAiCommand cmd = new ObjSetAiCommand();
      cmd.m_ObjId = m_ObjId.Clone();
      cmd.m_AiLogic = m_AiLogic.Clone();
      cmd.m_AiParams = m_AiParams.Clone();
      return cmd;
    }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_ObjId.Evaluate(iterator, args);
      m_AiLogic.Evaluate(iterator, args);
      m_AiParams.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_ObjId.Evaluate(instance);
      m_AiLogic.Evaluate(instance);
      m_AiParams.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      int objId = m_ObjId.Value;
      int aiLogic = m_AiLogic.Value;
      IEnumerable aiParams = m_AiParams.Value;
      LogSystem.Info("objsetai:{0} {1}", objId, aiLogic);
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 2) {
        m_ObjId.InitFromDsl(callData.GetParam(0));
        m_AiLogic.InitFromDsl(callData.GetParam(1));
        m_AiParams.InitFromDsl(callData.GetParam(2));
      }
    }

    private IStoryValue<int> m_ObjId = new StoryValue<int>();
    private IStoryValue<int> m_AiLogic = new StoryValue<int>();
    private IStoryValue<IEnumerable> m_AiParams = new StoryValue<IEnumerable>();
  }
  /// <summary>
  /// objaddimpact(obj_id, impactid);
  /// </summary>
  internal class ObjAddImpactCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      ObjAddImpactCommand cmd = new ObjAddImpactCommand();
      cmd.m_ObjId = m_ObjId.Clone();
      cmd.m_ImpactId = m_ImpactId.Clone();
      return cmd;
    }

    protected override void ResetState()
    {
    }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_ObjId.Evaluate(iterator, args);
      m_ImpactId.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_ObjId.Evaluate(instance);
      m_ImpactId.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      int objId = m_ObjId.Value;
      int impactId = m_ImpactId.Value;
      LogSystem.Info("objaddimpact:{0} {1}", objId, impactId);
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 1) {
        m_ObjId.InitFromDsl(callData.GetParam(0));
        m_ImpactId.InitFromDsl(callData.GetParam(1));
      }
    }

    private IStoryValue<int> m_ObjId = new StoryValue<int>();
    private IStoryValue<int> m_ImpactId = new StoryValue<int>();
  }
  /// <summary>
  /// objremoveimpact(obj_id, impactid);
  /// </summary>
  internal class ObjRemoveImpactCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      ObjRemoveImpactCommand cmd = new ObjRemoveImpactCommand();
      cmd.m_ObjId = m_ObjId.Clone();
      cmd.m_ImpactId = m_ImpactId.Clone();
      return cmd;
    }

    protected override void ResetState()
    {
    }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_ObjId.Evaluate(iterator, args);
      m_ImpactId.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_ObjId.Evaluate(instance);
      m_ImpactId.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      int objId = m_ObjId.Value;
      int impactId = m_ImpactId.Value;
      LogSystem.Info("objremoveimpact:{0} {1}", objId, impactId);
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 1) {
        m_ObjId.InitFromDsl(callData.GetParam(0));
        m_ImpactId.InitFromDsl(callData.GetParam(1));
      }
    }

    private IStoryValue<int> m_ObjId = new StoryValue<int>();
    private IStoryValue<int> m_ImpactId = new StoryValue<int>();
  }
  /// <summary>
  /// objcastskill(obj_id, skillid);
  /// </summary>
  internal class ObjCastSkillCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      ObjCastSkillCommand cmd = new ObjCastSkillCommand();
      cmd.m_ObjId = m_ObjId.Clone();
      cmd.m_SkillId = m_SkillId.Clone();
      return cmd;
    }

    protected override void ResetState()
    {
    }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_ObjId.Evaluate(iterator, args);
      m_SkillId.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_ObjId.Evaluate(instance);
      m_SkillId.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      int objId = m_ObjId.Value;
      int skillId = m_SkillId.Value;
      LogSystem.Info("objcastskill:{0} {1}", objId, skillId);
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 1) {
        m_ObjId.InitFromDsl(callData.GetParam(0));
        m_SkillId.InitFromDsl(callData.GetParam(1));
      }
    }

    private IStoryValue<int> m_ObjId = new StoryValue<int>();
    private IStoryValue<int> m_SkillId = new StoryValue<int>();
  }
  /// <summary>
  /// objstopskill(obj_id);
  /// </summary>
  internal class ObjStopSkillCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      ObjStopSkillCommand cmd = new ObjStopSkillCommand();
      cmd.m_ObjId = m_ObjId.Clone();
      return cmd;
    }

    protected override void ResetState()
    {
    }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_ObjId.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_ObjId.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      int objId = m_ObjId.Value;
      LogSystem.Info("objstopskill:{0}", objId);
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 0) {
        m_ObjId.InitFromDsl(callData.GetParam(0));
      }
    }

    private IStoryValue<int> m_ObjId = new StoryValue<int>();
    private IStoryValue<int> m_SkillId = new StoryValue<int>();
  }
  /// <summary>
  /// objaddskill(obj_id, skillid);
  /// </summary>
  internal class ObjAddSkillCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      ObjAddSkillCommand cmd = new ObjAddSkillCommand();
      cmd.m_ObjId = m_ObjId.Clone();
      cmd.m_SkillId = m_SkillId.Clone();
      return cmd;
    }

    protected override void ResetState()
    {
    }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_ObjId.Evaluate(iterator, args);
      m_SkillId.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_ObjId.Evaluate(instance);
      m_SkillId.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      int objId = m_ObjId.Value;
      int skillId = m_SkillId.Value;
      LogSystem.Info("objaddskill:{0} {1}", objId, skillId);
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 1) {
        m_ObjId.InitFromDsl(callData.GetParam(0));
        m_SkillId.InitFromDsl(callData.GetParam(1));
      }
    }

    private IStoryValue<int> m_ObjId = new StoryValue<int>();
    private IStoryValue<int> m_SkillId = new StoryValue<int>();
  }
  /// <summary>
  /// objremoveskill(obj_id, skillid);
  /// </summary>
  internal class ObjRemoveSkillCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      ObjRemoveSkillCommand cmd = new ObjRemoveSkillCommand();
      cmd.m_ObjId = m_ObjId.Clone();
      cmd.m_SkillId = m_SkillId.Clone();
      return cmd;
    }

    protected override void ResetState()
    {
    }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_ObjId.Evaluate(iterator, args);
      m_SkillId.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_ObjId.Evaluate(instance);
      m_SkillId.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      int objId = m_ObjId.Value;
      int skillId = m_SkillId.Value;
      LogSystem.Info("objremoveskill:{0} {1}", objId, skillId);
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 1) {
        m_ObjId.InitFromDsl(callData.GetParam(0));
        m_SkillId.InitFromDsl(callData.GetParam(1));
      }
    }

    private IStoryValue<int> m_ObjId = new StoryValue<int>();
    private IStoryValue<int> m_SkillId = new StoryValue<int>();
  }
  /// <summary>
  /// objlisten(unit_id, 消息类别, true_or_false);
  /// </summary>
  internal class ObjListenCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      ObjListenCommand cmd = new ObjListenCommand();
      cmd.m_ObjId = m_ObjId.Clone();
      cmd.m_Event = m_Event.Clone();
      cmd.m_Enable = m_Enable.Clone();
      return cmd;
    }

    protected override void ResetState()
    {
    }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_ObjId.Evaluate(iterator, args);
      m_Event.Evaluate(iterator, args);
      m_Enable.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_ObjId.Evaluate(instance);
      m_Event.Evaluate(instance);
      m_Enable.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      int objId = m_ObjId.Value;
      string eventName = m_Event.Value;
      string enable = m_Enable.Value;
      LogSystem.Info("objlisten:{0} {1} {2}", objId, eventName, enable);
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 2) {
        m_ObjId.InitFromDsl(callData.GetParam(0));
        m_Event.InitFromDsl(callData.GetParam(1));
        m_Enable.InitFromDsl(callData.GetParam(2));
      }
    }

    private IStoryValue<int> m_ObjId = new StoryValue<int>();
    private IStoryValue<string> m_Event = new StoryValue<string>();
    private IStoryValue<string> m_Enable = new StoryValue<string>();
  }
  /// <summary>
  /// setblockedshader(rimcolor1,rimpower1,rimcutvalue1,rimcolor2,rimpower2,rimcutvalue2);
  /// </summary>
  internal class SetBlockedShaderCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      SetBlockedShaderCommand cmd = new SetBlockedShaderCommand();
      cmd.m_RimColor1 = m_RimColor1.Clone();
      cmd.m_RimPower1 = m_RimPower1.Clone();
      cmd.m_RimCutValue1 = m_RimCutValue1.Clone();
      cmd.m_RimColor2 = m_RimColor2.Clone();
      cmd.m_RimPower2 = m_RimPower2.Clone();
      cmd.m_RimCutValue2 = m_RimCutValue2.Clone();
      return cmd;
    }

    protected override void ResetState()
    {
    }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_RimColor1.Evaluate(iterator, args);
      m_RimPower1.Evaluate(iterator, args);
      m_RimCutValue1.Evaluate(iterator, args);
      m_RimColor2.Evaluate(iterator, args);
      m_RimPower2.Evaluate(iterator, args);
      m_RimCutValue2.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_RimColor1.Evaluate(instance);
      m_RimPower1.Evaluate(instance);
      m_RimCutValue1.Evaluate(instance);
      m_RimColor2.Evaluate(instance);
      m_RimPower2.Evaluate(instance);
      m_RimCutValue2.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      uint rimColor1 = m_RimColor1.Value;
      float rimPower1 = m_RimPower1.Value;
      float rimCutValue1 = m_RimCutValue1.Value;
      uint rimColor2 = m_RimColor2.Value;
      float rimPower2 = m_RimPower2.Value;
      float rimCutValue2 = m_RimCutValue2.Value;
      LogSystem.Info("setblockedshader:{0} {1} {2} {3} {4} {5}", rimColor1, rimPower1, rimCutValue1, rimColor2, rimPower2, rimCutValue2);
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 5) {
        m_RimColor1.InitFromDsl(callData.GetParam(0));
        m_RimPower1.InitFromDsl(callData.GetParam(1));
        m_RimCutValue1.InitFromDsl(callData.GetParam(2));
        m_RimColor2.InitFromDsl(callData.GetParam(3));
        m_RimPower2.InitFromDsl(callData.GetParam(4));
        m_RimCutValue2.InitFromDsl(callData.GetParam(5));
      }
    }

    private IStoryValue<uint> m_RimColor1 = new StoryValue<uint>();
    private IStoryValue<float> m_RimPower1 = new StoryValue<float>();
    private IStoryValue<float> m_RimCutValue1 = new StoryValue<float>();
    private IStoryValue<uint> m_RimColor2 = new StoryValue<uint>();
    private IStoryValue<float> m_RimPower2 = new StoryValue<float>();
    private IStoryValue<float> m_RimCutValue2 = new StoryValue<float>();
  }
  /// <summary>
  /// sethp(objid,value);
  /// </summary>
  internal class SetHpCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      SetHpCommand cmd = new SetHpCommand();
      cmd.m_ObjId = m_ObjId.Clone();
      cmd.m_Value = m_Value.Clone();
      return cmd;
    }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_ObjId.Evaluate(iterator, args);
      m_Value.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_ObjId.Evaluate(instance);
      m_Value.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      int objId = m_ObjId.Value;
      int value = m_Value.Value;
      LogSystem.Info("sethp {0} {1}", objId, value);
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 1) {
        m_ObjId.InitFromDsl(callData.GetParam(0));
        m_Value.InitFromDsl(callData.GetParam(1));
      }
    }

    private IStoryValue<int> m_ObjId = new StoryValue<int>();
    private IStoryValue<int> m_Value = new StoryValue<int>();
  }
  /// <summary>
  /// setenergy(objid,value);
  /// </summary>
  internal class SetEnergyCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      SetEnergyCommand cmd = new SetEnergyCommand();
      cmd.m_ObjId = m_ObjId.Clone();
      cmd.m_Value = m_Value.Clone();
      return cmd;
    }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_ObjId.Evaluate(iterator, args);
      m_Value.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_ObjId.Evaluate(instance);
      m_Value.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      int objId = m_ObjId.Value;
      int value = m_Value.Value;
      LogSystem.Info("setenergy {0} {1}", objId, value);
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 1) {
        m_ObjId.InitFromDsl(callData.GetParam(0));
        m_Value.InitFromDsl(callData.GetParam(1));
      }
    }

    private IStoryValue<int> m_ObjId = new StoryValue<int>();
    private IStoryValue<int> m_Value = new StoryValue<int>();
  }
  /// <summary>
  /// setrage(objid,value);
  /// </summary>
  internal class SetRageCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      SetRageCommand cmd = new SetRageCommand();
      cmd.m_ObjId = m_ObjId.Clone();
      cmd.m_Value = m_Value.Clone();
      return cmd;
    }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_ObjId.Evaluate(iterator, args);
      m_Value.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_ObjId.Evaluate(instance);
      m_Value.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      int objId = m_ObjId.Value;
      int value = m_Value.Value;
      LogSystem.Info("setrage {0} {1}", objId, value);
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 1) {
        m_ObjId.InitFromDsl(callData.GetParam(0));
        m_Value.InitFromDsl(callData.GetParam(1));
      }
    }

    private IStoryValue<int> m_ObjId = new StoryValue<int>();
    private IStoryValue<int> m_Value = new StoryValue<int>();
  }
  /// <summary>
  /// objset(objid,localname,value);
  /// </summary>
  internal class ObjSetCommand : AbstractStoryCommand
  {
    public override IStoryCommand Clone()
    {
      ObjSetCommand cmd = new ObjSetCommand();
      cmd.m_ObjId = m_ObjId.Clone();
      cmd.m_LocalName = m_LocalName.Clone();
      cmd.m_Value = m_Value.Clone();
      return cmd;
    }

    protected override void UpdateArguments(object iterator, object[] args)
    {
      m_ObjId.Evaluate(iterator, args);
      m_LocalName.Evaluate(iterator, args);
      m_Value.Evaluate(iterator, args);
    }

    protected override void UpdateVariables(StoryInstance instance)
    {
      m_ObjId.Evaluate(instance);
      m_LocalName.Evaluate(instance);
      m_Value.Evaluate(instance);
    }

    protected override bool ExecCommand(StoryInstance instance, long delta)
    {
      int objId = m_ObjId.Value;
      string localName = m_LocalName.Value;
      object value = m_Value.Value;
      LogSystem.Info("objset {0} {1} {2}", objId, localName, value);
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num > 2) {
        m_ObjId.InitFromDsl(callData.GetParam(0));
        m_LocalName.InitFromDsl(callData.GetParam(1));
        m_Value.InitFromDsl(callData.GetParam(2));
      }
    }

    private IStoryValue<int> m_ObjId = new StoryValue<int>();
    private IStoryValue<string> m_LocalName = new StoryValue<string>();
    private IStoryValue<object> m_Value = new StoryValue();
  }
}
