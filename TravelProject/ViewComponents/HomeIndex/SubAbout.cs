using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TravelProject.ViewComponents.HomeIndex
{
	public class SubAbout : ViewComponent
	{
		private readonly ISubAboutService _subAboutService;
		public SubAbout(ISubAboutService subAboutService)
		{
			_subAboutService = subAboutService;
		}
		public IViewComponentResult Invoke()
		{
			return View(_subAboutService.GetAll());
		}
	}
}
