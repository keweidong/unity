﻿using System;
using System.Collections.Generic;
using UnityEngine;
using SkillSystem;

namespace GfxModule.Skill.Trigers
{
  public class MoveTargetInfo
  {
    public GameObject Target;
    public float ToTargetDistanceRatio;
    public float ToTargetConstDistance;
    public bool IsAdjustMove;
  }

  public class ChooseTargetTrigger : AbstractSkillTriger
  {
    public override ISkillTriger Clone()
    {
      ChooseTargetTrigger copy = new ChooseTargetTrigger();
      copy.m_StartTime = m_StartTime;
      copy.m_Center = m_Center;
      copy.m_Radius = m_Radius;
      copy.m_Degree = m_Degree;
      copy.m_DistancePriority = m_DistancePriority;
      copy.m_DegreePriority = m_DegreePriority;
      copy.m_ToTargetDistanceRatio = m_ToTargetDistanceRatio;
      copy.m_ToTargetConstDistance = m_ToTargetConstDistance;
      copy.m_IsAdjustMove = m_IsAdjustMove;
      copy.m_FiltStates.AddRange(m_FiltStates);
      copy.m_IsFiltSupperArmer = m_IsFiltSupperArmer;
      copy.m_Relation = m_Relation;
      copy.m_SignForSkill = m_SignForSkill;
      return copy;
    }

    public override void Reset()
    {
    }

    public override bool Execute(object sender, SkillInstance instance, long delta, long curSectionTime)
    {
      if (curSectionTime < m_StartTime) {
        return true;
      }
      GameObject obj = sender as GameObject;
      if (obj == null) {
        return false;
      }
      Vector3 center = obj.transform.TransformPoint(m_Center);
      List<GameObject> area_objects = TriggerUtil.FindTargetInSector(center, m_Radius,
                                                                     obj.transform.forward,
                                                                     obj.transform.position, m_Degree);
      List<GameObject> filted_objects = FiltStateObjects(TriggerUtil.FiltByRelation(obj, area_objects, m_Relation, m_SignForSkill));
      GameObject target = TriggerUtil.GetObjectByPriority(obj, filted_objects,
                                                          m_DistancePriority, m_DegreePriority,
                                                          m_Radius, m_Degree);

      if (target != null) {
        MoveTargetInfo targetinfo = new MoveTargetInfo();
        targetinfo.Target = target;
        targetinfo.ToTargetDistanceRatio = m_ToTargetDistanceRatio;
        targetinfo.ToTargetConstDistance = m_ToTargetConstDistance;
        targetinfo.IsAdjustMove = m_IsAdjustMove;
        instance.CustomDatas.AddData<MoveTargetInfo>(targetinfo);
      }
      return false;
    }

    protected override void Load(ScriptableData.CallData callData)
    {
      int num = callData.GetParamNum();
      if (num >= 8) {
        m_StartTime = long.Parse(callData.GetParamId(0));
        ScriptableData.CallData vect_param1 = callData.GetParam(1) as ScriptableData.CallData;
        m_Center = ScriptableDataUtility.CalcVector3(vect_param1);
        m_Radius = float.Parse(callData.GetParamId(2));
        m_Degree = float.Parse(callData.GetParamId(3));
        m_DistancePriority = float.Parse(callData.GetParamId(4));
        m_DegreePriority = float.Parse(callData.GetParamId(5));
        m_ToTargetDistanceRatio = float.Parse(callData.GetParamId(6));
        m_ToTargetConstDistance = float.Parse(callData.GetParamId(7));
      }
      if (num >= 9) {
        m_IsAdjustMove = bool.Parse(callData.GetParamId(8));
      }
      if (num >= 10) {
        string relation_str = callData.GetParamId(9);
        if (relation_str == "friend") {
          m_Relation = DashFire.CharacterRelation.RELATION_FRIEND;
        } else if(relation_str == "owner"){
          m_Relation = DashFire.CharacterRelation.RELATION_OWNER;
        } else if (relation_str == "sons") {
          m_Relation = DashFire.CharacterRelation.RELATION_FITSIGNSONS;
        } else {
          m_Relation = DashFire.CharacterRelation.RELATION_ENEMY;
        }
      }
    }

    protected override void Load(ScriptableData.FunctionData funcData)
    {
      ScriptableData.CallData callData = funcData.Call;
      if (null != callData) {
        Load(callData);
        for (int i = 0; i < funcData.Statements.Count; i++)
        {
          ScriptableData.CallData stCall = funcData.Statements[i] as ScriptableData.CallData;
          string id = stCall.GetId();
          if (id == "filtstate")
          {
            LoadFiltStateConfig(stCall);
          }
          if (id == "filtsupperarmer")
          {
            m_IsFiltSupperArmer = true;
          }
          if (id == "signforskill") {
            if (stCall.GetParamNum() >= 1) {
              m_SignForSkill = int.Parse(stCall.GetParamId(0));
            }
          }
        }
        /*
        foreach (ScriptableData.ISyntaxComponent statement in funcData.Statements) {
          ScriptableData.CallData stCall = statement as ScriptableData.CallData;
          string id = stCall.GetId();
          if (id == "filtstate") {
            LoadFiltStateConfig(stCall);
          }
          if (id == "filtsupperarmer") {
            m_IsFiltSupperArmer = true;
          }
        }*/
      }
    }

    private void LoadFiltStateConfig(ScriptableData.CallData stCall)
    {
      if (stCall.GetParamNum() >= 1) {
        BeHitState filtstate = TriggerUtil.GetBeHitStateFromStr(stCall.GetParamId(0));
        if (!IsFiltState(filtstate)) {
          m_FiltStates.Add(filtstate);
        }
      }
    }

    private List<GameObject> FiltStateObjects(List<GameObject> objects) {
      List<GameObject> result = new List<GameObject>();
      if (objects == null) {
        return result;
      }
      foreach (GameObject obj in objects) {
        if (m_IsFiltSupperArmer) {
          if (GrabTargetTrigger.IsGameObjectSupperArmer(obj)) {
            continue;
          }
        }
        BeHitState state = SkillDamageManager.GetBeHitState(obj);
        if (!IsFiltState(state)) {
          result.Add(obj);
        }
      }
      return result;
    }

    private bool IsFiltState(BeHitState state) {
      foreach (BeHitState bs in m_FiltStates) {
        if (bs == state) {
          return true;
        }
      }
      return false;
    }

    private int m_SignForSkill;
    private Vector3 m_Center;
    private float m_Radius;
    private float m_Degree;
    private float m_DistancePriority;
    private float m_DegreePriority;
    private float m_ToTargetDistanceRatio;
    private float m_ToTargetConstDistance;
    private bool m_IsAdjustMove = true;
    private bool m_IsFiltSupperArmer = false;
    private DashFire.CharacterRelation m_Relation = DashFire.CharacterRelation.RELATION_ENEMY;
    private List<BeHitState> m_FiltStates = new List<BeHitState>();
  }
}