﻿using System.Collections.Generic;
using CC.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CC.Utilities.Tests
{
    /// <summary>
    ///This is a test class for ObjectExtensionsTest and is intended
    ///to contain all ObjectExtensionsTest Unit Tests
    ///</summary>
    [TestClass]
    public class ObjectExtensionsTest
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
        ///A test for ToXml
        ///</summary>
        [TestMethod()]
        public void ToXmlTest()
        {
            const int o = 1;
            const string expected = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<int>1</int>";
            string actual = o.ToXml();
            Assert.AreEqual(expected, actual);
        }
    }
}
