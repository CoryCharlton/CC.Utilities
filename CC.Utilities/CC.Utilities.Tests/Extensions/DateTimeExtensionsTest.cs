using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CC.Utilities.Tests
{
    /// <summary>
    ///This is a test class for DateTimeExtensionsTest and is intended
    ///to contain all DateTimeExtensionsTest Unit Tests
    ///</summary>
    [TestClass]
    public class DateTimeExtensionsTest
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
        ///A test for ToStartDate
        ///</summary>
        [TestMethod]
        public void ToStartDateTest()
        {
            DateTime dateTime = DateTime.Now;
            DateTime expected = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, 0);
            DateTime actual = dateTime.ToStartDate();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ToFileDateString
        ///</summary>
        [TestMethod]
        public void ToFileDateStringTest()
        {
            DateTime dateTime = DateTime.Now;
            string expected = dateTime.ToString("yyyyMMdd");
            string actual = dateTime.ToFileDateString();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ToEndDate
        ///</summary>
        [TestMethod]
        public void ToEndDateTest()
        {
            DateTime dateTime = DateTime.Now;
            DateTime expected = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59, 999);
            DateTime actual = dateTime.ToEndDate();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ToCommonDateString
        ///</summary>
        [TestMethod]
        public void ToCommonDateStringTest()
        {
            DateTime dateTime = DateTime.Now;
            string expected = dateTime.ToString("MM/dd/yyyy");
            string actual = dateTime.ToCommonDateString();
            Assert.AreEqual(expected, actual);
        }
    }
}
