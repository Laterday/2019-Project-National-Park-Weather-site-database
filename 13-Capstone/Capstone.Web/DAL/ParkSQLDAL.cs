using Capstone.Web.DAL.Interfaces;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class ParkSQLDAL : IParkSQLDAL
    {
        private string connectionString;

        private const string SQL_GetParks = "SELECT * FROM park;";
        private const string SQL_GetUniqueParkNames = "SELECT DISTINCT parkCode, parkName FROM park ORDER BY parkName;";
        private const string SQL_GetParkDetails = "SELECT * FROM park WHERE parkCode = @parkCode;";

        public ParkSQLDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Park> GetParks()
        {
            List<Park> parks = new List<Park>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(SQL_GetParks, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Park park = new Park();

                        park.ParkCode = Convert.ToString(reader["parkCode"]);
                        park.ParkName = Convert.ToString(reader["parkName"]);
                        park.State = Convert.ToString(reader["state"]);
                        park.Acreage = Convert.ToInt32(reader["acreage"]);
                        park.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
                        park.MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]);
                        park.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
                        park.Climate = Convert.ToString(reader["climate"]);
                        park.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                        park.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
                        park.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
                        park.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        park.ParkDescription = Convert.ToString(reader["parkDescription"]);
                        park.EntryFee = Convert.ToInt32(reader["entryFee"]);
                        park.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);

                        parks.Add(park);
                    }
                }
            }
            catch (Exception)
            {
                parks = new List<Park>();
            }

            return parks;
        }

        public List<SelectListItem> GetUniqueParkNames()
        {
            List<SelectListItem> parks = new List<SelectListItem>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(SQL_GetUniqueParkNames, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        SelectListItem item = new SelectListItem();

                        item.Value = Convert.ToString(reader["parkCode"]);
                        item.Text = Convert.ToString(reader["parkName"]);

                        parks.Add(item);
                    }
                }
            }
            catch (Exception)
            {
                parks = new List<SelectListItem>();
            }

            return parks;
        }

        public Park GetParkDetails(string parkCode)
        {
            Park park = new Park();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(SQL_GetParkDetails, connection);
                    command.Parameters.AddWithValue("@parkCode", parkCode);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        park.ParkCode = Convert.ToString(reader["parkCode"]);
                        park.ParkName = Convert.ToString(reader["parkName"]);
                        park.State = Convert.ToString(reader["state"]);
                        park.Acreage = Convert.ToInt32(reader["acreage"]);
                        park.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
                        park.MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]);
                        park.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
                        park.Climate = Convert.ToString(reader["climate"]);
                        park.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                        park.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
                        park.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
                        park.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        park.ParkDescription = Convert.ToString(reader["parkDescription"]);
                        park.EntryFee = Convert.ToInt32(reader["entryFee"]);
                        park.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);
                    }
                }
            }
            catch (Exception)
            {
                park = new Park();
            }

            return park;
        }
    }
}
