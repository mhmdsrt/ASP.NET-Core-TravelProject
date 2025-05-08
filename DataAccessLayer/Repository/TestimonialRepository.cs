using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	public class TestimonialRepository : GenericRepository<Testimonial>, ITestimonialRepository
	{
		private readonly Context _context;
		public TestimonialRepository(Context context) : base(context)
		{
			_context = context;
		}
	}
}
