namespace TravelProject.CQRS
{
	public class CQRSHelper
	{
		/*
		 * Commands -> Komutlar, Queries -> Sorgular , Query -> Sorgu , Handler -> İşleyici
		 CQRS -> Command-Query Responsibility Segregation -> Komut ve Sorgu Sorumluluğunun Ayrılması
		 CQRS -> Bir metot ya geriye sonuç dönmelidir ya da objenin durumunu değiştirmelidir 
		 ancak her iki işi de aynı anda yapmamalıdır! Yani hem listeleme hem de ekleme, silme veya güncelleme olmamalı.

	     Commands yani Write işlemleri  -> Objenin veya Sistemin durumunu değiştirir. Geriye veri döndürmez
		 Commands yani Write işlemleri -> "Update-Insert-Delete" -> Veri tabanında değişiklik yapan işlemlerdir

		 Queries yani Read işlemleri -> Sadece sounucu geriye döner, herhangi bir sistemin veya nesnenin durumunu değiştirmez	 
		 Queries yani Read işlemleri -> "Select" -> GetList , GetByID -> Veri tabanında herhangibir değişiklik olmaz

		 Read ve Write için farklı veri tabanları kullanabiliriz!
		 Read ve Write işleleri ayrıldığı için herhangi bir Read işlemi, Write işlemini beklemek zorunda kalmaz.

		 Commands File -> Sadece veri üstünde değişiklik yapılacak belirli property'lerin tutulduğu Class'ların bulunduğu klasör. 
		 Commands File -> Yani sadece işlem yapılacak belirli property'lerin tutulduğu Class'ların bulunduğu klasördür.
		 Commands File -> Yani Entity’deki her şeyi değil, sadece üzerinde işlem yapacağımız belirli alanları taşır.
		 Queries File -> Sorgu parametrelerinin tutulduğu Class'ların bulunduğu klasördür.
		 Queries File -> Quries File'daki Class'ların içerisinde parametreler property olarak tutulur.
		 Queries File -> Parametreleri kullanırken bu klasördeki Class'ların propert'lerine Constructor ile atama yapıyoruz.
		 Handlers File -> Commands ve Queries'lerin işlenmesini sağlayan Class'ların bulunduğu klasör
		 Results File -> Sadece View'e veya Cliente göstereceğimiz belirli propertleri içeren Class'ların bulunduğu klasördür.
		 Results File -> DTO gibi davranır ama sadece CQRS özelinde kullanılır.
		 Results File -> Yani Entity’deki her şeyi değil, sadece ihtiyacımız olan alanları taşır.
		 
		 İsimlendirme Kuralları:
		 Commands File da bulunan Class'ların isimlendirilmesi:
		 UpdateDestinationCommand - DeleteUserCommand - CreateProductCommand

		 Queries File da bulunan Class'ların isimlendirilmesi:
		 GetAllDestinationQuery - GetUserByIdQuery - SearchOrdersQuery

		 Handlers File da bulunan Class'ların isimlendirilmesi:
		 UpdateDestinationCommandHandler - DeleteUserCommandHandler - CreateProductCommandHandler
		 GetAllDestinationQueryHandler - GetUserByIdQueryHandler - SerachOrdersQueryHandler

		 Result File da bulunan Class'ların isimlendirilmesi:
		 GetAllDestinationQueryResult - GetUserByIdQueryResult - CreateProductCommandResult




		 Tracking -> İzleme, Takip
		 AsNoTracking() -> Okuma(Read) işlemlerinde perfomansı arttırmak için kullanılan EF Core' un özelliğidir.
		 Veri Tabanından getirilen nesnelerin "Change Tacker(Değişiklik Takipçisi)" tarafından izlenmesini engeller,
		 yani Change Tracker'i kapatır.

		 Normalde EF Core bir sorgu çalışınca örneğin: "var destinations = _context.Destinations.ToList();"
		 bu sorguda her bir Destination nesnesini, Change Tracker bellekte izlemeye alır ve değişiklikleri takip eder, 
		 eğer değişiklik olursa farkı anında anlar. Change Tracker sayesinde yapılan değişikliliği RAM'de anında fark ediyor.
		 Ayrıca bu değişikliği de Veri Tabanına yansıtmak için de bildiğimiz gibi SaveChanges() metodu ile yapıyoruz.
		 

		 AsNoTracking() -> Bu metot ile EF Core'a şunu diyoruz: verileri okudum bunların üzerinde herhangi bir değişiklik 
		 yapmayacağım boşuna izlemene(takip etmene) gerek yok, yani RAM'i boşuna yorma.

		 Dolayısıyla:
		 Change Tracker kapatılır.
		 RAM daha az kullanılır.
		 Okuma performansı artar.
		 Query daha hızlı çalışır

		 */
	}
}
