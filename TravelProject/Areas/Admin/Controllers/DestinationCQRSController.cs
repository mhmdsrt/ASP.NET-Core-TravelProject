using MediatR;
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

		/*
		 MediatR, IMediator.Send(TRequest) metodu ile TRequest tipinde istek geldiğinde isteğe uygun Handler'i eşliyor 
		ve bu handler'ı çağrıyor. Handler ise "IRequestHandler<TRequest, TResponse>" interface'i impelement ettiğinden 
        dolayı o isteğe uygun TResponse döndürüyor.
		*/
		private readonly IMediator _mediator;
		public DestinationCQRSController(IMediator mediator)
		{
			_mediator = mediator;
		}
		public async Task<IActionResult> Index()
		{
			return View(await _mediator.Send(new GetAllDestinationQuery()));
		}

		[HttpGet]
		public async Task<IActionResult> GetDestinationById(int id)
		{
			// GetDestinationByIdQuery isteğini uygun Handler classına yeni bir GetDestinationByIdQuery nesnesi gönderir ve handle'ı çağırır
			return View(await _mediator.Send(new GetDestinationByIdQuery(id)));
		}

		[HttpPost]
		public async Task<IActionResult> GetDestinationById(UpdateDestinationCommand updateDestinationCommand)
		{
			// UpdateDestinationCommand isteğini işleyen uygun Handler Classına updateDestinationCommand nesnesini gönderir ve bu handler'ı çağrıyor
			await _mediator.Send(updateDestinationCommand);
			return RedirectToAction("Index", "DestinationCQRS");
		}

		[HttpGet]
		public IActionResult CreateDestination()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateDestination(CreateDestinationCommand createDestinationCommand)
		{
			// CreateDestinationCommand isteğini işleyen uygun Handler Classına createDestinationCommand nesnesini gönderir ve bu handler'ı çağrıyor
			await _mediator.Send(createDestinationCommand); 
			return RedirectToAction("Index", "DestinationCQRS");
		}

		public async Task<IActionResult> RemoveDestination(int id)
		{
			await _mediator.Send(new RemoveDestinationCommand(id));
			return RedirectToAction("Index", "DestinationCQRS");
		}
	}
}
