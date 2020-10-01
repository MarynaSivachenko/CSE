using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestL2
{
    [TestClass]
    public class L2Test
    {

        [TestMethod]
        public void Equals_Vaska3_SameReferance_trueReturned()
        {
            Cat cat1 = new Cat("Vaska", 3);
            Cat cat2 = cat1;
            bool expected = true;

            bool actual = IIG.BinaryFlag.MultipleBinaryFlag.Equals(cat1, cat2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equals_Vaska3_Murzik4_falseReturned()
        {
            Cat cat1 = new Cat("Vaska", 3);
            Cat cat2 = new Cat("Murzik", 4);
            bool expected = false;

            bool actual = IIG.BinaryFlag.MultipleBinaryFlag.Equals(cat1, cat2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equals_world_SameReferance_trueReturned()
        {
            String s1 = "world";
            String s2 = "world";
            bool expected = true;

            bool actual = IIG.BinaryFlag.MultipleBinaryFlag.Equals(s1, s2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equals_Vaska3_Vaska3_trueReturned()
        {
            Cat cat1 = new Cat("Vaska", 3);
            Cat cat2 = new Cat("Vaska", 3);
            bool expected = true;

            bool actual = IIG.BinaryFlag.MultipleBinaryFlag.Equals(cat1, cat2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equals_world_word_falseReturned()
        {
            String s1 = new String(new char[] { 'w', 'o', 'r', 'l', 'd' });
            String s2 = new String(new char[] { 'w', 'o', 'r', 'd' });
            bool expected = false;

            bool actual = IIG.BinaryFlag.MultipleBinaryFlag.Equals(s1, s2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equals_world_world_trueReturned()
        {
            String s1 = new String(new char[] { 'w', 'o', 'r', 'l', 'd' });
            String s2 = new String(new char[] { 'w', 'o', 'r', 'l', 'd' });
            bool expected = true;

            bool actual = IIG.BinaryFlag.MultipleBinaryFlag.Equals(s1, s2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReferenceEquals_Vaska3_Vaska3_falseReturned()
        {
            Cat cat1 = new Cat("Vaska", 3);
            Cat cat2 = new Cat("Vaska", 3);
            bool expected = false;

            bool actual = IIG.BinaryFlag.MultipleBinaryFlag.ReferenceEquals(cat1, cat2);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void ReferenceEquals_Vaska3_SameReference_trueReturned()
        {
            Cat cat1 = new Cat("Vaska", 3);
            Cat cat2 = cat1;
            bool expected = true;

            bool actual = IIG.BinaryFlag.MultipleBinaryFlag.ReferenceEquals(cat1, cat2);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void ReferenceEquals_world_SameReferance_trueReturned()
        {
            String s1 = "world";
            String s2 = "world";
            bool expected = true;

            bool actual = IIG.BinaryFlag.MultipleBinaryFlag.ReferenceEquals(s1, s2);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void ReferenceEquals_world_world_falseReturned()
        {
            String s1 = new String(new char[] { 'w', 'o', 'r', 'l', 'd' });
            String s2 = new String(new char[] { 'w', 'o', 'r', 'l', 'd' });
            bool expected = false;

            bool actual = IIG.BinaryFlag.MultipleBinaryFlag.ReferenceEquals(s1, s2);

            Assert.AreEqual(expected, actual);

        }
    }
}
