using CC.Utilities.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace CC.Utilities.Tests
{
    //TODO: Add test for FromFontNames method

    /// <summary>
    ///This is a test class for FontBuilderTest and is intended
    ///to contain all FontBuilderTest Unit Tests
    ///</summary>
    [TestClass]
    public class FontBuilderTest
    {
        #region Private Constants
        // ReSharper disable InconsistentNaming
        private readonly Font FONT = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point);
        private const string FONT_STRING = "[Font: Name=Arial, Size=10, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=1]";
        // ReSharper restore InconsistentNaming
        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        ///A test for ToStringEx
        ///</summary>
        [TestMethod]
        public void ToStringExTest()
        {
            string actual = FONT.ToStringEx();
            Assert.AreEqual(FONT_STRING, actual);
        }

        /// <summary>
        ///A test for FromString
        ///</summary>
        [TestMethod]
        public void FromStringTest()
        {
            Font actual = FontBuilder.FromString(FONT_STRING);
            Assert.AreEqual(FONT, actual);
        }
    }
}
