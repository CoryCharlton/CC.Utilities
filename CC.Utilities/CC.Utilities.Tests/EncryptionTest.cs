using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CC.Utilities.Tests
{
    /// <summary>
    ///This is a test class for EncryptionTest and is intended
    ///to contain all EncryptionTest Unit Tests
    ///</summary>
    [TestClass]
    public class EncryptionTest
    {
        #region Private Constants
        // ReSharper disable InconsistentNaming
        private const string ENCRYPTED_TEXT = "O6VTIcgQeHzTLdbMNMKkILuSb0edGKCUDVnDDsowLRfU9amUBM73lYOMgC9/tbJZ";
        private const string PASSPHRASE = "The passPhrase...";
        private const string PLAIN_TEXT = "Initialize to an appropriate value";
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
        ///A test for Decrypt
        ///</summary>
        [TestMethod]
        public void DecryptTest()
        {
            string actual = Encryption.Decrypt(ENCRYPTED_TEXT, PASSPHRASE);
            Assert.AreEqual(PLAIN_TEXT, actual);
        }

        /// <summary>
        ///A test for Encrypt
        ///</summary>
        [TestMethod]
        public void EncryptTest()
        {
            string actual = Encryption.Encrypt(PLAIN_TEXT, PASSPHRASE);
            Assert.AreEqual(ENCRYPTED_TEXT, actual);
        }
        #endregion
    }
}
