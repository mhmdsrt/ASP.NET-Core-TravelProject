using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{

	/*
	 Varsayılan olarak Identity, Primary Key 'ler için string tipini kullanır biz int kullanmak istediğimiz için <int> verdik.
	 Bu classı UndetityUser'ın bize verdiği tablodaki sütunlardan ekstra yeni sütun ekleyebilmek için kullanıyoruz.

	 */
	public class AppUser : IdentityUser<int> // Identity Framework'ünün bize verdiği tablolara ekstra sütun ekleyebilmek için kullanacağımız AppUser Classı 
	{
		public string? ImageUrl { get; set; }
		public string Name { get; set; }
		public string SurName { get; set; }
		public string? Gender { get; set; }
	}
}
