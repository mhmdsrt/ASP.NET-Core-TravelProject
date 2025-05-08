using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelProject.Controllers
{
	[AllowAnonymous]
	public class ErrorPageController : Controller
	{
		/*
		  app.UseStatusCodePagesWithReExecute("/ErrorPage/Error", "?code={0}"); -> Program.cs'deki soldaki kod sayesinde
		  oluşan hatanın durum kodu ErrorPage Controller'ın altındaki Error metoduna parametre olarak gönderilir
		 */
		public IActionResult Error(int code)
		{
			if (code == 404)
			{
				return View("NotFound404");
			}

			// 404 dışında başka bir hata geldiyse, GenericErrorPage metoduna code'u gönder

			return RedirectToAction(nameof(GenericErrorPage), new { code = code });
			/*
			  Burada nameof(GenericErrorPage) ifadesi, "GenericErrorPage" gibi string döner.
			 Yani metot adını string olarak yazmak yerine nameof() kullanıyoruz ki
             eğer ileride GenericErrorPage metodunun adını değiştirirsek (refactor yaparsak), burada otomatik güncellenir.

             Böylece yazım hatalarını engellemiş oluruz 
			 */
		}

		public IActionResult NotFound404() // Sayfa Bulunamadı hatası için özel hata sayfası
		{
			return View();
		}

		public IActionResult GenericErrorPage(int code) // Genel Hata Sayfası
		{
			ViewBag.ErrorCode = code;
			return View();
		}
	}
}
