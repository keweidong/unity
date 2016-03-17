using System;
using System.Collections.Generic;
using UnityEngine;
using DashFire;

namespace GfxModule.Impact {
  class GfxImpactLogic_Default : AbstarctGfxImpactLogic{

    public override void StartImpact(ImpactLogicInfo logicInfo) {
    }

    public override void Tick(ImpactLogicInfo logicInfo)
    {
      try {
        UnityEngine.Profiler.BeginSample("GfxImpactLogic_Default.Tick");
        UpdateEffect(logicInfo);
        if (Time.time > logicInfo.StartTime + logicInfo.Duration) {
          StopImpact(logicInfo);
        }
      } finally {
        UnityEngine.Profiler.EndSample();
      }
    }

    public override void StopImpact(ImpactLogicInfo logicInfo) {
      for (int i = 0; i < logicInfo.EffectsDelWithImpact.Count; i++)
      {
        ResourceSystem.RecycleObject(logicInfo.EffectsDelWithImpact[i]);
      }
      /*
      foreach(GameObject obj in logicInfo.EffectsDelWithImpact){
        ResourceSystem.RecycleObject(obj);
      }*/
      logicInfo.IsActive = false;
    }

    public override void OnInterrupted(ImpactLogicInfo logicInfo) {
      StopImpact(logicInfo);
    }

    public override bool OnOtherImpact(int logicId, ImpactLogicInfo logicInfo, bool isSameImpact) {
      OnInterrupted(logicInfo);
      return true;
    }
  }
}
