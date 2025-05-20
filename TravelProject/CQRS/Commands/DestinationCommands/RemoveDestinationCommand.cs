using MediatR;

namespace TravelProject.CQRS.Commands.DestinationCommands
{
	public class RemoveDestinationCommand : IRequest<Unit>
	{
		public int Id { get; set; }

		public RemoveDestinationCommand(int id)
		{
			Id = id;
		}
	}
}
