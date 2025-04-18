using System.ComponentModel.DataAnnotations;

namespace TravelProject.Models
{
	public class UserRegisterViewModel
	{
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
