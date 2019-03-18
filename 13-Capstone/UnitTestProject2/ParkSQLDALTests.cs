
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using Capstone.Web.Models;
using System.Data.SqlClient;
using System.Collections.Generic;
using Capstone.Web.DAL;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web
{
    [TestClass]
    public class ParkSQLDALTests
    {
        private TransactionScope transaction;
        private string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=NPGeek;Integrated Security=True";
        private int affectedRows;

        [TestInitialize]
        public void Initialize()
        {
            transaction = new TransactionScope();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO park VALUES ('FP', 'Fake Park', 'Ohio', 100, 100, 100, 100, 'Warm', 2000, 100, 'Visit soon!', 'Bono', 'A really cool park.', 1, 100)", connection);

                affectedRows =  (int)command.ExecuteNonQuery();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            transaction.Dispose();
        }

        [TestMethod]
        public void GetParksTest()
        {
            ParkSQLDAL park = new ParkSQLDAL(connectionString);
            List<Park> parks = park.GetParks();

            Assert.AreEqual(1, affectedRows);
            Assert.IsTrue(parks.Count >= 1);
        }

        [TestMethod]
        public void GetUniqueParkNamesTest()
        {
            ParkSQLDAL park = new ParkSQLDAL(connectionString);
            List<SelectListItem> parks = park.GetUniqueParkNames();

            Assert.AreEqual(1, affectedRows);
            Assert.IsTrue(parks.Count >= 1);
        }

        [TestMethod]
        public void GetParkDetailsTest()
        {
            ParkSQLDAL park = new ParkSQLDAL(connectionString);
            Park newPark = park.GetParkDetails("FP");

            Assert.AreEqual(1, affectedRows);
            Assert.AreEqual("Fake Park", newPark.ParkName);
        }
    }
}
