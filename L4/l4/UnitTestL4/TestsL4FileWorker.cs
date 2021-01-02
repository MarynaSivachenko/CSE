using IIG.CoSFE.DatabaseUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;



namespace UnitTestL4
{
    [TestClass]
    public class TestsL4FileWorker
    {

        [TestMethod]
        public void FileWorker_Add_Get_FlagFalse()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(2, false);

            IIG.FileWorker.BaseFileWorker.Write(mbf.GetFlag().ToString(), @"C:\Users\user\Desktop\Навчання\4 курс\7 семестр\КПІ-3\l4\l4\UnitTestL4\TextFile.txt");

            string expected = mbf.GetFlag().ToString();
            string actual = IIG.FileWorker.BaseFileWorker.ReadAll(@"C:\Users\user\Desktop\Навчання\4 курс\7 семестр\КПІ-3\l4\l4\UnitTestL4\TextFile.txt");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FileWorker_Add_Get_FlagTrue()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(2, true);

            IIG.FileWorker.BaseFileWorker.Write(mbf.GetFlag().ToString(), @"C:\Users\user\Desktop\Навчання\4 курс\7 семестр\КПІ-3\l4\l4\UnitTestL4\TextFile.txt");

            string expected = mbf.GetFlag().ToString();
            string actual = IIG.FileWorker.BaseFileWorker.ReadAll(@"C:\Users\user\Desktop\Навчання\4 курс\7 семестр\КПІ-3\l4\l4\UnitTestL4\TextFile.txt");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FileWorker_Add_Get_FlagTrueChanged()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(10, true);
            mbf.ResetFlag(2);

            IIG.FileWorker.BaseFileWorker.Write(mbf.GetFlag().ToString(), @"C:\Users\user\Desktop\Навчання\4 курс\7 семестр\КПІ-3\l4\l4\UnitTestL4\TextFile.txt");

            string expected = mbf.GetFlag().ToString();
            string actual = IIG.FileWorker.BaseFileWorker.ReadAll(@"C:\Users\user\Desktop\Навчання\4 курс\7 семестр\КПІ-3\l4\l4\UnitTestL4\TextFile.txt");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FileWorker_Add_Get_FlagFalseChanged()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(10, false);
            mbf.SetFlag(2);

            IIG.FileWorker.BaseFileWorker.Write(mbf.GetFlag().ToString(), @"C:\Users\user\Desktop\Навчання\4 курс\7 семестр\КПІ-3\l4\l4\UnitTestL4\TextFile.txt");

            string expected = mbf.GetFlag().ToString();
            string actual = IIG.FileWorker.BaseFileWorker.ReadAll(@"C:\Users\user\Desktop\Навчання\4 курс\7 семестр\КПІ-3\l4\l4\UnitTestL4\TextFile.txt");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FileWorker_Get_FlagsFalse()
        {
            string[] arrFlag = new string[10];
            for (int i = 0; i < 10; i++)
            {
                arrFlag[i] = (new IIG.BinaryFlag.MultipleBinaryFlag(2, false)).GetFlag().ToString();
            }

            string[] actualArr = IIG.FileWorker.BaseFileWorker.ReadLines(@"C:\Users\user\Desktop\Навчання\4 курс\7 семестр\КПІ-3\l4\l4\UnitTestL4\TextFile1.txt");

            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(arrFlag[i], actualArr[i]);
            }
        }

        [TestMethod]
        public void FileWorker_Get_FlagsTrue()
        {
            string[] arrFlag = new string[10];
            for (int i = 0; i < 10; i++)
            {
                arrFlag[i] = (new IIG.BinaryFlag.MultipleBinaryFlag(2, true)).GetFlag().ToString();
            }

            string[] actualArr = IIG.FileWorker.BaseFileWorker.ReadLines(@"C:\Users\user\Desktop\Навчання\4 курс\7 семестр\КПІ-3\l4\l4\UnitTestL4\TextFile2.txt");

            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(arrFlag[i], actualArr[i]);
            }
        }

        [TestMethod]
        public void FileWorker_Get_FlagsDifferent()
        {
            string[] arrFlag = new string[10];
            for (int i = 0; i < 10; i++)
            {
                if (i == 0 || i == 5 || i == 7 || i == 8 || i == 9)
                {
                    arrFlag[i] = (new IIG.BinaryFlag.MultipleBinaryFlag(2, false)).GetFlag().ToString();
                }
                else {
                    arrFlag[i] = (new IIG.BinaryFlag.MultipleBinaryFlag(2, true)).GetFlag().ToString();
                }
            }

            string[] actualArr = IIG.FileWorker.BaseFileWorker.ReadLines(@"C:\Users\user\Desktop\Навчання\4 курс\7 семестр\КПІ-3\l4\l4\UnitTestL4\TextFile3.txt");

            string actual = IIG.FileWorker.BaseFileWorker.ReadAll(@"C:\Users\user\Desktop\Навчання\4 курс\7 семестр\КПІ-3\l4\l4\UnitTestL4\TextFile3.txt");

            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(arrFlag[i], actualArr[i]);
            }
        } 
    }
}
