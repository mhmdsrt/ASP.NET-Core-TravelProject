using MediatR;
using TravelProject.CQRS.Results.DestinationResults;

namespace TravelProject.CQRS.Queries.DestinationQueries
{
	public class GetAllDestinationQuery : IRequest<IEnumerable<GetAllDestinationQueryResult>>
	{
	}
}
