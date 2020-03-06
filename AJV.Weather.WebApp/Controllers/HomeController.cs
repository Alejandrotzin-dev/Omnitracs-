using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AJV.Weather.WebApp.Core;

namespace AJV.Weather.WebApp.Controllers
{
	public class HomeController : Controller
	{
		private WeatherApi _weather;
		public WeatherApi Weather
		{
			get
			{
				if (_weather == null)
					_weather = new WeatherApi();

				return _weather;
			}
		}

		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> LocalWeather(decimal latitude, decimal longitude)
		{
			var weather = await Weather.GetWeatherByCoords(latitude, longitude);
			return PartialView("_Weather", weather); //Json(weather, JsonRequestBehavior.DenyGet);
		}


	}
}