using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SaludAr.Services.Crypto
{
    /// <summary>
    /// Implementa la funcionalidad de un proveedor de servicios criptográficos
    /// </summary>
    public class CSP
    {
        private static readonly byte[] InternalIV = new byte[]
            {170, 13, 23, 31, 231, 49, 2, 138, 123, 27, 15, 104, 241, 184, 90, 75};

        private byte[] _saltKey;
        private string _base64SaltKey;

        public CSP(string base64SaltKey)
        {
            this.SaltKey = base64SaltKey;
            this.DefaultEncoding = Encoding.UTF8;
        }

        public Encoding DefaultEncoding { get; set; }

        public string SaltKey
        {
            get { return _base64SaltKey; }
            private set
            {
                _base64SaltKey = value;
                _saltKey = Convert.FromBase64String(_base64SaltKey);

                if (_saltKey.Length < 32)
                    throw new ArgumentException("La clave de cifrado debe tener al menos 32 bytes", "SaltKey");
            }
        }

        public byte[] Encrypt(byte[] data)
        {
            byte[] encryptedBytes;
            using (var rijndaelManaged = new RijndaelManaged())
            {
                rijndaelManaged.Key = _saltKey;
                rijndaelManaged.IV = InternalIV;

                var memoryStream = new MemoryStream();

                //Calling the method create encryptor method Needs both the Key and IV these have to be from the original Rijndael call
                //If these are changed nothing will work right.
                var encryptor = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(data, 0, data.Length);
                    cryptoStream.Flush();
                    cryptoStream.Close();
                }

                encryptedBytes = memoryStream.ToArray();
            }

            return encryptedBytes;
        }

        public byte[] Decrypt(byte[] cipherText)
        {
            byte[] decryptedBytes;
            using (var rijndaelManaged = new RijndaelManaged())
            {
                rijndaelManaged.Key = _saltKey;
                rijndaelManaged.IV = InternalIV;

                // Create a decrytor to perform the stream transform.
                var decryptor = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);

                // Create the streams used for decryption.
                using (var cipheredMemoryStream = new MemoryStream(cipherText))
                {
                    using (var cryptoStream = new CryptoStream(cipheredMemoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (var ms = new MemoryStream())
                        {
                            cryptoStream.CopyTo(ms);
                            decryptedBytes = ms.ToArray();
                        }
                    }
                }
            }

            return decryptedBytes;
        }

        public byte[] EncryptString(string data)
        {
            var bytes = this.DefaultEncoding.GetBytes(data);
            return this.Encrypt(bytes);
        }

        public string DecryptString(byte[] cipherText)
        {
            var bytes = this.Decrypt(cipherText);
            return this.DefaultEncoding.GetString(bytes);
        }
    }
}