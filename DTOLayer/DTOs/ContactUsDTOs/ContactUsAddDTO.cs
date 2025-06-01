using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.ContactUsDTOs
{
	public class ContactUsAddDTO
	{
		public string? ContactUsName { get; set; }
		public string? ContactUsMail { get; set; }
		public string? ContactUsSubject { get; set; }
		public string? ContactUsMessageBody { get; set; }
		public DateTime ContactUsMessageDate { get; set; }
		public bool ContactUsStatus { get; set; }
	}
}
