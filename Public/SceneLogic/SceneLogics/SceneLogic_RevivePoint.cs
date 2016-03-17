﻿using System;
using System.Collections.Generic;

namespace DashFire
{
  public class SceneLogic_RevivePoint : AbstractSceneLogic
  {
    public override void Execute(SceneLogicInfo info, long deltaTime)
    {
      if (null == info || info.IsLogicFinished || info.IsLogicPaused) return;
      if (null != info) {
        info.Time += deltaTime;
        if (info.Time >= 2000) {
          info.Time = 0;
          RevivePointLogicInfo data = info.LogicDatas.GetData<RevivePointLogicInfo>();
          //初始化逻辑数据
          if (null == data) {
            data = new RevivePointLogicInfo();
            info.LogicDatas.AddData(data);

            SceneLogicConfig sc = info.SceneLogicConfig;
            if (null != sc) {
              string[] pos = sc.m_Params[0].Split(' ');
              data.m_Center.X = float.Parse(pos[0]);
              data.m_Center.Y = float.Parse(pos[1]);
              data.m_Center.Z = float.Parse(pos[2]);
              data.m_RadiusOfTrigger = float.Parse(sc.m_Params[1]);
            }
          }
          //执行逻辑
          if (null != data) {
            List<DashFireSpatial.ISpaceObject> objs = info.SpatialSystem.GetObjectInCircle(data.m_Center, data.m_RadiusOfTrigger);
            if (null != objs) {
              for (int i = 0; i < objs.Count; i++ )
              {
                if (objs[i].GetObjType() == DashFireSpatial.SpatialObjType.kUser)
                {
                  UserInfo ui = info.UserManager.GetUserInfo((int)objs[i].GetID());
                  if (null != ui)
                  {
                    ui.RevivePoint = data.m_Center;
                  }
                }
              }
              /*
              foreach (DashFireSpatial.ISpaceObject obj in objs) {
                if (obj.GetObjType() == DashFireSpatial.SpatialObjType.kUser) {
                  UserInfo ui = info.UserManager.GetUserInfo((int)obj.GetID());
                  if (null != ui) {
                    ui.RevivePoint = data.m_Center;
                  }
                }
              }*/
            }
          }
        }
      }
    }
  }
}
