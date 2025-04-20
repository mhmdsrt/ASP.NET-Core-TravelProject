using System.ComponentModel.DataAnnotations;

namespace TravelProject.Models
{
	public class UserRegisterViewModel
	{
		/*
		 AppUser gibi özelleştirilmiş bir veri tabanında tablomuz varken bu classı kullanmamızın sebepleri şunlardır:
		 AppUser tablosunda cok fazla alan yani tüm kullanıcı bilgileri var  ama biz oturum açarken sadece 2 alan kullanacağız.
		 Ayrıca AppUser'da şifre  hashlenmiş olarak kayıtlıdır yan dümdüz şifrenin kendisi yazmaz veritabanında.
		 Ayrıca View ile sadece gerekli alanları kullanarak performans artışı sağlanır diğer türlü AppUser'da tüm alanlar gelicekti.
		 Ayrıca oturum açma ve kayıt olma formları herkese açık (public) olduğu için bu saldırlardan korumak adına gerçek veri tabanına
		 ait alanlar yerine sadece kullanacağımız alanları içeren bir ViewModel kullanmak daha iyidir.
		 Ayrıca Data annotation ile doğrulama kontrollerini yapabiliyoryuz.

		Yani AppUser'ı direkt oturum açma yerinde kullanmak ciddi güvenlik acıklarına sebep olur.

		*/
		[Required(ErrorMessage ="Lütfen Adınızı Giriniz")]
		public string Name { get; set; }

		[Required(ErrorMessage ="Lütfen Soyadınızı Giriniz")]
		public string SurName { get; set; }

		[Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Giriniz")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Lütfen Mailinizi Giriniz")]
		public string UserMail { get; set; }

		[Required(ErrorMessage = "Lütfen Şifre Giriniz")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Lütfen Şifrenizi Tekrar Giriniz")] // Comfirm -> Onaylamak, Compare -> Karşılaştırmak
		[Compare("Password",ErrorMessage ="Şifreler Uyuşmuyor!")] 
		public string PasswordConfirm { get; set; }

		/*
		 Compare Attribute'ı ile 2 şifrenin birebir aynı girilmesini sağlayacağız aksi takdirde hata mesajı verdireceğiz
		 */

	}
}
