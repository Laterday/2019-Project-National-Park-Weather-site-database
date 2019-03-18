using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using Capstone.Web.Models;
using System.Data.SqlClient;
using Capstone.Web.DAL;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.Tests
{
    [TestClass]
    public class SurveySQLDALTests
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

                SqlCommand command = new SqlCommand("INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) VALUES ('YNP', 'g@gmail.com', 'OH', 'Active')", connection);

                affectedRows = (int)command.ExecuteNonQuery();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            transaction.Dispose();
        }

        [TestMethod]
        public void GetSurveyCountTest()
        {
            SurveySQLDAL survey = new SurveySQLDAL(connectionString);
            List<SurveyResult> result = survey.GetSurveyCount();

            Assert.AreEqual(1, affectedRows);
            Assert.IsTrue(result.Count >= 1);
        }

        [TestMethod]
        public void AddSurveyTest()
        {
            SurveySQLDAL surveyDAL = new SurveySQLDAL(connectionString);

            Survey survey = new Survey
            {
                ParkCode = "YNP",
                EmailAddress = "k@gmail.com",
                State = "OH",
                ActivityLevel = "Active"
            };

            bool result = surveyDAL.AddSurvey(survey);
            
            Assert.IsTrue(result);
        }
    }
}
