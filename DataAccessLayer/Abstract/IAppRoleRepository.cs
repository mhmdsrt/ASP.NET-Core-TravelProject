using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IAppRoleRepository : IGenericRepository<AppRole>
	{
		Task<AppRole?> GetRoleById(int id);
		Task DeleteRole(AppRole appRole);
		Task UpdateRole(AppRole appRole);
	}
}
