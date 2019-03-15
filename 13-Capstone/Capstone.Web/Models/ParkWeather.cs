using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class ParkWeather
    {
        public Park Park { get; set; }
        public List<Weather> WeatherList { get; set; }
        public string ParkName { get; set; }
        public string ParkCode { get; set; }
    }
}
