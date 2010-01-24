using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace CC.Utilities.Tests
{
    /// <summary>
    ///This is a test class for ConvertExTest and is intended
    ///to contain all ConvertExTest Unit Tests
    ///</summary>
    [TestClass]
    public class ConvertExTest
    {
        #region Private Constants
        // ReSharper disable InconsistentNaming
        private const float DPI = 96;
        // ReSharper restore InconsistentNaming
        #endregion

        #region Public Properties
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }
        #endregion

        #region Public Methods
        /// <summary>
        ///A test for TwipsToPoints
        ///</summary>
        [TestMethod]
        public void TwipsToPointsTest()
        {
            const int twips = 20;
            const float expected = 1F;
            float actual = ConvertEx.TwipsToPoints(twips);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for TwipsToInches
        ///</summary>
        [TestMethod]
        public void TwipsToInchesTest()
        {
            const int twips = 1440;
            const float expected = 1F;
            float actual = ConvertEx.TwipsToInches(twips);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for PointsToTwips
        ///</summary>
        [TestMethod]
        public void PointsToTwipsTest()
        {
            const float points = 1F;
            const float expected = 20F;
            float actual = ConvertEx.PointsToTwips(points);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for PixelsToInches
        ///</summary>
        [TestMethod]
        public void PixelsToInchesTest()
        {
            const float expected = 1F;
            float actual = ConvertEx.PixelsToInches(DPI, DPI);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for InchesToTwips
        ///</summary>
        [TestMethod]
        public void InchesToTwipsTest()
        {
            const float inches = 1F;
            const float expected = 1440F;
            float actual = ConvertEx.InchesToTwips(inches);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for InchesToPixels
        ///</summary>
        [TestMethod]
        public void InchesToPixelsTest()
        {
            const float length = 1F;
            float actual = ConvertEx.InchesToPixels(length, DPI);
            Assert.AreEqual(DPI, actual);
        }

        /// <summary>
        ///A test for HundredthInchToTwips
        ///</summary>
        [TestMethod]
        public void HundredthInchToTwipsTest()
        {
            const int n = 1;
            const int expected = 14;
            int actual = ConvertEx.HundredthInchToTwips(n);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ColorRefToColor
        ///</summary>
        [TestMethod]
        public void ColorRefToColorTest()
        {
            const uint colorRef = 16777215;
            Color expected = Color.FromArgb(255, 255, 255, 255);
            Color actual = ConvertEx.ColorRefToColor(colorRef);
            Assert.AreEqual(expected, actual);
        }
        #endregion
    }
}
