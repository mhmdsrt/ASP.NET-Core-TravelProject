using DataAccessLayer.Concrete;
using MediatR;
using TravelProject.CQRS.Commands.DestinationCommands;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TravelProject.CQRS.Handlers.DestinationHandlers
{
	public class RemoveDestinationCommandHandler : IRequestHandler<RemoveDestinationCommand, Unit>
	{
		private readonly Context _context;

		public RemoveDestinationCommandHandler(Context context)
		{
			_context = context;
		}

		public async Task<Unit> Handle(RemoveDestinationCommand request, CancellationToken cancellationToken)
		{
			var entity = await _context.Destinations.FindAsync(request.Id);
			_context.Destinations.Remove(entity);
			await _context.SaveChangesAsync();
			return Unit.Value;
		}
	}
}
