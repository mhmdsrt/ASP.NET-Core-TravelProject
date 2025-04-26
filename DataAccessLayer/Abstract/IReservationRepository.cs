using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IReservationRepository : IGenericRepository<Reservation>
	{
		IEnumerable<Reservation> GetAllReservationByWaitApproval(int id); // Giriş yapan kullanıcı id sine göre onay bekleyen rezervasyonları getir
		IEnumerable<Reservation> GetAllReservationByGivenApproval(int id); // Giriş yapan kullanıcı id sine göre onay verilen rezervasyonları getir, given -> verildi
		IEnumerable<Reservation> GetAllReservationByOld(int id); // Giriş yapan kullanıcı id sine göre eski rezervasyonları getir
	}
}
