using AutoMapper;
using DTOLayer.DTOs.AppUserDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http.HttpResults;

namespace TravelProject.Mapping.AutoMapperProfile
{
	/*
	 AutoMapper Framework -> Nesneler arasında otomatik dönüşüm(eşleme) yapabilmemizi sağlar.
	 Mapping -> Eşleme, Mapper -> Eşleştirici(Dönüştürücü)
	 Örnek : DTO -> Entity veya Entity -> DTO döşümleri için aynı veri tipi ver aynı isimdeki propertyleri eşleyip
	 satır satır manuel atama yapmadan birbirine dönüştürür(eşler).
	 AutoMapper kullanma sebeplerimiz:
	 Dönüşüm gerektiren yerlerde satır satır appUser.Name = UserRegisterViewModel.Name gibi atamalar yapmamıza gerek kalmadan
	 tek satırda dönüşümü sağlayabiliyoruz üstelik .ReverseMap() metodu ile dönüşümü çift taraflı yapıp tek satırda işi hallediyoruz.
	 Tüm Mapping kuralları Profile sınıfında miras alınan sınıfta toplanacağı için merkezi yerden yönetilir.
	 
	 */

	/*
	 DTO -> Data Transfer Object -> Veri Taşıma Nesnesi
     DTO 'yu kullanma sebeplerimiz:
	 1) View tarafında örneğin sadece Kullanıcı adı ve şifre alanlarını göstereceksek neden tüm alanları taşıyalım. 
	 Yani gereksiz sütunlar taşınmaz sadece ihtiyacımız olan sütunları taşırız.
	 Dolayısıyla API ve View performansı artar az veri olacağından dolayı performans artışı sağlanır.
	 Ayrıca PasswordHash, ID gibi hassas alanları taşımamıza gerek yok sadece ihtiyacımız olan ve kullanacağımız alanları taşıyabileceğiz.
	 Güvenlik açısından çok önemli.
	 2) Veri tabanı değilse bile yani Entitylerimiz değişse bile UI(User Interface) etkilenmez çünkü UI tarafında doğrudan 
	 Entitylerimizi değil, Entitylere karşılık gelen DTO'ları kullanmış olacağız. Bu sayede UI, Entity'lere bağımlı olmayacak.
	 
	 */
	public class MapProfile : Profile // AutoMapper' da tüm eşleştirmeleri tanımladığımız sınıfa Profile denir
	{
		/*
		 Source -> Kaynak
		 Destination -> Hedef

		 CreateMap<TSource,TDestination>(); -> Kaynaktan -> Hedefe dönüşümü sağlar
		 
		 */
		public MapProfile()
		{
			/*
			 CreateMap<AppUser, AppUserLoginDTOs>();  -> AppUser propertleri AppUserLoginDTOs propertlerinin 
			 veri tipleri ve isimleriyle aynıysa eşleştirip kopyalayabilirsin demek.

			 CreateMap<TSource,TDestination>(); kodunu dönüşümü yapabilmek için tanımlıyoruz henüz dönüşüm yapmadık,
			 Dönüşüm için "Map<List<AppUserLoginDTOs>>(AppUser)" dediğimizde dönüşümü gerçekleştireceğiz.
			 Buradaki List<AppUserLoginDTOs> -> Dönüştürülmek istenen hedef liste tipi
			 (AppUser) -> Dönüştürülecek Kaynak 
				*/
			CreateMap<AppUser, AppUserLoginDTO>();  // Bu kod satırına bide ReverseMap() da ekleyerek "CreateMap<AppUserLoginDTO, AppUser>();" kod satırını yazmaya gerek kalmayabilirdi.
			CreateMap<AppUserLoginDTO, AppUser>();

			CreateMap<AppUserRegisterDTO, AppUser>().ReverseMap(); // ReverseMap() -> Yazılan dönüşümün tam tersininde yapılacağını bildirdik.
			
		}
	}
}
