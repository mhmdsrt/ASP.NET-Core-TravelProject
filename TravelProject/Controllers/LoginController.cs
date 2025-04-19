using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TravelProject.Models;

namespace TravelProject.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public LoginController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public IActionResult SignUp()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SignUp(UserRegisterViewModel userRegisterViewModel) // SignUp -> Uye Ol 
		{
			AppUser appUser = new AppUser()
			{
				// Şifre bu kod bloğunda verilmez çünkü şifre Identity tarafından Hash’lenerek güvenli şekilde saklanır.

				Name = userRegisterViewModel.Name,
				SurName = userRegisterViewModel.SurName,
				Email = userRegisterViewModel.UserMail,
				UserName = userRegisterViewModel.UserName
			};
			/*
			  Şifre arka tarafda Hash'lendiği için böyle bir yapı kullandık.
			 */
			if (userRegisterViewModel.Password == userRegisterViewModel.PasswordConfirm && userRegisterViewModel.Password != null)
			{
				var result = await _userManager.CreateAsync(appUser, userRegisterViewModel.Password);
				/*
				 await _userManager.CreateAsync(appUser, userRegisterViewModel.Password) -> kullanıcıyı parolarısını hash'leyerek database'e kaydeder
				 */

				if (result.Succeeded)
				{
					return RedirectToAction("SignIn");

				}
				else
				{
					foreach (var item in result.Errors)
					{
						/*
						 Identity sistemindeki hata mesajlarını view tarafında görüntüyelebilmek hata mesajlarını için ModelState'e ekliyoruz
						 */
						ModelState.AddModelError("", item.Description);
					}
				}
			}
			return View(userRegisterViewModel);
			/*
			  Kayıt başarısızsa veya form geçersizse, aynı sayfa tekrar gösterilir.
              Kullanıcının girdiği veriler kaybolmasın diye userRegisterViewModel geri gönderilir.
			 */
		}

		public IActionResult SignIn() // SignIn -> Oturum Ac
		{
			return View();
		}
	}
}
