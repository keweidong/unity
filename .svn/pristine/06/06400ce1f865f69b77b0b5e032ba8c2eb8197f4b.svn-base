using System;
using System.Collections.Generic;
using UnityEngine;
using DashFire;

namespace GfxModule.Impact
{
  class ImpactUtility
  {
    public static float RadianToDegree(float dir)
    {
      return (float)(dir * 180 / Math.PI);
    }
    public static Vector3 ConvertVector3D(string vec)
    {
      Vector3 vector = Vector3.zero;
      try {
        string strPos = vec;
        string[] resut = strPos.Split(s_ListSplitString, StringSplitOptions.None);
        vector = new Vector3(Convert.ToSingle(resut[0]), Convert.ToSingle(resut[1]), Convert.ToSingle(resut[2]));
      } catch (System.Exception ex) {
        LogicSystem.LogicErrorLog("ImpactUtility.ConvertVector3D failed. ex:{0} st:{1}", ex.Message, ex.StackTrace);
      }

      return vector;
    }

    public static void MoveObject(GameObject obj, Vector3 motion)
    {
      CharacterController ctrl = obj.GetComponent<CharacterController>();
      if (null != ctrl) {
        ctrl.Move(motion);
      } else {
        ctrl.transform.position += motion;
      }
    }

    public static bool IsLogicDead(GameObject obj)
    {
      if (null != obj) {
        SharedGameObjectInfo shareInfo = LogicSystem.GetSharedGameObjectInfo(obj);
        {
          if (null != shareInfo && shareInfo.Blood > 0) {
            return false;
          }
        }
      }
      return true;
    }

    public static void PlaySound(GameObject obj, string sound)
    {
      if (null != obj) {
        AudioSource audioSource = obj.audio;
        if (null != audioSource) {
          AudioClip clip = ResourceSystem.GetSharedResource(sound) as AudioClip;
          if (null != clip) {
            audioSource.clip = clip;
            audioSource.Play();
          }
        }
      }
    }
    private static string[] s_ListSplitString = new string[] { ",", " ", ", ", "|" };
  }
}
