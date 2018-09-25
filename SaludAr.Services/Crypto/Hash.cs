using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SaludAr.Services.Crypto
{
    public class Hash : IDisposable
    {
        private SHA256 _sha256 = SHA256.Create();

        public byte[] CreateHash(IEnumerable<byte[]> seed)
        {
            byte[] hashValue;
            using (var memoryStream = new MemoryStream(4096))
            {
                foreach (var bytes in seed)
                    memoryStream.Write(bytes, 0, 32);

                memoryStream.Position = 0;

                hashValue = _sha256.ComputeHash(memoryStream);
            }

            return hashValue;
        }

        public byte[] CreateHash(string seed)
        {
            var sourceBytes = Encoding.UTF8.GetBytes(seed);
            var hashValue = _sha256.ComputeHash(sourceBytes);

            return hashValue;
        }

        public void Dispose()
        {
            if (_sha256 != null)
            {
                _sha256.Dispose();
                _sha256 = null;
            }
        }
    }
}