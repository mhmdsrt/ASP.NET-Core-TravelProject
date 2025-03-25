using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class TestimonialService : GenericService<Testimonial>, ITestimonialService
	{
		private readonly ITestimonialRepository _testimonialRepository;
		public TestimonialService(ITestimonialRepository testimonialRepository) : base(testimonialRepository)
		{
			_testimonialRepository = testimonialRepository;
		}
	}
}
