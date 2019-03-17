
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using Capstone.Web.Models;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace Capstone.Web.Tests
{
    [TestClass]
    public class CapstoneWebTests
    {
        private TransactionScope tran;
        private string connectionString;

        public CapstoneWebTests(string connectionString)
        {
            this.connectionString = connectionString;
        }

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
