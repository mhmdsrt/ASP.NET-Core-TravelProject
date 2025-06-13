using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.PasswordDTOs
{
	public class PasswordResetDTO
	{
		public string? Password { get; set; }
		public string? ConfirmPassword { get; set; }
	}
}
