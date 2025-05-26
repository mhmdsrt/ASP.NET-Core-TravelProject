using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TravelProject.ViewComponents.HomeIndex
{
	public class Statistics:ViewComponent
	{
		private readonly IDestinationService _destinationService;
		private readonly IReservationService _reservationService;
		private readonly IGuideService _guideService;
		private readonly UserManager<AppUser> _userManager;

		public Statistics(IDestinationService destinationService, IReservationService reservationService, IGuideService guideService, UserManager<AppUser> userManager)
		{
			_destinationService = destinationService;
			_reservationService = reservationService;
			_guideService = guideService;
			_userManager = userManager;
		}

		public IViewComponentResult Invoke()
		{
			ViewBag.DestinationCount = _destinationService.GetCountDestination();
			ViewBag.UserCount = _userManager.Users.Count();
			ViewBag.ReservationCount = _reservationService.GetReservationCount();
			ViewBag.GuideCount = _guideService.GetGuideCount();
			return View();
		}
	}
}
