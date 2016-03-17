﻿using System;
using System.Collections.Generic;
using System.Text;
using DashFire.Network;

namespace DashFire
{
  internal class GameLogicThread : MyClientThread
  {
    protected override void OnStart()
    {
    }

    protected override void OnTick()
    {
      //这里是在逻辑线程执行的tick，渲染线程的在GameControler.cs:TickGame里。
      try {
        TimeUtility.SampleClientTick();

        long curTime = TimeUtility.GetLocalMilliseconds();
        if (m_LastLogTime + 10000 < curTime) {
          m_LastLogTime = curTime;
#if DEBUG        
          if (WorldSystem.Instance.IsPvpScene() || WorldSystem.Instance.IsMultiPveScene()) {
            GfxSystem.GfxLog("AverageRoundtripTime:{0}", TimeUtility.AverageRoundtripTime);
          }

          if (this.CurActionNum > 10) {
            GfxSystem.GfxLog("LogicThread.Tick actionNum {0}", this.CurActionNum);
          }

          DebugPoolCount((string msg) => {
            GfxSystem.GfxLog("LogicActionQueue {0}", msg);
          });
#endif
        }

        if (!GameControler.IsPaused) {
          NetworkSystem.Instance.Tick();
          LobbyNetworkSystem.Instance.Tick();
          PlayerControl.Instance.Tick();
          WorldSystem.Instance.Tick();
        }
        GameControler.LogicLoggerInstance.Tick();
      } catch (Exception ex) {
        LogSystem.Error("GameLogicThread.Tick throw Exception:{0}\n{1}", ex.Message, ex.StackTrace);
      }
    }

    protected override void OnQuit()
    {
    }

    private long m_LastLogTime = 0;
  }
}
