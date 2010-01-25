using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CC.Utilities.Tests
{
    /// <summary>
    ///This is a test class for ArgumentTest and is intended
    ///to contain all ArgumentTest Unit Tests
    ///</summary>
    [TestClass]
    public class ArgumentTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        ///A test for Argument Constructor
        ///</summary>
        [TestMethod]
        public void ArgumentConstructorTest()
        {
            const string name = "ArgumentConstructorTest";
            const string expected = "argumentconstructortest";
            const bool hasPrefix = true;
            Argument target = new Argument(name, hasPrefix);
            Assert.AreEqual(expected, target.Name);
        }
    }
}
