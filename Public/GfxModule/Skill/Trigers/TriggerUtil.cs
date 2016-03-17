using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace GfxModule.Skill.Trigers
{
  public class TriggerUtil
  {
    private static float m_RayCastMaxDistance = 50;
    private static int m_TerrainLayer = 1 << 16;
    private static int m_CurCameraControlId = 0;
    private static bool m_IsMoveCameraTriggerContol = false;
    private static long m_HitCountId = 0;
    private static long m_MinHitCountCD = 200;

    public static int CAMERA_CONTROL_FAILED = -1;
    public static int CAMERA_NO_ONE_CONTROL = 0;
    public static int CAMERA_CONTROL_START_ID = 1;

    public static long NextHitCountId()
    {
      return ++m_HitCountId;
    }

    public static long MinHitCountCD()
    {
      return m_MinHitCountCD;
    }

    public static void OnFingerDown(DashFire.GestureArgs e)
    {
      if (DashFire.LogicSystem.PlayerSelfInfo != null)
      {
        DashFire.LogicSystem.PlayerSelfInfo.IsTouchDown = true;
      }
    }

    public static void OnFingerUp(DashFire.GestureArgs e)
    {
      if (DashFire.LogicSystem.PlayerSelfInfo != null) {
        DashFire.LogicSystem.PlayerSelfInfo.IsTouchDown = false;
      }
    }
    
    public static Transform GetChildNodeByName(GameObject gameobj, string name)
    {
      if (gameobj == null) {
        return null;
      }
      if (string.IsNullOrEmpty(name)) {
        return null;
      }
      Transform[] ts = gameobj.transform.GetComponentsInChildren<Transform>();
      for (int i = 0; i < ts.Length; i++ )
      {
        if (ts[i].name == name)
        {
          return ts[i];
        }
      }
      /*
      foreach (Transform t in ts) {
        if (t.name == name) {
            UnityEngine.Profiler.EndSample();
          return t;
        }
      }*/
      return null;
    }

    public static bool AttachNodeToNode(GameObject source,
                                     string sourcenode,
                                     GameObject target,
                                     string targetnode)
    {
      Transform source_child = GetChildNodeByName(source, sourcenode);
      Transform target_child = GetChildNodeByName(target, targetnode);
      if (source_child == null || target_child == null) {
        return false;
      }
      target.transform.parent = source_child;
      target.transform.localRotation = Quaternion.identity;
      target.transform.localPosition = Vector3.zero;
      Vector3 ss = source_child.localScale;
      Vector3 scale = new Vector3(1 / ss.x, 1 / ss.y, 1 / ss.z);
      Vector3 relative_motion = (target_child.position - target.transform.position);
      target.transform.position -= relative_motion;
      //target.transform.localPosition = Vector3.Scale(target.transform.localPosition, scale);
      return true;
    }

    public static void MoveChildToNode(GameObject obj, string childname, string nodename)
    {
      Transform child = GetChildNodeByName(obj, childname);
      if (child == null) {
        DashFire.LogSystem.Debug("----not find child! {0} on {1}", childname, obj.name);
        return;
      }
      Transform togglenode = TriggerUtil.GetChildNodeByName(obj, nodename);
      if (togglenode == null) {
        DashFire.LogSystem.Debug("----not find node! {0} on {1}", nodename, obj.name);
        return;
      }
      child.parent = togglenode;
      child.localRotation = Quaternion.identity;
      child.localPosition = Vector3.zero;
    }


    public static BeHitState GetBeHitStateFromStr(string str)
    {
      BeHitState result = BeHitState.kDefault;
      if (str.Equals("kDefault")) {
        result = BeHitState.kDefault;
      } else if (str.Equals("kStand")) {
        result = BeHitState.kStand;
      } else if (str.Equals("kStiffness")) {
        result = BeHitState.kStiffness;
      } else if (str.Equals("kKnockDown")) {
        result = BeHitState.kKnockDown;
      } else if (str.Equals("kLauncher")) {
        result = BeHitState.kLauncher;
      }
      return result;
    }

    public static GameObject DrawCircle(Vector3 center, float radius, Color color, float circle_step = 0.05f)
    {
      GameObject obj = new GameObject();
      LineRenderer linerender = obj.AddComponent<LineRenderer>();
      linerender.SetWidth(0.05f, 0.05f);

      Shader shader = Shader.Find("Particles/Additive");
      if (shader != null) {
        linerender.material = new Material(shader);
      }
      linerender.SetColors(color, color);

      float step_degree = Mathf.Atan(circle_step / 2) * 2;
      int count = (int)(2 * Mathf.PI / step_degree);

      linerender.SetVertexCount(count + 1);

      for (int i = 0; i < count + 1; i++) {
        float angle = 2 * Mathf.PI / count * i;
        Vector3 pos = center + new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
        linerender.SetPosition(i, pos);
      }
      return obj;
    }

    public static bool IsPlayerSelf(GameObject obj)
    {
      return DashFire.LogicSystem.PlayerSelf == obj;
    }

    public static GameObject GetCameraObj()
    {
      GameObject gfx_root = GameObject.Find("GfxGameRoot");
      return gfx_root;
    }

    public static bool IsControledCamera(int control_id)
    {
      if (m_CurCameraControlId == CAMERA_NO_ONE_CONTROL) {
        return false;
      }
      if (control_id <= CAMERA_CONTROL_FAILED) {
        return false;
      }
      if (control_id == m_CurCameraControlId) {
        return true;
      }
      return false;
    }

    public static int ControlCamera(bool is_control, bool is_move_trigger = false)
    {
      if (m_IsMoveCameraTriggerContol && !is_move_trigger) {
        return CAMERA_CONTROL_FAILED;
      }
      GameObject gfx_root = GameObject.Find("GfxGameRoot");
      if (gfx_root != null) {
        if (is_control) {
          if (++m_CurCameraControlId < 0) {
            m_CurCameraControlId = CAMERA_CONTROL_START_ID;
          }
          if (is_move_trigger) {
            m_IsMoveCameraTriggerContol = true;
          }
          gfx_root.SendMessage("BeginShake");
        } else {
          m_CurCameraControlId = CAMERA_NO_ONE_CONTROL;
          m_IsMoveCameraTriggerContol = false;
          gfx_root.SendMessage("EndShake");
        }
        return m_CurCameraControlId;
      }
      return CAMERA_CONTROL_FAILED;
    }

    public static List<GameObject> GetRayHitObjects(int layermask, Vector3 touch_pos)
    {
      List<GameObject> result = new List<GameObject>();
      if (Camera.main == null) {
        return result;
      }
      Ray ray = Camera.main.ScreenPointToRay(touch_pos);
      RaycastHit[] rch = Physics.RaycastAll(ray, 200f, layermask);
      for (int i = 0; i < rch.Length; i++ )
      {
        if (null != rch[i].collider.gameObject)
        {
          result.Add(rch[i].collider.gameObject);
        }
      }
      /*
      foreach (RaycastHit node in rch) {
        if (null != node.collider.gameObject) {
          result.Add(node.collider.gameObject);
        }
      }*/
      return result;
    }

    public static void SetFollowEnable(bool is_enable)
    {
      GameObject gfx_root = GameObject.Find("GfxGameRoot");
      if (gfx_root != null) {
        gfx_root.SendMessage("SetFollowEnable", is_enable);
      }
    }

    public static List<GameObject> FindTargetInSector(Vector3 center,
                                                  float radius,
                                                  Vector3 direction,
                                                  Vector3 degreeCenter,
                                                  float degree)
    {
      List<GameObject> result = new List<GameObject>();
      int layermask = 1 << LayerMask.NameToLayer("Player") | 1 << LayerMask.NameToLayer("Monster");
      Collider[] colliders = Physics.OverlapSphere(center, radius, layermask);
      direction.y = 0;
      for (int i = 0; i < colliders.Length; i++)
      {
        GameObject obj = colliders[i].gameObject;
        Vector3 targetDir = obj.transform.position - degreeCenter;
        targetDir.y = 0;
        if (Mathf.Abs(Vector3.Angle(targetDir, direction)) <= degree)
        {
          result.Add(obj);
        }
      }
      /*
      foreach (Collider co in colliders) {
        GameObject obj = co.gameObject;
        Vector3 targetDir = obj.transform.position - degreeCenter;
        targetDir.y = 0;
        if (Mathf.Abs(Vector3.Angle(targetDir, direction)) <= degree) {
          result.Add(obj);
        }
      }*/
      return result;
    }

    public static GameObject GetObjectByPriority(GameObject source, List<GameObject> list, 
                                                 float distance_priority, float degree_priority,
                                                 float max_distance, float max_degree)
    {
      GameObject target = null;
      float max_score = -1;
      for (int i = 0; i < list.Count; i++)
      {
        float distance = (list[i].transform.position - source.transform.position).magnitude;
        float distance_score = 1 - distance / max_distance;
        Vector3 targetDir = list[i].transform.position - source.transform.position;
        float angle = Vector3.Angle(targetDir, source.transform.forward);
        float degree_score = 1 - angle / max_degree;
        float final_score = distance_score * distance_priority + degree_score * degree_priority;
        if (final_score > max_score)
        {
          target = list[i];
          max_score = final_score;
        }
      }
      /*
      foreach (GameObject obj in list) {
        float distance = (obj.transform.position - source.transform.position).magnitude;
        float distance_score = 1 - distance / max_distance;
        Vector3 targetDir = obj.transform.position - source.transform.position;
        float angle = Vector3.Angle(targetDir, source.transform.forward);
        float degree_score = 1 - angle / max_degree;
        float final_score = distance_score * distance_priority + degree_score * degree_priority;
        if (final_score > max_score) {
          target = obj;
          max_score = final_score;
        }
      }*/
      return target;
    }

    public static List<GameObject> FiltEnimy(GameObject source, List<GameObject> list)
    {
      List<GameObject> result = new List<GameObject>();
      for (int i = 0; i < list.Count; i++)
      {
        if (SkillDamageManager.IsEnemy(source, list[i]) && !IsObjectDead(list[i]))
        {
          result.Add(list[i]);
        }
      }
      /*
      foreach (GameObject obj in list) {
        if (SkillDamageManager.IsEnemy(source, obj) && !IsObjectDead(obj)) {
          result.Add(obj);
        }
      }*/
      return result;
    }

    public static List<GameObject> FiltByRelation(GameObject source, List<GameObject> list, DashFire.CharacterRelation relation, int signforskill)
    {
      List<GameObject> result = new List<GameObject>();
      foreach (GameObject obj in list) {
        if (GetRelation(source, obj, signforskill) == relation) {
          result.Add(obj);
        }
      }
      return result;
    }

    public static DashFire.CharacterRelation GetRelation(GameObject one, GameObject other, int signforskill)
    {
      DashFire.SharedGameObjectInfo obj_info = DashFire.LogicSystem.GetSharedGameObjectInfo(one);
      DashFire.SharedGameObjectInfo other_info = DashFire.LogicSystem.GetSharedGameObjectInfo(other);
      if (obj_info == null || other_info == null) {
        return DashFire.CharacterRelation.RELATION_INVALID;
      }
      if (obj_info.SummonOwnerActorId == other_info.m_ActorId) {
        return DashFire.CharacterRelation.RELATION_OWNER;
      } else if (CheckTwoIsOneProgeny(obj_info, other_info, signforskill)) {
        return DashFire.CharacterRelation.RELATION_FITSIGNSONS;
      } else {
        DashFire.CharacterRelation relation = DashFire.CharacterInfo.GetRelation(obj_info.CampId, other_info.CampId);
        return relation;
      }
    }
    private static bool CheckTwoIsOneProgeny(DashFire.SharedGameObjectInfo one, DashFire.SharedGameObjectInfo two, int signforskill)
    {
      if (two.SummonOwnerActorId == one.m_ActorId && two.SignForSkill == signforskill) {
        return true;
      } else {
        DashFire.SharedGameObjectInfo twopar = DashFire.LogicSystem.GetSharedGameObjectInfo(two.SummonOwnerActorId);
        if (twopar == null) {
          return false;
        } else {
          return CheckTwoIsOneProgeny(one, twopar, signforskill);
        }
      }
    }
    public static bool IsObjectDead(GameObject obj)
    {
      DashFire.SharedGameObjectInfo si = DashFire.LogicSystem.GetSharedGameObjectInfo(obj);
      if (si.Blood <= 0) {
        return true;
      } else {
        return false;
      }
    }

    public static float ConvertToSecond(long delta)
    {
      return delta / 1000000.0f;
    }

    public static StateImpact ParseStateImpact(ScriptableData.CallData stCall)
    {
      StateImpact stateimpact = new StateImpact();
      stateimpact.m_State = GetBeHitStateFromStr(stCall.GetParamId(0));
      for (int i = 1; i < stCall.GetParamNum(); i = i+2) {
        ImpactData im = new ImpactData();
        im.ImpactId = int.Parse(stCall.GetParamId(i));
        if (stCall.GetParamNum() > i + 1) {
          im.RemainTime = int.Parse(stCall.GetParamId(i + 1));
        } else {
          im.RemainTime = -1;
        }
        stateimpact.m_Impacts.Add(im);
      }
      return stateimpact;
    }

    public static void SetObjVisible(GameObject obj, bool isShow)
    {
      Renderer[] renders = obj.GetComponentsInChildren<Renderer>();
      for (int i = 0; i < renders.Length; i++)
      {
        renders[i].enabled = isShow;
      }
      /*
      foreach (Renderer r in renders) {
        r.enabled = isShow;
      }*/
    }

    public static void UpdateObjTransform(GameObject obj)
    {
      if (obj == null) {
        return;
      }
      DashFire.LogicSystem.NotifyGfxUpdatePosition(obj, obj.transform.position.x, obj.transform.position.y, obj.transform.position.z,
                                                   0, (float)(obj.transform.rotation.eulerAngles.y * Math.PI / 180.0f), 0);
    }

    public static void UpdateObjWantDir(GameObject obj)
    {
      if (obj == null) {
        return;
      }
      DashFire.LogicSystem.NotifyGfxChangedWantDir(obj, (float)(obj.transform.rotation.eulerAngles.y * Math.PI / 180.0f));
    }

    public static void UpdateObjPosition(GameObject obj)
    {
      if (obj == null) {
        return;
      }
      DashFire.LogicSystem.NotifyGfxUpdatePosition(obj, obj.transform.position.x, obj.transform.position.y, obj.transform.position.z);
    }

    public static void MoveObjTo(GameObject obj, Vector3 position)
    {
      CharacterController ctrl = obj.GetComponent<CharacterController>();
      if (null != ctrl && ctrl.enabled) {
        ctrl.Move(position- obj.transform.position);
      } else {
        obj.transform.position = position;
      }
    }

    public static float GetObjFaceDir(GameObject obj)
    {
      return obj.transform.rotation.eulerAngles.y * UnityEngine.Mathf.PI / 180.0f;
    }

    public static void MoveChildToNode(int actorid, string childname, string nodename)
    {
      GameObject obj = DashFire.LogicSystem.GetGameObject(actorid);
      MoveChildToNode(obj, childname, nodename);
    }

    public static float GetHeightWithGround(GameObject obj)
    {
      return GetHeightWithGround(obj.transform.position);
    }

    public static float GetHeightWithGround(Vector3 pos)
    {
      if (Terrain.activeTerrain != null) {
        return pos.y - Terrain.activeTerrain.SampleHeight(pos);
      } else {
        RaycastHit hit;
        Vector3 higher_pos = pos;
        higher_pos.y += 2;
        if (Physics.Raycast(higher_pos, -Vector3.up, out hit, m_RayCastMaxDistance, m_TerrainLayer)) {
          return pos.y - hit.point.y;
        }
        return m_RayCastMaxDistance;
      }
    }

    public static bool IsCollideGrounded(CharacterController controller)
    {
      if (controller == null) {
        return false;
      }
      if ((controller.collisionFlags & CollisionFlags.Below) != 0) {
        return true;
      }
      return false;
    }

    public static Vector3 GetGroundPos(Vector3 pos)
    {
      Vector3 sourcePos = pos;
      RaycastHit hit;
      pos.y += 2;
      if (Physics.Raycast(pos, -Vector3.up, out hit, m_RayCastMaxDistance, m_TerrainLayer)) {
        sourcePos.y = hit.point.y;
      }
      return sourcePos;
    }

    public static bool FloatEqual(float a, float b)
    {
      if (Math.Abs(a - b) <= 0.0001) {
        return true;
      }
      return false;
    }

    public static GameObject GetFinalOwner(GameObject source, int skillid, out int final_skillid)
    {
      DashFire.SharedGameObjectInfo result = null;
      DashFire.SharedGameObjectInfo si = DashFire.LogicSystem.GetSharedGameObjectInfo(source);
      final_skillid = skillid;
      int break_protector = 10000;
      while (si != null) {
        result = si;
        if (si.SummonOwnerActorId >= 0) {
          final_skillid = si.SummonOwnerSkillId;
          si = DashFire.LogicSystem.GetSharedGameObjectInfo(si.SummonOwnerActorId);
        } else {
          break;
        }
        if (break_protector-- <= 0) {
          break;
        }
      }
      if (result != null) {
        return DashFire.LogicSystem.GetGameObject(result.m_ActorId);
      } else {
        return source;
      }
    }

    public static bool IsTouching(GameObject obj)
    {
      DashFire.SharedGameObjectInfo share_info = DashFire.LogicSystem.GetSharedGameObjectInfo(obj);
      if (share_info == null || !share_info.IsTouchDown) {
        return false;
      }
      return true;
    }

    public static Vector3 GetTouchPos(GameObject obj)
    {
      Vector3 pos = Vector3.zero;
      pos.x = DashFire.GfxSystem.GetTouchPointX();
      pos.y = DashFire.GfxSystem.GetTouchPointY();
      pos.z = DashFire.GfxSystem.GetTouchPointZ();
      Ray ray = Camera.main.ScreenPointToRay(pos);
      int layermask = 1 << LayerMask.NameToLayer("Terrains");
      RaycastHit[] rch = Physics.RaycastAll(ray, 200f, layermask);
      if (rch.Length > 0) {
        return rch[0].point;
      } else {
        float height = ray.origin.y - obj.transform.position.y;
        float distance = Math.Abs(height * ray.direction.magnitude / ray.direction.y);
        Vector3 height_pos = ray.GetPoint(distance);
        return height_pos;
      }
    }


    public static bool NeedCalculateNpcDropPoint(GameObject startgo, GameObject endgo, out Vector3 newpos)
    {
      if (startgo == null || endgo == null) {
        newpos = Vector3.zero;
        return false;
      }
      float scale = endgo.transform.localScale.x >= endgo.transform.localScale.z ? endgo.transform.localScale.x : endgo.transform.localScale.z;
      CharacterController charContr = endgo.GetComponent<CharacterController>();
      if (charContr != null) {
        newpos = Vector3.zero;
        if (CalculateNpcDropPoint(startgo.transform.position, endgo.transform.position, charContr.radius * scale, 0, out newpos) == 0) {
          return false;
        } else {
          return true;
        }
      } else {
        newpos = Vector3.zero;
        return false;
      }
    }

    private static int CalculateNpcDropPoint(Vector3 heropos, Vector3 npcpos, float radius, int count, out Vector3 newpos)
    {
      if (count > 10) {
        newpos = heropos;
        return count;
      }
      RaycastHit hit;
      Collider[] colliderarry = Physics.OverlapSphere(npcpos, radius, 1 << LayerMask.NameToLayer("AirWall"));
      if (colliderarry != null && colliderarry.Length > 0) {
        Transform tf = colliderarry[0].transform;
        Vector3 ccp = tf.position;
        if (Physics.Linecast(heropos, ccp, out hit, 1 << LayerMask.NameToLayer("AirWall"))) {
          float angle = Vector3.Angle(hit.normal, new Vector3(npcpos.x - ccp.x, npcpos.y - ccp.y, npcpos.z - ccp.z));
          if (angle > 90) {
            angle = 180 - angle;
          }
          float d = Mathf.Cos(angle * Mathf.Deg2Rad) * Vector3.Distance(ccp, npcpos);
          Vector3 apos = new Vector3(d * hit.normal.x + npcpos.x, d * hit.normal.y + npcpos.y, d * hit.normal.z + npcpos.z);
          if (((ccp.x - apos.x) * hit.normal.x + (ccp.y - apos.y) * hit.normal.y + (ccp.z - apos.z) * hit.normal.z) != 0) {
            apos = new Vector3(npcpos.x - d * hit.normal.x, npcpos.y - d * hit.normal.y, npcpos.z - d * hit.normal.z);
          }
          Vector2 normal;
          if ((hit.normal.x * tf.forward.x + hit.normal.y * tf.forward.y + hit.normal.z * tf.forward.z) == 0) {
            d = Mathf.Sqrt(tf.right.x * tf.right.x + tf.right.z * tf.right.z);
            normal = new Vector2(tf.right.x / d, tf.right.z / d);
            if (Vector3.Angle(hit.normal, tf.right) > 5f) {
              normal *= -1;
            }
            d = tf.localScale.x / 2;
          } else {
            d = Mathf.Sqrt(tf.forward.x * tf.forward.x + tf.forward.z * tf.forward.z);
            normal = new Vector2(tf.forward.x/d, tf.forward.z/d);
            if (Vector3.Angle(hit.normal, tf.forward) > 5f) {
              normal *= -1;
            }
            d = tf.localScale.z / 2;
           }
          d = (d + radius + 0.01f);
          newpos = new Vector3(normal.x * d + hit.point.x, npcpos.y, normal.y * d + hit.point.z);
          return CalculateNpcDropPoint(heropos, newpos, radius, count + 1, out newpos);
        } else {
          Debug.LogError("CalculateNpcDropPoint");
          newpos = Vector3.zero;
          return 0;
        }
      } else {
        //NPC与阻挡不相交
        if (Physics.Linecast(heropos, npcpos, out hit, 1 << LayerMask.NameToLayer("AirWall"))) {
          //NPC在阻挡外
          float newr = radius + 0.01f;
          newpos = new Vector3(newr * hit.normal.x + hit.point.x, newr * hit.normal.y + hit.point.y, newr * hit.normal.z + hit.point.z);
          return CalculateNpcDropPoint(heropos, newpos, radius, count + 1, out newpos);
        } else {
          //NPC在阻挡内，理想情况
          newpos = npcpos;
          return count;
        }
      }
    }
  }
}
