using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using Capstone.Web.Models;
using System.Data.SqlClient;
using System.Collections.Generic;
using Capstone.Web.DAL;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.Tests
{
    [TestClass]
    public class WeatherSQLDALTest
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

                SqlCommand command = new SqlCommand("INSERT INTO weather VALUES ('FP', 1, 28, 100, 'rain')", connection);

                affectedRows = (int)command.ExecuteNonQuery();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            transaction.Dispose();
        }

        [TestMethod]
        public void GetWeatherTest()
        {
            WeatherSQLDAL weather = new WeatherSQLDAL(connectionString);
            List<Weather> weatherList = weather.GetForecast("FP");

            Assert.AreEqual(1, affectedRows);
            Assert.AreEqual("rain", weatherList[0].Forecast);
            Assert.AreEqual("Be sure to pack rain gear and wear waterproof shoes. Since it will be so warm out, bringing an extra gallon of water is recommended.", weatherList[0].Recommendation);
        }
    }
}
