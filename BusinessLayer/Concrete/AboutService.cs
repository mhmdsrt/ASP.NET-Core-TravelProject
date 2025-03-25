using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class AboutService : GenericService<About>, IAboutService
	{
		
		private readonly IAboutRepository _aboutRepository;

		public AboutService(IAboutRepository aboutRepository) : base(aboutRepository) // Program.cs'de hangi IAboutRepository için hangi repository enjekte ediliyorsa o kullanılır
		{
			_aboutRepository = aboutRepository;
		}
		/*
		 Eğer yukarıda IAboutRepository yerine AboutRepository kullansaydık AboutService doğrudan somut AboutRepository'e sıkı bağımlı olucaktı ve esneklik azalacaktı.Böylelikle gevşek bağımlılık sağlanıyor
		 Ayrıca bu kullanım sayesinde Moq kütüphanesini kullanarak Mock(Tatlit) nesnesi ile Unit Test yapılabilir böylece gerçek veritabanına bağlı olmadan AboutService test edilebilir
		 Yani AboutRepository'deki yapılan değişiklikler AboutService'i doğrudan etkiliyecekti.
		 Ayrıca AboutRepository kullanılsaydı, AboutRepository değiştirmek istediğimiz zaman AboutService'de değiştirmek zorunda kalıcaktık.
		Özet: AboutService'in IAboutRepository'i implement eden AboutRepository'den başka AboutRepository2 diye bir repository kullanılmaya ihtiyaç olabilme 
		ihtimalini olabileceğinden dolayı böyle yapıyoruz.
		 */
	}
}
