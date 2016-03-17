using DashFireSpatial;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ScriptRuntime;
using System.Collections.Generic;

namespace TestSpatialSystem
{
    
    
    /// <summary>
    ///This is a test class for CollideTest and is intended
    ///to contain all CollideTest Unit Tests
    ///</summary>
  [TestClass()]
  public class CollideTest
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
    ///A test for GetCollidePoint
    ///</summary>
    [TestMethod()]
    public void GetCollidePointTest()
    {
      Collide target = new Collide();
      Vector3 start = new Vector3(30, 0, 50);
      Vector3 end = new Vector3(80, 0, 50);
      Line line = new Line(start, end);
      Shape shape = new Rect(new Vector3(50, 0, 50), 20, 20);
      List<Vector3> actual;

      shape.IdenticalTransform();
      actual = target.GetCollidePoint(line, shape);
      Assert.AreEqual(actual.Count, 2);
    }

    /// <summary>
    ///A test for GetHitPoint
    ///</summary>
    [TestMethod()]
    [DeploymentItem("SpatialSystem.dll")]
    public void GetHitPointTest()
    {
      Collide_Accessor target = new Collide_Accessor(); 
      Line one = new Line(new Vector3(10, 0, 10), new Vector3(30, 0, 10)); 
      Line two = new Line(new Vector3(20, 0, 5), new Vector3(20, 0, 15));
      Vector3 hitpos = new Vector3(); 
      bool actual;
      actual = target.GetHitPoint(one, two, out hitpos);
      Assert.AreEqual(actual, true);
      Assert.AreEqual(hitpos.X, 20);
      Assert.AreEqual(hitpos.Z, 10);

      one= new Line(new Vector3(10, 0, 10), new Vector3(30, 0, 30));
      two = new Line(new Vector3(20, 0, 20), new Vector3(40, 0, 40));
      actual = target.GetHitPoint(one, two, out hitpos);
      Assert.AreEqual(actual, true);
      Assert.AreEqual(hitpos.X, 20);
      Assert.AreEqual(hitpos.Z, 20);

      one = new Line(new Vector3(30, 0, 30), new Vector3(50, 0, 50));
      two = new Line(new Vector3(20, 0, 20), new Vector3(40, 0, 40));
      actual = target.GetHitPoint(one, two, out hitpos);
      Assert.AreEqual(actual, true);
      Assert.AreEqual(hitpos.X, 40);
      Assert.AreEqual(hitpos.Z, 40);

      one = new Line(new Vector3(10, 0, 10), new Vector3(30, 0, 10));
      two = new Line(new Vector3(20, 0, 10), new Vector3(40, 0, 10));
      actual = target.GetHitPoint(one, two, out hitpos);
      Assert.AreEqual(actual, true);
      Assert.AreEqual(hitpos.X, 20);
      Assert.AreEqual(hitpos.Z, 10);

      one = new Line(new Vector3(10, 0, 10), new Vector3(10, 0, 30));
      two = new Line(new Vector3(10, 0, 20), new Vector3(10, 0, 40));
      actual = target.GetHitPoint(one, two, out hitpos);
      Assert.AreEqual(actual, true);
      Assert.AreEqual(hitpos.X, 10);
      Assert.AreEqual(hitpos.Z, 20);
    }
  }
}
