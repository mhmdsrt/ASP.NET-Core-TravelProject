﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	/*
Include => Dahil etmek.
Then => Daha sonra.
Include() metodu doğrudan ilişkili varlıkları yüklemek için kullanılır.
ThenInclude() metodu iç içe ilişkili varlıkları yüklemek için kullanılır.(Dolaylı yoldan ilişkili olanı getirmek için)		
*/
	public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
	{
		private readonly Context _context;
		public ReservationRepository(Context context) : base(context)
		{
			_context = context;
		}
		public IQueryable<Reservation> GetAllReservationByWaitApproval(int id)
		{
			// İlişkili Destination ve AppUser Sütunlarını(Propertylerini) dahil ederek
			// Giriş yapan kullanıcı id sine göre onay bekleyen rezervasyonları getir 
			return _context.Reservations.Include(d => d.Destination).Include(a => a.AppUser).Where(a => a.AppUserID == id && a.ReservationStatus == "Onay Bekliyor");
		}

		public IQueryable<Reservation> GetAllReservationByGivenApproval(int id)
		{
			// İlişkili Destination ve AppUser  Sütunlarını(Propertylerini) dahil ederek
			// Giriş yapan kullanıcı id sine göre onay verilen rezervasyonları getir, given -> verildi
			return _context.Reservations.Include(d => d.Destination).Include(a => a.AppUser).Where(a => a.AppUserID == id && a.ReservationStatus == "Onay Verildi");
		}

		public IQueryable<Reservation> GetAllReservationByOld(int id)
		{
			// İlişkili Destination ve AppUser Sütunlarını(Propertylerini) dahil ederek
			// Giriş yapan kullanıcı id sine göre eski rezervasyonları getir
			return _context.Reservations.Include(d => d.Destination).Include(a => a.AppUser).Where(a => a.AppUserID == id && a.ReservationStatus == "Geçmiş");
		}

		public int GetReservationCount() // Toplam rezervasyon sayısını getir
		{
			return _context.Reservations.Count();
		}

		public IQueryable<Reservation> GetAllWaitOrGiveApprovalGiveReservation() // onay bekleyen veya onay verilen tüm rezervasyonları getir
		{
			return _context.Reservations.Where(r => r.ReservationStatus == "Onay Bekliyor" || r.ReservationStatus == "Onay Verildi").Include(a => a.AppUser).Include(a => a.Destination);
		}

		public void GiveApprovalChange(int id) // rezervasyonu onay verildi olarak değiştir
		{
			var reservation = GetById(id);
			reservation.ReservationStatus = "Onay Verildi";
			_context.Update(reservation);
			_context.SaveChanges();
		}
		public void WaitApprovalChange(int id) // rezervasyonu onay bekliyor olarak değiştir
		{
			var reservation = GetById(id);
			reservation.ReservationStatus = "Onay Bekliyor";
			_context.Update(reservation);
			_context.SaveChanges();
		}

	}

}
