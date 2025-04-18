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
		public async Task<IActionResult> SignUp(UserRegisterViewModel userRegisterViewModel) // SignUp -> Uye Ol 
		{
			AppUser appUser = new AppUser()
			{
				Name = userRegisterViewModel.Name,
				SurName = userRegisterViewModel.SurName,
				Email = userRegisterViewModel.UserMail,
				UserName = userRegisterViewModel.UserName
			};
			/*
			  Şifre arka tarafda Hash'lendiği için böyle bir yapı kullandık.
			 */
			if (userRegisterViewModel.Password == userRegisterViewModel.PasswordConfirm)
			{
				var result = await _userManager.CreateAsync(appUser, userRegisterViewModel.Password);

				if (result.Succeeded)
				{
					return RedirectToAction("SignIn");

				}
				else
				{
					foreach (var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
				}
			}
			return View(userRegisterViewModel);
		}

		public IActionResult SignIn() // SignIn -> Oturum Ac
		{
			return View();
		}
	}
}
