using Microsoft.AspNetCore.SignalR;
using SignalR_API.DAL;
using SignalR_API.Hubs;

namespace SignalR_API.Model
{
	public class VisitorService
	{
		private readonly Context _context;
		private readonly IHubContext<VisitorHub> _hubContext;

		public VisitorService(Context context, IHubContext<VisitorHub> hubContext)
		{
			_context = context;
			_hubContext = hubContext;
		}

		public IQueryable<Visitor> GetList()
		{
			return _context.Visitors.AsQueryable();
		}

		public async Task SaveVisitor(Visitor visitor)
		{
			await _context.Visitors.AddAsync(visitor);
			await _context.SaveChangesAsync();
			await _hubContext.Clients.All.SendAsync("CallVisitorList", GetVisitorChartList());
		}

		
	}
}
