using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CC.Utilities
{
    public static class Encryption
    {
        private const string InitVector = "T=A4rAzu94ez-dra";
        private const int KeySize = 256;
        private const int PasswordIterations = 1000; //2;
        private const string SaltValue = "d=?ustAF=UstenAr3B@pRu8=ner5sW&h59_Xe9P2za-eFr2fa&ePHE@ras!a+uc@";

        public static string Decrypt(string encryptedText, string passPhrase)
        {
#if DEBUG
            DateTime enterTime = Logging.EnterMethod("CC.Utilities.Decrypt");
#endif
            byte[] encryptedTextBytes = Convert.FromBase64String(encryptedText);
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(InitVector);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(passPhrase);
            string plainText;
            byte[] saltValueBytes = Encoding.UTF8.GetBytes(SaltValue);

            Rfc2898DeriveBytes password = new Rfc2898DeriveBytes(passwordBytes, saltValueBytes, PasswordIterations);
            byte[] keyBytes = password.GetBytes(KeySize / 8);

            RijndaelManaged rijndaelManaged = new RijndaelManaged { Mode = CipherMode.CBC };

            try
            {
                using (ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(keyBytes, initVectorBytes))
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

        public static string Encrypt(string plainText, string passPhrase)
        {
#if DEBUG
            DateTime enterTime = Logging.EnterMethod("CC.Utilities.Encrypt");
#endif
            string encryptedText;
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(InitVector);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(passPhrase);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] saltValueBytes = Encoding.UTF8.GetBytes(SaltValue);

            Rfc2898DeriveBytes password = new Rfc2898DeriveBytes(passwordBytes, saltValueBytes, PasswordIterations);
            byte[] keyBytes = password.GetBytes(KeySize / 8);

            RijndaelManaged rijndaelManaged = new RijndaelManaged {Mode = CipherMode.CBC};

            using (ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(keyBytes, initVectorBytes))
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
    }
}
