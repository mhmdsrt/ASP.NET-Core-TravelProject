using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Testimonial // Testimonial -> Referans
	{
		[Key]
		public int TestimonialID { get; set; }
		public string TestimonialClient{ get; set; }
		public string TestimonialComment { get; set; }
		public string TestimonialImage { get; set; }
		public bool TestimonialStatus { get; set; }
	}
}
