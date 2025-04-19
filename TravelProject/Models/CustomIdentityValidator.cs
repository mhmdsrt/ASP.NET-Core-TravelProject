using Microsoft.AspNetCore.Identity;

namespace TravelProject.Models
{
	// Custom Identity Validator -> özel kimlik doğrulayıcı
	// Identity Error Describer -> Kimlik Hata Tanımlayıcısı

	/*
	 "IdentityErrorDescriber" classı Identity Frameworkunde kimlik doğrulama ile ilgili hata mesajlarını üretir
	 "CustomIdentityValidator" classı ile "IdentityErrorDescriber" sınıfından miras alarak kendi özel türkçe hata 
	 mesajlarımızı tanımlıyoruz.

	FluentValidation ile bunu yapmamızın sebebi zaten Identity bellir koşullara göre kendine özel hata mesajlarının 
	olması ve bu hata mesajlarının "IdentityErrorDescriber" classı tarafından yönetiliyor olması.
	Bizde zaten var olan hata mesajlarını "CustomIdentityValidator" classı ile IdentityErrorDescriber sınıfındaki virtual metotları
	override ederek türkçeleştirip kendimize özel metotlar yazdık.

	Kalıtım aldığımız sınıftaki "Virtual" tipindeki metotları istersek direkt kullanabiliriz, istersek de override edip kendimize göre değiştirebiliriz.
	 */
	public class CustomIdentityValidator:IdentityErrorDescriber // Describer -> tanımlayıcı
	{
		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError()
			{
				Code = "PasswordTooShort",
				Description = $"Parola minumum {length} karakter olmalı!"
			};
		}

		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresLower",
				Description = "Parola en az bir tane küçük harf içerlemeli!"
			};
		}

		public override IdentityError PasswordRequiresUpper()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresUpper",
				Description = "Parola en az bir tane büyük harf içermeli!"
			};
		}

		public override IdentityError PasswordRequiresNonAlphanumeric()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresNonAlphanumeric",
				Description = "Parola en az bir sembol içermeli!"
			};
		}
	}
}
