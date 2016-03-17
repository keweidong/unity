using DashFireSpatial;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ScriptRuntime;
using System.Collections.Generic;

namespace TestSpatialSystem
{
    
    
    /// <summary>
    ///This is a test class for SpatialSystemTest and is intended
    ///to contain all SpatialSystemTest Unit Tests
    ///</summary>
  [TestClass()]
  public class SpatialSystemTest
  {

    private TestContext testContextInstance;

    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
    ///</summary>
    public TestContext TestContext
    {
      get
      {
        return testContextInstance;
      }
      set
      {
        testContextInstance = value;
      }
    }

    #region Additional test attributes
    // 
    //You can use the following additional attributes as you write your tests:
    //
    //Use ClassInitialize to run code before running the first test in the class
    //[ClassInitialize()]
    //public static void MyClassInitialize(TestContext testContext)
    //{
    //}
    //
    //Use ClassCleanup to run code after all tests in a class have run
    //[ClassCleanup()]
    //public static void MyClassCleanup()
    //{
    //}
    //
    //Use TestInitialize to run code before running each test
    //[TestInitialize()]
    //public void MyTestInitialize()
    //{
    //}
    //
    //Use TestCleanup to run code after each test has run
    //[TestCleanup()]
    //public void MyTestCleanup()
    //{
    //}
    //
    #endregion


    /// <summary>
    ///A test for GetObjectInShape
    ///</summary>
    [TestMethod()]
    public void GetObjectInShapeTest()
    {
      SpatialSystem target = new SpatialSystem(); // TODO: Initialize to an appropriate value

      TestSpaceObject obj1 = new TestSpaceObject(1);
      obj1.SetPosition(new Vector3(20, 0, 20));
      obj1.SetFaceDirection(0);
      obj1.SetCollideShape(new Rect(10, 10));

      target.AddObj(obj1);
      target.Tick();

      Vector3 pos = new Vector3(10, 0, 30); // TODO: Initialize to an appropriate value
      double direction = 0F; // TODO: Initialize to an appropriate value
      Shape area = new Rect(10, 10);
      List<ISpaceObject> actual;

      // 左下角碰撞
      actual = target.GetObjectInShape(pos, direction, area);
      Assert.AreEqual(actual.Count, 1);

      // 不碰撞
      pos.X = 9.9f;
      actual = target.GetObjectInShape(pos, direction, area);
      Assert.AreEqual(actual.Count, 0);

      // 在左上角碰撞到
      pos.X = 10;
      pos.Z = 10;
      actual = target.GetObjectInShape(pos, direction, area);
      Assert.AreEqual(actual.Count, 1);

      // 在右上角碰撞到
      pos.X = 30;
      pos.Z = 10;
      actual = target.GetObjectInShape(pos, direction, area);
      Assert.AreEqual(actual.Count, 1);

      // 在右下角碰撞到
      pos.X = 30;
      pos.Z = 30;
      actual = target.GetObjectInShape(pos, direction, area);
      Assert.AreEqual(actual.Count, 1);
    }

