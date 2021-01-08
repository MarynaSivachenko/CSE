using Microsoft.VisualStudio.TestTools.UnitTesting;
using IIG.CoSFE.DatabaseUtils;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestL4
{

    [TestClass]
    public class TestsL4DBFewRecords
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
            Assert.IsTrue(authDatabaseUtils.AddCredentials(dLogin, dPassword) 
                && authDatabaseUtils.AddCredentials(newdLogin, newdPassword));
        }

        [TestMethod]
        public void Database_CheckFew()
        {
            /*bool res;
            bool res2 = authDatabaseUtils.CheckCredentials(dLogin, dPassword);
            bool res1 = authDatabaseUtils.CheckCredentials(newdLogin, newdPassword);

            if (res1 == true && res2 == true)
                res = true;
            else
                res = false;*/
            Assert.IsTrue(authDatabaseUtils.CheckCredentials(dLogin, dPassword) 
                && authDatabaseUtils.CheckCredentials(newdLogin, newdPassword));
        }

        [TestMethod]
        public void Database_DeleteOneFromFew()
        {
            Assert.IsTrue(authDatabaseUtils.DeleteCredentials(dLogin, dPassword));
        }

        [TestMethod]
        public void Database_CheckWrong()
        {
            Assert.IsFalse(authDatabaseUtils.CheckCredentials(wrongdLogin, wrongdPassword));
        }

        [TestMethod]
        public void Database_AddSame()
        {
            Assert.IsFalse(authDatabaseUtils.AddCredentials(dLogin, dPassword));
        }

        [TestMethod]
        public void Database_DeleteWrong()
        {           
            Assert.IsTrue(authDatabaseUtils.DeleteCredentials(dLogin, dPassword));
        }

       [TestMethod]
       public void Database_DeleteLast()
       {
            Assert.IsTrue(authDatabaseUtils.DeleteCredentials(newdLogin, newdPassword));
       }
    }
}
