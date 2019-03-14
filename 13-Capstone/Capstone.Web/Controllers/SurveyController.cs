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

        public SurveyController(ISurveySQLDAL surveySQLDAL)
        {
            this.surveySQLDAL = surveySQLDAL;
        }

        [HttpGet]
        public IActionResult Submit()
        {
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