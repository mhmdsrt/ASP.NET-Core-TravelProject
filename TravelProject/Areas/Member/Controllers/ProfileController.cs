using Microsoft.AspNetCore.Mvc;

namespace TravelProject.Areas.Member.Controllers
{
	public class ProfileController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
