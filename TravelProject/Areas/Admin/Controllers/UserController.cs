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
		private readonly ICommentService _commentService;

		public UserController(IAppUserService appUserService, IReservationService reservationService, UserManager<AppUser> userManager, ICommentService commentService)
		{
			_appUserService = appUserService;
			_reservationService = reservationService;
			_userManager = userManager;
			_commentService = commentService;
		}

		public IActionResult Index()
		{
			return View(_appUserService.GetAll());
		}

		public IActionResult GetUserReservationByOld(int id)
		{
			return View(_reservationService.GetAllReservationByOld(id));
		}

		public IActionResult GetAllCommentByUserId(int id)
		{
			return View(_commentService.GetAllCommentByUserId(id));
		}

		public IActionResult GetAllWaitOrGiveApprovalGiveReservation()// Approval -> Onay , WaitApprovalReservation-> Onay Bekleyen Rezervasyonlar
		{
			return View(_reservationService.GetAllWaitOrGiveApprovalGiveReservation());
		}

		public IActionResult GiveApprovalChange(int id)
		{
			_reservationService.GiveApprovalChange(id);
			return RedirectToAction("GetAllWaitOrGiveApprovalGiveReservation", "User", new { area = "Admin" });
		}

		public IActionResult WaitApprovalChange(int id)
		{
			_reservationService.WaitApprovalChange(id);
			return RedirectToAction("GetAllWaitOrGiveApprovalGiveReservation", "User", new { area = "Admin" });
		}
	}
}
