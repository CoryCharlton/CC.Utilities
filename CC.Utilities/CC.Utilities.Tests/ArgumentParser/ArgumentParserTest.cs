using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace CC.Utilities.Tests
{
    /// <summary>
    ///This is a test class for ArgumentParserTest and is intended
    ///to contain all ArgumentParserTest Unit Tests
    ///</summary>
    [TestClass]
    public class ArgumentParserTest
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
        ///A test for RequirePrefix
        ///</summary>
        [TestMethod()]
        public void RequirePrefixTest()
        {
            ArgumentParser target = new ArgumentParser(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.RequirePrefix = expected;
            actual = target.RequirePrefix;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Prefixes
        ///</summary>
        [TestMethod()]
        public void PrefixesTest()
        {
            ArgumentParser target = new ArgumentParser(); // TODO: Initialize to an appropriate value
            List<string> expected = null; // TODO: Initialize to an appropriate value
            List<string> actual;
            target.Prefixes = expected;
            actual = target.Prefixes;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ParsedArguments
        ///</summary>
        [TestMethod()]
        public void ParsedArgumentsTest()
        {
            ArgumentParser target = new ArgumentParser(); // TODO: Initialize to an appropriate value
            ArgumentDictionary actual;
            actual = target.ParsedArguments;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AllowedArguments
        ///</summary>
        [TestMethod()]
        public void AllowedArgumentsTest()
        {
            ArgumentParser target = new ArgumentParser(); // TODO: Initialize to an appropriate value
            ArgumentDictionary actual;
            actual = target.AllowedArguments;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Parse
        ///</summary>
        [TestMethod()]
        public void ParseTest()
        {
            ArgumentParser target = new ArgumentParser(); // TODO: Initialize to an appropriate value
            string[] args = null; // TODO: Initialize to an appropriate value
            target.Parse(args);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddAllowedArgument
        ///</summary>
        [TestMethod()]
        public void AddAllowedArgumentTest_String()
        {
            ArgumentParser target = new ArgumentParser(); // TODO: Initialize to an appropriate value
            string argumentName = string.Empty; // TODO: Initialize to an appropriate value
            target.AddAllowedArgument(argumentName);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddAllowedArgument
        ///</summary>
        [TestMethod()]
        public void AddAllowedArgumentTest_Argument()
        {
            ArgumentParser target = new ArgumentParser(); // TODO: Initialize to an appropriate value
            Argument argument = null; // TODO: Initialize to an appropriate value
            target.AddAllowedArgument(argument);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
