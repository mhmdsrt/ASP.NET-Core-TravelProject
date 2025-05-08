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
	public class AppUserService : GenericService<AppUser>, IAppUserService
	{
		private readonly IAppUserRepository _appUserRepository;

		public AppUserService(IAppUserRepository appUserRepository):base(appUserRepository)
		{
			_appUserRepository = appUserRepository;
		}

		public int GetCountUser() // Kullanıcı Sayısını Getir
		{
			return _appUserRepository.GetCountUser();
		}

	}
}
