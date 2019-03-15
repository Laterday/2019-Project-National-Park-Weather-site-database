using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL.Interfaces;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private IParkSQLDAL parkSQLDAL;
        private IWeatherSQLDAL weatherSQLDAL;

        public HomeController(IParkSQLDAL parkSQLDAL, IWeatherSQLDAL weatherSQLDAL)
        {
            this.parkSQLDAL = parkSQLDAL;
            this.weatherSQLDAL = weatherSQLDAL;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //if (ViewBag.TempUnit == null)
            //{
            //    ViewBag.TempUnit = "";
            //}

            List<Park> parks = parkSQLDAL.GetParks();
            return View(parks);
        }

        [HttpGet]
        public IActionResult Detail(string parkCode)
        {
            Park park = parkSQLDAL.GetParkDetails(parkCode);
            List<Weather> weatherList = weatherSQLDAL.GetForecast(parkCode);
            ParkWeather parkWeather = new ParkWeather
            {
                Park = park,
                WeatherList = weatherList
            };

            if (TempData["TempUnit"] == null)
            {
                TempData["TempUnit"] = "";
            }

            ViewBag.TempUnit = TempData["TempUnit"].ToString();

            return View(parkWeather);
        }

        [HttpGet]
        public IActionResult ConvertTemperature(string parkCode)
        {
            if (ViewBag.TempUnit == "Celsius")
            {
                TempData["TempUnit"] = "";
            }
            else
            {
                TempData["TempUnit"] = "Celsius";
            }

            Park park = parkSQLDAL.GetParkDetails(parkCode);
            List<Weather> weatherList = weatherSQLDAL.GetForecast(parkCode);
            ParkWeather parkWeather = new ParkWeather
            {
                Park = park,
                WeatherList = weatherList,
                ParkCode = parkCode
            };

            return RedirectToAction("Detail", "Home", parkCode as object);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
