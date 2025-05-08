using Microsoft.AspNetCore.Mvc;

namespace TravelProject.ViewComponents.AdminDashboard
{
	public class DashboardBanner:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
