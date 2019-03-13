using Capstone.Web.DAL.Interfaces;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class WeatherSQLDAL : IWeatherSQLDAL
    {
        private string connectionString;

        private const string SQL_GetWeather = "SELECT * FROM weather WHERE parkCode = @parkCode;";

        public WeatherSQLDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Weather> GetForecast(string parkCode)
        {
            List<Weather> forecast = new List<Weather>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(SQL_GetWeather, connection);
                    command.Parameters.AddWithValue("@parkCode", parkCode);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Weather weather = new Weather();

                        weather.ParkCode = Convert.ToString(reader["parkCode"]);
                        weather.FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]);
                        weather.Low = Convert.ToInt32(reader["low"]);
                        weather.High = Convert.ToInt32(reader["high"]);
                        weather.Forecast = Convert.ToString(reader["forecast"]);

                        forecast.Add(weather);
                    }
                }
            }
            catch (Exception)
            {
                forecast = new List<Weather>();
            }

            return forecast;
        }
    }
}
