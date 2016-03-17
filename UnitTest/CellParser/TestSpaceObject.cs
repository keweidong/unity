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

    public double GetRadius() { return collide_shape_.GetRadius(); }
    public Vector3 GetVelocity() { return new Vector3(); }
    public bool IsAvoidable() { return false; }

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

    public object RealObject
    {
      get
      {
        return this;
      }
    }
    
    public void SetPosition(Vector3 pos)
    {
      old_pos_ = pos_;
      pos_ = pos;
    }
    public void SetFaceDirection(double dict)
    {
      direction_ = dict;
      cos_dir_ = Math.Cos(direction_);
      sin_dir_ = Math.Sin(direction_);
    }
    public void SetCollideShape(Shape s) { collide_shape_ = s; }

    public double GetFaceDirection()
    {
      return direction_;
    }
    public double CosDir
    {
      get { return cos_dir_; }
    }
    public double SinDir
    {
      get { return sin_dir_; }
    }

    public Vector3 Position
    {
      set { pos_ = value; }
      get { return pos_; }
    }
    // private attributes-----------------------------------------------------
    private uint id_;
    private Shape collide_shape_ = new Circle(new Vector3(0, 0, 0), 2);
    private Vector3 pos_ = new Vector3(0, 0, 0);
    private Vector3 old_pos_ = new Vector3();
    private double direction_ = 0;
    private double cos_dir_ = 1;
    private double sin_dir_ = 0;
    private List<ISpaceObject> collide_objects_ = new List<ISpaceObject>();
    private SpatialObjType obj_type_ = SpatialObjType.kUser;
  }
}
