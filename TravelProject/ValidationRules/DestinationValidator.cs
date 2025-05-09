using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelProject.ValidationRules
{
	// Validator -> Doğrulayıcı , Validation -> Doğrulama, Rule -> Kural, Fluent -> Sürekli,akıcı 
	// Empty -> Boş, yoksun
	public class DestinationValidator:AbstractValidator<Destination> 
	{
		// AbstractValidator<T> sınıfı, otomatik olarak IValidator<T> arayüzünü uygular.
		public DestinationValidator()
		{
			RuleFor(d => d.DestinationCity)
				.NotEmpty().WithMessage("Şehir Boş Geçilemez")
				.MaximumLength(30).WithMessage("Maksimum 30 Karakter Olmalıdır")
				.MinimumLength(2).WithMessage("Minumum 2 Karakter Olmalıdır");

			RuleFor(d => d.DestinationAccomodationDay)
				.NotEmpty().WithMessage("Gün-Gece Boş Geçilemez")
				.MaximumLength(30).WithMessage("Maksimum 30 Karakter Olmalıdır")
				.MinimumLength(2).WithMessage("Minumum 2 Karakter Olmalıdır");
		}
	}
}
