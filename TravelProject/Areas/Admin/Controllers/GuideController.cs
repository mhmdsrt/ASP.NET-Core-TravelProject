using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelProject.Areas.Admin.Controllers
{
	[AllowAnonymous]
	[Area("Admin")]
	[Route("Admin/[Controller]/[Action]/{id?}")]
	public class GuideController : Controller
	{
		private readonly IGuideService _guideService;

		public GuideController(IGuideService guideService)
		{
			_guideService = guideService;
		}
		public IActionResult Index()
		{
			return View(_guideService.GetAll());
		}

		public IActionResult ChangeToFalse(int id)
		{
			_guideService.ChangeToFalse(id);
			return RedirectToAction("Index", "Guide");
		}

		public IActionResult ChangeToTrue(int id)
		{
			_guideService.ChangeToTrue(id);
			return RedirectToAction("Index", "Guide");
		}
	}
}
