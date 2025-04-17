using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TravelProject.Controllers
{
	public class CommentController : Controller
	{
		private readonly ICommentService _commentService;
		public CommentController(ICommentService commentService)
		{
			_commentService = commentService;
		}

		[HttpGet]
		public PartialViewResult AddComment() // Asenkron olarak cagıralacak partial view
		{
			return PartialView();
		}

		[HttpPost]
		public IActionResult AddComment(Comment comment)
		{
			comment.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
			comment.CommentStatus = true;
			comment.DestinationID = 8;
			_commentService.Insert(comment);
			return RedirectToAction("Index", "Destination");
		}
	}
}
