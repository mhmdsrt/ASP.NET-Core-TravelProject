using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
	/*
     ORM (Object-Relational Mapping) -> Nesne-İlişkisel Eşleme
     Nesne yönelimli progralama ile Veri tabanı arasında köprü görevi görevi görür.
     Class'ı tablo, property'leri ise sütun olarak eşler.

     Bu projede ORM aracı olarak Entity Framework kullanıyoruz.
     */
	public class Context : DbContext
	{
		/*
            Builder -> Kurucu
            Configuration -> Yapılandırma
            Options -> Seçenekler
            integrated -> Entegre
            security -> güvenlik
            on -> üzerinde
         */
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
	}
}
