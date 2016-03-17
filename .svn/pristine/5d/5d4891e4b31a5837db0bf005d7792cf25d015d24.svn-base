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
  ///
  public class ActionLogic_0002 : AbstractActionLogic
  {
    public delegate void ActionLogicEventHandler(CharacterInfo entity, ActionInfo actionInfo, int sectionNum);
    public static ActionLogicEventHandler EventActionSectionStart;
    public static ActionLogicEventHandler EventActionOver;

    //private static Int64 tickstarttime = 0;

    public ActionLogic_0002()
    {
      m_ActionLogicId = ActionLogicId.ACTION_LOGIC_ID_MOVETOPOS;
    }

    protected override void OnTick(CharacterInfo entity, ActionInfo actionInfo)
    {
      ActionMoveData data = actionInfo.LogicDatas.GetData<ActionMoveData>();
      if (null != data && data.StartTime > 0) {
        float movePassTime = (TimeUtility.GetServerMilliseconds() - data.StartTime) / 1000.0f;
        if (movePassTime <= data.MoveTime) {
          float nowX = data.StartPos.X + data.VX * movePassTime;
          float nowZ = data.StartPos.Z + data.VZ * movePassTime;
          float nowY = entity.GetMovementStateInfo().GetPosition3D().Y;
          entity.GetMovementStateInfo().SetPosition(nowX, nowY, nowZ);
        }
      }

      DoSectionTick(entity, actionInfo);
    }
    protected override bool OnBeforeStartAction(CharacterInfo entity, ActionInfo actionInfo)
    {
      if (entity.GetAIEnable()) {
        entity.SetAIEnable(false);
        actionInfo.IsAiStateChange = true;
      }
      ActionMoveData data = new ActionMoveData();
      actionInfo.LogicDatas.AddData<ActionMoveData>(data);
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
        data.StartPos.X = entityPos.X;
        data.StartPos.Z = entityPos.Z;

        // 判断轨迹过程中是否有阻挡，有则取得轨迹终点位置
        if (data.HasBlock) {
          data.MoveTime = 0;
        } else {
          data.TargetPos.X = data.StartPos.X + data.VX * dataAction.SectionList[sectionNum].PlayTime;
          data.TargetPos.Z = data.StartPos.Z + data.VZ * dataAction.SectionList[sectionNum].PlayTime;
          ScriptRuntime.Vector3 hitPos;
          if (entity.SpatialSystem.RayCastForPass(data.StartPos, data.TargetPos, out hitPos)) {
            float hitDistance = (float)Math.Sqrt(Math.Pow(hitPos.X - entityPos.X, 2) + Math.Pow(hitPos.Z - entityPos.Z, 2));
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
          if (Math.Abs(data.VX) > Math.Abs(data.VZ))
          {
            data.MoveTime = (data.TargetPos.X - data.StartPos.X) / data.VX;
          }
          else
          {
            data.MoveTime = (data.TargetPos.Z - data.StartPos.Z) / data.VZ;
          }
        }
      } else {
        data.MoveTime = 0;
      }
    }

    protected override void OnSectionOver(CharacterInfo entity, ActionInfo actionInfo, int sectionNum)
    {
      ActionLogicData dataAction = actionInfo.ConfigData;
      if (null == dataAction) return;
      /*
      if (dataAction.SectionList[sectionNum].MoveSpeed > 0
        && CanEntityMove(entity)) {
        ActionMoveData data = actionInfo.LogicDatas.GetData<ActionMoveData>();
        if (null != data) {
          data.TargetPos.Y = entity.GetMovementStateInfo().GetPosition3D().Y;
          entity.GetMovementStateInfo().SetPosition(data.TargetPos);
        }
      }
       */
      
      if((dataAction.SectionNumber-1) == sectionNum){
        if (null != EventActionOver) {
          EventActionOver(entity, actionInfo, sectionNum);
        }
      }

      EndSection(entity, actionInfo, sectionNum);
    }
  }
}
