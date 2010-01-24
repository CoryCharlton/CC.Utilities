using CC.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace CC.Utilities.Tests
{
    /// <summary>
    ///This is a test class for ImageExtensionsTest and is intended
    ///to contain all ImageExtensionsTest Unit Tests
    ///</summary>
    [TestClass]
    public class ImageExtensionsTest
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
        ///A test for GetRectangle
        ///</summary>
        [TestMethod]
        public void GetRectangleTest()
        {
            using (Image image = new Bitmap(250, 250))
            {
                Rectangle expected = new Rectangle(0, 0, 250, 250);
                Rectangle actual = image.GetRectangle();
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
