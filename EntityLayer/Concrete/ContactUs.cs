using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class ContactUs // Bize ulaşın kısmındaki Mail atma yeri için
	{
		public int ContactUsId { get; set; }
		public string ContactUsName { get; set; }
		public string ContactUsMail { get; set; }
		public string ContactUsSubject { get; set; }
		public string ContactUsMessageBody { get; set; }
		public DateTime ContactUsMessageDate { get; set; }
		public bool ContactUsStatus { get; set; }
	}
}
