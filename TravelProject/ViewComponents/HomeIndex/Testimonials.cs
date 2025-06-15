using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TravelProject.ViewComponents.HomeIndex
{
	public class Testimonials : ViewComponent
	{
		//private readonly ITestimonialService _testimonialService;
		private readonly ICommentService _commentService;

		public Testimonials(ICommentService commentService)
		{
			_commentService = commentService;
		}

		public IViewComponentResult Invoke()
		{
			return View(_commentService.GetAllCommentIncludeDestination());
		}
	}
}
