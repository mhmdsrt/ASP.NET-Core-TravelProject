﻿using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TravelProject.ViewComponents.HomeIndex
{
	public class Testimonials : ViewComponent
	{
		private readonly ITestimonialService _testimonialService;

		public Testimonials(ITestimonialService testimonialService)
		{
			_testimonialService = testimonialService;
		}
		public IViewComponentResult Invoke()
		{
			return View(_testimonialService.GetAll());
		}
	}
}
