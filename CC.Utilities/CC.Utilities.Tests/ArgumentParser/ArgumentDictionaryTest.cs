using CC.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using System.Collections;

namespace CC.Utilities.Tests
{
    
    
    /// <summary>
    ///This is a test class for ArgumentDictionaryTest and is intended
    ///to contain all ArgumentDictionaryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ArgumentDictionaryTest
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
        ///A test for Item
        ///</summary>
        [TestMethod()]
        public void ItemTestName()
        {
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Item
        ///</summary>
        [TestMethod()]
        public void ItemTestIndex()
        {
            ArgumentDictionary target = new ArgumentDictionary(); // TODO: Initialize to an appropriate value
            int argumentIndex = 0; // TODO: Initialize to an appropriate value
            Argument expected = null; // TODO: Initialize to an appropriate value
            Argument actual;
            target[argumentIndex] = expected;
            actual = target[argumentIndex];
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Count
        ///</summary>
        [TestMethod()]
        public void CountTest()
        {
            ArgumentDictionary target = new ArgumentDictionary(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Count;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TryGetValue
        ///</summary>
        [TestMethod()]
        public void TryGetValueTest()
        {
            ArgumentDictionary target = new ArgumentDictionary(); // TODO: Initialize to an appropriate value
            string argumentName = string.Empty; // TODO: Initialize to an appropriate value
            Argument value = null; // TODO: Initialize to an appropriate value
            Argument valueExpected = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.TryGetValue(argumentName, out value);
            Assert.AreEqual(valueExpected, value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for System.Collections.IEnumerable.GetEnumerator
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CC.Utilities.dll")]
        public void GetEnumeratorTest1()
        {
            IEnumerable target = new ArgumentDictionary(); // TODO: Initialize to an appropriate value
            IEnumerator expected = null; // TODO: Initialize to an appropriate value
            IEnumerator actual;
            actual = target.GetEnumerator();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RemoveAt
        ///</summary>
        [TestMethod()]
        public void RemoveAtTest()
        {
            ArgumentDictionary target = new ArgumentDictionary(); // TODO: Initialize to an appropriate value
            int index = 0; // TODO: Initialize to an appropriate value
            target.RemoveAt(index);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Remove
        ///</summary>
        [TestMethod()]
        public void RemoveTest1()
        {
            ArgumentDictionary target = new ArgumentDictionary(); // TODO: Initialize to an appropriate value
            Argument argument = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Remove(argument);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Remove
        ///</summary>
        [TestMethod()]
        public void RemoveTest()
        {
            ArgumentDictionary target = new ArgumentDictionary(); // TODO: Initialize to an appropriate value
            string argumentName = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Remove(argumentName);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OnDictionaryChanged
        ///</summary>
        [TestMethod()]
        [DeploymentItem("CC.Utilities.dll")]
        public void OnDictionaryChangedTest()
        {
            ArgumentDictionary_Accessor target = new ArgumentDictionary_Accessor(); // TODO: Initialize to an appropriate value
            EventArgs eventArgs = null; // TODO: Initialize to an appropriate value
            target.OnDictionaryChanged(eventArgs);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for IndexOf
        ///</summary>
        [TestMethod()]
        public void IndexOfTest1()
        {
            ArgumentDictionary target = new ArgumentDictionary(); // TODO: Initialize to an appropriate value
            Argument argument = null; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.IndexOf(argument);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IndexOf
        ///</summary>
        [TestMethod()]
        public void IndexOfTest()
        {
            ArgumentDictionary target = new ArgumentDictionary(); // TODO: Initialize to an appropriate value
            string argumentName = string.Empty; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.IndexOf(argumentName);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetValidArguments
        ///</summary>
        [TestMethod()]
        public void GetValidArgumentsTest()
        {
            ArgumentDictionary target = new ArgumentDictionary(); // TODO: Initialize to an appropriate value
            ArgumentDictionary expected = null; // TODO: Initialize to an appropriate value
            ArgumentDictionary actual;
            actual = target.GetValidArguments();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetInvalidArguments
        ///</summary>
        [TestMethod()]
        public void GetInvalidArgumentsTest()
        {
            ArgumentDictionary target = new ArgumentDictionary(); // TODO: Initialize to an appropriate value
            ArgumentDictionary expected = null; // TODO: Initialize to an appropriate value
            ArgumentDictionary actual;
            actual = target.GetInvalidArguments();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetEnumerator
        ///</summary>
        [TestMethod()]
        public void GetEnumeratorTest()
        {
            ArgumentDictionary target = new ArgumentDictionary(); // TODO: Initialize to an appropriate value
            IEnumerator<Argument> expected = null; // TODO: Initialize to an appropriate value
            IEnumerator<Argument> actual;
            actual = target.GetEnumerator();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Contains
        ///</summary>
        [TestMethod()]
        public void ContainsTest1()
        {
            ArgumentDictionary target = new ArgumentDictionary(); // TODO: Initialize to an appropriate value
            Argument argument = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Contains(argument);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Contains
        ///</summary>
        [TestMethod()]
        public void ContainsTest()
        {
            ArgumentDictionary target = new ArgumentDictionary(); // TODO: Initialize to an appropriate value
            string argumentName = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Contains(argumentName);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Clear
        ///</summary>
        [TestMethod()]
        public void ClearTest()
        {
            ArgumentDictionary target = new ArgumentDictionary(); // TODO: Initialize to an appropriate value
            target.Clear();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for AddRange
        ///</summary>
        [TestMethod()]
        public void AddRangeTest()
        {
            ArgumentDictionary target = new ArgumentDictionary(); // TODO: Initialize to an appropriate value
            IEnumerable<Argument> arguments = null; // TODO: Initialize to an appropriate value
            target.AddRange(arguments);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest()
        {
            ArgumentDictionary target = new ArgumentDictionary(); // TODO: Initialize to an appropriate value
            Argument argument = null; // TODO: Initialize to an appropriate value
            target.Add(argument);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ArgumentDictionary Constructor
        ///</summary>
        [TestMethod()]
        public void ArgumentDictionaryConstructorTest1()
        {
            ArgumentDictionary target = new ArgumentDictionary();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ArgumentDictionary Constructor
        ///</summary>
        [TestMethod()]
        public void ArgumentDictionaryConstructorTest()
        {
            IEnumerable<Argument> arguments = null; // TODO: Initialize to an appropriate value
            ArgumentDictionary target = new ArgumentDictionary(arguments);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
