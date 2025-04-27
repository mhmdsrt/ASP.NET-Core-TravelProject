using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TravelProject.ViewComponents.MemberDashboard
{
	public class GuideList : ViewComponent
	{
		private readonly IGuideService _guideService;

		public GuideList(IGuideService guideService)
		{
			_guideService = guideService;
		}

		public IViewComponentResult Invoke()
		{
			return View(_guideService.GetAll());
		}
	}
}
