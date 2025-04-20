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
		private readonly UserManager<AppUser> _userManager; // Kullanıcıyı kaydetmek için kullanılan servis
		private readonly SignInManager<AppUser> _signInManager; // Oturum Açmak için kullanılan servis


		public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
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

		[HttpGet]
		public IActionResult SignIn() // SignIn -> Oturum Ac
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SignIn(UserSignInViewModel userSignInViewModel)
		{
			/*
			 Valid -> Geçerli

			 ModelState.IsValid ifadesi post edilen formun eksik/hatalı doldurulmasını göre true veya false değeri döndürür.
			 Örneğin ilgili modelde(property'de) [Required] ile data annotation tanınmış ve boş geçilmişse doğrulama(validation) 
			 işlemi başarısız olur ve false döner.
			 */
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(userSignInViewModel.UserName, userSignInViewModel.Password, false, true);
				if (result.Succeeded) // Success -> Başarılı olmak, başarılı
				{
					return RedirectToAction("Index", "Destination");
				}
				else
				{
					return RedirectToAction("SignIn", "Login");
				}
			}

			return View();
			/*
			 _signInManager.PasswordSignInAsync(userSignInViewModel.UserName, userSignInViewModel.Password, false, true)
			bu ifade kullanıcı adı ve şifresi uyuşuyorsa oturum açar.
			1. Parametre -> KullanıcıAdı
			2. Parametre -> Şifre
			3. Parametre -> Beni Hatırla? (Kalıcı Oturum)  -> bool isPersistent - > Tarayıcı kapatıldığında cookie'nin kalıcı olup olmayacağı -> "Beni Hatırla" seçeneği (cookie kalıcılığı)
			4. Parametre -> Başarısız girişde hesabu kitlesin mi? -> bool lockoutOnFailure -> Yanlış girişte hesabı kilitle (5 denemeden sonra)
			 */



		}
	}
}
