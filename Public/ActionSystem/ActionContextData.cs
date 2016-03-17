using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DashFire
{
  ///
  /// @说明
  ///   动作中伴随移动时，移动的上下文数据定义
  ///
  public class ActionMoveData
  {
    public long StartTime = 0;
    public float MoveTime = 0;
    public float VX = 0;
    public float VY = 0;
    public float VZ = 0;
    public float AX = 0;
    public float AY = 0;
    public float AZ = 0;
    public ScriptRuntime.Vector3 StartPos = new ScriptRuntime.Vector3();
    public ScriptRuntime.Vector3 TargetPos = new ScriptRuntime.Vector3();
    public bool HasBlock = false;
    public ScriptRuntime.Vector3 BlockPos = new ScriptRuntime.Vector3();
  }
  ///
  /// @说明
  ///   技能中，用做标记的上下文数据定义
  ///
  public class ActionMarkData
  {
    public bool m_isPlayEffect = true;
    public bool m_isCall = false;
    public bool m_isPlayAnimation = false;
  }
}
