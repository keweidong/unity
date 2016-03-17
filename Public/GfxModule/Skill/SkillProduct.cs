using System;
using System.Collections.Generic;
using UnityEngine;
using SkillSystem;

namespace GfxModule.Skill
{
  public class ISkillProduct
  {
    public virtual void Tick(long delta_ns)
    {
    }

    public virtual bool IsStoped()
    {
      return true;
    }
  }

  public class ShadowProduct : ISkillProduct
  {
    public ShadowProduct(GameObject orig_obj,
                         string shadow_material,
                         string shader_name,
                         long hold_time,
                         long fade_out_time,
                         float start_alpha,
                         List<string> ignore_list)
    {
      m_IsOver = false;
      m_OrigObject = orig_obj;
      m_ShadowMaterial = shadow_material;
      m_ShaderName = shader_name;
      m_CurTimeNs = 0;
      m_HoldTime = hold_time;
      m_FadeOutTime = fade_out_time;
      m_StartAlpha = start_alpha;
      m_IgnoreList.AddRange(ignore_list);
      Start(orig_obj);
    }

    public void Start(GameObject obj)
    {
      m_ShadowObject = DashFire.ResourceSystem.NewObject(obj) as GameObject;
      if (m_ShadowObject == null) {
        m_IsOver = true;
        return;
      }
      m_ShadowObject.transform.position = obj.transform.position;
      m_ShadowObject.transform.rotation = obj.transform.rotation;
      foreach (AnimationState state in obj.animation) {
        if (state.enabled && state.weight > 0) {
          m_ShadowObject.animation[state.name].normalizedTime = state.normalizedTime;
          m_ShadowObject.animation[state.name].weight = state.weight;
          m_ShadowObject.animation[state.name].speed = 0;
          m_ShadowObject.animation.Play(state.name);
        }
      }
      Renderer[] renders = m_ShadowObject.GetComponentsInChildren<Renderer>();
      Texture shadow_texture = Resources.Load(m_ShadowMaterial) as Texture;
      Shader shader = Shader.Find(m_ShaderName);
      for (int i = 0; i < renders.Length; i++ )
      {
        if (renders[i].gameObject != null && IsInIgnoreList(renders[i].gameObject.name))
        {
          renders[i].enabled = false;
          continue;
        }
        if (!renders[i].enabled)
        {
          continue;
        }
        if (shader != null)
        {
          renders[i].material.shader = shader;
        }
        renders[i].material.mainTexture = shadow_texture;
        Color co = renders[i].material.color;
        co.a = m_StartAlpha;
        renders[i].material.color = co;
      }
      /*
      foreach(Renderer r in renders) {
        if (r.gameObject != null && IsInIgnoreList(r.gameObject.name)) {
          r.enabled = false;
          continue;
        }
        if (!r.enabled) {
          continue;
        }
        if (shader != null) {
          r.material.shader = shader;
        }
        r.material.mainTexture = shadow_texture;
        Color co = r.material.color;
        co.a = m_StartAlpha;
        r.material.color = co;
      }*/
    }

    public override void Tick(long delta_ns)
    {
      if (m_IsOver) {
        return;
      }
      m_CurTimeNs += delta_ns;
      if (m_HoldTime < GetCurTime()) {
        long pass_time = GetCurTime() - m_HoldTime;
        float t = pass_time / (m_FadeOutTime * 1.0f);
        t = t > 1 ? 1 : t;
        float new_alpha = Mathf.Lerp(m_StartAlpha, 0, t);
        SetGameObjectAlpha(m_ShadowObject, new_alpha);
      }
      if (m_HoldTime + m_FadeOutTime < GetCurTime()) {
        DashFire.ResourceSystem.RecycleObject(m_ShadowObject);
        m_IsOver = true;
      }
    }

    public override bool IsStoped()
    {
      return m_IsOver;
    }

    private long GetCurTime()
    {
      return m_CurTimeNs / 1000;
    }

    private void SetGameObjectAlpha(GameObject obj, float alpha)
    {
      Renderer[] renders = obj.GetComponentsInChildren<Renderer>();
      for (int i = 0; i < renders.Length; i++ )
      {
        if (renders[i].gameObject != null && IsInIgnoreList(renders[i].gameObject.name))
        {
          continue;
        }
        if (renders[i].enabled)
        {
          Color old_color = renders[i].material.color;
          old_color.a = alpha;
          renders[i].material.color = old_color;
        }
      }
      /*
      foreach (Renderer r in renders) {
        if (r.gameObject != null && IsInIgnoreList(r.gameObject.name)) {
          continue;
        }
        if (r.enabled) {
          Color old_color = r.material.color;
          old_color.a = alpha;
          r.material.color = old_color;
        }
      }*/
    }

    private bool IsInIgnoreList(string part_name)
    {
      for (int i = 0; i < m_IgnoreList.Count; i++)
      {
        if (m_IgnoreList[i].StartsWith(part_name))
        {
          return true;
        }
      }
      /*
      foreach (string ignore in m_IgnoreList) {
          if (ignore.StartsWith(part_name))
          {
              //UnityEngine.Profiler.EndSample();
          return true;
        }
      }*/
      return false;
    }

    private bool m_IsOver = false;
    private GameObject m_OrigObject;
    private GameObject m_ShadowObject;
    private string m_ShadowMaterial;
    private string m_ShaderName;
    private long m_StartTime;
    private long m_HoldTime;
    private long m_FadeOutTime;
    private float m_StartAlpha;
    private long m_CurTimeNs = 0;
    private List<String> m_IgnoreList = new List<String>();
  }
}