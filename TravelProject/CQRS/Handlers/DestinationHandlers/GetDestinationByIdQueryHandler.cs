using DataAccessLayer.Concrete;
using TravelProject.CQRS.Queries.DestinationQueries;
using TravelProject.CQRS.Results.DestinationResults;

namespace TravelProject.CQRS.Handlers.DestinationHandlers
{
	public class GetDestinationByIdQueryHandler
	{
		private readonly Context _context;

		public GetDestinationByIdQueryHandler(Context context)
		{
			_context = context;
		}

		public GetDestinationByIdQueryResult Handle(GetDestinationByIdQuery query)
		{
			/*
			 CQRS Design Patter'i uygylarken Parametre olarak int id değil,
			 Parametrelerimizin tutulduğu Quries File klasörü altındaki  "GetDestinationByIdQuery" class'ını kullanıyoruz.
			 Controller tarafından bu metodu çağırıken GetDestinationByIdQuery sınfından obje new'lediğimiz zaman 
			 bu nesnenin property'lerine Constructor ile atama yapıyoruz.
			 
			 */
			var entity = _context.Destinations.Find(query.Id);

			return new GetDestinationByIdQueryResult
			{
				Id = entity.DestinationID,
				City = entity.DestinationCity,
				DayNight = entity.DestinationAccomodationDay,
				Capacity=entity.DestinationCapacity,
				Price=entity.DestinationPrice
			};
		}
	}
}
