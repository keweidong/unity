using DashFireSpatial;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestSpatialSystem
{
    
    
    /// <summary>
    ///This is a test class for CellManagerTest and is intended
    ///to contain all CellManagerTest Unit Tests
    ///</summary>
  [TestClass()]
  public class CellManagerTest
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
    ///A test for Save
    ///</summary>
    [TestMethod()]
    public void SaveTest()
    {
      CellManager target = new CellManager();
      target.Init(100, 100, 5f);
      string filename = "D:/tmp/blockinfo.map";
      bool result = target.Save(filename);
      Assert.AreEqual(result, true);
      int a, b;
      target.GetCell(new ScriptRuntime.Vector3(100, 0, 100), out a, out b);
      Assert.AreEqual(a, 11);
      Assert.AreEqual(b, 13);
    }
  }
}