    /// <summary>
    ///A test for GetObjectInShape
    ///</summary>
    [TestMethod()]
    public void ObjectCollideTest()
    {
      SpatialSystem target = new SpatialSystem(); // TODO: Initialize to an appropriate value

      TestSpaceObject obj1 = new TestSpaceObject(1);
      obj1.SetPosition(new Vector3(20, 0, 20));
      obj1.SetFaceDirection(0);
      obj1.SetCollideShape(new Circle(new Vector3(), 5));

      TestSpaceObject obj2 = new TestSpaceObject(2);
      obj2.SetPosition(new Vector3(10, 0, 20));
      obj2.SetFaceDirection(0);
      obj2.SetCollideShape(new Circle(new Vector3(), 5));
      obj2.SetObjType(SpatialObjType.kBullet);
      target.AddObj(obj1);
      target.AddObj(obj2);

      //左边边界碰撞
      target.Tick();
      List<ISpaceObject> actual = obj1.GetCollideObjects();
      Assert.AreEqual(actual.Count, 0);

      //左边相交碰撞
      obj2.SetPosition(new Vector3(10.1f, 0, 20));
      target.Tick();
      actual = obj1.GetCollideObjects();
      Assert.AreEqual(actual.Count, 1);

      //右边相交碰撞
      obj2.SetPosition(new Vector3(29.9f, 0, 20));
      target.Tick();
      actual = obj1.GetCollideObjects();
      Assert.AreEqual(actual.Count, 1);
      
      //上边相交碰撞
      obj2.SetPosition(new Vector3(20f, 0, 10.1f));
      target.Tick();
      actual = obj1.GetCollideObjects();
      Assert.AreEqual(actual.Count, 1);

      //下边相交碰撞
      obj2.SetPosition(new Vector3(20f, 0, 29.9f));
      target.Tick();
      actual = obj1.GetCollideObjects();
      Assert.AreEqual(actual.Count, 1);

      //左上边相交碰撞
      obj2.SetPosition(new Vector3(11f, 0, 11f));
      target.Tick();
      actual = obj1.GetCollideObjects();
      Assert.AreEqual(actual.Count, 1);

      //左下边相交碰撞
      obj2.SetPosition(new Vector3(29f, 0, 29f));
      target.Tick();
      actual = obj1.GetCollideObjects();
      Assert.AreEqual(actual.Count, 1);
    }

    /// <summary>
    ///A test for GetObjectInArea
    ///</summary>
    [TestMethod()]
    public void GetObjectInAreaTestRect()
    {
      SpatialSystem target = new SpatialSystem(); // TODO: Initialize to an appropriate value

      TestSpaceObject obj1 = new TestSpaceObject(1);
      obj1.SetPosition(new Vector3(20, 0, 20));
      obj1.SetFaceDirection(0);
      obj1.SetCollideShape(new Circle(new Vector3(0, 0, 0), 0));

      target.AddObj(obj1);

      TestSpaceObject obj2 = new TestSpaceObject(2);
      obj2.SetPosition(new Vector3());
      obj2.SetFaceDirection(0);
      obj2.SetCollideShape(new Circle(new Vector3(0, 0, 0), 0));
      target.AddObj(obj2);
      target.Tick();

      Shape area = new Rect(new Vector3(0, 0, 5), 2, 10);
      List<ISpaceObject> actual;

      obj2.SetPosition(new Vector3(20, 0, 9));
      actual = target.GetObjectInShape(obj2.GetPosition(), obj2.GetFaceDirection(), area);
      Assert.AreEqual(actual.Count, 1);

      obj2.SetPosition(new Vector3(20, 0, 10));
      actual = target.GetObjectInShape(obj2.GetPosition(), obj2.GetFaceDirection(), area);
      Assert.AreEqual(actual.Count, 2);
    }

    /// <summary>
    ///A test for GetObjectInArea
    ///</summary>
    [TestMethod()]
    public void GetObjectInAreaTestRotate()
    {
      SpatialSystem target = new SpatialSystem(); // TODO: Initialize to an appropriate value

      TestSpaceObject obj1 = new TestSpaceObject(1);
      obj1.SetPosition(new Vector3(20, 0, 20));
      obj1.SetFaceDirection(0);
      obj1.SetCollideShape(new Rect(10, 10));

      target.AddObj(obj1);
      target.Tick();

      Vector3 pos = new Vector3(9.8f, 0, 20f); // TODO: Initialize to an appropriate value
      double direction = 0; // TODO: Initialize to an appropriate value
      Shape area = new Rect(10, 10);
      List<ISpaceObject> actual;

      // 左侧不碰撞
      actual = target.GetObjectInShape(pos, direction, area);
      Assert.AreEqual(actual.Count, 0);

      // 左侧旋转才会碰撞到
      direction = Math.PI / 4;
      actual = target.GetObjectInShape(pos, direction, area);
      Assert.AreEqual(actual.Count, 1);
    }

