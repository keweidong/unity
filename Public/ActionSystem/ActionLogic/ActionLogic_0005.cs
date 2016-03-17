using System;
using System.Collections.Generic;
using DashFire.Debug;
using ScriptRuntime;

namespace DashFire
{
  ///
  /// @说明
  ///   跳跃或者击飞动作逻辑
  ///   
  ///   可以借此配置为击退或击高
  ///   击退：水平速度非0，动作结束时速度减为0，垂直加速度为0。
  ///   击高：水平速度非0但非常小，可配置为0.001之类，垂直加速度非0
  ///   

  ///
  public class ActionLogic_0005 : AbstractActionLogic
  {
    public delegate void ActionLogicEventHandler(CharacterInfo entity, ActionInfo actionInfo, int sectionNum);
    public static ActionLogicEventHandler EventActionSectionStart;
    public static ActionLogicEventHandler EventActionOver;

    //private static Int64 tickstarttime = 0;
    enum Type
    {
      HIT_HIGH = 0,
      HIT_BACK = 1,
    }

    public ActionLogic_0005()
    {
      m_ActionLogicId = ActionLogicId.ACTION_LOGIC_ID_BEAT_BACK;
    }

    protected override void OnTick(CharacterInfo entity, ActionInfo actionInfo)
    {
      ActionLogicData dataAction = actionInfo.ConfigData;
      if (null == dataAction) return;
      ActionMoveData data = actionInfo.LogicDatas.GetData<ActionMoveData>();
      if (null != data && data.MoveTime > 0 && data.StartTime > 0) {
        float passTime = (TimeUtility.GetServerMilliseconds() - data.StartTime) / 1000.0f;
        if (passTime <= data.MoveTime) {
         float nowX = data.StartPos.X + data.VX * passTime + data.AX * passTime * passTime / 2;
          float nowZ = data.StartPos.Z + data.VZ * passTime + data.AZ * passTime * passTime / 2;
          float nowY = entity.GetMovementStateInfo().GetPosition3D().Y;
          if (data.VY > 0) {
            float ay = float.Parse(dataAction.ExtraParams[0]);
            nowY = data.StartPos.Y + data.VY * passTime + ay * passTime * passTime / 2;
          }
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
      if (!entity.IsFlying) {
        entity.IsFlying = true;
        actionInfo.IsFlyStateChange = true;
      }
      ActionMoveData data = new ActionMoveData();
      actionInfo.LogicDatas.AddData<ActionMoveData>(data);
      return true;
    }

    protected override void OnSectionStart(CharacterInfo entity, ActionInfo actionInfo, int sectionNum)
    {
      ActionLogicData dataAction = actionInfo.ConfigData;
      if (null == dataAction) return;
      ActionMoveData data = actionInfo.LogicDatas.GetData<ActionMoveData>();
      if (null == data) return;
      if (dataAction.SectionList[sectionNum].MoveSpeed > 0
        && CanEntityMove(entity)) {
          float moveTowardsAngle = entity.GetMovementStateInfo().GetFaceDir() + dataAction.SectionList[sectionNum].MoveTowards * (float)Math.PI / 180.0f;
        ScriptRuntime.Vector3 entityPos = entity.GetMovementStateInfo().GetPosition3D();
        if (actionInfo.ActType == ActionType.IMPACT) {
          int impactId = actionInfo.UsagerId;
          if (impactId > 0) {
            ImpactInfo impactInfo = entity.GetSkillStateInfo().GetImpactInfoById(impactId);
            if (null != impactInfo) {
              Vector3 impactSrcPos = entity.GetSkillStateInfo().GetImpactInfoById(impactId).m_ImpactSourcePos;
              moveTowardsAngle = (float)Math.Atan2(entityPos.X - impactSrcPos.X, entityPos.Z - impactSrcPos.Z);
            }
          }
        }
        data.VX = dataAction.SectionList[sectionNum].MoveSpeed * (float)Math.Sin(moveTowardsAngle);
        data.VZ = dataAction.SectionList[sectionNum].MoveSpeed * (float)Math.Cos(moveTowardsAngle);
        data.StartTime = TimeUtility.GetServerMilliseconds();
        data.StartPos = entityPos;
        int type = (int)Type.HIT_HIGH;
        if (dataAction.ExtraParams.Count > 1 && dataAction.ExtraParams[1].Length > 0)
        {
          type = int.Parse(dataAction.ExtraParams[1]);
          if ((int)Type.HIT_BACK == type)
          {
            data.AX = -1 * data.VX / dataAction.SectionList[sectionNum].PlayTime;
            data.AZ = -1 * data.VZ/ dataAction.SectionList[sectionNum].PlayTime;
          }
          else if ((int)Type.HIT_HIGH == type)
          {
            data.AX = 0;
            data.AZ = 0;
          }
        }

        if (dataAction.ExtraParams.Count > 0 && dataAction.ExtraParams[0].Length > 0 && 0 != float.Parse(dataAction.ExtraParams[0])) {
          data.VY = -1 * float.Parse(dataAction.ExtraParams[0]) * dataAction.SectionList[sectionNum].PlayTime / 2;
        }

        if (data.HasBlock) {
          // 如果上一段动作已遇到阻挡，本段动作不移动
          data.MoveTime = 0;
        } else {
          float playTime = dataAction.SectionList[sectionNum].PlayTime;
          data.TargetPos.X = data.StartPos.X + data.VX * playTime + data.AX * playTime * playTime / 2;
          data.TargetPos.Z = data.StartPos.Z + data.VZ * playTime + data.AZ * playTime * playTime / 2;
          // 判断轨迹过程中是否有阻挡，有则取得轨迹终点位置
          ScriptRuntime.Vector3 hitPos;
          bool ret = entity.SpatialSystem.RayCastForPass(data.StartPos , data.TargetPos, out hitPos);
          if (ret) {
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
          /// 如果是击退的话 在水平方向上是最终速度为0的匀减速运动
          if ((int)Type.HIT_BACK == type)
          {
            data.MoveTime = (data.TargetPos.X - data.StartPos.X) / data.VX * 2;
          }
          /// 击高的话，在水平方向是匀速运动
          else if ((int)Type.HIT_HIGH == type)
          {
            data.MoveTime = (data.TargetPos.X - data.StartPos.X) / data.VX;
          }
        }
      } else {
        data.MoveTime = 0;
      }

      StartSection(entity, actionInfo, sectionNum);

      if (null != EventActionSectionStart) {
        EventActionSectionStart(entity, actionInfo, sectionNum);
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
        if (null == data) return;
        data.TargetPos.Y = entity.GetMovementStateInfo().GetPosition3D().Y;
        entity.GetMovementStateInfo().SetPosition(data.TargetPos);
      }
       */
      
      if(null != entity && (dataAction.SectionNumber-1) == sectionNum){
        if (null != EventActionOver) {
          EventActionOver(entity, actionInfo, sectionNum);
        }
      }

      EndSection(entity, actionInfo, sectionNum);
    }
  }
}
