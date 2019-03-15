using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class SurveyResult
    {
        [Display(Name = "Survey Count")]
        public int SurveyCount { get; set; }

        [Display(Name = "Park Code")]
        public string ParkCode { get; set; }

        [Display(Name = "Park Name")]
        public string ParkName { get; set; }
    }
}
