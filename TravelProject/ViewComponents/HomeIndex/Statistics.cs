using Microsoft.AspNetCore.Mvc;

namespace TravelProject.ViewComponents.HomeIndex
{
	public class Statistics:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
