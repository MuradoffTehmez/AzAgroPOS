using AzAgroPOS.Entities.Domain;
using FluentValidation;

namespace AzAgroPOS.BLL.Validators
{
    public class IstifadeciValidator : AbstractValidator<Istifadeci>
    {
        public IstifadeciValidator()
        {
            RuleFor(i => i.Ad)
                .NotEmpty()
                .WithMessage("İstifadəçi adı mütləqdir")
                .Length(2, 100)
                .WithMessage("İstifadəçi adı 2-100 simvol arasında olmalıdır");

            RuleFor(i => i.Soyad)
                .NotEmpty()
                .WithMessage("İstifadəçi soyadı mütləqdir")
                .Length(2, 100)
                .WithMessage("İstifadəçi soyadı 2-100 simvol arasında olmalıdır");

            RuleFor(i => i.Email)
                .NotEmpty()
                .WithMessage("Email mütləqdir")
                .EmailAddress()
                .WithMessage("Email formatı düzgün deyil");

            RuleFor(i => i.Telefon)
                .NotEmpty()
                .WithMessage("Telefon nömrəsi mütləqdir")
                .Matches(@"^\+?[1-9]\d{1,14}$")
                .WithMessage("Telefon nömrəsi düzgün formatda olmalıdır");

            RuleFor(i => i.Sifre)
                .NotEmpty()
                .WithMessage("Şifrə mütləqdir")
                .MinimumLength(6)
                .WithMessage("Şifrə ən azı 6 simvol olmalıdır");

            RuleFor(i => i.IstifadeciAdi)
                .NotEmpty()
                .WithMessage("İstifadəçi adı mütləqdir")
                .Length(3, 50)
                .WithMessage("İstifadəçi adı 3-50 simvol arasında olmalıdır")
                .Matches(@"^[a-zA-Z0-9_]+$")
                .WithMessage("İstifadəçi adı yalnız hərf, rəqəm və _ simvolunu daxil edə bilər");

            RuleFor(i => i.RolId)
                .NotEmpty()
                .WithMessage("Rol seçilməlidir")
                .GreaterThan(0)
                .WithMessage("Rol düzgün seçilməlidir");

            RuleFor(i => i.Maas)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Maaş mənfi ola bilməz")
                .When(i => i.Maas.HasValue);

            RuleFor(i => i.DogumTarixi)
                .LessThan(DateTime.Now.AddYears(-16))
                .WithMessage("İstifadəçi ən azı 16 yaşında olmalıdır")
                .When(i => i.DogumTarixi.HasValue);
        }
    }
}