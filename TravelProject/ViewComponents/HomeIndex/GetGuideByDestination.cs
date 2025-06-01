using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TravelProject.ViewComponents.HomeIndex
{
	public class GetGuideByDestination:ViewComponent
	{
		private readonly IGuideService _guideService;

		public GetGuideByDestination(IGuideService guideService)
		{
			_guideService = guideService;
		}
		public IViewComponentResult Invoke(int guideId)
		{
			return View(_guideService.GetById(guideId));
		}
	}
}
