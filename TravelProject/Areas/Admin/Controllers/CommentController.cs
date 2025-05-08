using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	[AllowAnonymous]
	[Route("Admin/[Controller]/[Action]/{id?}")]
	public class CommentController : Controller
	{
		private readonly ICommentService _commentService;
		public CommentController(ICommentService commentService)
		{
			_commentService = commentService;
		}
		public IActionResult Index()
		{
			return View(_commentService.GetAllCommentIncludeDestination());
		}

		public IActionResult DeleteComment(int id)
		{
			_commentService.Delete(id);
			return RedirectToAction("Index","Comment");
		}
	}
}
