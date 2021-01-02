using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestsL2
{
    [TestClass]
    public class TestsFlagBinary
    {

        [TestMethod]
        public void Constructor_ulongMaxLength_falseReturned()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(4294967295, false);

            Assert.AreEqual(false, mbf.GetFlag());
        }

        [TestMethod]
        public void GetFlag_falseReturned()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(2, false);

            Assert.AreEqual(false, mbf.GetFlag());
        }

        [TestMethod]
        public void GetFlag_trueReturned()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(2, true);

            Assert.AreEqual(true, mbf.GetFlag());
        }

        [TestMethod]
        public void SetFlag_1_99_trueReturned()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(99, false);
            for (ulong i = 0; i < 99; i++)
            {
                mbf.SetFlag(i);
            }

            Assert.AreEqual(true, mbf.GetFlag());
        }

        [TestMethod]
        public void SetFlag_1_999_trueReturned()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(999, false);
            for (ulong i = 0; i < 999; i++)
            {
                mbf.SetFlag(i);
            }

            Assert.AreEqual(true, mbf.GetFlag());
        }

        [TestMethod]
        public void ResetFlag_1_9_falseReturned()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(99, true);
            for (ulong i = 0; i < 9; i++)
            {
                mbf.ResetFlag(i);
            }

            Assert.AreEqual(false, mbf.GetFlag());
        }

        [TestMethod]
        public void ResetFlag_10_99_falseReturned()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(99, true);
            for (ulong i = 9; i < 99; i++)
            {
                mbf.ResetFlag(i);
            }

            Assert.AreEqual(false, mbf.GetFlag());
        }

        [TestMethod]
        public void GetFlag_01_falseReturned()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(2, false);

            mbf.SetFlag(1);

            Assert.AreEqual(false, mbf.GetFlag());
        }

        [TestMethod]
        public void GetFlag_0positionFalse_falseReturned()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(1000, false);

            for (ulong i = 1; i < 1000; i++)
            {
                mbf.SetFlag(i);
            }

            Assert.AreEqual(false, mbf.GetFlag());
        }

        [TestMethod]
        public void GetFlag_300positionTrue_falseReturned()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(1000, false);

            mbf.SetFlag(300);

            Assert.AreEqual(false, mbf.GetFlag());
        }

        [TestMethod]
        public void GetFlag_999positionFalse_falseReturned()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(1000, true);

            mbf.ResetFlag(999);

            Assert.AreEqual(false, mbf.GetFlag());
        }

        [TestMethod]
        public void GetFlag_0positionTrue_falseReturned()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(1000, false);

            mbf.SetFlag(0);

            Assert.AreEqual(false, mbf.GetFlag());
        }
    }
}
