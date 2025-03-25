using Microsoft.AspNetCore.Mvc;

namespace TravelProject.ViewComponents
{
	public class SliderPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
