using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IReservationService : IGenericService<Reservation>
	{
		IEnumerable<Reservation> GetAllReservationByWaitApproval(int id); // Giriş yapan kullanıcı id sine göre onay bekleyen rezervasyonları getir
		IEnumerable<Reservation> GetAllReservationByGivenApproval(int id); // Giriş yapan kullanıcı id sine göre onay verilen rezervasyonları getir, given -> verildi
		IEnumerable<Reservation> GetAllReservationByOld(int id); // Giriş yapan kullanıcı id sine göre eski rezervasyonları getir
		int GetReservationCount(); // Toplam rezervasyon sayısını getir
		IQueryable<Reservation> GetAllWaitOrGiveApprovalGiveReservation(); // onay bekleyen tüm rezervasyonları getir
		void GiveApprovalChange(int id); // rezervasyonu onay verildi olarak değiştir
		void WaitApprovalChange(int id); // rezervasyonu onay bekliyor olarak değiştir
	}
}
