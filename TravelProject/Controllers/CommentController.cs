using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TravelProject.Controllers
{
	public class CommentController : Controller
	{
		private readonly ICommentService _commentService;
		private readonly UserManager<AppUser> _userManager;
		public CommentController(ICommentService commentService, UserManager<AppUser> userManager)
		{
			_commentService = commentService;
			_userManager = userManager;
		}

		[HttpGet]
		public PartialViewResult AddComment() // Asenkron olarak cagıralacak partial view
		{
			return PartialView();
		}

		[HttpPost]
		public async Task<IActionResult> AddComment([FromBody] Comment comment)
		{
			comment.CommentDate = Convert.ToDateTime(DateTime.Now);
			comment.CommentStatus = true;
			var userName = await _userManager.FindByNameAsync(User.Identity.Name);
			comment.AppUserId = userName.Id;
	
			_commentService.Insert(comment);
			return Json(new
			{
				comment.CommentContent,
				comment.CommentDate,
				AppUser = new
				{
					Name = userName.Name,
					SurName = userName.SurName,  // dikkat: büyük S
					ImageUrl = userName.ImageUrl
				}
			});
		}
	}
}
