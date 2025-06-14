﻿using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppRoleDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.ContactUsDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http.HttpResults;
using TravelProject.CQRS.Commands.DestinationCommands;
using TravelProject.CQRS.Results.DestinationResults;

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
	 2) Veri tabanı değişse bile yani Entitylerimiz değişse bile UI(User Interface) etkilenmez çünkü UI tarafında doğrudan 
	 Entitylerimizi değil, Entitylere karşılık gelen DTO'ları kullanmış olacağız. Bu sayede UI, Entity'lere bağımlı olmayacak.
	 
	 */
	public class MapProfile : Profile // AutoMapper' da tüm eşleştirmeleri tanımladığımız sınıfa Profile denir
	{
		/*
		 Source -> Kaynak
		 Destination -> Hedef

		 CreateMap<TSource,TDestination>(); -> Kaynaktan -> Hedefe dönüşümü sağlar

		Automapper tüm dönüşüm işlemlerini IMapper interface'i üzerinden yapar.
		Map<T>() metodu da bu interface'in içindedir.

		 _mapper.Map<<Destination>>(Source) -> Paranten içindeki kaynağı <> içerisinde hedefe dönüştürür

	     _mapper.Map<IEnumerable<AnnouncementListDTO>>(_announcementService.GetAll()) ifadesi açıklama:
		 (_announcementService.GetAll()) -> Nereden? , Dönüşüm yapacağımız Kaynak
		 <IEnumerable<AnnouncementListDTO>> -> Nereye ? , Dönüşüm yapacağımız Hedef
		 
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
			CreateMap<Announcement, AnnouncementListDTO>().ReverseMap();
			CreateMap<AnnouncementAddDTO, Announcement>().ReverseMap();
			CreateMap<AnnouncementUpdateDTO, Announcement>().ReverseMap();
			CreateMap<GetAllDestinationQueryResult, Destination>().ReverseMap();
			CreateMap<CreateDestinationCommand, Destination>().ReverseMap();
			CreateMap<GetDestinationByIdQueryResult, Destination>().ReverseMap();
			CreateMap<UpdateDestinationCommand, Destination>().ReverseMap();
			CreateMap<ContactUsAddDTO, ContactUs>().ReverseMap();
			CreateMap<AppRoleCreateDTO, AppRole>().ReverseMap();
			CreateMap<AppRoleUpdateDTO, AppRole>().ReverseMap();
		}
	}
}
