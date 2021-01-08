using Microsoft.VisualStudio.TestTools.UnitTesting;
using IIG.CoSFE.DatabaseUtils;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestL4
{
    [TestClass]
    public class TestsL4DB1Record
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

        string spaceLP = IIG.PasswordHashingUtils.PasswordHasher.GetHash(" ");
        string fewSpaceLP = IIG.PasswordHashingUtils.PasswordHasher.GetHash("      ");

        string spSymbolsLP = IIG.PasswordHashingUtils.PasswordHasher.GetHash("!@#$%^&*()_+~:?><\\|\"'");


        [TestMethod]
        public void Database_Add()
        {
            Assert.IsTrue(authDatabaseUtils.AddCredentials(dLogin, dPassword));
        }

        [TestMethod]
        public void Database_Add_nullLP()
        {
            Assert.IsFalse(authDatabaseUtils.AddCredentials(null, null));
        }

        [TestMethod]
        public void Database_Add_spaceLP()
        {
            Assert.IsTrue(authDatabaseUtils.AddCredentials(spaceLP, spaceLP));
        }

        [TestMethod]
        public void Database_Add_fewSpaceLP()
        {
            Assert.IsTrue(authDatabaseUtils.AddCredentials(fewSpaceLP, fewSpaceLP));
        }

        [TestMethod]
        public void Database_Add_spSymbols()
        {
            Assert.IsFalse(authDatabaseUtils.AddCredentials("!@#$%^&*()_+~:?><\\|\"'", "!@#$%^&*()_+~:?><|\\\"'"));
        }

        [TestMethod]
        public void Database_Add_spSymbolsHash()
        {
            Assert.IsTrue(authDatabaseUtils.AddCredentials(spSymbolsLP, spSymbolsLP));
        }

        [TestMethod]
        public void Database_Check()
        {
            Assert.IsTrue(authDatabaseUtils.CheckCredentials(dLogin, dPassword));
        }

        [TestMethod]
        public void Database_Update()
        {
            Assert.IsTrue(authDatabaseUtils.UpdateCredentials(dLogin, dPassword, newdLogin, newdPassword));
        }

        [TestMethod]
        public void Database_Delete()
        {
            Assert.IsTrue(authDatabaseUtils.DeleteCredentials(newdLogin, newdPassword));
        }

        [TestMethod]
        public void Database_DeleteAllS()
        {
            Assert.IsTrue(authDatabaseUtils.DeleteCredentials(spaceLP, spaceLP)
                && authDatabaseUtils.DeleteCredentials(fewSpaceLP, fewSpaceLP) 
                && authDatabaseUtils.DeleteCredentials(spSymbolsLP, spSymbolsLP));
        }
    }
}
