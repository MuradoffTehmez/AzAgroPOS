using AzAgroPOS.Entities.Domain;
using FluentValidation;
using System;

namespace AzAgroPOS.BLL.Validators
{
    public class IstifadeciValidator : AbstractValidator<Istifadeci>
    {
        public IstifadeciValidator()
        {
            RuleFor(i => i.Ad)
                .NotEmpty()
                .WithMessage("İstifadəçi adı mütləqdir")
                .Length(2, 50)
                .WithMessage("İstifadəçi adı 2-50 simvol arasında olmalıdır");

            RuleFor(i => i.Soyad)
                .NotEmpty()
                .WithMessage("İstifadəçi soyadı mütləqdir")
                .Length(2, 50)
                .WithMessage("İstifadəçi soyadı 2-50 simvol arasında olmalıdır");

            RuleFor(i => i.Email)
                .NotEmpty()
                .WithMessage("Email mütləqdir")
                .EmailAddress()
                .WithMessage("Email formatı düzgün deyil")
                .MaximumLength(100)
                .WithMessage("Email maksimum 100 simvol ola bilər");

            RuleFor(i => i.RolId)
                .NotEmpty()
                .WithMessage("Rol seçilməlidir")
                .GreaterThan(0)
                .WithMessage("Rol düzgün seçilməlidir");

            RuleFor(i => i.Status)
                .NotEmpty()
                .WithMessage("Status mütləqdir")
                .MaximumLength(20)
                .WithMessage("Status maksimum 20 simvol ola bilər");

            RuleFor(i => i.PasswordHash)
                .NotEmpty()
                .WithMessage("Parol hash mütləqdir")
                .When(i => i.PasswordHash != null);

            RuleFor(i => i.PasswordSalt)
                .NotEmpty()
                .WithMessage("Parol salt mütləqdir")
                .When(i => i.PasswordSalt != null);
        }
    }
}