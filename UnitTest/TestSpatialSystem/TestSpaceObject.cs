using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DashFireSpatial;
using ScriptRuntime;

namespace DashFireSpatial
{
  class TestSpaceObject : ISpaceObject
  {
    public TestSpaceObject(uint id)
    {
      id_ = id;
    }

    public uint GetID()
    {
      return id_;
    }

    public SpatialObjType GetObjType()
    {
      return obj_type_;
    }

    public void SetObjType(SpatialObjType ot)
    {
      obj_type_ = ot;
    }

    public Vector3 GetPosition()
    {
      return pos_;
    }

    public double GetSightRadius() { return sight_radius_; }
    public void SetSightRadius(double radius) { sight_radius_ = radius; }
    public double GetRadius() { return collide_shape_.GetRadius(); }
    public void SetCampID(int campid) { camp_id_ = campid; }
    public int GetCampID() { return camp_id_; }
    public Vector3 GetVelocity() { return new Vector3(); }
    public bool IsAvoidable() { return false; }
    public double GetFaceDirection()
    {
      return direction_;
    }

    public Shape GetCollideShape()
    {
      return collide_shape_;
    }

    public List<ISpaceObject> GetCollideObjects()
    {
      return collide_objects_;
    }

    public void OnCollideObject(ISpaceObject obj)
    {
      collide_objects_.Add(obj);
    }

    public void OnDepartObject(ISpaceObject obj)
    {
      collide_objects_.Remove(obj);
    }

    public bool CanCollideWith(ISpaceObject obj)
    {
      return true;
    }

    public Vector3 GetOldPosition() { return old_pos_; }
    public void SetCellPos(CellPos pos) { cell_pos_ = pos; }
    public CellPos GetCellPos() { return cell_pos_; }
    public CellPos GetZonePos() { return zone_pos_; }
    public CellPos GetLastZonePos() { return last_zone_pos_; }
    public void SetZonePos(CellPos pos)
    {
      if (zone_pos_.row != pos.row || zone_pos_.col != pos.col) {
        last_zone_pos_ = zone_pos_;
      }
      zone_pos_ = pos;
    }

    public void SetPosition(Vector3 pos)
    {
      old_pos_ = pos_;
      pos_ = pos;
    }
    public void SetFaceDirection(double dict) { direction_ = dict; }
    public void SetCollideShape(Shape s) { collide_shape_ = s; }

    public bool IsMoving { set; get; }
    public Vector3 Position
    {
      set { pos_ = value; }
      get { return pos_; }
    }
    // private attributes-----------------------------------------------------
    private uint id_;
    private double sight_radius_;
    private int camp_id_;
    private Shape collide_shape_ = null;
    private Vector3 pos_ = new Vector3(0, 0, 0);
    private Vector3 old_pos_ = new Vector3();
    private double direction_ = 0;
    private List<ISpaceObject> collide_objects_ = new List<ISpaceObject>();
    private CellPos cell_pos_;
    private CellPos zone_pos_;
    private CellPos last_zone_pos_ = new CellPos(-1, -1);
    private SpatialObjType obj_type_ = SpatialObjType.kUser;
  }
}
