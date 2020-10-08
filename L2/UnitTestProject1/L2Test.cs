﻿using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestL2
{
    [TestClass]
    public class L2Test
    {

        [TestMethod]
        public void GetFlag_falseReturned()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(2, false);

            bool expected = false;

            bool actual = mbf.GetFlag();

            Assert.AreEqual(expected, actual);
        }



        [TestMethod]
        public void GetFlag_trueReturned()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(2, true);

            bool expected = true;
            bool actual = mbf.GetFlag();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetFlag_trueReturned()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(2, false);
            for (ulong i = 0; i < 2; i++)
            {
                mbf.SetFlag(i);
            }

            bool expected = true;
            bool actual = mbf.GetFlag();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ResetFlag_falseReturned()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(2, true);
            for (ulong i = 0; i < 2; i++)
            {
                mbf.ResetFlag(i);
            }

            bool expected = false;
            bool actual = mbf.GetFlag();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFlag_01_falseReturned()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(2, false);

            mbf.SetFlag(1);

            bool expected = false;

            bool actual = mbf.GetFlag();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFlag_0positionFalse_falseReturned()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(1000, false);

            for (ulong i = 1; i < 1000; i++)
            {
                mbf.SetFlag(i);
            }

            bool expected = false;

            bool actual = mbf.GetFlag();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFlag_300positionTrue_falseReturned()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(1000, false);

                mbf.SetFlag(300);           

            bool expected = false;

            bool actual = mbf.GetFlag();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFlag_999positionFalse_falseReturned()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(1000, true);

            mbf.ResetFlag(999);

            bool expected = false;

            bool actual = mbf.GetFlag();

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void GetFlag_0positionTrue_falseReturned()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(1000, false);

            mbf.SetFlag(0);

            bool expected = false;

            bool actual = mbf.GetFlag();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equals_01_00_falseReturned()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf1 = new IIG.BinaryFlag.MultipleBinaryFlag(2, false);
            IIG.BinaryFlag.MultipleBinaryFlag mbf2 = new IIG.BinaryFlag.MultipleBinaryFlag(2, false);

            mbf1.SetFlag(1);

            bool expected = false;

            bool actual = mbf1.Equals(mbf2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equals_falseReturned()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf1 = new IIG.BinaryFlag.MultipleBinaryFlag(100000, false);
            IIG.BinaryFlag.MultipleBinaryFlag mbf2 = new IIG.BinaryFlag.MultipleBinaryFlag(100000, false);

            mbf1.SetFlag(14567);

            bool expected = false;

            bool actual = mbf1.Equals(mbf2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equals_00_00_trueReturned()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf1 = new IIG.BinaryFlag.MultipleBinaryFlag(2, true);
            IIG.BinaryFlag.MultipleBinaryFlag mbf2 = new IIG.BinaryFlag.MultipleBinaryFlag(2, true);

            bool expected = true;

            bool actual = mbf1.Equals(mbf2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equals_trueReturned()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf1 = new IIG.BinaryFlag.MultipleBinaryFlag(1000000, true);
            IIG.BinaryFlag.MultipleBinaryFlag mbf2 = new IIG.BinaryFlag.MultipleBinaryFlag(1000000, true);

            bool expected = true;

            bool actual = mbf1.Equals(mbf2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equals_sameRef_trueReturned()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf1 = new IIG.BinaryFlag.MultipleBinaryFlag(2, true);
            IIG.BinaryFlag.MultipleBinaryFlag mbf2 = mbf1;

            bool expected = true;

            bool actual = mbf1.Equals(mbf2);

            Assert.AreEqual(expected, actual);
        }

    }
}
