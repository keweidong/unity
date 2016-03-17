using DashFireSpatial;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ScriptRuntime;
using System.Collections.Generic;

namespace TestSpatialSystem
{
    
    
    /// <summary>
    ///This is a test class for RectTest and is intended
    ///to contain all RectTest Unit Tests
    ///</summary>
  [TestClass()]
  public class RectTest
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
    ///A test for Rect Constructor
    ///</summary>
    [TestMethod()]
    public void RectConstructorTest()
    {
      Vector3 pos = new Vector3(0, 0 , 5);
      double width = 2F;
      double height = 10F;
      Rect target = new Rect(pos, width, height);
      target.IdenticalTransform();
      List<Vector3> vertexs = target.world_vertex();
      Assert.AreEqual(vertexs.Count, 4);
      Assert.AreEqual(vertexs[0].X, -1);
      Assert.AreEqual(vertexs[0].Z, 10);
      Assert.AreEqual(vertexs[1].X, -1);
      Assert.AreEqual(vertexs[1].Z, 0);
      Assert.AreEqual(vertexs[2].X, 1);
      Assert.AreEqual(vertexs[2].Z, 0);
      Assert.AreEqual(vertexs[3].X, 1);
      Assert.AreEqual(vertexs[3].Z, 10);
    }
  }
}
