using IIG.CoSFE.DatabaseUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;



namespace UnitTestL4
{
    [TestClass]
    public class TestsL4
    {
   
        private const string Server = @"DESKTOP-TCRGH8J\MSSQLSERVER1";
        private const string Database = @"IIG.CoSWE.AuthDB";
        private const bool IsTrusted = false;
        private const string Login = @"sa";
        private const string Password = @"sqlserver1";
        private const int ConnectionTimeout = 75;
        public AuthDatabaseUtils authDatabaseUtils =
            new AuthDatabaseUtils(Server, Database, IsTrusted, Login, Password, ConnectionTimeout);

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

        string dLogin = IIG.PasswordHashingUtils.PasswordHasher.GetHash("user1");
        string dPassword = IIG.PasswordHashingUtils.PasswordHasher.GetHash("user1pass");

        string newdLogin = IIG.PasswordHashingUtils.PasswordHasher.GetHash("user1change");
        string newdPassword = IIG.PasswordHashingUtils.PasswordHasher.GetHash("user1passChange");

        [TestMethod]
        public void Database_Add()
        {    
            bool res = authDatabaseUtils.AddCredentials(dLogin, dPassword);
            
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Database_Check()
        {
            bool res = authDatabaseUtils.CheckCredentials(dLogin, dPassword);
           
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Database_Update()
        {

            bool res = authDatabaseUtils.UpdateCredentials(dLogin, dPassword, newdLogin, newdPassword);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Database_Delete()
        {


            bool res = authDatabaseUtils.DeleteCredentials(newdLogin, newdPassword);

            Assert.IsTrue(res);
        }

     

        
        
       
    }

    [TestClass]
    public class TestsL4part2
    {

        private const string Server = @"DESKTOP-TCRGH8J\MSSQLSERVER1";
        private const string Database = @"IIG.CoSWE.AuthDB";
        private const bool IsTrusted = false;
        private const string Login = @"sa";
        private const string Password = @"sqlserver1";
        private const int ConnectionTimeout = 75;
        public AuthDatabaseUtils authDatabaseUtils =
            new AuthDatabaseUtils(Server, Database, IsTrusted, Login, Password, ConnectionTimeout);


        string dLogin = IIG.PasswordHashingUtils.PasswordHasher.GetHash("user1");
        string dPassword = IIG.PasswordHashingUtils.PasswordHasher.GetHash("user1pass");

        string newdLogin = IIG.PasswordHashingUtils.PasswordHasher.GetHash("user1change");
        string newdPassword = IIG.PasswordHashingUtils.PasswordHasher.GetHash("user1passChange");

        string wrongdLogin = IIG.PasswordHashingUtils.PasswordHasher.GetHash("userwrong");
        string wrongdPassword = IIG.PasswordHashingUtils.PasswordHasher.GetHash("user1passwrong");


        [TestMethod]
        public void Database_AddFew()
        {
            bool res;
            bool res2 = authDatabaseUtils.AddCredentials(dLogin, dPassword);
            bool res1 = authDatabaseUtils.AddCredentials(newdLogin, newdPassword);

            if (res1 == true && res2 == true)
                res = true;
            else
                res = false;
            Assert.IsTrue(res);

        }

        [TestMethod]
        public void Database_CheckFew()
        {
            bool res;
            bool res2 = authDatabaseUtils.CheckCredentials(dLogin, dPassword);
            bool res1 = authDatabaseUtils.CheckCredentials(newdLogin, newdPassword);

            if (res1 == true && res2 == true)
                res = true;
            else
                res = false;
            Assert.IsTrue(res);

        }

        [TestMethod]
        public void Database_DeleteOneFromFew()
        {

            bool res = authDatabaseUtils.DeleteCredentials(dLogin, dPassword);

            Assert.IsTrue(res);

        }

        [TestMethod]
        public void Database_CheckWrong()
        {

            bool res = authDatabaseUtils.CheckCredentials(wrongdLogin, wrongdPassword);

            Assert.IsFalse(res);

        }

        [TestMethod]
        public void Database_AddSame()
        {

            bool res = authDatabaseUtils.AddCredentials(dLogin, dPassword);

            Assert.IsFalse(res);

        }

        [TestMethod]
        public void Database_DeleteWrong()
        {

            bool res = authDatabaseUtils.DeleteCredentials(dLogin, dPassword);
            authDatabaseUtils.DeleteCredentials(newdLogin, newdPassword);
            Assert.IsTrue(res);


        }
    }
}
