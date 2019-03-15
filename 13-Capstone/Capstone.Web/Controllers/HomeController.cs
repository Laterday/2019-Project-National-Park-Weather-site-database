using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL.Interfaces;
using Microsoft.AspNetCore.Http;

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
            if (HttpContext.Session.GetString("TempData") == null)
            {
                HttpContext.Session.SetString("TempData", "");
            }

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
                WeatherList = weatherList,
                ParkCode = parkCode
            };

            ViewBag.TempUnit = HttpContext.Session.GetString("TempData");

            return View(parkWeather);
        }

        [HttpGet]
        public IActionResult ConvertTemperature(string parkCode)
        {
            if (HttpContext.Session.GetString("TempData") == "")
            {
                HttpContext.Session.SetString("TempData", "Celsius");
            }
            else
            {
                HttpContext.Session.SetString("TempData", "");
            }

            Park park = parkSQLDAL.GetParkDetails(parkCode);
            List<Weather> weatherList = weatherSQLDAL.GetForecast(parkCode);
            ParkWeather parkWeather = new ParkWeather
            {
                Park = park,
                WeatherList = weatherList,
                ParkCode = parkCode
            };

            return RedirectToAction("Detail", "Home", new { parkCode = parkWeather.ParkCode });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
