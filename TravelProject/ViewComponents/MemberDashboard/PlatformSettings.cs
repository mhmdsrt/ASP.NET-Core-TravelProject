using Microsoft.AspNetCore.Mvc;

namespace TravelProject.ViewComponents.MemberDashboard
{
	public class PlatformSettings:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
