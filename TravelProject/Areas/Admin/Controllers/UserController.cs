using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	[AllowAnonymous]
	[Route("Admin/[Controller]/[Action]/{id?}")]
	public class UserController : Controller
	{
		private readonly IAppUserService _appUserService;
		private readonly IReservationService _reservationService;
		public UserController(IAppUserService appUserService,IReservationService reservationService)
		{
			_appUserService = appUserService;
			_reservationService = reservationService;
		}
		public IActionResult Index()
		{
			return View(_appUserService.GetAll());
		}

		public IActionResult GetUserReservationByOld(int id)
		{
			return View(_reservationService.GetAllReservationByOld(id));
		}
	}
}
