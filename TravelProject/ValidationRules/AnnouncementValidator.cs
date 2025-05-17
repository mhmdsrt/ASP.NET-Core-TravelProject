using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;

namespace TravelProject.ValidationRules
{
	public class AnnouncementValidator:AbstractValidator<AnnouncementAddDTO>
	{
		public AnnouncementValidator()
		{
			RuleFor(t => t.AnnouncementTitle)
				.NotEmpty().WithMessage("Başlık(Konu) Boş Geçilemez")
				.MaximumLength(50).WithMessage("50 Karakterden Fazla Olamaz")
				.MinimumLength(3).WithMessage("3 Karakterden fazla olmalıdır");

			RuleFor(c => c.AnnouncementContent)
				.NotEmpty().WithMessage("Duyuru İçeriği Boş Geçilemez")
				.MaximumLength(50).WithMessage("50 Karakterden Fazla Olamaz")
				.MinimumLength(3).WithMessage("3 Karakterden fazla olmalıdır");


		}
	}
}
