using CC.Utilities.Interop;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Windows.Forms;

namespace CC.Utilities.Tests
{
    /// <summary>
    ///This is a test class for InteropConvertTest and is intended
    ///to contain all InteropConvertTest Unit Tests
    ///</summary>
    [TestClass]
    public class InteropConvertTest
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

        #region Public Methods
        // ReSharper disable InconsistentNaming
        /// <summary>
        ///A test for PFA_ToHorizontalAlignment
        ///</summary>
        [TestMethod]
        public void PFA_ToHorizontalAlignmentTest()
        {
            const PFA pfa1 = PFA.CENTER;
            const PFA pfa2 = PFA.LEFT;
            const PFA pfa3 = PFA.RIGHT;

            const HorizontalAlignment expected1 = HorizontalAlignment.Center;
            const HorizontalAlignment expected2 = HorizontalAlignment.Left;
            const HorizontalAlignment expected3 = HorizontalAlignment.Right;            

            HorizontalAlignment actual1 = InteropConvert.PFA_ToHorizontalAlignment(pfa1);
            HorizontalAlignment actual2 = InteropConvert.PFA_ToHorizontalAlignment(pfa2);
            HorizontalAlignment actual3 = InteropConvert.PFA_ToHorizontalAlignment(pfa3);

            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
            Assert.AreEqual(expected3, actual3);
        }

        /// <summary>
        ///A test for HorizontalAlignmentTo_PFA
        ///</summary>
        [TestMethod]
        public void HorizontalAlignmentTo_PFATest()
        {
            const HorizontalAlignment alignment1 = HorizontalAlignment.Center;
            const HorizontalAlignment alignment2 = HorizontalAlignment.Left;
            const HorizontalAlignment alignment3 = HorizontalAlignment.Right;

            const PFA expected1 = PFA.CENTER;
            const PFA expected2 = PFA.LEFT;
            const PFA expected3 = PFA.RIGHT;

            PFA actual1 = InteropConvert.HorizontalAlignmentTo_PFA(alignment1);
            PFA actual2 = InteropConvert.HorizontalAlignmentTo_PFA(alignment2);
            PFA actual3 = InteropConvert.HorizontalAlignmentTo_PFA(alignment3);

            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
            Assert.AreEqual(expected3, actual3);
        }

        /// <summary>
        ///A test for FontStyleTo_CFM
        ///</summary>
        [TestMethod]
        public void FontStyleTo_CFMTest()
        {
            const FontStyle fontStyle1 = FontStyle.Bold;
            const FontStyle fontStyle2 = FontStyle.Italic;
            const FontStyle fontStyle3 = FontStyle.Strikeout;
            const FontStyle fontStyle4 = FontStyle.Underline;

            const CFM expected1 = CFM.BOLD;
            const CFM expected2 = CFM.ITALIC;
            const CFM expected3 = CFM.STRIKEOUT;
            const CFM expected4 = CFM.UNDERLINE;

            CFM actual1 = InteropConvert.FontStyleTo_CFM(fontStyle1);
            CFM actual2 = InteropConvert.FontStyleTo_CFM(fontStyle2);
            CFM actual3 = InteropConvert.FontStyleTo_CFM(fontStyle3);
            CFM actual4 = InteropConvert.FontStyleTo_CFM(fontStyle4);

            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
            Assert.AreEqual(expected3, actual3);
            Assert.AreEqual(expected4, actual4);
        }

        /// <summary>
        ///A test for CFM_ToFontStyle
        ///</summary>
        [TestMethod]
        public void CFM_ToFontStyleTest()
        {
            const CFM dwMask1 = CFM.BOLD;
            const CFM dwMask2 = CFM.ITALIC;
            const CFM dwMask3 = CFM.STRIKEOUT;
            const CFM dwMask4 = CFM.UNDERLINE;

            const FontStyle expected1 = FontStyle.Bold;
            const FontStyle expected2 = FontStyle.Italic;
            const FontStyle expected3 = FontStyle.Strikeout;
            const FontStyle expected4 = FontStyle.Underline;

            FontStyle actual1 = InteropConvert.CFM_ToFontStyle(dwMask1);
            FontStyle actual2 = InteropConvert.CFM_ToFontStyle(dwMask2);
            FontStyle actual3 = InteropConvert.CFM_ToFontStyle(dwMask3);
            FontStyle actual4 = InteropConvert.CFM_ToFontStyle(dwMask4);

            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
            Assert.AreEqual(expected3, actual3);
            Assert.AreEqual(expected4, actual4);
        }
        // ReSharper restore InconsistentNaming
        #endregion
    }
}
