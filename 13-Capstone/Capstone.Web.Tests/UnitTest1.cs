using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using System.Data.SqlClient;


namespace Capstone.Web.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private TransactionScope tran;
        private string connectionString = "";

        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command;
                connection.Open();
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(true);
        }
    }
}
