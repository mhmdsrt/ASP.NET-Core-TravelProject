namespace TravelProject.CQRS.Queries.DestinationQueries
{
	public class GetDestinationByIdQuery
	{
		public int Id { get; set; }

		public GetDestinationByIdQuery(int id)
		{
			Id = id;
		}
	}
}
