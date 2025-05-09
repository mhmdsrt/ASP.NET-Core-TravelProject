using EntityLayer.Concrete;
using FluentValidation;

namespace TravelProject.ValidationRules
{
	public class ReservationValidator : AbstractValidator<Reservation>
	{
		// Validator -> Doğrulayıcı , Validation -> Doğrulama, Rule -> Kural, Fluent -> Sürekli,akıcı 
		// Empty -> Boş, yoksun
		// AbstractValidator<T> sınıfı, otomatik olarak IValidator<T> arayüzünü uygular.
		public ReservationValidator()
		{
			RuleFor(d => d.ReservationVisitorCount)
				.NotEmpty().WithMessage("Ziyaretçi Sayısı Boş Geçilemez");
				

			RuleFor(d => d.ReservationDate)
			   .NotEmpty().WithMessage("Tarih boş geçilemez.")
			   .GreaterThan(DateTime.Now).WithMessage("Tarih bugünden ileri bir tarih olmalıdır.");

			RuleFor(d => d.ReservationDescription)
			   .NotEmpty().WithMessage("Açıklama boş geçilemez.")
			   .MaximumLength(100).WithMessage("Maksimum 100 Karakter Olmalıdır")
				.MinimumLength(5).WithMessage("Minumum 5 Karakter Olmalıdır");

		}
	}
}
