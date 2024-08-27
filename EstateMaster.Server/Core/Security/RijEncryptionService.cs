using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EstateMaster.Server.Security
{
    public class RijEncryptionService : IRijEncryptionService
    {
        private RijndaelManaged rijAlg { get; set; }

        public RijEncryptionService()
        {
            // Create an RijndaelManaged object  
            // with the specified key and IV.  
            rijAlg = new RijndaelManaged();

            //Settings  
            rijAlg.Mode = CipherMode.CBC;
            rijAlg.Padding = PaddingMode.PKCS7;
            rijAlg.FeedbackSize = 128;

            rijAlg.Key = Encoding.UTF8.GetBytes("UxLPuYFIzdOPKcTW");
            rijAlg.IV = Encoding.UTF8.GetBytes("Bhuywg7tzjks3ZbW");
        }

        public string Decrypt(string encrypted)
        {
            byte[] cipherText = Convert.FromBase64String(encrypted);
            // Declare the string used to hold  
            // the decrypted text.  
            string plaintext = null;

            // Create a decrytor to perform the stream transform.  
            using (ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV))
            {
                // Create the streams used for decryption.  
                using (var msDecrypt = new MemoryStream(cipherText))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream  
                            // and place them in a string.  
                            plaintext = srDecrypt.ReadToEnd();
                        }

                    }
                }
            }

            return plaintext;
        }

        public string Encrypt(string plainText)
        {
            byte[] encrypted;

            // Create a decrytor to perform the stream transform.  
            using (ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV))
            {
                // Create the streams used for encryption.  
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.  
                            swEncrypt.Write(plainText);
                        }

                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            // Return the encrypted bytes from the memory stream.  
            return Convert.ToBase64String(encrypted);
        }
    }
}