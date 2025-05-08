using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TravelProject.ViewComponents.AdminDashboard
{
	public class Cards1Statistics : ViewComponent
	{
		private readonly IDestinationService _destinationService;
		private readonly IAppUserService _appUserService;
		public Cards1Statistics(IDestinationService destinationService, IAppUserService appUserService)
		{
			_destinationService = destinationService;
			_appUserService = appUserService;
		}
		public IViewComponentResult Invoke()
		{
			ViewBag.DestinationCount = _destinationService.GetCountDestination();
			ViewBag.UserCount = _appUserService.GetCountUser();
			return View();
		}
	}
}
