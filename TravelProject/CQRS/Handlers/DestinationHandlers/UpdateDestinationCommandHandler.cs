using AutoMapper;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using MediatR;
using NuGet.Protocol.Plugins;
using TravelProject.CQRS.Commands.DestinationCommands;

namespace TravelProject.CQRS.Handlers.DestinationHandlers
{
	public class UpdateDestinationCommandHandler : IRequestHandler<UpdateDestinationCommand, Unit>
	{
		private readonly Context _context;
		private readonly IMapper _mapper;

		public UpdateDestinationCommandHandler(Context context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}


		public async Task<Unit> Handle(UpdateDestinationCommand request, CancellationToken cancellationToken)
		{
			_context.Update(_mapper.Map<Destination>(request));
			await _context.SaveChangesAsync();
			return Unit.Value;
		}
	}
}
