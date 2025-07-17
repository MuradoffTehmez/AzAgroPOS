using AzAgroPOS.Entities.Domain;
using FluentValidation;

namespace AzAgroPOS.BLL.Validators
{
    public class MusteriValidator : AbstractValidator<Musteri>
    {
        public MusteriValidator()
        {
            RuleFor(m => m.Ad)
                .NotEmpty()
                .WithMessage("Müştəri adı mütləqdir")
                .Length(2, 100)
                .WithMessage("Müştəri adı 2-100 simvol arasında olmalıdır");

            RuleFor(m => m.Soyad)
                .NotEmpty()
                .WithMessage("Müştəri soyadı mütləqdir")
                .Length(2, 100)
                .WithMessage("Müştəri soyadı 2-100 simvol arasında olmalıdır");

            RuleFor(m => m.Telefon)
                .NotEmpty()
                .WithMessage("Telefon nömrəsi mütləqdir")
                .Matches(@"^\+?[1-9]\d{1,14}$")
                .WithMessage("Telefon nömrəsi düzgün formatda olmalıdır");

            RuleFor(m => m.Email)
                .EmailAddress()
                .WithMessage("Email formatı düzgün deyil")
                .When(m => !string.IsNullOrEmpty(m.Email));

            RuleFor(m => m.Unvan)
                .MaximumLength(500)
                .WithMessage("Ünvan 500 simvoldan çox ola bilməz")
                .When(m => !string.IsNullOrEmpty(m.Unvan));

            RuleFor(m => m.BorcLimiti)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Borc limiti mənfi ola bilməz");

            RuleFor(m => m.EndirimFaizi)
                .InclusiveBetween(0, 100)
                .WithMessage("Endirim faizi 0-100 arasında olmalıdır");
        }
    }
}