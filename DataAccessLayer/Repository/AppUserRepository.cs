using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly Context _context;

		public AppUserRepository(Context context, UserManager<AppUser> userManager) : base(context)
		{
			_context = context;
			_userManager = userManager;
		}
		public async Task<IEnumerable<AppUser>> GetAllUsersByRoleInMember() // Role == Member olanları getir
		{
			return await _userManager.GetUsersInRoleAsync("Member");
			//return await _userManager.Users.ToListAsync();
		}
		public async Task<AppUser?> GetUserById(int id)
		{
			return await _userManager.Users.FirstOrDefaultAsync(i => i.Id == id);
		}
		public int GetCountUser() // Kullanıcı Sayısını Getir
		{
			return _userManager.Users.Count();
		}

		
	}
}
