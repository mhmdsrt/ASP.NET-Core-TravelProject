using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TravelProject.ViewComponents.MemberDashboard
{
	public class ProfileInformation : ViewComponent
	{
		private readonly UserManager<AppUser> _userManager;

		public ProfileInformation(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var userName = await _userManager.FindByNameAsync(User.Identity.Name);
			ViewBag.UserNameAndSurName = userName.Name + " " + userName.SurName;
			ViewBag.UserPhoneNumber = userName.PhoneNumber;
			ViewBag.UserMail = userName.Email;
			return View();
		}
	}
}
