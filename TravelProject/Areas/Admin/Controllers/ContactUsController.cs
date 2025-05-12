using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelProject.Areas.Admin.Controllers
{
	[AllowAnonymous]
	[Area("Admin")]
	[Route("Admin/[Controller]/[Action]/{id?}")]
	public class ContactUsController : Controller
	{
		private readonly IContactUsService _contactUsService;
		public ContactUsController(IContactUsService contactUsService)
		{
			_contactUsService = contactUsService;
		}
		public IActionResult Index()
		{
			return View(_contactUsService.GetAll());
		}
	}
}
