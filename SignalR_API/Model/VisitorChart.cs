namespace SignalR_API.Model
{
	public class VisitorChart
	{
		public VisitorChart()
		{
			Counts = new List<int>();
		}
		public List<int> Counts { get; set; }
		public string VisitDate { get; set; }
	}
}
