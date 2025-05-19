using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelProject.CQRS.Commands.DestinationCommands;
using TravelProject.CQRS.Handlers.DestinationHandlers;
using TravelProject.CQRS.Queries.DestinationQueries;

namespace TravelProject.Areas.Admin.Controllers
{
	[AllowAnonymous]
	[Area("Admin")]
	[Route("Admin/[Controller]/[Action]/{id?}")]
	public class DestinationCQRSController : Controller

	{
		private readonly GetAllDestinationQueryHandler _getAllDestinationQueryHandler;
		private readonly GetDestinationByIdQueryHandler _getDestinationByIdQueryHandler;
		private readonly CreateDestinationCommandHandler _createDestinationCommandHandler;
		public DestinationCQRSController(GetAllDestinationQueryHandler getAllDestinationQueryHandler, 
			GetDestinationByIdQueryHandler getDestinationByIdQueryHandler, CreateDestinationCommandHandler
			createDestinationCommandHandler)
		{
			_getAllDestinationQueryHandler = getAllDestinationQueryHandler;
			_getDestinationByIdQueryHandler = getDestinationByIdQueryHandler;
			_createDestinationCommandHandler = createDestinationCommandHandler;
		}
		public IActionResult Index()
		{
			return View(_getAllDestinationQueryHandler.Handle());
		}

		[HttpGet]
		public IActionResult GetDestinationById(int id)
		{
			return View(_getDestinationByIdQueryHandler.Handle(new GetDestinationByIdQuery(id)));
		}

		[HttpGet]
		public IActionResult CreateDestination()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateDestination(CreateDestinationCommand createDestinationCommand)
		{
			_createDestinationCommandHandler.Handle(createDestinationCommand);
			return RedirectToAction("Index", "DestinationCQRS");
		}
	}
}
