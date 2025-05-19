using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelProject.CQRS.Handlers.DestinationHandlers;

namespace TravelProject.Areas.Member.Controllers
{
	[AllowAnonymous]
	[Area("Member")]
	[Route("Member/[Controller]/[Action]/{id?}")]
	public class DestinationCQRSController : Controller
	{
		private readonly GetAllDestinationQueryHandler _getAllDestinationQueryHandler;

		public DestinationCQRSController(GetAllDestinationQueryHandler getAllDestinationQueryHandler)
		{
			_getAllDestinationQueryHandler = getAllDestinationQueryHandler;
		}
		public IActionResult Index()
		{
			return View(_getAllDestinationQueryHandler.Handle());
		}
	}
}
