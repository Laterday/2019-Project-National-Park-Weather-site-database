using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Weather
    {
        public string ParkCode { get; set; }
        public int FiveDayForecastValue { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public string Forecast { get; set; }
        public string PictureName
        {
            get
            {
                if (Forecast == "partly cloudy")
                {
                    return "partlyCloudy";
                }
                else
                {
                    return Forecast;
                }
            }
            set { }
        }
        public string Recommendation
        {
            get
            {
                string result = "Be sure to ";

                switch (Forecast)
                {
                    case "snow":
                        result += "pack snowshoes.";
                        break;
                    case "rain":
                        result += "pack rain gear and wear waterproof shoes.";
                        break;
                    case "thunderstorms":
                        result += "seek shelter and avoid hiking on exposed ridges.";
                        break;
                    case "sunny":
                        result += "pack sunblock.";
                        break;
                    default:
                        result += "enjoy the cloudy day.";
                        break;
                }

                if (High > 75)
                {
                    result += " Since it will be so warm out, bringing an extra gallon of water is recommended.";
                }

                if (Low < 20)
                {
                    result += " Since it will be so cold out, be aware that sustained exposure to frigid temperatures is dangerous.";
                }

                if (Math.Abs(High - Low) > 20)
                {
                    result += " It may be worthwhile to dress in breathable layers due to the variation in temperature throughout the day.";
                }

                return result;
            }
        }

        public static double FarenheitToCelsius(int farenheitValue)
        {
            return (double)((farenheitValue - 32) * 5/9);
        }

        //public static string GetRecommendation(string forecast, int high, int low)
        //{
        //    string result = "Be sure to ";

        //    switch (forecast)
        //    {
        //        case "snow":
        //            result += "pack snowshoes.";
        //            break;
        //        case "rain":
        //            result += "pack rain gear and wear waterproof shoes.";
        //            break;
        //        case "thunderstorms":
        //            result += "seek shelter and avoid hiking on exposed ridges.";
        //            break;
        //        case "sunny":
        //            result += "pack sunblock.";
        //            break;
        //        default:
        //            result += "enjoy the cloudy day.";
        //            break;
        //    }

        //    if (high > 75)
        //    {
        //        result += " Since it will be so warm out, bringing an extra gallon of water is recommended.";
        //    }

        //    if (low < 20)
        //    {
        //        result += " Since it will be so cold out, be aware that sustained exposure to frigid temperatures is dangerous.";
        //    }

        //    if (Math.Abs(high - low) > 20)
        //    {
        //        result += " It may be worthwhile to dress in breathable layers due to the variation in temperature throughout the day.";
        //    }

        //    return result;
        //}
    }
}
