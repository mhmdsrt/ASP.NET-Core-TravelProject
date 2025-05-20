namespace TravelProject.CQRS.Results.DestinationResults
{
	public class GetDestinationByIdQueryResult
	{
		public int DestinationID { get; set; }
		public string? DestinationCity { get; set; } // Gidilecek yerin şehri
		public string? DestinationAccomodationDay { get; set; } // Accomodation -> konaklama , gidilecek yerin konaklama gün sayısı
		public double? DestinationPrice { get; set; } // Gidilecek yerin ücreti
		public int? DestinationCapacity { get; set; } // Capacity -> Kapasite, max yolcu sayısı
	}
}
