using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IAppUserService:IGenericService<AppUser>
	{
		Task<IEnumerable<AppUser>> GetAllUsersByRoleInMember();
		 int GetCountUser(); // Kullanıcı Sayısını Getir
		Task<AppUser?> GetUserById(int id);

	}
}
