using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordHasherTests
{
    [TestClass]
    public class PHTests
    {
        [TestMethod]
        public void NotNullReturned()
        {
            IIG.PasswordHashingUtils.PasswordHasher.GetHash("1234");
            Assert.IsNotNull(IIG.PasswordHashingUtils.PasswordHasher.GetHash("1234"));
        }

        [TestMethod]
        public void SamePassword_trueReturned()
        {
            String hash1 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("1234");
            String hash2 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("1234");
            Assert.IsTrue(hash1.Equals(hash2));
        }


        [TestMethod]
        public void DifferentPassword_trueReturned()
        {
            String hash1 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("1235");
            String hash2 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("1234");
            Assert.IsFalse(hash1.Equals(hash2));
        }

        [TestMethod]
        public void DifferentSalt_FalseReturned()
        {
            IIG.PasswordHashingUtils.PasswordHasher.Init("new", 0);
            String hash1 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("1234");
            IIG.PasswordHashingUtils.PasswordHasher.Init("old", 0);
            String hash2 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("1234");
            Assert.IsFalse(hash1.Equals(hash2));
        }

        [TestMethod]
        public void DifferentAdlerMod32_FalseReturned()
        {
            IIG.PasswordHashingUtils.PasswordHasher.Init(null, 1151111615);
            String hash1 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("1234");
            IIG.PasswordHashingUtils.PasswordHasher.Init(null, 1151111614);
            String hash2 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("1234");
            Assert.IsFalse(hash1.Equals(hash2));
        }

        [TestMethod]
        public void Different2AdlerMod32_FalseReturned()
        {
            IIG.PasswordHashingUtils.PasswordHasher.Init(null, 115);
            String hash1 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("1234");
            IIG.PasswordHashingUtils.PasswordHasher.Init(null, 116);
            String hash2 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("1234");
            Assert.IsFalse(hash1.Equals(hash2));
        }

        [TestMethod]
        public void DifferentSalt_AdlerMod32_FalseReturned()
        {
            IIG.PasswordHashingUtils.PasswordHasher.Init("newdsjhbhjdbjhdfoijslsmcnbwwdv;sz", 1151111615);
            String hash1 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("1234");
            IIG.PasswordHashingUtils.PasswordHasher.Init("oldslksmnlaiuhaiubxcmc,nbvbcbcbdh", 1151111614);
            String hash2 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("1234");
            Assert.IsFalse(hash1.Equals(hash2));
        }
    }
}
