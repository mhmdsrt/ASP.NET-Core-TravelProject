using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TravelProject.ViewComponents
{
	public class PopulerDestination : ViewComponent
	{
		private readonly IDestinationService _destinationService;
		public PopulerDestination(IDestinationService destinationService)
		{
			_destinationService = destinationService;
		}
		public IViewComponentResult Invoke()
		{
			return View(_destinationService.GetAll());
		}
	}
}
