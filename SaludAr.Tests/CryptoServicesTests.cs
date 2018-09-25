using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SaludAr.Services.Crypto;

namespace SaludAr.Tests
{
    [TestClass]
    public class CryptoServicesTests
    {
        //Clave secreta de 32 bytes
        private static readonly string SampleKey = "SakR6YLvT3l7c90l4V+1LuYgKzqd7o9hBDrD0BEiHSw=";
        private readonly CSP _csp = new CSP(SampleKey);

        private const string TestWord = "Hola Mundo";
        private const string CipheredText = "w9wP7hCE1Ts52ugU368D8g==";
        private static readonly byte[] HashedBytes = { 195,164,162,228,157,145,242,23,113,19,169,173,252,185,239,154,249,103,157,196,85,122,10,58,70,2,225,189,57,166,244,129 };

        [TestMethod]
        public void EncryptSomeWord()
        {
            //ACT
            var bytes = _csp.EncryptString(TestWord);

            //ASSERT
            Assert.AreEqual(CipheredText, Convert.ToBase64String(bytes));
        }

        [TestMethod]
        public void DecryptSomeWord()
        {
            //ACT
            var text = _csp.DecryptString(Convert.FromBase64String(CipheredText));

            //ASSERT
            Assert.AreEqual(TestWord, text);
        }

        [TestMethod]
        public void CreateHashFromString()
        {
            var hash = new Hash();

            //ACT
            var hashedBytes = hash.CreateHash(TestWord);

            //ASSERT
            Assert.IsTrue(HashedBytes.SequenceEqual(hashedBytes), "HashedBytes.SequenceEqual(hashedBytes)");
        }
    }
}