    /// <summary>
    ///A test for GetObjectInArea
    ///</summary>
    [TestMethod()]
    public void GetObjectInAreaTestDifferentPos()
    {
      SpatialSystem target = new SpatialSystem(); // TODO: Initialize to an appropriate value

      // 第一象限
      Vector3 pos = new Vector3(0f, 0, 0f);
      double direction = 0;
      Shape area = new Rect(10, 10);
      List<ISpaceObject> actual;

      // 第一象限
      TestSpaceObject obj1 = new TestSpaceObject(1);
      obj1.SetPosition(new Vector3(30, 0, 30));
      obj1.SetFaceDirection(Math.PI / 4);
      obj1.SetCollideShape(new Rect(2, 2));
      target.AddObj(obj1);
      target.Tick();

      pos.X = 23.9f;
      pos.Z = 30;
      actual = target.GetObjectInShape(pos, direction, area);
      Assert.AreEqual(actual.Count, 1);

      // 第二象限
      TestSpaceObject obj2 = new TestSpaceObject(2);
      obj2.SetPosition(new Vector3(30, 0, -30));
      obj2.SetFaceDirection(Math.PI / 4);
      obj2.SetCollideShape(new Rect(2, 2));
      target.AddObj(obj2);
      target.Tick();

      pos.X = 23.9f;
      pos.Z = -30;
      actual = target.GetObjectInShape(pos, direction, area);
      Assert.AreEqual(actual.Count, 1);

      // 第三象限
      TestSpaceObject obj3 = new TestSpaceObject(3);
      obj3.SetPosition(new Vector3(-30, 0, -30));
      obj3.SetFaceDirection(Math.PI / 4);
      obj3.SetCollideShape(new Rect(2, 2));
      target.AddObj(obj3);
      target.Tick();

      pos.X = -23.9f;
      pos.Z = -30;
      actual = target.GetObjectInShape(pos, direction, area);
      Assert.AreEqual(actual.Count, 1);

      // 第四象限
      TestSpaceObject obj4 = new TestSpaceObject(4);
      obj4.SetPosition(new Vector3(-30, 0, 30));
      obj4.SetFaceDirection(Math.PI / 4);
      obj4.SetCollideShape(new Rect(2, 2));
      target.AddObj(obj4);
      target.Tick();

      pos.X = -23.9f;
      pos.Z = 30;
      actual = target.GetObjectInShape(pos, direction, area);
      Assert.AreEqual(actual.Count, 1);
    }

    /// <summary>
    ///A test for GetObjectInShape
    ///</summary>
    [TestMethod()]
    public void GetObjectInAreaTestMoreObjects()
    {
      SpatialSystem target = new SpatialSystem(); // TODO: Initialize to an appropriate value

      // 第一象限
      Vector3 pos = new Vector3(20, 0, 20);
      double direction = 0;
      Shape area = new Rect(10, 10);
      List<ISpaceObject> actual;

      TestSpaceObject obj1 = new TestSpaceObject(1);
      obj1.SetPosition(new Vector3(14, 0, 17));
      obj1.SetFaceDirection(Math.PI / 4);
      obj1.SetCollideShape(new Rect(2, 2));
      target.AddObj(obj1);

      TestSpaceObject obj2 = new TestSpaceObject(2);
      obj2.SetPosition(new Vector3(21, 0, 14));
      obj2.SetFaceDirection(Math.PI / 4);
      obj2.SetCollideShape(new Rect(2, 2));
      target.AddObj(obj2);

      TestSpaceObject obj3 = new TestSpaceObject(3);
      obj3.SetPosition(new Vector3(21, 0, 21));
      obj3.SetFaceDirection(Math.PI / 4);
      obj3.SetCollideShape(new Rect(2, 2));
      target.AddObj(obj3);

      TestSpaceObject obj4 = new TestSpaceObject(4);
      obj4.SetPosition(new Vector3(26, 0, 21));
      obj4.SetFaceDirection(Math.PI / 4);
      obj4.SetCollideShape(new Rect(2, 2));
      target.AddObj(obj4);
      target.Tick();

      actual = target.GetObjectInShape(pos, direction, area);
      Assert.AreEqual(actual.Count, 4);
    }


