namespace TravelProject.CQRS.Results.DestinationResults
{
	public class GetDestinationByIdQueryResult
	{
		public int? Id { get; set; }
		public string? City { get; set; }
		public string? DayNight { get; set; }
		public double? Price { get; set; }
		public int? Capacity { get; set; }
	}
}
