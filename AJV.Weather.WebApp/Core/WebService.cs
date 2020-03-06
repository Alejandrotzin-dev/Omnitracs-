using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AJV.Weather.WebApp.Core
{
	/// <summary>
	/// actions to consue web service
	/// </summary>
	public class WebService
	{
		public async Task<T> Get<T>(string url)
		{
			HttpClient http = new HttpClient();
			//var data = default(T);

			try
			{
				var response = await http.GetAsync(url);
				response.EnsureSuccessStatusCode();
				var result = await response.Content.ReadAsStringAsync();
				var data = JsonConvert.DeserializeObject<T>(result);
				//return result;
				return data;
			}
			catch(Exception ex)
			{
				return default(T);
			}
			finally
			{
				http.Dispose();
			}
		}
	}
}