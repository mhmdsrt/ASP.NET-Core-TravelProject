using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TravelProject.ViewComponents.HomeIndex
{
	public class SliderPartial : ViewComponent
	{
		private readonly IDestinationService _destinationService;

		public SliderPartial(IDestinationService destinationService)
		{
			_destinationService = destinationService;
		}

		public IViewComponentResult Invoke()
		{
			return View(_destinationService.GetAll());
		}
	}
}
