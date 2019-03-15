using Capstone.Web.DAL.Interfaces;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class SurveySQLDAL : ISurveySQLDAL
    {
        private string connectionString;

        private const string SQL_GetSurveyCount = "SELECT COUNT(survey_result.parkCode) AS surveyCount, survey_result.parkCode, park.parkName FROM survey_result JOIN park ON survey_result.parkCode = park.parkCode GROUP BY survey_result.parkCode, park.parkName ORDER BY surveyCount DESC";
        private const string SQL_AddSurvey = "INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) VALUES (@parkCode, @emailAddress, @state, @activityLevel);";

        public SurveySQLDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<SurveyResult> GetSurveyCount()
        {
            List<SurveyResult> surveyResultList = new List<SurveyResult>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetSurveyCount, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        SurveyResult surveyResult = new SurveyResult();

                        surveyResult.SurveyCount = Convert.ToInt32(reader["surveyCount"]);
                        surveyResult.ParkCode = Convert.ToString(reader["parkCode"]);
                        surveyResult.ParkName = Convert.ToString(reader["parkName"]);

                        surveyResultList.Add(surveyResult);
                    }
                }
            }
            catch
            {
                surveyResultList = new List<SurveyResult>();
            }
            return surveyResultList;
        }

        public bool AddSurvey(Survey survey)
        {
            int count = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(SQL_AddSurvey, conn);

                cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                cmd.Parameters.AddWithValue("@emailAddress", survey.EmailAddress);
                cmd.Parameters.AddWithValue("@state", survey.State);
                cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);

                count = cmd.ExecuteNonQuery();
            }

            if (count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