    /// <summary>
    ///A test for GetObjectInCircle
    ///</summary>
    [TestMethod()]
    public void GetObjectInCircleTest()
    {
      SpatialSystem target = new SpatialSystem(); // TODO: Initialize to an appropriate value

      TestSpaceObject obj1 = new TestSpaceObject(1);
      obj1.SetPosition(new Vector3(20, 0, 20));
      obj1.SetFaceDirection(0);
      obj1.SetCollideShape(new Rect(10, 10));
      target.AddObj(obj1);
      target.Tick();

      Vector3 pos = new Vector3(15, 0, 10f);
      List<ISpaceObject> actual;
      actual = target.GetObjectInCircle(pos, 5);
      Assert.AreEqual(actual.Count, 1);

      actual = target.GetObjectInCircle(new Vector3(10, 0, 10), 5);
      Assert.AreEqual(actual.Count, 0);

      actual = target.GetObjectInCircle(new Vector3(12.4f, 0, 12.4f), 5);
      Assert.AreEqual(actual.Count, 1);

      actual = target.GetObjectInCircle(new Vector3(10.1f, 0, 20), 5);
      Assert.AreEqual(actual.Count, 1);
    }

    /// <summary>
    ///A test for GetObjectCrossByLine
    ///</summary>
    [TestMethod()]
    public void GetObjectCrossByLineTest()
    {
      SpatialSystem target = new SpatialSystem();
      TestSpaceObject obj1 = new TestSpaceObject(1);
      obj1.SetPosition(new Vector3(20, 0, 20));
      obj1.SetFaceDirection(0);
      obj1.SetCollideShape(new Rect(20, 20));
      target.AddObj(obj1);
      target.Tick();

      List<ISpaceObject> actual;
      Vector3 start = new Vector3(20, 0, 20);
      Vector3 end = new Vector3(30, 0, 20);

      actual = target.GetObjectCrossByLine(start, end);
      Assert.AreEqual(actual.Count, 1);

      start = new Vector3(0, 0, 10);
      end = new Vector3(9.9f, 0, 10);
      actual = target.GetObjectCrossByLine(start, end);
      Assert.AreEqual(actual.Count, 0);

      start = new Vector3(0, 0, 9);
      end = new Vector3(11, 0, 9);
      actual = target.GetObjectCrossByLine(start, end);
      Assert.AreEqual(actual.Count, 0);

      start = new Vector3(0, 0, 0);
      end = new Vector3(13, 0, 13);
      actual = target.GetObjectCrossByLine(start, end);
      Assert.AreEqual(actual.Count, 1);

      start = new Vector3(20, 0, 0);
      end = new Vector3(0, 0, 20);
      actual = target.GetObjectCrossByLine(start, end);
      Assert.AreEqual(actual.Count, 1);

      start = new Vector3(19.5f, 0, 0);
      end = new Vector3(0, 0, 20);
      actual = target.GetObjectCrossByLine(start, end);
      Assert.AreEqual(actual.Count, 0);

      start = new Vector3(19.5f, 0, 0);
      end = new Vector3(12, 0, 11);
      actual = target.GetObjectCrossByLine(start, end);
      Assert.AreEqual(actual.Count, 1);
    }


