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
			  Yukarıda Category ve Writer doğrudan Blog ile ilişkili olduğundan Include() kullandık.			
			 */
	public class CommentRepository : GenericRepository<Comment>, ICommentRepository
	{
		private readonly Context _context;
		public CommentRepository(Context context) : base(context)
		{
			_context = context;
		}
		/*
 Sadece okuma gerekiyorsa → IEnumerable<T>

Değiştirme gerekiyorsa → ICollection<T> veya List<T>

Veritabanına sorgu atılacaksa → IQueryable<T> -> LINQ sorguları SQL sorgularına çevrilerek sorgular SQL 'de calıştırır performans artar

 */

		public IQueryable<Comment> GetAllCommentByDestinationId(int id) // AppUser'ı dahil ederek Dest ID'ye göre tüm yorumları getirç
		{
			return _context.Comments.Where(i => i.DestinationID == id).Include(a => a.AppUser);
		}
		public IQueryable<Comment> GetAllCommentIncludeDestination()// Tüm Yorumları ilişkili olduğu Destination nesnesi ile beraber getir
		{
			return _context.Comments.Include(d => d.Destination).Include(a => a.AppUser);
		}


		public int GetCommentCountByDestinationId(int id) // rotaya yapılan yorum sayısını getir
		{
			return _context.Comments.Where(d => d.DestinationID == id).Count();
		}
		public IQueryable<Comment> GetAllCommentByUserId(int id) // User id ye göre kullanıcının yaptıgı tüm yorumları getir
		{
			return _context.Comments.Include(a => a.AppUser).Include(d=>d.Destination).Where(i => i.AppUserId == id);
		}

	}

	/*
         İSİMLENDİRME KURALLARI
         
         Method -> PascalCase -> Örnek : GetAllBlogs()
         Property -> PascalCase ->  Örnek : public int BlogID { get; set; }
         Method Parametreleri -> camelCase -> Örnek :  blogService
         Field (Özel Değişkenler) -> _camelCase -> Örnek _categoryService
         */
	/*
	List<> yerine ICollection<> kullanmamızın nedenleri başka koleksiyon türüne geçmek istediğimizde bu sürecin daha kolay olması.
   List<> daha fazla özellik içerdiği için daha fazla bellek tüketebilir. Yani fazladan ve metotlar içerdiğinden daha fazla yük oluşturabilir.
   Yani List<> EF CORE için açısından gereksiz özellikler barındırdığı için List<> değil ICollection önerilir.
   List<> somut bir sınıf, ICollection ise bir interfacedir.
   ICollection daha hızlı ve esnektir List<> ' e göre.
   IEnumerable<T> sadece veri okuma işlemlerinde kullanılabilir,Insert ve Delete işlemlerini desteklemez. Dolasıyla ICollection tipi IEnumerable'ye göre daha iyi bir seçimdir.


	*/
}
/*
 2. IEnumerable<T>
Sadece veri üzerinde dolaşmaya izin verir.

Okuma (Read-Only) amaçlıdır.

foreach, First(), Where() gibi LINQ komutlarıyla çalışır.

Lazy/deferred execution sağlar: Yani sorgu, çağrılana kadar çalışmaz.

🔸 Ne zaman kullanılır?

Filtreleme ya da döngü için sadece okumak gerekiyorsa.

Hafif veri erişimi gerekiyorsa.


 3. IQueryable<T>
IEnumerable<T>’in gelişmiş halidir.

IQueryable<T> ile yazılan LINQ sorguları veritabanına SQL sorgusu olarak çevrilir.

Böylece filtreleme/sıralama gibi işlemler veritabanında çalışır -> çok daha performanslı olur.

🔸 Ne zaman kullanılır?

Entity Framework ile veritabanı sorgularında.

Daha az veri çekmek istiyorsan.
 */