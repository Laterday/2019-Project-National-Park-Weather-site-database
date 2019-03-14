using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL.Interfaces;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveySQLDAL surveySQLDAL;
        private IParkSQLDAL parkSQLDAL;

        public SurveyController(ISurveySQLDAL surveySQLDAL, IParkSQLDAL parkSQLDAL)
        {
            this.surveySQLDAL = surveySQLDAL;
            this.parkSQLDAL = parkSQLDAL;
        }

        [HttpGet]
        public IActionResult Submit()
        {
            ViewBag.ParkSelectList = parkSQLDAL.GetUniqueParkNames();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Submit(Survey survey)
        {
            if (!ModelState.IsValid)
            {
                return View(survey);
            }
            else
            {
                bool result = surveySQLDAL.AddSurvey(survey);
                return RedirectToAction(nameof(ViewSurveyResults));
            }
        }

        [HttpGet]
        public IActionResult ViewSurveyResults()
        {
            List<SurveyResult> results = surveySQLDAL.GetSurveyCount();
            return View(results);
        }
    }
}