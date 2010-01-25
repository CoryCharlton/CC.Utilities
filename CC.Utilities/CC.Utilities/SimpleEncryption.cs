using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CC.Utilities
{
    /// <summary>
    /// Provides simple <see cref="RijndaelManaged"/> Decrypt() and Encrypt() methods. 
    /// <see cref="SimpleEncryption"/> is preferred over the static <see cref="Encryption"/>
    /// class if you will be performing many Decrypt/Encrypt calls using the same password.
    /// </summary>
    public class SimpleEncryption
    {
        #region Constructor
        /// <summary>
        /// Creates a new <see cref="SimpleEncryption"/> instance.
        /// </summary>
        /// <param name="password">The password used to Decrypt/Encrypt data</param>
        public SimpleEncryption(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltValueBytes = Encoding.UTF8.GetBytes(SaltValue);

            _DeriveBytes = new Rfc2898DeriveBytes(passwordBytes, saltValueBytes, PasswordIterations);
            _InitVectorBytes = Encoding.UTF8.GetBytes(InitVector);
            _KeyBytes = _DeriveBytes.GetBytes(32);
        }
        #endregion

        #region Private Constants
        private const string InitVector = "T=A4rAzu94ez-dra";
        private const int PasswordIterations = 1000; //2;
        private const string SaltValue = "d=?ustAF=UstenAr3B@pRu8=ner5sW&h59_Xe9P2za-eFr2fa&ePHE@ras!a+uc@";
        #endregion

        #region Private Fields
        private readonly Rfc2898DeriveBytes _DeriveBytes;
        private readonly byte[] _InitVectorBytes;
        private readonly byte[] _KeyBytes;
        #endregion

        #region Public Methods
        /// <summary>
        /// Decrypts the encrypted text
        /// </summary>
        /// <param name="encryptedText">The encrypted text to decrypt</param>
        /// <returns>The plain text decrypted</returns>
        public string Decrypt(string encryptedText)
        {
#if DEBUG
            DateTime enterTime = Logging.EnterMethod("CC.Utilities.SimpleEncryption.Decrypt");
#endif
            byte[] encryptedTextBytes = Convert.FromBase64String(encryptedText);
            string plainText;

            RijndaelManaged rijndaelManaged = new RijndaelManaged { Mode = CipherMode.CBC };

            try
            {
                using (ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(_KeyBytes, _InitVectorBytes))
                {
                    using (MemoryStream memoryStream = new MemoryStream(encryptedTextBytes))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            //TODO: Need to look into this more. Assuming encrypted text is longer than plain but there is probably a better way
                            byte[] plainTextBytes = new byte[encryptedTextBytes.Length];

                            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                            plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                        }
                    }
                }
            }
            catch (CryptographicException)
            {
                plainText = string.Empty; // Assume the error is caused by an invalid password
            }

#if DEBUG
            Logging.ExitMethod("CC.Utilities.Decrypt", enterTime);
#endif
            return plainText;
        }

        /// <summary>
        /// Encrypts the plain text
        /// </summary>
        /// <param name="plainText">The plain text to encrypt</param>
        /// <returns>The encrypted text</returns>
        public string Encrypt(string plainText)
        {
#if DEBUG
            DateTime enterTime = Logging.EnterMethod("CC.Utilities.SimpleEncryption.Encrypt");
#endif
            string encryptedText;
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            RijndaelManaged rijndaelManaged = new RijndaelManaged {Mode = CipherMode.CBC};

            using (ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(_KeyBytes, _InitVectorBytes))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                        cryptoStream.FlushFinalBlock();

                        byte[] cipherTextBytes = memoryStream.ToArray();
                        encryptedText = Convert.ToBase64String(cipherTextBytes);
                    }
                }
            }

#if DEBUG
            Logging.ExitMethod("CC.Utilities.Encrypt", enterTime);
#endif
            return encryptedText;
        }
        #endregion
    }
}
