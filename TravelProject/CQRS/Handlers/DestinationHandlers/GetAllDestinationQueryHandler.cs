using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using TravelProject.CQRS.Results.DestinationResults;

namespace TravelProject.CQRS.Handlers.DestinationHandlers
{
	public class GetAllDestinationQueryHandler
	{
		private readonly Context _context;

		public GetAllDestinationQueryHandler(Context context)
		{
			_context = context;
		}

		public IEnumerable<GetAllDestinationQueryResult> Handle()
		{
			var values = _context.Destinations.Select(d => new GetAllDestinationQueryResult
			{
				Id=d.DestinationID,
				Image=d.DestinationImage,
				City = d.DestinationCity,
				DayNight=d.DestinationAccomodationDay,
				Price=d.DestinationPrice,
				Capacity=d.DestinationCapacity
			}).AsNoTracking();

			return values;
		}
		/*
		 Tracking -> İzleme, Takip
		 AsNoTracking() -> Okuma(Read) işlemlerinde perfomansı arttırmak için kullanılan EF Core' un özelliğidir.
		 Veri Tabanından getirilen nesnelerin "Change Tacker(Değişiklik Takipçisi)" tarafından izlenmesini engeller,
		 yani Change Tracker'i kapatır.

		 Normalde EF Core bir sorgu çalışınca örneğin: "var destinations = _context.Destinations.ToList();"
		 bu sorguda her bir Destination nesnesini bellekte izlemeye alır ve değişiklikleri takip eder, 
		 eğer değişiklik olursa farkı anında anlar. Change Tracker sayesinde yapılan değişikliliği RAM'de anında fark ediyor.
		 Ayrıca bu değişikliği de Veri Tabanına yansıtma için de bildiğimiz gibi SaveChanges() metodu ile yapıyoruz.
		 

		 AsNoTracking() -> Bu metot ile EF Core'a şunu diyoruz: verileri okudum bunların üzerinde herhangi bir değişiklik 
		 yapmayacağım boşuna izlemene(takip etmene) gerek yok, yani RAM'i boşuna yorma.

		 Dolayısıyla:
		 Change Tracker kapatılır.
		 RAM daha az kullanılır.
		 Okuma performansı artar.
		 Query daha hızlı çalışır.
		 */
	}
}
