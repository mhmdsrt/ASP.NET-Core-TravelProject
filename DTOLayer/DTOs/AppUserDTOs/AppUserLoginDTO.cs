using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.AppUserDTOs
{
	/*
 AppUser gibi özelleştirilmiş bir veri tabanında tablomuz varken bu classı kullanmamızın sebepleri şunlardır:
 AppUser tablosunda cok fazla alan yani tüm kullanıcı bilgileri var  ama biz oturum açarken sadece 2 alan kullanacağız.
 Ayrıca AppUser'da şifre  hashlenmiş olarak kayıtlıdır yan dümdüz şifrenin kendisi yazmaz veritabanında.
 Ayrıca View ile sadece gerekli alanları kullanarak performans artışı sağlanır diğer türlü AppUser'da tüm alanlar gelicekti.
 Ayrıca oturum açma ve kayıt olma formları herkese açık (public) olduğu için bu saldırlardan korumak adına gerçek veri tabanına
 ait alanlar yerine sadece kullanacağımız alanları içeren bir ViewModel kullanmak daha iyidir.
Yani AppUser'ı direkt oturum açma yerinde kullanmak ciddi güvenlik acıklarına sebep olur.

*/
	public class AppUserLoginDTO
	{
		public string? UserName { get; set; }
		public string? Password { get; set; }
	}

}
