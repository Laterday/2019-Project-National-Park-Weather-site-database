using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Survey
    {
        [Required]
        [Display(Name = "Park Name")]
        public string ParkCode { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [Display(Name = "Activity Level")]
        public string ActivityLevel { get; set; }
    }
}
