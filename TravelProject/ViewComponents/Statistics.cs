using Microsoft.AspNetCore.Mvc;

namespace TravelProject.ViewComponents
{
	public class Statistics:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
