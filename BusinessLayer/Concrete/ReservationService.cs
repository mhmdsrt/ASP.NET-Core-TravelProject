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
	public class ReservationService : GenericService<Reservation>, IReservationService
	{
		private readonly IReservationRepository _reservationRepository;
		public ReservationService(IReservationRepository reservationRepository) : base(reservationRepository)
		{
			_reservationRepository = reservationRepository;
		}

		public IEnumerable<Reservation> GetAllReservationByWaitApproval(int id)
		{
			// Giriş yapan kullanıcı id sine göre onay bekleyen rezervasyonları getir
			return _reservationRepository.GetAllReservationByWaitApproval(id);
		}

		public IEnumerable<Reservation> GetAllReservationByGivenApproval(int id)
		{
			// Giriş yapan kullanıcı id sine göre onay verilen rezervasyonları getir, given ->

			return _reservationRepository.GetAllReservationByGivenApproval(id);
		}

		public IEnumerable<Reservation> GetAllReservationByOld(int id)
		{
			// Giriş yapan kullanıcı id sine göre eski rezervasyonları getir
			return _reservationRepository.GetAllReservationByOld(id);
		}
	}
}
