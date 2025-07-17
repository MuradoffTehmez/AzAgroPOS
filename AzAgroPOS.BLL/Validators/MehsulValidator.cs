using AzAgroPOS.Entities.Domain;
using FluentValidation;

namespace AzAgroPOS.BLL.Validators
{
    public class MehsulValidator : AbstractValidator<Mehsul>
    {
        public MehsulValidator()
        {
            RuleFor(m => m.Ad)
                .NotEmpty()
                .WithMessage("Məhsul adı mütləqdir")
                .Length(2, 200)
                .WithMessage("Məhsul adı 2-200 simvol arasında olmalıdır");

            RuleFor(m => m.SKU)
                .NotEmpty()
                .WithMessage("SKU mütləqdir")
                .Length(2, 50)
                .WithMessage("SKU 2-50 simvol arasında olmalıdır");

            RuleFor(m => m.Barkod)
                .NotEmpty()
                .WithMessage("Barkod mütləqdir")
                .Length(8, 50)
                .WithMessage("Barkod 8-50 simvol arasında olmalıdır");

            RuleFor(m => m.AlisQiymeti)
                .GreaterThan(0)
                .WithMessage("Alış qiyməti 0-dan böyük olmalıdır");

            RuleFor(m => m.SatisQiymeti)
                .GreaterThan(0)
                .WithMessage("Satış qiyməti 0-dan böyük olmalıdır");

            RuleFor(m => m.SatisQiymeti)
                .GreaterThanOrEqualTo(m => m.AlisQiymeti)
                .WithMessage("Satış qiyməti alış qiymətindən az ola bilməz");

            RuleFor(m => m.MovcudMiqdar)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Mövcud miqdar mənfi ola bilməz");

            RuleFor(m => m.MinimumMiqdar)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Minimum miqdar mənfi ola bilməz");

            RuleFor(m => m.KateqoriyaId)
                .NotEmpty()
                .WithMessage("Kateqoriya seçilməlidir")
                .GreaterThan(0)
                .WithMessage("Kateqoriya düzgün seçilməlidir");

            RuleFor(m => m.VahidId)
                .NotEmpty()
                .WithMessage("Vahid seçilməlidir")
                .GreaterThan(0)
                .WithMessage("Vahid düzgün seçilməlidir");

            RuleFor(m => m.Tesvir)
                .MaximumLength(1000)
                .WithMessage("Təsvir 1000 simvoldan çox ola bilməz")
                .When(m => !string.IsNullOrEmpty(m.Tesvir));
        }
    }
}