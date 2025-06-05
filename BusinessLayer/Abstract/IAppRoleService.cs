using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IAppRoleService : IGenericService<AppRole>
	{
		Task RemoveAppRole(int id);
		Task UpdateRole(AppRole appRole);
		Task<AppRole?> GetRoleById(int id);
	}
}
