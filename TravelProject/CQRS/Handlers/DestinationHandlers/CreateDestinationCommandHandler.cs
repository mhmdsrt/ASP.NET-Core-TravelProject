using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using TravelProject.CQRS.Commands.DestinationCommands;

namespace TravelProject.CQRS.Handlers.DestinationHandlers
{
	public class CreateDestinationCommandHandler
	{
		private readonly Context _context;

		public CreateDestinationCommandHandler(Context context)
		{
			_context = context;
		}

		public void Handle(CreateDestinationCommand command)
		{
			_context.Destinations.Add(new Destination
			{
				DestinationCity=command.DestinationCity,
				DestinationAccomodationDay=command.DestinationAccomodationDay,
				DestinationPrice=command.DestinationPrice,
				DestinationDescription=command.DestinationDescription,
				DestinationCapacity=command.DestinationCapacity,
				DestinationStatus=true
			});
			_context.SaveChanges();
		}
	}
}
