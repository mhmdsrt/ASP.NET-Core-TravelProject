using AutoMapper;
using DataAccessLayer.Concrete;
using MediatR;
using TravelProject.CQRS.Queries.DestinationQueries;
using TravelProject.CQRS.Results.DestinationResults;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TravelProject.CQRS.Handlers.DestinationHandlers
{
	public class GetDestinationByIdQueryHandler : IRequestHandler<GetDestinationByIdQuery, GetDestinationByIdQueryResult>
	{
		private readonly Context _context;
		private readonly IMapper _mapper;
		public GetDestinationByIdQueryHandler(Context context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}


		public async Task<GetDestinationByIdQueryResult> Handle(GetDestinationByIdQuery request, CancellationToken cancellationToken)
		{
			/*
			 CQRS Design Patter'i uygylarken Parametre olarak int id değil,
			 Parametrelerimizin tutulduğu Quries File klasörü altındaki  "GetDestinationByIdQuery" class'ını kullanıyoruz.
			 Controller tarafından bu metodu çağırıken GetDestinationByIdQuery sınfından obje new'lediğimiz zaman 
			 bu nesnenin property'lerine Constructor ile atama yapıyoruz.
			 
			 */
			var destination = await _context.Destinations.FindAsync(request.Id);
			return _mapper.Map<GetDestinationByIdQueryResult>(destination);
		}
	}
}
