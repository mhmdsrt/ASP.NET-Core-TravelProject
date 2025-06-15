using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IDestinationRepository : IGenericRepository<Destination>
	{
		int GetCountDestination(); // Tur sayısını getir
		IQueryable<Destination> GetAllDestinationBySearchComboBox(string destinationCityName); // şehir ismine göre rotaları getir

	}
}
