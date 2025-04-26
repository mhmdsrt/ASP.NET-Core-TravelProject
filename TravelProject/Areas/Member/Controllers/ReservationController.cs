using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TravelProject.Areas.Member.Controllers
{
	[Area("Member")]
	[Route("Member/[Controller]/[Action]")]
	public class ReservationController : Controller
	{
		private readonly IReservationService _reservationService;
		private readonly IDestinationService _destinationService;
		private readonly UserManager<AppUser> _userManager;

		public ReservationController(IReservationService reservationService, IDestinationService destinationService, UserManager<AppUser> userManager)
		{
			_reservationService = reservationService;
			_destinationService = destinationService;
			_userManager = userManager;
		}
		public async Task<IActionResult> GivenApprovalReservation() // Given Approval -> Onay verildi
		{
			var appUserId = await _userManager.FindByNameAsync(User.Identity.Name); // AspNetUsers tablosundaki UserName sütununa karşılık gelir
			return View(_reservationService.GetAllReservationByGivenApproval(appUserId.Id));
		}

		public async Task<IActionResult> OldReservation()
		{
			var appUserId = await _userManager.FindByNameAsync(User.Identity.Name); // AspNetUsers tablosundaki UserName sütununa karşılık gelir
			return View(_reservationService.GetAllReservationByOld(appUserId.Id));
		}

		public async Task<IActionResult> WaitApprovalReservation() // Approval -> Onay , WaitApprovalReservation-> Onay Bekleyen Rezervasyonlar 
		{
			var appUserId = await _userManager.FindByNameAsync(User.Identity.Name); // AspNetUsers tablosundaki UserName sütununa karşılık gelir
			return View(_reservationService.GetAllReservationByWaitApproval(appUserId.Id));
		}

		[HttpGet]
		public IActionResult NewReservation()
		{
			List<SelectListItem> DestinationSelectList = (from d in _destinationService.GetAll() // DropdownList oluşturduk
														  select new SelectListItem
														  {
															  Value = d.DestinationID.ToString(),
															  Text = d.DestinationCity
														  }).ToList();
			ViewBag.DestinationSelectList = DestinationSelectList;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> NewReservation(Reservation reservation)
		{
			var userName = await _userManager.FindByNameAsync(User.Identity.Name); // AspNetUsers tablosundaki UserName sütununa karşılık gelir

			reservation.AppUserID = userName.Id;
			reservation.ReservationStatus = "Onay Bekliyor"; // Kullanıcı rezervasyon yaptıktan sonra Adminin onay vermesini beklicek, kontenjanı dolmus veya tur iptal edilmiş olabilir
			_reservationService.Insert(reservation);
			return RedirectToAction("ActiveReservation", "Reservation");
		}
	}
}
