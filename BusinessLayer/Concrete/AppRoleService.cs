using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class AppRoleService : GenericService<AppRole>, IAppRoleService
	{
		private readonly IAppRoleRepository _appRoleRepository;

		public AppRoleService(IAppRoleRepository appRoleRepository) : base(appRoleRepository)
		{
			_appRoleRepository = appRoleRepository;
		}

		public async Task<IEnumerable<AppRole>> GetAllRole()
		{
			return await _appRoleRepository.GetAllRole();
		}
		public async Task<AppRole?> GetRoleById(int id)
		{
			var role = await _appRoleRepository.GetRoleById(id);
			if (role != null)
			{
				return role;
			}
			return null;
		}
		public async Task RemoveAppRole(int id) // önce id ye göre rolü bul sonra kaldır
		{
			var role = await _appRoleRepository.GetRoleById(id);
			if (role != null)
			{
				await _appRoleRepository.DeleteRole(role);
			}
		}

		public async Task UpdateRole(AppRole appRole)
		{
			await _appRoleRepository.UpdateRole(appRole);
		}
	}
}
