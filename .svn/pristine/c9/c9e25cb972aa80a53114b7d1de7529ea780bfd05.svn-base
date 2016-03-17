using DashFireSpatial;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestSpatialSystem
{
    
    
    /// <summary>
    ///This is a test class for AOIManagerTest and is intended
    ///to contain all AOIManagerTest Unit Tests
    ///</summary>
  [TestClass()]
  public class AOIManagerTest
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
    ///A test for GetAroundZone
    ///</summary>
    [TestMethod()]
    public void GetAroundZoneTest()
    {
      AOIManager target = new AOIManager();
      target.Init(400, 400, 20, 20);
      CellPos zone_pos = new CellPos();
      zone_pos.row = 5;
      zone_pos.col = 5;
      Zone center = target.GetZone(zone_pos);
      int depth = 1;
      List<Zone> actual;
      actual = target.GetAroundZone(center, depth);
      Assert.AreEqual(actual.Count, 1);

      depth = 2;
      actual = target.GetAroundZone(center, depth);
      Assert.AreEqual(actual.Count, 9);

      depth = 3;
      actual = target.GetAroundZone(center, depth);
      Assert.AreEqual(actual.Count, 25);
    }

  }
}
