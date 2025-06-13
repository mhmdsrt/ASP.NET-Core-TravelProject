using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.AppRoleDTOs
{
	public class AppRoleAssignRoleDTO
	{
		public int RoleId { get; set; }
		public string? RoleName { get; set; }
		public bool RoleExist { get; set; } // rol kullanıcı da var mı?
	}
}
