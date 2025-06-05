namespace SignalR_API.DAL
{
	public enum ECity
	{
		Ankara = 1,
		İstanbul = 2,
		Bursa = 3,
		Antalya = 4,
		Muğla = 5

	}
	public class Visitor
	{
		public int VisitorID { get; set; }
		public ECity VisitorECity { get; set; }
		public int VisitorCityCount { get; set; }
		public DateTime VisitorDate { get; set; }
	}
}
