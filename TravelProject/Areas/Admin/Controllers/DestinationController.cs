using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using FluentValidation;
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
		private readonly IValidator<Destination> _validator;

		public DestinationController(IDestinationService destinationService, IValidator<Destination> validator)
		{
			_destinationService = destinationService;
			_validator = validator;
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
			var result = _validator.Validate(destination);

			if (!result.IsValid)
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}

				return View(destination);
			}
			_destinationService.Insert(destination);
			return RedirectToAction("Index","Destination");
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
