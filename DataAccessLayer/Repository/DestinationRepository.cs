using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	public class DestinationRepository : GenericRepository<Destination>, IDestinationRepository
	{
		private readonly Context _context;
		public DestinationRepository(Context context) : base(context)
		{
			_context = context;
		}

		public int GetCountDestination() // Tur sayısını getir
		{
			return _context.Destinations.Count();
		}

		public IQueryable<Destination> GetAllDestinationBySearchComboBox(string destinationCityName) // şehir ismine göre rotaları getir
		{

			return _context.Destinations.Where(c => c.DestinationCity == destinationCityName);
		}
	}
}
