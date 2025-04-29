using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/[Controller]/[Action]/{id?}")]
	[AllowAnonymous]
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

		[HttpGet]
		public IActionResult AddDestination()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddDestination(Destination destination)
		{
			destination.DestinationStatus = true;
			_destinationService.Insert(destination);
			return RedirectToAction("Index");
		}

		public IActionResult DeleteDestination(int id)
		{
			_destinationService.Delete(id);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult UpdateDestination(int id)
		{
			return View(_destinationService.GetById(id));
		}

		[HttpPost]
		public IActionResult UpdateDestination(Destination destination)
		{
			_destinationService.Update(destination);
			return RedirectToAction("Index");
		}
	}
}
