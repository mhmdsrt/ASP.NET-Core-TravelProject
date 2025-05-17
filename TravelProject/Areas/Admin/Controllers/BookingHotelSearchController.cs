using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TravelProject.Areas.Admin.Models;

namespace TravelProject.Areas.Admin.Controllers
{
	[AllowAnonymous]
	[Area("Admin")]
	[Route("Admin/[Controller]/[Action]/{id?}")]
	public class BookingHotelSearchController : Controller // Rapid API üzerinden verileri çekeceğimiz Controller	
	{
		public async Task<IActionResult> Index(string? cityID= "-1456928")
		{
			var client = new HttpClient(); // API isteği atmak için istemci oluşturuyoruz
			var request = new HttpRequestMessage // request -> istek

			{
				Method = HttpMethod.Get, // GET isteği başlatıyor
				// Otel Arama API'sine özel sorgu parametreleri bir URL
				RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/search?categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&adults_number=2&page_number=0&children_number=2&include_adjacency=true&children_ages=5%2C0&locale=tr&dest_type=city&filter_by_currency=EUR&dest_id={cityID}&order_by=popularity&units=metric&checkout_date=2025-10-15&room_number=1&checkin_date=2025-10-14"),
				Headers =
	{
	    // Rapid API Kimlik Bilgileri , bunlar olmadan Booking API bizi tanımaz
		{ "x-rapidapi-key", "2f10fbb030msh7bdfe2c628c49cdp12bafbjsn1228b9170732" },
		{ "x-rapidapi-host", "booking-com.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request)) // İstek gönderilir ve cevap beklenir 
			{ // using bloğu sayesinde istekten sonra response nesnesi dispose edilir
			  // Ensure -> Emin Olamak, 
				response.EnsureSuccessStatusCode(); // İstek başarılı mı(200) emin ol!, başarısızsa hata fırlatır
				var body = await response.Content.ReadAsStringAsync(); // Gelen JSON verisini düz metin olarak alır
																	   // SerializeObject() -> C# Nesnesini JSON formatına dönüştürür. Serialize Object -> Nesneyi Serileştir
																	   // DeserializeObject<T>() -> JSON formatındaki metni C# nesnesine dönüştürür
				var values = JsonConvert.DeserializeObject<BookingHotelSeachViewModel>(body); // JSON verisi, BookingHotelSeachViewModel sınıfı tipine dönüştürülür
				return View(values.result);
			}
			
		}

		public async Task<IActionResult> GetIdByCity(string cityName="Paris") // Şehrin ismine göre Şehrin ID sini getiriyoruz, ama id değerini string dönüyor
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=en-gb&name={cityName}"),
				Headers =
	{
		{ "x-rapidapi-key", "2f10fbb030msh7bdfe2c628c49cdp12bafbjsn1228b9170732" },
		{ "x-rapidapi-host", "booking-com.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				var destID = JsonConvert.DeserializeObject<List<BookingHotelSeachViewModel>>(body);
				var _cityID = destID.FirstOrDefault().dest_id;

				if (string.IsNullOrEmpty(_cityID))
				{
					return RedirectToAction("Index", new {cityID= "-1456928" });
				}
				return RedirectToAction("Index", new { cityID = _cityID });


			}
		}
	}

	
}
