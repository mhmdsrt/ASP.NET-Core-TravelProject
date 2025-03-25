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
	/*
 Bu class yani About2Repository sınıfı, Generic_Repository sınıfından <About> tipinde miras alarak 
 IGenericRepository<About> interface'ini implement etmiş oluyor. Ayrıca YAboutRepository interfaceni implement etmek için burada 
 o metotları tanımlamak zorunda.

About2Repository sınıfı Generic_Repository<T> sıfından miras aldığından dolayı ve
T yerine About ile verdiğinden Generic_Repository<About> classının tüm metotlarını kullanabiliyor About tipinde.

 */
	/*
  Include => Dahil etmek.
  Then => Daha sonra.
  Include() metodu doğrudan ilişkili varlıkları yüklemek için kullanılır.
  ThenInclude() metodu iç içe ilişkili varlıkları yüklemek için kullanılır.(Dolaylı yoldan ilişkili olanı getirmek için)		
 */
	public class About2Repository : GenericRepository<About2>, IAbout2Repository
	{
		private readonly Context _context;
		public About2Repository(Context context) : base(context)
		/*
		  Miras Aldığı GenericRepository<About2> Constructor'ırına Program.cs'de yazılan Dependecy Injection
		  ile buraya context nesnesi enjekte ediliyor ve enjekte edilen context nesneside GenericRepository classına gönderiliyor.
		  Böylelikle About2Repository Classından bir nesne oluşturulduğu anda tek bir context nesnesi oluşturup, oluşturulan 
		  About2Repository nesnesi üzerinden aynı Context nesnesi kullanılır.
		  
         Yani Program.cs içinde Dependency Injection kullanılarak oluşturulan `Context` nesnesi, 
         bu constructor’a otomatik olarak enjekte edilir.

         `base(context)` ile bu `Context`, GenericRepository<About2> sınıfına iletilir.
         Böylece About2Repository üzerinden yapılan işlemlerde **tek bir `Context` nesnesi** kullanılır.


		*/
		{
			_context = context;
		}
	}
}
