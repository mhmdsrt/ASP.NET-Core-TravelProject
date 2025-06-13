using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TravelProject.ViewComponents.MemberDashboard
{
	public class GetAllDestinationForSlider : ViewComponent
	{
		private readonly IDestinationService _destinationService;

		public GetAllDestinationForSlider(IDestinationService destinationService)
		{
			_destinationService = destinationService;
		}

		public IViewComponentResult Invoke()
		{
			return View(_destinationService.GetAll());
		}
	}
}
