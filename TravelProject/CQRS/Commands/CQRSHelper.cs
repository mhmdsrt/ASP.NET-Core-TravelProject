namespace TravelProject.CQRS.Commands
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
		 Read ve Write işleleri ayrıldığı için herhangi bir Read işleminde Write işlemini beklemek zorunda kalmayız.

		 Commands File -> Insert-Delete-Update gibi veri üstünde değişiklik yapan Class'ların bulunduğu klasör
		 Queries File -> Select yani veri listeleme işlemlerini yapan Class'ların bulunduğu klasör
		 Handlers File -> Commands ve Queries'lerin işlenmesini sağlayan Class'ların bulunduğu klasör
		 Results File -> View'e veya Cliente göstereceğimiz belirli propertleri içeren Class'ların bulunduğu klasördür.
		 DTO gibi davranır ama sadece CQRS özelinde kullanılır.
		 
		 İsimlendirme Kuralları:
		 Commands File da bulunan Class'ların isimlendirilmesi:
		 UpdateDestinationCommand - DeleteUserCommand - CreateProductCommand

		 Queries File da bulunan Class'ların isimlendirilmesi:
		 GetAllDestinationQuery - GetUserByIdQuery - SearchOrdersQuery

		 Handlers File da bulunan Class'ların isimlendirilmesi:
		 UpdateDestinationCommandHandler - DeleteUserCommandHandler - CreateProductCommandHandler
		 GetAllDestinationQueryHandler - GetUserByIdQueryHandler - SerachOrdersQueryHandler

		 Result File da bulunan Class'ların isimlendirilmesi:
		 GetAllDestinationQueryResult - GetUserByIdQueryResult - CreateProductCommandQuery

		 */
	}
}
