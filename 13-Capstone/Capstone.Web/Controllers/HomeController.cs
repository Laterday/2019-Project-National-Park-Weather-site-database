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

        public HomeController(IParkSQLDAL parkSQLDAL)
        {
            this.parkSQLDAL = parkSQLDAL;
        }

        public IActionResult Index()
        {
            List<Park> parks = parkSQLDAL.GetParks();
            return View(parks);
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
