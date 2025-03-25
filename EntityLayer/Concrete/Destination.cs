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
	}
}
