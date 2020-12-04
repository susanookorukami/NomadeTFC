using NomadeTFC.Models;
using NomadeTFC.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NomadeTFC.ViewModels
{
    public class WeatherCore
    {
        public static async Task<Weather> GetWeather(string ville)
        {
            string key = "d2dc2b04ca7fa14e73f5058111029bf2";
            string queryString = "api.openweathermap.org/data/2.5/weather?q="+ville+"&appid="+key+"&units=metric";

            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            if (results["weather"] != null)
            {
                Weather weather = new Weather();
                weather.Title = (string)results["name"];
                weather.Temperature = (string)results["main"]["temp"]+ "C°";
                weather.Wind = (string)results["wind"]["speed"] + "Km/h";
                weather.Humidity = (string)results["main"]["humidity"] + " %";
                weather.Visibility = (string)results["weather"][0]["main"];

                DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0);
                DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
                DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);

                weather.Sunrise = sunrise.ToString();
                weather.Sunset = sunset.ToString();

                return weather;
            }
            else
            {
                return null;
            }
        }
    }
}
