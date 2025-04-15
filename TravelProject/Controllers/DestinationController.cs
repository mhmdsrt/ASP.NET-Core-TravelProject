using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TravelProject.Controllers
{
	public class DestinationController : Controller
	{
		private readonly IDestinationService _destinationService;

		public DestinationController(IDestinationService destinationService)
		{
			_destinationService = destinationService;
		}
		public IActionResult Index()
		{
			return View(_destinationService.GetAll());
		}

		public IActionResult DestinationDetails(int id)
		{
			return View(_destinationService.GetById(id));
		}
	}
}
