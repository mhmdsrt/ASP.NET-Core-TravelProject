using AutoMapper;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using MediatR;
using TravelProject.CQRS.Commands.DestinationCommands;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TravelProject.CQRS.Handlers.DestinationHandlers
{
	public class CreateDestinationCommandHandler : IRequestHandler<CreateDestinationCommand, Unit>
	{
		private readonly Context _context;
		private readonly IMapper _mapper;
		public CreateDestinationCommandHandler(Context context,IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<Unit> Handle(CreateDestinationCommand request, CancellationToken cancellationToken)
		{

			await _context.Destinations.AddAsync(_mapper.Map<Destination>(request));
			
			await _context.SaveChangesAsync();

			return Unit.Value;
		}
	}
}