    /// <summary>
    ///A test for GetObjectCrossByLine
    ///</summary>
    [TestMethod()]
    public void GetObjectCrossByLineTestMoreObj()
    {
      SpatialSystem target = new SpatialSystem();
      TestSpaceObject obj1 = new TestSpaceObject(1);
      obj1.SetPosition(new Vector3(20, 0, 20));
      obj1.SetFaceDirection(0);
      obj1.SetCollideShape(new Rect(20, 20));
      target.AddObj(obj1);

      TestSpaceObject obj2 = new TestSpaceObject(2);
      obj2.SetPosition(new Vector3(40, 0, 40));
      obj2.SetFaceDirection(0);
      obj2.SetCollideShape(new Circle(new Vector3(0, 0, 0), 5));
      target.AddObj(obj2);

      TestSpaceObject obj3 = new TestSpaceObject(3);
      obj3.SetPosition(new Vector3(41, 0, 41));
      obj3.SetFaceDirection(0);
      obj3.SetCollideShape(new Circle(new Vector3(0, 0, 0), 3));
      target.AddObj(obj3);
      target.Tick();

      List<ISpaceObject> actual;
      Vector3 start = new Vector3(20, 0, 20);
      Vector3 end = new Vector3(41, 0, 38);

      actual = target.GetObjectCrossByLine(start, end);
      Assert.AreEqual(actual.Count, 3);

      Assert.AreEqual(actual[0].GetID(), (uint)1);
      Assert.AreEqual(actual[1].GetID(), (uint)2);
      Assert.AreEqual(actual[2].GetID(), (uint)3);

      start = new Vector3(41, 0, 42);
      end = new Vector3(30, 0, 30);
      actual = target.GetObjectCrossByLine(start, end);
      Assert.AreEqual(actual.Count, 3);
      Assert.AreEqual(actual[0].GetID(), (uint)3);
      Assert.AreEqual(actual[1].GetID(), (uint)2);
      Assert.AreEqual(actual[2].GetID(), (uint)1);
    }

    /// <summary>
    ///A test for GetObjectCrossByLine
    ///</summary>
    [TestMethod()]
    public void GetObjectCrossByLineBlockTest()
    {
      SpatialSystem target = new SpatialSystem();
      target.Init("");

      CellManager cell_manager = target.GetCellManager();
      //float grid_height = cell_manager.GetGridHeight();
      float grid_height = 1;
      Vector3 center_pos = cell_manager.GetCellCenter(10, 10);
      cell_manager.SetCellStatus(10, 10, BlockType.STATIC_BLOCK);

      TestSpaceObject obj1 = new TestSpaceObject(1);
      obj1.SetPosition(new Vector3(center_pos.X + 10, 0, center_pos.Z));
      obj1.SetFaceDirection(0);
      obj1.SetCollideShape(new Rect(10, 10));
      target.AddObj(obj1);

      TestSpaceObject obj2 = new TestSpaceObject(2);
      obj2.SetPosition(new Vector3(center_pos.X - 10, 0, center_pos.Z));
      obj2.SetFaceDirection(0);
      obj2.SetCollideShape(new Rect(10, 10));
      target.AddObj(obj2);
      target.Tick();

      Vector3 line_start = new Vector3(center_pos.X - 30, 0, center_pos.Z - grid_height + 0.01f);
      Vector3 line_end = new Vector3(center_pos.X + 30, 0, center_pos.Z - grid_height + 0.01f);
      CellPos new_pos;
      cell_manager.GetCell(new Vector3(center_pos.X, 0, center_pos.Z - grid_height + 0.01f), out new_pos.row, out new_pos.col);
      Assert.AreEqual(new_pos.row, 10);
      Assert.AreEqual(new_pos.col, 10);
      List<ISpaceObject> result = target.GetObjectCrossByLine(line_start, line_end);
      Assert.AreEqual(result.Count, 1);

      line_start = new Vector3(center_pos.X - 30, 0, center_pos.Z - grid_height - 0.1f);
      line_end = new Vector3(center_pos.X + 30, 0, center_pos.Z - grid_height - 0.1f);
      result = target.GetObjectCrossByLine(line_start, line_end);
      Assert.AreEqual(result.Count, 2);
    }
  }
}
