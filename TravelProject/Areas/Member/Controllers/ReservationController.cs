using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TravelProject.Areas.Member.Controllers
{
	[Area("Member")]
	[Route("Member/[Controller]/[Action]/{id?}")]
	public class ReservationController : Controller
	{
		private readonly IReservationService _reservationService;
		private readonly IDestinationService _destinationService;
		private readonly UserManager<AppUser> _userManager;
		private readonly IValidator<Reservation> _validator;

		public ReservationController(IReservationService reservationService, IDestinationService destinationService,
			UserManager<AppUser> userManager, IValidator<Reservation> validator)
		{
			_reservationService = reservationService;
			_destinationService = destinationService;
			_userManager = userManager;
			_validator = validator;
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
			ViewBag.DestinationSelectList = GetDropDownListDestination();
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> NewReservation(Reservation reservation)
		{
			
			ViewBag.DestinationSelectList = GetDropDownListDestination();
			var result = _validator.Validate(reservation);
			if (!result.IsValid)
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
				return View(reservation);
			}

			var userName = await _userManager.FindByNameAsync(User.Identity.Name); // AspNetUsers tablosundaki UserName sütununa karşılık gelir

			reservation.AppUserID = userName.Id;
			reservation.ReservationStatus = "Onay Bekliyor"; // Kullanıcı rezervasyon yaptıktan sonra Adminin onay vermesini beklicek, kontenjanı dolmus veya tur iptal edilmiş olabilir
			_reservationService.Insert(reservation);
			return RedirectToAction("WaitApprovalReservation", "Reservation");
		}

		public List<SelectListItem> GetDropDownListDestination()
		{
			List<SelectListItem> DestinationSelectList = (from d in _destinationService.GetAll() // DropdownList oluşturduk
														  select new SelectListItem
														  {
															  Value = d.DestinationID.ToString(),
															  Text = d.DestinationCity
														  }).ToList();

			return DestinationSelectList;
		}
	}
}
