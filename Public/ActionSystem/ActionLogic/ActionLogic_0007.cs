using System;
using System.Collections.Generic;
using DashFire.Debug;

namespace DashFire
{
  ///
  /// @说明
  ///   动作中可以伴随移动，移动可配置速度
  ///   但遇到静态阻挡会停止移动
  ///   
  public class ActionLogic_0007 : AbstractActionLogic
  {
    public delegate void ActionLogicEventHandler(CharacterInfo entity, ActionInfo actionInfo, int sectionNum);
    public static ActionLogicEventHandler EventActionSectionStart;
    public static ActionLogicEventHandler EventActionOver;
    public static ActionLogicEventHandler EventPlayEffect;
    public delegate void PlayBlastEventHandler(CharacterInfo entity, ScriptRuntime.Vector3 tPos);
    public static PlayBlastEventHandler EventPlayBlast;

    public ActionLogic_0007()
    {
      m_ActionLogicId = ActionLogicId.ACTION_LOGIC_ID_JUMPTOPOS;
    }

    protected override void OnTick(CharacterInfo entity, ActionInfo actionInfo)
    {
      ActionLogicData dataAction = actionInfo.ConfigData;
      if (null == dataAction) return;
		  // 移动
      ActionMoveData data = actionInfo.LogicDatas.GetData<ActionMoveData>();
      if (null != data && data.MoveTime > 0 && data.StartTime > 0) {

        int passTime = (int)(TimeUtility.GetServerMilliseconds() - data.StartTime);

        // 触发通知
        if (!actionInfo.HasCallbackAtSpecifiedTime
          && actionInfo.ConfigData.CallbackSection > 0
          && passTime > (int)(data.MoveTime * 1000)) {
          ActionAtSpecifiedTime(entity, actionInfo);
        }
        // 移动
        if (passTime <= (int)(data.MoveTime * 1000)) {
          if (1 == actionInfo.CurrentActiveSection || 2 == actionInfo.CurrentActiveSection) {
            float nowX = data.StartPos.X + data.VX * passTime / 1000.0f;
            float nowZ = data.StartPos.Z + data.VZ * passTime / 1000.0f;
            int total_time = (int)(data.MoveTime * 1000);
            int cur_elapsed_time = passTime;
            float gravity1 = float.Parse(dataAction.ExtraParams[0]);
            float v = float.Parse(dataAction.ExtraParams[1]);
            float t2 = float.Parse(dataAction.ExtraParams[2]);
            float nowY = ComputeCurrentPos(entity,
                                            actionInfo,
                                            data.StartPos,
                                            total_time,
                                            cur_elapsed_time,
                                            gravity1,
                                            v,
                                            t2);
            entity.GetMovementStateInfo().SetPosition(nowX, nowY, nowZ);
          }
        }

        if (passTime > (int)(data.MoveTime * 1000)) {
          OnSectionOver(entity, actionInfo, actionInfo.CurrentActiveSection);
          if (actionInfo.CurrentActiveSection != dataAction.SectionNumber - 1) {
              OnSectionStart(entity, actionInfo, actionInfo.CurrentActiveSection + 1);
          }
        }
      } else {
        DoSectionTick(entity, actionInfo);
      }
    }

