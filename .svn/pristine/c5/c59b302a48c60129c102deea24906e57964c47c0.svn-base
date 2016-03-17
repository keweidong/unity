using System;
using System.Collections.Generic;
using DashFire.Debug;

namespace DashFire
{
  ///
  /// @说明
  ///   动作中直接设置目标位置
  ///   
  /// 
  /// @ActionInfo中LogicDynamicParam只在该节动作有位置移动时有用，定义如下
  ///
  public class ActionLogic_0006 : AbstractActionLogic
  {
    public delegate void ActionLogicEventHandler(CharacterInfo entity, ActionInfo actionInfo, int sectionNum);
    public static ActionLogicEventHandler EventActionSectionStart;
    public static ActionLogicEventHandler EventActionOver;

    public ActionLogic_0006()
    {
      m_ActionLogicId = ActionLogicId.ACTION_LOGIC_ID_SETPOS;
    }
    ///
    protected override void OnSectionStart(CharacterInfo entity, ActionInfo actionInfo, int sectionNum)
    {
      StartSection(entity, actionInfo, sectionNum);
      
      if (null != EventActionSectionStart) {
        EventActionSectionStart(entity, actionInfo, sectionNum);
      }
    }
    ///
    protected override void OnSectionOver(CharacterInfo entity, ActionInfo actionInfo, int sectionNum)
    {
      ActionLogicData dataAction = actionInfo.ConfigData;
      if (null == dataAction) return;
      if (CanEntityMove(entity)
          && dataAction.SectionList[sectionNum].MoveSpeed > 0) {
        float moveTowardsAngle = entity.GetMovementStateInfo().GetFaceDir();
        float velocityX = dataAction.SectionList[sectionNum].MoveSpeed * (float)Math.Sin(moveTowardsAngle) * dataAction.SectionList[sectionNum].PlayTime;
        float velocityZ = dataAction.SectionList[sectionNum].MoveSpeed * (float)Math.Cos(moveTowardsAngle) * dataAction.SectionList[sectionNum].PlayTime;
        float nowX = entity.GetMovementStateInfo().GetPosition3D().X + velocityX;
        float nowZ = entity.GetMovementStateInfo().GetPosition3D().Z + velocityZ;
        float nowY = entity.GetMovementStateInfo().GetPosition3D().Y;
        
        /// 阻挡判断
        if(!entity.SpatialSystem.CanPass(new ScriptRuntime.Vector3(nowX, nowY, nowZ), 1)){
          ScriptRuntime.Vector3 entityPos = entity.GetMovementStateInfo().GetPosition3D();
          ScriptRuntime.Vector3 destPos = new ScriptRuntime.Vector3(nowX, 0, nowZ);
          ScriptRuntime.Vector3 hitPos;
          if (entity.SpatialSystem.RayCastForPass(entityPos, destPos, out hitPos)) {
            float hitDistance = (float)Math.Sqrt(Math.Pow(hitPos.X - entityPos.X, 2) + Math.Pow(hitPos.Z - entityPos.Z, 2));
            if (hitDistance < entity.GetRadius() + 0.5) {
              nowX = entityPos.X;
              nowZ = entityPos.Z;
            } else {
              float angle = (float)Math.Atan2(velocityX, velocityZ);
              nowX = hitPos.X - (float)(entity.GetRadius() + 0.5) * (float)Math.Sin(angle);
              nowZ = hitPos.Z - (float)(entity.GetRadius() + 0.5) * (float)Math.Cos(angle);
            }
          }
        }
        
        entity.GetMovementStateInfo().SetPosition(nowX, nowY, nowZ);
      }
      
      if(null != entity && (dataAction.SectionNumber-1) == sectionNum){
        if (null != EventActionOver) {
          EventActionOver(entity, actionInfo, sectionNum);
        }
      }
      EndSection(entity, actionInfo, sectionNum);
    }
  }
}
