using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class DestinationService : GenericService<Destination>, IDestinationService
	{
		private readonly IDestinationRepository _destinationRepository;

		public DestinationService(IDestinationRepository destinationRepository) : base(destinationRepository)
		{
			_destinationRepository = destinationRepository;
		}

		public int GetCountDestination() // Tur sayısını getir
		{
			return _destinationRepository.GetCountDestination();
		}
	}
}
