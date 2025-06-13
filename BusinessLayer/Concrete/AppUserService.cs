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

		public async Task<IEnumerable<AppUser>> GetAllUsersByRoleInMember()
		{
			return await _appUserRepository.GetAllUsersByRoleInMember();
		}

		public int GetCountUser() // Kullanıcı Sayısını Getir
		{
			return _appUserRepository.GetCountUser();
		}
		public async Task<AppUser?> GetUserById(int id)
		{
			return await _appUserRepository.GetUserById(id);
		}
	}
}
