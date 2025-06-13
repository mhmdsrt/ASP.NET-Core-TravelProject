using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	public class AppRoleRepository : GenericRepository<AppRole>, IAppRoleRepository
	{
		private readonly Context _context;
		private readonly RoleManager<AppRole> _roleManager;


		public AppRoleRepository(Context context, RoleManager<AppRole> roleManager) : base(context)
		{
			_context = context;
			_roleManager = roleManager;
		}
		public async Task<IEnumerable<AppRole>> GetAllRole()
		{
			return await _roleManager.Roles.ToListAsync();
		}
		public async Task<AppRole?> GetRoleById(int id)// id değerini ait role'u bul sonra sil, null olup olmadıgı kontrolünü business'da yaparız :)
		{
			return await _roleManager.Roles.FirstOrDefaultAsync(i => i.Id == id);
		}

		public async Task DeleteRole(AppRole appRole) // Silme ve id ye göre bulma işlemleri Identity kütüphanesine göre yapıyoruz
		{
			await _roleManager.DeleteAsync(appRole);
		}

		public async Task UpdateRole(AppRole appRole)
		{
			/*
			 UpdateAsync() metodu  tek başına tüm alanları(propertyleri) güncelliyor ama üst üst aynı veri üstünde 
			 güncelleme yapmak istediğim zaman EF Core yapılan "Name" alanı için değişikliği algılamıyor ve
			 güncellesek bile hata fırtlatmaması rağmen güncelleme işlemi yapılmıyor.
			 Dolayısıyla bizde  "role.Name = appRole.Name;" satırına ihtiyac duyduk

			 */
			var role = await GetRoleById(appRole.Id);
			role.Name = appRole.Name;
			await _roleManager.UpdateAsync(role);
		}
	}
}
