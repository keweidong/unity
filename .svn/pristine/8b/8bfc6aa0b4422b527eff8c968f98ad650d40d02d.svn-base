using System;
using System.Collections.Generic;
using ScriptRuntime;
using StorySystem;
using DashFire;

namespace TestStory
{
  public sealed class TestStorySystem
  {
    private class StoryInstanceInfo
    {
      public int m_StoryId;
      public StoryInstance m_StoryInstance;
      public bool m_IsUsed;
    }
    public void Init()
    {
      //注册剧情命令
      StoryCommandManager.Instance.RegisterCommandFactory("startstory", new StoryCommandFactoryHelper<Commands.StartStoryCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("stopstory", new StoryCommandFactoryHelper<Commands.StopStoryCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("firemessage", new StoryCommandFactoryHelper<Commands.FireMessageCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("missioncompleted", new StoryCommandFactoryHelper<Commands.MissionCompletedCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("changescene", new StoryCommandFactoryHelper<Commands.ChangeSceneCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("updatecoefficient", new StoryCommandFactoryHelper<Commands.UpdateCoefficientCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("pausescenelogic", new StoryCommandFactoryHelper<Commands.PauseSceneLogicCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("restartareamonitor", new StoryCommandFactoryHelper<Commands.RestartAreaMonitorCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("restarttimeout", new StoryCommandFactoryHelper<Commands.RestartTimeoutCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("restartareadetect", new StoryCommandFactoryHelper<Commands.RestartAreaDetectCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("createnpc", new StoryCommandFactoryHelper<Commands.CreateNpcCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("dropnpc", new StoryCommandFactoryHelper<Commands.DropNpcCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("destroynpc", new StoryCommandFactoryHelper<Commands.DestroyNpcCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("destroynpcwithobjid", new StoryCommandFactoryHelper<Commands.DestroyNpcWithObjIdCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("npcface", new StoryCommandFactoryHelper<Commands.NpcFaceCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("npcmove", new StoryCommandFactoryHelper<Commands.NpcMoveCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("npcmovewithwaypoints", new StoryCommandFactoryHelper<Commands.NpcMoveWithWaypointsCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("npcpatrol", new StoryCommandFactoryHelper<Commands.NpcPatrolCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("npcpatrolwithobjid", new StoryCommandFactoryHelper<Commands.NpcPatrolWithObjIdCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("npcstop", new StoryCommandFactoryHelper<Commands.NpcStopCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("npcattack", new StoryCommandFactoryHelper<Commands.NpcAttackCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("npcpursuit", new StoryCommandFactoryHelper<Commands.NpcPursuitCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("enableai", new StoryCommandFactoryHelper<Commands.EnableAiCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("setai", new StoryCommandFactoryHelper<Commands.SetAiCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("npcaddimpact", new StoryCommandFactoryHelper<Commands.NpcAddImpactCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("npcremoveimpact", new StoryCommandFactoryHelper<Commands.NpcRemoveImpactCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("npccastskill", new StoryCommandFactoryHelper<Commands.NpcCastSkillCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("npcstopskill", new StoryCommandFactoryHelper<Commands.NpcStopSkillCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("npcaddskill", new StoryCommandFactoryHelper<Commands.NpcAddSkillCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("npcremoveskill", new StoryCommandFactoryHelper<Commands.NpcRemoveSkillCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("npclisten", new StoryCommandFactoryHelper<Commands.NpcListenCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("setcamp", new StoryCommandFactoryHelper<Commands.SetCampCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("objface", new StoryCommandFactoryHelper<Commands.ObjFaceCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("objmove", new StoryCommandFactoryHelper<Commands.ObjMoveCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("objmovewithwaypoints", new StoryCommandFactoryHelper<Commands.ObjMoveWithWaypointsCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("objstop", new StoryCommandFactoryHelper<Commands.ObjStopCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("objanimation", new StoryCommandFactoryHelper<Commands.ObjAnimationCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("objpursuit", new StoryCommandFactoryHelper<Commands.ObjPursuitCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("objenableai", new StoryCommandFactoryHelper<Commands.ObjEnableAiCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("objsetai", new StoryCommandFactoryHelper<Commands.ObjSetAiCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("objaddimpact", new StoryCommandFactoryHelper<Commands.ObjAddImpactCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("objremoveimpact", new StoryCommandFactoryHelper<Commands.ObjRemoveImpactCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("objcastskill", new StoryCommandFactoryHelper<Commands.ObjCastSkillCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("objstopskill", new StoryCommandFactoryHelper<Commands.ObjStopSkillCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("objaddskill", new StoryCommandFactoryHelper<Commands.ObjAddSkillCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("objremoveskill", new StoryCommandFactoryHelper<Commands.ObjRemoveSkillCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("objlisten", new StoryCommandFactoryHelper<Commands.ObjListenCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("setblockedshader", new StoryCommandFactoryHelper<Commands.SetBlockedShaderCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("sethp", new StoryCommandFactoryHelper<Commands.SetHpCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("setenergy", new StoryCommandFactoryHelper<Commands.SetEnergyCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("setrage", new StoryCommandFactoryHelper<Commands.SetRageCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("objset", new StoryCommandFactoryHelper<Commands.ObjSetCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("playerselfface", new StoryCommandFactoryHelper<Commands.PlayerselfFaceCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("playerselfmove", new StoryCommandFactoryHelper<Commands.PlayerselfMoveCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("playerselfmovewithwaypoints", new StoryCommandFactoryHelper<Commands.PlayerselfMoveWithWaypointsCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("playerselfpursuit", new StoryCommandFactoryHelper<Commands.PlayerselfPursuitCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("playerselfstop", new StoryCommandFactoryHelper<Commands.PlayerselfStopCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("playerselflisten", new StoryCommandFactoryHelper<Commands.PlayerselfListenCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("cameralookat", new StoryCommandFactoryHelper<Commands.CameraLookatCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("camerafollow", new StoryCommandFactoryHelper<Commands.CameraFollowCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("cameralookatimmediately", new StoryCommandFactoryHelper<Commands.CameraLookatImmediatelyCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("camerafollowimmediately", new StoryCommandFactoryHelper<Commands.CameraFollowImmediatelyCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("lockframe", new StoryCommandFactoryHelper<Commands.LockFrameCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("camerayaw", new StoryCommandFactoryHelper<Commands.CameraYawCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("cameraheight", new StoryCommandFactoryHelper<Commands.CameraHeightCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("cameradistance", new StoryCommandFactoryHelper<Commands.CameraDistanceCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("cameraenable", new StoryCommandFactoryHelper<Commands.CameraEnableCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("enableinput", new StoryCommandFactoryHelper<Commands.EnableInputCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("showui", new StoryCommandFactoryHelper<Commands.ShowUiCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("showwall", new StoryCommandFactoryHelper<Commands.ShowWallCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("showdlg", new StoryCommandFactoryHelper<Commands.ShowDlgCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("startcountdown", new StoryCommandFactoryHelper<Commands.StartCountDownCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("highlightprompt", new StoryCommandFactoryHelper<Commands.HighlightPromptCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("reconnectlobby", new StoryCommandFactoryHelper<Commands.ReconnectLobbyCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("disconnectlobby", new StoryCommandFactoryHelper<Commands.DisconnectLobbyCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("publishfilterevent", new StoryCommandFactoryHelper<Commands.PublishFilterEventCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("publishlogicevent", new StoryCommandFactoryHelper<Commands.PublishLogicEventCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("publishgfxevent", new StoryCommandFactoryHelper<Commands.PublishGfxEventCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("sendgfxmessage", new StoryCommandFactoryHelper<Commands.SendGfxMessageCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("sendgfxmessagewithtag", new StoryCommandFactoryHelper<Commands.SendGfxMessageWithTagCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("sendgfxmessagebyid", new StoryCommandFactoryHelper<Commands.SendGfxMessageByIdCommand>());
      StoryCommandManager.Instance.RegisterCommandFactory("createnpcbyscore", new StoryCommandFactoryHelper<Commands.CreateNpcByScoreCommand>());

      //注册值与函数处理
      StoryValueManager.Instance.RegisterValueHandler("useridlist", new StoryValueFactoryHelper<Values.UserIdListValue>());
      StoryValueManager.Instance.RegisterValueHandler("playerselfid", new StoryValueFactoryHelper<Values.PlayerselfIdValue>());
      StoryValueManager.Instance.RegisterValueHandler("winuserid", new StoryValueFactoryHelper<Values.WinUserIdValue>());
      StoryValueManager.Instance.RegisterValueHandler("lostuserid", new StoryValueFactoryHelper<Values.LostUserIdValue>());
      StoryValueManager.Instance.RegisterValueHandler("livingusercount", new StoryValueFactoryHelper<Values.LivingUserCountValue>());
      StoryValueManager.Instance.RegisterValueHandler("npcidlist", new StoryValueFactoryHelper<Values.NpcIdListValue>());
      StoryValueManager.Instance.RegisterValueHandler("combatnpccount", new StoryValueFactoryHelper<Values.CombatNpcCountValue>());
      StoryValueManager.Instance.RegisterValueHandler("iscombatnpc", new StoryValueFactoryHelper<Values.IsCombatNpcValue>());
      StoryValueManager.Instance.RegisterValueHandler("unitid2objid", new StoryValueFactoryHelper<Values.UnitId2ObjIdValue>());
      StoryValueManager.Instance.RegisterValueHandler("objid2unitid", new StoryValueFactoryHelper<Values.ObjId2UnitIdValue>());
      StoryValueManager.Instance.RegisterValueHandler("getposition", new StoryValueFactoryHelper<Values.GetPositionValue>());
      StoryValueManager.Instance.RegisterValueHandler("getpositionx", new StoryValueFactoryHelper<Values.GetPositionXValue>());
      StoryValueManager.Instance.RegisterValueHandler("getpositiony", new StoryValueFactoryHelper<Values.GetPositionYValue>());
      StoryValueManager.Instance.RegisterValueHandler("getpositionz", new StoryValueFactoryHelper<Values.GetPositionZValue>());
      StoryValueManager.Instance.RegisterValueHandler("getcamp", new StoryValueFactoryHelper<Values.GetCampValue>());
      StoryValueManager.Instance.RegisterValueHandler("isenemy", new StoryValueFactoryHelper<Values.IsEnemyValue>());
      StoryValueManager.Instance.RegisterValueHandler("isfriend", new StoryValueFactoryHelper<Values.IsFriendValue>());
      StoryValueManager.Instance.RegisterValueHandler("gethp", new StoryValueFactoryHelper<Values.GetHpValue>());
      StoryValueManager.Instance.RegisterValueHandler("getenergy", new StoryValueFactoryHelper<Values.GetEnergyValue>());
      StoryValueManager.Instance.RegisterValueHandler("getrage", new StoryValueFactoryHelper<Values.GetRageValue>());
      StoryValueManager.Instance.RegisterValueHandler("getmaxhp", new StoryValueFactoryHelper<Values.GetMaxHpValue>());
      StoryValueManager.Instance.RegisterValueHandler("getmaxenergy", new StoryValueFactoryHelper<Values.GetMaxEnergyValue>());
      StoryValueManager.Instance.RegisterValueHandler("getmaxrage", new StoryValueFactoryHelper<Values.GetMaxRageValue>());
      StoryValueManager.Instance.RegisterValueHandler("islobbyconnected", new StoryValueFactoryHelper<Values.IsLobbyConnectedValue>());
      StoryValueManager.Instance.RegisterValueHandler("islobbylogining", new StoryValueFactoryHelper<Values.IsLobbyLoginingValue>());
      StoryValueManager.Instance.RegisterValueHandler("haslobbyloggedon", new StoryValueFactoryHelper<Values.HasLobbyLoggedOnValue>());
      StoryValueManager.Instance.RegisterValueHandler("calcdir", new StoryValueFactoryHelper<Values.CalcDirValue>());
      StoryValueManager.Instance.RegisterValueHandler("objget", new StoryValueFactoryHelper<Values.ObjGetValue>());

    }
    public void PreloadStoryInstance(int storyId)
    {
      StoryInstanceInfo info = NewStoryInstance(storyId);
      if (null != info) {
        RecycleStorylInstance(info);
      }
    }
    public void ClearStoryInstancePool()
    {
      m_StoryInstancePool.Clear();
    }
    public void Reset()
    {
      m_GlobalVariables.Clear();
      m_StoryLogicInfos.Clear();
    }
    public int ActiveStoryCount
    {
      get
      {
        return m_StoryLogicInfos.Count;
      }
    }
    public Dictionary<string, object> GlobalVariables
    {
      get { return m_GlobalVariables; }
    }
    public void StartStory(int storyId)
    {
      StoryInstanceInfo inst = NewStoryInstance(storyId);
      if (null != inst) {
        m_StoryLogicInfos.Add(inst);
        inst.m_StoryInstance.Context = Context.Instance;
        inst.m_StoryInstance.GlobalVariables = m_GlobalVariables;
        inst.m_StoryInstance.Start();

        LogSystem.Info("StartStory {0}", storyId);
      }
    }
    public void StopStory(int storyId)
    {
      int count = m_StoryLogicInfos.Count;
      for (int index = count - 1; index >= 0; --index) {
        StoryInstanceInfo info = m_StoryLogicInfos[index];
        if (info.m_StoryId == storyId) {
          RecycleStorylInstance(info);
          m_StoryLogicInfos.RemoveAt(index);
        }
      }
    }
    public void Tick()
    {
      long time = TimeUtility.GetLocalMilliseconds();
      int ct = m_StoryLogicInfos.Count;
      for (int ix = ct - 1; ix >= 0; --ix) {
        StoryInstanceInfo info = m_StoryLogicInfos[ix];
        info.m_StoryInstance.Tick(time);
        if (info.m_StoryInstance.IsTerminated) {
          RecycleStorylInstance(info);
          m_StoryLogicInfos.RemoveAt(ix);
        }
      }
    }
    public void SendMessage(string msgId, params object[] args)
    {
      int ct = m_StoryLogicInfos.Count;
      for (int ix = ct - 1; ix >= 0; --ix) {
        StoryInstanceInfo info = m_StoryLogicInfos[ix];
        info.m_StoryInstance.SendMessage(msgId, args);
      }
    }

    private StoryInstanceInfo NewStoryInstance(int storyId)
    {
      StoryInstanceInfo instInfo = GetUnusedStoryInstanceInfoFromPool(storyId);
      if (null == instInfo) {
        Data_SceneConfig cfg = SceneConfigProvider.Instance.GetSceneConfigById(Context.Instance.GetCurSceneId());
        if (null != cfg) {
          int ct = cfg.m_StoryDslFile.Count;
          string[] filePath = new string[ct];
          for (int i = 0; i < ct; i++) {
            filePath[i] = HomePath.GetAbsolutePath(FilePathDefine_Server.C_RootPath + cfg.m_StoryDslFile[i]);
          }
          StoryConfigManager.Instance.LoadStoryIfNotExist(storyId, 0, filePath);
          StoryInstance inst = StoryConfigManager.Instance.NewStoryInstance(storyId, 0);

          if (inst == null) {
            DashFire.LogSystem.Error("Can't load story config, story:{0} !", storyId);
            return null;
          }
          StoryInstanceInfo res = new StoryInstanceInfo();
          res.m_StoryId = storyId;
          res.m_StoryInstance = inst;
          res.m_IsUsed = true;

          AddStoryInstanceInfoToPool(storyId, res);
          return res;
        } else {
          DashFire.LogSystem.Error("Can't find story config, story:{0} !", storyId);
          return null;
        }
      } else {
        instInfo.m_IsUsed = true;
        return instInfo;
      }
    }
    private void RecycleStorylInstance(StoryInstanceInfo info)
    {
      info.m_StoryInstance.Reset();
      info.m_IsUsed = false;
    }
    private void AddStoryInstanceInfoToPool(int storyId, StoryInstanceInfo info)
    {
      List<StoryInstanceInfo> infos;
      if (m_StoryInstancePool.TryGetValue(storyId, out infos)) {
        infos.Add(info);
      } else {
        infos = new List<StoryInstanceInfo>();
        infos.Add(info);
        m_StoryInstancePool.Add(storyId, infos);
      }
    }
    private StoryInstanceInfo GetUnusedStoryInstanceInfoFromPool(int storyId)
    {
      StoryInstanceInfo info = null;
      List<StoryInstanceInfo> infos;
      if (m_StoryInstancePool.TryGetValue(storyId, out infos)) {
        int ct = infos.Count;
        for (int ix = 0; ix < ct; ++ix) {
          if (!infos[ix].m_IsUsed) {
            info = infos[ix];
            break;
          }
        }
      }
      return info;
    }

    private TestStorySystem() { }

    private Dictionary<string, object> m_GlobalVariables = new Dictionary<string, object>();

    private List<StoryInstanceInfo> m_StoryLogicInfos = new List<StoryInstanceInfo>();
    private Dictionary<int, List<StoryInstanceInfo>> m_StoryInstancePool = new Dictionary<int, List<StoryInstanceInfo>>();

    public static TestStorySystem Instance
    {
      get
      {
        return s_Instance;
      }
    }
    private static TestStorySystem s_Instance = new TestStorySystem();
  }
}
