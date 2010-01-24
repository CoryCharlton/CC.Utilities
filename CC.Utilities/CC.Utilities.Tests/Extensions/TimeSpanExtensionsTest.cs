using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CC.Utilities.Tests
{
    /// <summary>
    ///This is a test class for TimeSpanExtensionsTest and is intended
    ///to contain all TimeSpanExtensionsTest Unit Tests
    ///</summary>
    [TestClass]
    public class TimeSpanExtensionsTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

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
        ///A test for ToFriendlyString
        ///</summary>
        [TestMethod]
        public void ToFriendlyStringTest()
        {
            TimeSpan timeSpan = new TimeSpan(0, 13, 25, 54, 873);
            const string expected1 = "13:25:54";
            const string expected2 = "13:25:54.873";
            string actual1 = timeSpan.ToFriendlyString(false);
            string actual2 = timeSpan.ToFriendlyString(true);
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }
    }
}
