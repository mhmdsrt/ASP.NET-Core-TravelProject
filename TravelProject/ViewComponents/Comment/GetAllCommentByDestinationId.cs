using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TravelProject.ViewComponents.Comment
{
	public class GetAllCommentByDestinationId : ViewComponent
	{
		private readonly ICommentService _commentService;
		public GetAllCommentByDestinationId(ICommentService commentService)
		{
			_commentService = commentService;
		}
		public IViewComponentResult Invoke(int id)
		{
			return View(_commentService.GetAllCommentByDestinationId(id));
		}
	}
}
