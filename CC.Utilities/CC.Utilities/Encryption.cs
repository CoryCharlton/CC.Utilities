using System;
using System.Security.Cryptography;
using System.Text;

namespace CC.Utilities
{
    /// <summary>
    /// Provides simple <see cref="RijndaelManaged"/> Decrypt() and Encrypt() methods using a static implementation of <see cref="SimpleEncryption"/>
    /// </summary>
    public static class Encryption
    {
        #region Private Static Fields
        private static string _HashedPassword = string.Empty;
        // ReSharper disable InconsistentNaming
        private static MD5 _MD5;
        // ReSharper restore InconsistentNaming
        private static SimpleEncryption _SimpleEncryption;
        #endregion

        #region Private Methods
        private static void BuildSimpleEncryption(string password)
        {
            if (_MD5 == null)
            {
                _MD5 = MD5.Create();
            }

            string hashedPassword = Encoding.UTF8.GetString(_MD5.ComputeHash(Encoding.UTF8.GetBytes(password)));

            if (_SimpleEncryption == null || !hashedPassword.Equals(_HashedPassword))
            {
                _HashedPassword = hashedPassword;
                _SimpleEncryption = new SimpleEncryption(password);
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Decrypts the encrypted text
        /// </summary>
        /// <param name="encryptedText">The encrypted text to decrypt</param>
        /// <param name="password">The password used to decrypt the text</param>
        /// <returns>The plain text decrypted</returns>
        public static string Decrypt(string encryptedText, string password)
        {
#if DEBUG
            DateTime enterTime = Logging.EnterMethod("CC.Utilities.Encryption.Decrypt");
#endif
            BuildSimpleEncryption(password);
#if DEBUG
            Logging.ExitMethod("CC.Utilities.Encryption.Decrypt", enterTime);
#endif
            return _SimpleEncryption.Decrypt(encryptedText);
        }

        /// <summary>
        /// Encrypts the plain text
        /// </summary>
        /// <param name="plainText">The plain text to encrypt</param>
        /// <param name="password">The password used to encrypt the text</param>
        /// <returns>The encrypted text</returns>
        public static string Encrypt(string plainText, string password)
        {
#if DEBUG
            DateTime enterTime = Logging.EnterMethod("CC.Utilities.Encryption.Encrypt");
#endif
            BuildSimpleEncryption(password);
#if DEBUG
            Logging.ExitMethod("CC.Utilities.Encryption.Encrypt", enterTime);
#endif
            return _SimpleEncryption.Encrypt(plainText);
        }
        #endregion
    }
}