    protected override bool OnBeforeStartAction(CharacterInfo entity, ActionInfo actionInfo)
    {
      if (null != actionInfo) {
        if (entity.GetAIEnable()) {
          entity.SetAIEnable(false);
          actionInfo.IsAiStateChange = true;
        }
        if (!entity.IsFlying) {
          entity.IsFlying = true;
          actionInfo.IsFlyStateChange = true;
        }
        ActionMoveData data = new ActionMoveData();
        actionInfo.LogicDatas.AddData<ActionMoveData>(data);
        ActionMarkData markData = new ActionMarkData();
        actionInfo.LogicDatas.AddData<ActionMarkData>(markData);
      }
      return true;
    }
    protected override void OnSectionStart(CharacterInfo entity, ActionInfo actionInfo, int sectionNum)
    {
      StartSection(entity, actionInfo, sectionNum);

      ActionLogicData dataAction = actionInfo.ConfigData;
      if (null == dataAction) return;
      if (null != EventActionSectionStart) {
        EventActionSectionStart(entity, actionInfo, sectionNum);
      }
      ActionMoveData data = actionInfo.LogicDatas.GetData<ActionMoveData>();
      if (null == data) return;
      if (dataAction.SectionList[sectionNum].MoveSpeed > 0
        && CanEntityMove(entity)) {
        ScriptRuntime.Vector3 entityPos = entity.GetMovementStateInfo().GetPosition3D();
        float moveAngle = entity.GetMovementStateInfo().GetFaceDir() + dataAction.SectionList[sectionNum].MoveTowards * (float)Math.PI / 180.0f;
        data.VX = dataAction.SectionList[sectionNum].MoveSpeed * (float)Math.Sin(moveAngle);
        data.VZ = dataAction.SectionList[sectionNum].MoveSpeed * (float)Math.Cos(moveAngle);
        data.StartTime = TimeUtility.GetServerMilliseconds();
        data.StartPos = entityPos;

        if (data.HasBlock) {
          data.MoveTime = 0;
        } else {
          data.TargetPos.X = data.StartPos.X + data.VX * dataAction.SectionList[sectionNum].PlayTime;
          data.TargetPos.Z = data.StartPos.Z + data.VZ * dataAction.SectionList[sectionNum].PlayTime;
          data.TargetPos.Y = entityPos.Y;

          SkillInfo skillInfo = entity.GetSkillStateInfo().GetCurSkillInfo();
          if (null == skillInfo) return;
          SkillParameter skillParam = skillInfo.SkillParam;
          float pointDis = (float)Math.Sqrt(Math.Pow(skillParam.TargetPos.X - entityPos.X, 2) + Math.Pow(skillParam.TargetPos.Z - entityPos.Z, 2));
          float actionDis = (float)Math.Sqrt(Math.Pow(data.TargetPos.X - entityPos.X, 2) + Math.Pow(data.TargetPos.Z - entityPos.Z, 2));

          if (actionDis > pointDis) {
            data.TargetPos.X = skillParam.TargetPos.X;
            data.TargetPos.Z = skillParam.TargetPos.Z;
          }

          // 判断轨迹过程中是否有阻挡，有则取得轨迹终点位置
          if(!entity.SpatialSystem.CanPass(data.TargetPos, 1)){
            ScriptRuntime.Vector3 hitPos;
            if (entity.SpatialSystem.RayCastForPass(data.StartPos, data.TargetPos, out hitPos)) {
              float hitDistance = (float)Math.Sqrt(Math.Pow(hitPos.X - data.StartPos.X, 2) + Math.Pow(hitPos.Z - data.StartPos.Z, 2));
              if (hitDistance < entity.GetRadius() + 0.5) {
                data.TargetPos.X = entityPos.X;
                data.TargetPos.Z = entityPos.Z;
              } else {
                float angle = (float)Math.Atan2(data.VX, data.VZ);
                data.TargetPos.X = hitPos.X - (float)(entity.GetRadius() + 0.5) * (float)Math.Sin(angle);
                data.TargetPos.Z = hitPos.Z - (float)(entity.GetRadius() + 0.5) * (float)Math.Cos(angle);
              }
              data.HasBlock = true;
            }
          }

          data.MoveTime = (data.TargetPos.X - data.StartPos.X) / data.VX;
        }
      } else {
        data.MoveTime = 0;
      }
    }

    protected override void OnSectionOver(CharacterInfo entity, ActionInfo actionInfo, int sectionNum)
    {
      ActionLogicData dataAction = actionInfo.ConfigData;
      if (null == dataAction) return;
      if(null != entity && (dataAction.SectionNumber-1) == sectionNum){
        if (null != EventActionOver) {
          EventActionOver(entity, actionInfo, sectionNum);
        }
      }
      EndSection(entity, actionInfo, sectionNum);
    }

    private float ComputeCurrentPos(CharacterInfo entity, ActionInfo actionInfo, ScriptRuntime.Vector3 pos, int total_time, int cur_elapsed_time, float g, float v, float t2)
    {
      ScriptRuntime.Vector3 _pos = pos;
      float newY = 0;

      float seconds = cur_elapsed_time / 1000.0f;
      float total_seconds = total_time / 1000.0f;
      /*
      float t3 = (g * (total_seconds - t2) * (total_seconds - t2) - g * t2 * t2) / (2 * g * t2 + 2 * v + 2 * g);
      float t1 = total_seconds - t2 - t3;
      float h = g * t1 * t1 / 2.0f;
      */
      float t3 = total_seconds / 6.0f;
      t2 = total_seconds / 4.0f;
      float t1 = total_seconds - t2 - t3;
      float h = g * t1 * t1 / 2.0f;

      if (seconds < t1 && seconds >= 0) {
        newY = h - g * (t1 - seconds) * (t1 - seconds) / 2.0f;
      } else if (seconds >= t1 && seconds <= (t1 + t2)) {
        newY = h - g * (seconds - t1) * (seconds - t1) / 2.0f;
      } else if (seconds > (t1 + t2)) {
        ActionMarkData data = actionInfo.LogicDatas.GetData<ActionMarkData>();
        if (null != data){
          if(data.m_isPlayEffect){
            data.m_isPlayEffect = false;
              if(false == data.m_isPlayAnimation){
                data.m_isPlayAnimation = true;
                StartSection(entity, actionInfo, actionInfo.ConfigData.SectionNumber - 1);
              }
            }
        }
        newY = h - ((g * t2 * t2 / 2.0f) + (g * t2 + v) * (seconds - t1 - t2) + (g * (seconds - t1 - t2) * (seconds - t1 - t2) / 2.0f));
      }
      
      _pos.Y = pos.Y + newY;
      if(_pos.Y < pos.Y){
        _pos.Y = pos.Y;
      }
      return _pos.Y;
    }
  }
}
