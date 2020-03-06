using AJV.Weather.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AJV.Weather.WebApp.Core
{
	public class WeatherApi
	{
		private const string apiUrl = "https://api.openweathermap.org/data/2.5/weather?";
		private const string apiKey = "4fd018d9b26828aefeb74e8283437a25";
		private WebService WS = new WebService();


		/// <summary>
		/// get weather by coords
		/// </summary>
		/// <param name="latitude"></param>
		/// <param name="longitude"></param>
		public async Task<WeatherResponse> GetWeatherByCoords(decimal latitude, decimal longitude)
		{
			string url = apiUrl + string.Format("lat={0}&lon={1}&appid={2}", latitude, longitude, apiKey);
			var weather = await WS.Get<WeatherResponse>(url);
			return weather;
		}
	}
}