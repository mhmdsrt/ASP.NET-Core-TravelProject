using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
	/*
            Builder -> Kurucu
            Configuration -> Yapılandırma
            Options -> Seçenekler
            integrated -> Entegre
            security -> güvenlik
            on -> üzerinde
         */
	/*
     ORM (Object-Relational Mapping) -> Nesne-İlişkisel Eşleme
     Nesne yönelimli progralama ile Veri tabanı arasında köprü görevi görevi görür.
     Class'ı tablo, property'leri ise sütun olarak eşler.

     Bu projede ORM aracı olarak Entity Framework kullanıyoruz.
     */

	/*
	 IdentityDbContext deki generic ifadelerin açıklaması:
	 AppUser -> Kullanacağımız özelleştirilmiş kullanıcı sınıfı, IdentityUser<int>'den türetilmiş
	 AppRole -> Kullanacağımız özelleştirilmiş Rol Sınıfı, IdentityRole<int>'den türetilmiş
	 int -> Primary keyler için kullanacağımız veri tipi (default olarak string'tir)
	 */
	public class Context : IdentityDbContext<AppUser, AppRole, int>
	{

		public Context(DbContextOptions<Context> options) : base(options)
		{

		}

		public DbSet<About> Abouts { get; set; } // Buradaki About Classı'mız Abouts ise veritabanında oluşacak olan tablomuz
		public DbSet<About2> About2s { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Destination> Destinations { get; set; }
		public DbSet<Feature> Features { get; set; }
		public DbSet<Feature2> Feature2s { get; set; }
		public DbSet<Guide> Guides { get; set; }
		public DbSet<Newsletter> Newsletters { get; set; }
		public DbSet<SubAbout> SubAbouts { get; set; }
		public DbSet<Testimonial> Testimonials { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Reservation> Reservations { get; set; }
	}
}
