using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordHashingUtilsTests
{
    [TestClass]
    public class PasswordHashingTests
    {
        [TestMethod]
        public void PasswordHasher_Init_AllValid()
        {
            
            var a = "string";
            uint b = 5;
            
            IIG.PasswordHashingUtils.PasswordHasher.Init(a, b);

            Type type = typeof(IIG.PasswordHashingUtils.PasswordHasher);
            var saltInfo = type.GetField("_salt", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            var modAdler32Info = type.GetField("_modAdler32", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

            var saltVal = saltInfo.GetValue(null);
            var modAdler32Val = modAdler32Info.GetValue(null);

            Assert.AreEqual(saltVal, a);
            Assert.AreEqual(modAdler32Val, b);
        }

        [TestMethod]
        public void PasswordHasher_Init_FirstValid()
        {

            var a = "string";
            uint b = 0;

            IIG.PasswordHashingUtils.PasswordHasher.Init(a, b);

            Type type = typeof(IIG.PasswordHashingUtils.PasswordHasher);
            var saltInfo = type.GetField("_salt", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            var modAdler32Info = type.GetField("_modAdler32", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

            var saltVal = saltInfo.GetValue(null);
            var modAdler32Val = modAdler32Info.GetValue(null);

            Assert.AreEqual(saltVal, a);
            Assert.AreNotEqual(modAdler32Val, b);
        
        }

        [TestMethod]
        public void PasswordHasher_Init_SecondValid()
        {

            var a = "";
            uint b = 5;

            IIG.PasswordHashingUtils.PasswordHasher.Init(a, b);

            Type type = typeof(IIG.PasswordHashingUtils.PasswordHasher);
            var saltInfo = type.GetField("_salt", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            var modAdler32Info = type.GetField("_modAdler32", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

            var saltVal = saltInfo.GetValue(null);
            var modAdler32Val = modAdler32Info.GetValue(null);

            Assert.AreNotEqual(saltVal, a);
            Assert.AreEqual(modAdler32Val, b);

        }

        [TestMethod]
        public void PasswordHasher_Init_Second2Valid()
        {

            String a = null;
            uint b = 5;

            IIG.PasswordHashingUtils.PasswordHasher.Init(a, b);

            Type type = typeof(IIG.PasswordHashingUtils.PasswordHasher);
            var saltInfo = type.GetField("_salt", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            var modAdler32Info = type.GetField("_modAdler32", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

            var saltVal = saltInfo.GetValue(null);
            var modAdler32Val = modAdler32Info.GetValue(null);

            Assert.AreNotEqual(saltVal, a);
            Assert.AreEqual(modAdler32Val, b);

        }

        [TestMethod]
        public void PasswordHasher_Init_AllInvalid()
        {

            String a = null;
            uint b = 0;

            IIG.PasswordHashingUtils.PasswordHasher.Init(a, b);

            Type type = typeof(IIG.PasswordHashingUtils.PasswordHasher);
            var saltInfo = type.GetField("_salt", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            var modAdler32Info = type.GetField("_modAdler32", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

            var saltVal = saltInfo.GetValue(null);
            var modAdler32Val = modAdler32Info.GetValue(null);

            Assert.AreNotEqual(saltVal, a);
            Assert.AreNotEqual(modAdler32Val, b);

        }

        [TestMethod]
        public void PasswordHasher_Adler32CheckSum_1Field()
        {

            var a = "n";
           
            IIG.PasswordHashingUtils.PasswordHasher.Init(null ,2);

            Type type = typeof(IIG.PasswordHashingUtils.PasswordHasher);
            var Adler32CheckSumInfo = type.GetMethod("Adler32CheckSum", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
           
            var Adler32CheckSumVal = Adler32CheckSumInfo.Invoke(null, new object[]{a, 0, 0});
           
            
            Assert.AreEqual("01000000", Adler32CheckSumVal);
            

        }

        [TestMethod]
        public void PasswordHasher_Adler32CheckSum_3NegativeFields()
        {

            var a = "n";

            IIG.PasswordHashingUtils.PasswordHasher.Init(null, 2);

            Type type = typeof(IIG.PasswordHashingUtils.PasswordHasher);
            var Adler32CheckSumInfo = type.GetMethod("Adler32CheckSum", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

            var Adler32CheckSumVal = Adler32CheckSumInfo.Invoke(null, new object[] { a, -1, -1 });


            Assert.AreEqual("01000000", Adler32CheckSumVal);


        }

        [TestMethod]
        public void PasswordHasher_Adler32CheckSum_3PositiveFields()
        {

            var a = "n";

            IIG.PasswordHashingUtils.PasswordHasher.Init(null, 2);

            Type type = typeof(IIG.PasswordHashingUtils.PasswordHasher);
            var Adler32CheckSumInfo = type.GetMethod("Adler32CheckSum", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

            var Adler32CheckSumVal = Adler32CheckSumInfo.Invoke(null, new object[] { a, 1, 1 });


            Assert.AreEqual("01000000", Adler32CheckSumVal);

        }

        [TestMethod]
        public void PasswordHasher_GetHash_NegativeField()
        {

            var a = "-11";
            var b = "1";

            IIG.PasswordHashingUtils.PasswordHasher.Init(null, 2);
            String val1 = IIG.PasswordHashingUtils.PasswordHasher.GetHash(a);
            IIG.PasswordHashingUtils.PasswordHasher.Init(null, 2);
            String val2 = IIG.PasswordHashingUtils.PasswordHasher.GetHash(b);


            Assert.AreNotEqual(val1, val2);

        }

        [TestMethod]
        public void PasswordHasher_GetHash_WithInitField()
        {

            var a = "-1";
            var b = "1";
            uint c = 2;

            IIG.PasswordHashingUtils.PasswordHasher.GetHash(a, b, c);

            Type type = typeof(IIG.PasswordHashingUtils.PasswordHasher);
            var saltInfo = type.GetField("_salt", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            var modAdler32Info = type.GetField("_modAdler32", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

            var saltVal = saltInfo.GetValue(null);
            var modAdler32Val = modAdler32Info.GetValue(null);

            Assert.AreEqual(saltVal, b);
            Assert.AreEqual(modAdler32Val, c);
        }

        [TestMethod]
        public void PasswordHasher_GetHash_WithInitInvalidField()
        {

            var a = "-1";
            String b = null;
            uint c = 0;

            String val1 = IIG.PasswordHashingUtils.PasswordHasher.GetHash(a, b, c);

            Type type = typeof(IIG.PasswordHashingUtils.PasswordHasher);
            var saltInfo = type.GetField("_salt", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            var modAdler32Info = type.GetField("_modAdler32", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

            var saltVal = saltInfo.GetValue(null);
            var modAdler32Val = modAdler32Info.GetValue(null);

            Assert.AreNotEqual(saltVal, b);
            Assert.AreNotEqual(modAdler32Val, c);

        }

        [TestMethod]
        public void PasswordHasher_GetHash_WithInitInvalid1Field()
        {

            var a = "-1";
            String b = null;
            uint c = 2;

            String val1 = IIG.PasswordHashingUtils.PasswordHasher.GetHash(a, b, c);

            Type type = typeof(IIG.PasswordHashingUtils.PasswordHasher);
            var saltInfo = type.GetField("_salt", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            var modAdler32Info = type.GetField("_modAdler32", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

            var saltVal = saltInfo.GetValue(null);
            var modAdler32Val = modAdler32Info.GetValue(null);

            Assert.AreNotEqual(saltVal, b);
            Assert.AreEqual(modAdler32Val, c);

        }

        [TestMethod]
        public void PasswordHasher_GetHash_WithInitInvalid2Field()
        {

            var a = "-1";
            var b = "1";
            uint c = 0;

            String val1 = IIG.PasswordHashingUtils.PasswordHasher.GetHash(a, b, c);

            Type type = typeof(IIG.PasswordHashingUtils.PasswordHasher);
            var saltInfo = type.GetField("_salt", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            var modAdler32Info = type.GetField("_modAdler32", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

            var saltVal = saltInfo.GetValue(null);
            var modAdler32Val = modAdler32Info.GetValue(null);

            Assert.AreEqual(saltVal, b);
            Assert.AreNotEqual(modAdler32Val, c);

        }
    }
}
