using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
		private readonly UserManager<AppUser> _userManager;

		public UserController(IAppUserService appUserService, IReservationService reservationService, UserManager<AppUser> userManager)
		{
			_appUserService = appUserService;
			_reservationService = reservationService;
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			return View( _appUserService.GetAll());
		}

		public IActionResult GetUserReservationByOld(int id)
		{
			return View(_reservationService.GetAllReservationByOld(id));
		}


	}
}
