using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	// Gidilecek yerleri tutacak olan alan
	public class Destination // Destination -> Varış noktası, gidilecek yer
	{
		[Key]
		public int DestinationID { get; set; }
		public string DestinationCity { get; set; } // Gidilecek yerin şehri
		public string DestinationAccomodationDay { get; set; } // Accomodation -> konaklama , gidilecek yerin konaklama gün sayısı
		public double DestinationPrice { get; set; } // Gidilecek yerin ücreti
		public string DestinationImage { get; set; }
		public string DestinationDescription { get; set; } // Destination -> Tanımlama
		public int DestinationCapacity { get; set; } // Capacity -> Kapasite, max yolcu sayısı
		public bool DestinationStatus { get; set; }
		public string DestinationDetailDescription1 { get; set; } // Gidilecek yerin ayrıntı bölümündeki açıklama 1
		public string DestinationDetailDescription2 { get; set; } // Gidilecek yerin ayrıntı bölümündeki açıklama 2
		public string DestinationDetailImage { get; set; } // Gidilecek yerin ayrıntı bölümündeki resim 
		public ICollection<Comment> Comments { get; set; } // Gidilecek yerlere ait birden fazla yorum olabileceğinden dolayı

		public ICollection<Reservation> Reservations { get; set; } // Bir gidilecek şehir birden fazla rezervasyonun içerisinde bulunabilir
	}
}
