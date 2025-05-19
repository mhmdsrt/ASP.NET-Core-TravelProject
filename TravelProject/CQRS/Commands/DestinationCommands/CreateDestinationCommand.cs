namespace TravelProject.CQRS.Commands.DestinationCommands
{
	public class CreateDestinationCommand
	{
		public string? DestinationCity { get; set; } // Gidilecek yerin şehri
		public string? DestinationAccomodationDay { get; set; } // Accomodation -> konaklama , gidilecek yerin konaklama gün sayısı
		public double? DestinationPrice { get; set; } // Gidilecek yerin ücreti
		public string? DestinationDescription { get; set; } // Destination -> Tanımlama
		public int? DestinationCapacity { get; set; } // Capacity -> Kapasite, max yolcu sayısı
		public bool DestinationStatus { get; set; }
	}
}
