using AzAgroPOS.Entities.Domain;
using FluentValidation;

namespace AzAgroPOS.BLL.Validators
{
    public class MusteriValidator : AbstractValidator<Musteri>
    {
        public MusteriValidator()
        {
            RuleFor(m => m.MusteriKodu)
                .NotEmpty()
                .WithMessage("Müştəri kodu mütləqdir")
                .MaximumLength(20)
                .WithMessage("Müştəri kodu maksimum 20 simvol ola bilər");

            RuleFor(m => m.Ad)
                .NotEmpty()
                .WithMessage("Müştəri adı mütləqdir")
                .Length(2, 50)
                .WithMessage("Müştəri adı 2-50 simvol arasında olmalıdır");

            RuleFor(m => m.Soyad)
                .NotEmpty()
                .WithMessage("Müştəri soyadı mütləqdir")
                .Length(2, 50)
                .WithMessage("Müştəri soyadı 2-50 simvol arasında olmalıdır");

            RuleFor(m => m.SirketAdi)
                .MaximumLength(100)
                .WithMessage("Şirkət adı maksimum 100 simvol ola bilər")
                .When(m => !string.IsNullOrEmpty(m.SirketAdi));

            RuleFor(m => m.Telefon)
                .MaximumLength(20)
                .WithMessage("Telefon maksimum 20 simvol ola bilər")
                .When(m => !string.IsNullOrEmpty(m.Telefon));

            RuleFor(m => m.MobilTelefon)
                .MaximumLength(20)
                .WithMessage("Mobil telefon maksimum 20 simvol ola bilər")
                .When(m => !string.IsNullOrEmpty(m.MobilTelefon));

            RuleFor(m => m.Email)
                .EmailAddress()
                .WithMessage("Email formatı düzgün deyil")
                .MaximumLength(100)
                .WithMessage("Email maksimum 100 simvol ola bilər")
                .When(m => !string.IsNullOrEmpty(m.Email));

            RuleFor(m => m.Unvan)
                .MaximumLength(500)
                .WithMessage("Ünvan maksimum 500 simvol ola bilər")
                .When(m => !string.IsNullOrEmpty(m.Unvan));

            RuleFor(m => m.KreditLimiti)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Kredit limiti mənfi ola bilməz");

            RuleFor(m => m.CariBorc)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Cari borc mənfi ola bilməz");

            RuleFor(m => m.UmumiAlis)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Ümumi alış mənfi ola bilməz");

            RuleFor(m => m.VOEN)
                .MaximumLength(20)
                .WithMessage("VÖEN maksimum 20 simvol ola bilər")
                .When(m => !string.IsNullOrEmpty(m.VOEN));

            RuleFor(m => m.VergiNomresi)
                .MaximumLength(20)
                .WithMessage("Vergi nömrəsi maksimum 20 simvol ola bilər")
                .When(m => !string.IsNullOrEmpty(m.VergiNomresi));

            RuleFor(m => m.Status)
                .NotEmpty()
                .WithMessage("Status mütləqdir")
                .MaximumLength(20)
                .WithMessage("Status maksimum 20 simvol ola bilər");
        }
    }
}