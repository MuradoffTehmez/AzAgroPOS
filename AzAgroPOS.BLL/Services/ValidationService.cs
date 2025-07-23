using AzAgroPOS.BLL.Interfaces;
using AzAgroPOS.Entities.Constants;
using AzAgroPOS.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AzAgroPOS.BLL.Services
{
    /// <summary>
    /// Məlumatların yoxlanılmasının (Validation) mərkəzləşdirilməsi
    /// ZƏİFLİK: Məlumatların Yoxlanılmasının Mərkəzləşdirilməməsi problemini həll edir
    /// </summary>
    public class ValidationService : IDisposable
    {
        private readonly ILoggerService _logger;
        private bool _disposed = false;

        public ValidationService(ILoggerService logger = null)
        {
            _logger = logger;
        }

        #region Müştəri Validasiyası

        /// <summary>
        /// Müştəri məlumatlarını yoxlayır
        /// </summary>
        /// <param name="musteri">Müştəri obyekti</param>
        /// <returns>Validasiya nəticəsi</returns>
        // FluentValidation istifadə olunduğu üçün bu metod artıq lazım deyil və silinir
        // public ValidationResult ValidateMusteri(Musteri musteri)
        // {
        //     ...
        // }

        #endregion

        #region Məhsul Validasiyası

        /// <summary>
        /// Məhsul məlumatlarını yoxlayır
        /// </summary>
        /// <param name="mehsul">Məhsul obyekti</param>
        /// <returns>Validasiya nəticəsi</returns>
        public ValidationResult ValidateMehsul(Mehsul mehsul)
        {
            var result = new ValidationResult { IsValid = true };
            var errors = new List<string>();

            try
            {
                if (mehsul == null)
                {
                    result.IsValid = false;
                    result.ErrorMessage = "Məhsul məlumatları boş ola bilməz";
                    return result;
                }

                // Ad yoxlaması
                if (string.IsNullOrWhiteSpace(mehsul.Ad))
                {
                    errors.Add("Məhsul adı mütləqdir");
                }
                else if (mehsul.Ad.Length < 2)
                {
                    errors.Add("Məhsul adı minimum 2 simvoldan ibarət olmalıdır");
                }
                else if (mehsul.Ad.Length > 200)
                {
                    errors.Add("Məhsul adı maksimum 200 simvoldan ibarət ola bilər");
                }

                // SKU yoxlaması
                if (string.IsNullOrWhiteSpace(mehsul.SKU))
                {
                    errors.Add("Məhsul SKU kodu mütləqdir");
                }
                else if (mehsul.SKU.Length > 50)
                {
                    errors.Add("Məhsul SKU kodu maksimum 50 simvoldan ibarət ola bilər");
                }

                // Qiymət yoxlaması
                if (mehsul.SatisQiymeti <= 0)
                {
                    errors.Add("Satış qiyməti 0-dan böyük olmalıdır");
                }

                if (mehsul.AlisQiymeti < 0)
                {
                    errors.Add("Alış qiyməti mənfi ola bilməz");
                }

                if (mehsul.AlisQiymeti > mehsul.SatisQiymeti)
                {
                    errors.Add("Alış qiyməti satış qiymətindən böyük ola bilməz");
                }

                // Stok yoxlaması
                if (mehsul.MovcudMiqdar < 0)
                {
                    errors.Add("Mövcud miqdar mənfi ola bilməz");
                }

                if (mehsul.MinimumMiqdar < 0)
                {
                    errors.Add("Minimum miqdar mənfi ola bilməz");
                }

                // Kateqoriya yoxlaması
                if (mehsul.KateqoriyaId <= 0)
                {
                    errors.Add("Kateqoriya ID-si düzgün deyil");
                }

                // Vahid yoxlaması
                if (mehsul.VahidId <= 0)
                {
                    errors.Add("Vahid ID-si düzgün deyil");
                }

                if (errors.Any())
                {
                    result.IsValid = false;
                    result.ErrorMessage = string.Join("; ", errors);
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger?.LogError(new Exception("Məhsul validasiya xətası", ex));
                result.IsValid = false;
                result.ErrorMessage = "Validasiya zamanı xəta baş verdi";
                return result;
            }
        }

        #endregion

        #region İstifadəçi Validasiyası

        /// <summary>
        /// İstifadəçi məlumatlarını yoxlayır
        /// </summary>
        /// <param name="istifadeci">İstifadəçi obyekti</param>
        /// <returns>Validasiya nəticəsi</returns>
        public ValidationResult ValidateIstifadeci(Istifadeci istifadeci)
        {
            var result = new ValidationResult { IsValid = true };
            var errors = new List<string>();

            try
            {
                if (istifadeci == null)
                {
                    result.IsValid = false;
                    result.ErrorMessage = "İstifadəçi məlumatları boş ola bilməz";
                    return result;
                }

                // Ad yoxlaması
                if (string.IsNullOrWhiteSpace(istifadeci.Ad))
                {
                    errors.Add("İstifadəçi adı mütləqdir");
                }
                else if (istifadeci.Ad.Length < 2)
                {
                    errors.Add("İstifadəçi adı minimum 2 simvoldan ibarət olmalıdır");
                }
                else if (istifadeci.Ad.Length > 50)
                {
                    errors.Add("İstifadəçi adı maksimum 50 simvoldan ibarət ola bilər");
                }

                // Soyad yoxlaması
                if (string.IsNullOrWhiteSpace(istifadeci.Soyad))
                {
                    errors.Add("İstifadəçi soyadı mütləqdir");
                }
                else if (istifadeci.Soyad.Length < 2)
                {
                    errors.Add("İstifadəçi soyadı minimum 2 simvoldan ibarət olmalıdır");
                }
                else if (istifadeci.Soyad.Length > 50)
                {
                    errors.Add("İstifadəçi soyadı maksimum 50 simvoldan ibarət ola bilər");
                }

                // Email yoxlaması
                if (string.IsNullOrWhiteSpace(istifadeci.Email))
                {
                    errors.Add("Email mütləqdir");
                }
                else
                {
                    var emailValidation = ValidateEmail(istifadeci.Email);
                    if (!emailValidation.IsValid)
                    {
                        errors.Add(emailValidation.ErrorMessage);
                    }
                }

                // Rol yoxlaması
                if (!istifadeci.RolId.HasValue || istifadeci.RolId.Value <= 0)
                {
                    errors.Add("Rol seçimi mütləqdir");
                }

                // Status yoxlaması
                if (string.IsNullOrWhiteSpace(istifadeci.Status))
                {
                    errors.Add("Status mütləqdir");
                }
                else if (!IsValidStatus(istifadeci.Status))
                {
                    errors.Add("Status düzgün deyil");
                }

                if (errors.Any())
                {
                    result.IsValid = false;
                    result.ErrorMessage = string.Join("; ", errors);
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger?.LogError(new Exception("İstifadəçi validasiya xətası", ex));
                result.IsValid = false;
                result.ErrorMessage = "Validasiya zamanı xəta baş verdi";
                return result;
            }
        }

        #endregion

        #region Satış Validasiyası

        /// <summary>
        /// Satış məlumatlarını yoxlayır
        /// </summary>
        /// <param name="satis">Satış obyekti</param>
        /// <param name="satisDetallari">Satış detalları</param>
        /// <returns>Validasiya nəticəsi</returns>
        public ValidationResult ValidateSatis(Satis satis, List<SatisDetali> satisDetallari)
        {
            var result = new ValidationResult { IsValid = true };
            var errors = new List<string>();

            try
            {
                if (satis == null)
                {
                    result.IsValid = false;
                    result.ErrorMessage = "Satış məlumatları boş ola bilməz";
                    return result;
                }

                // Satış tarixi yoxlaması
                if (satis.SatisTarixi == default(DateTime))
                {
                    errors.Add("Satış tarixi mütləqdir");
                }
                else if (satis.SatisTarixi > DateTime.Now)
                {
                    errors.Add("Satış tarixi gələcəkdə ola bilməz");
                }

                // Ödəmə növü yoxlaması
                if (string.IsNullOrWhiteSpace(satis.OdemeNovu))
                {
                    errors.Add("Ödəmə növü mütləqdir");
                }
                else if (!IsValidPaymentType(satis.OdemeNovu))
                {
                    errors.Add("Ödəmə növü düzgün deyil");
                }

                // Satış detalları yoxlaması
                if (satisDetallari == null || !satisDetallari.Any())
                {
                    errors.Add("Satış detalları boş ola bilməz");
                }
                else
                {
                    foreach (var detal in satisDetallari)
                    {
                        var detailValidation = ValidateSatisDetali(detal);
                        if (!detailValidation.IsValid)
                        {
                            errors.Add($"Satış detalı xətası: {detailValidation.ErrorMessage}");
                        }
                    }
                }

                // Ümumi məbləğ yoxlaması
                if (satis.UmumiMebleg < 0)
                {
                    errors.Add("Ümumi məbləğ mənfi ola bilməz");
                }

                if (errors.Any())
                {
                    result.IsValid = false;
                    result.ErrorMessage = string.Join("; ", errors);
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger?.LogError(new Exception("Satış validasiya xətası", ex));
                result.IsValid = false;
                result.ErrorMessage = "Validasiya zamanı xəta baş verdi";
                return result;
            }
        }

        /// <summary>
        /// Satış detalını yoxlayır
        /// </summary>
        /// <param name="detal">Satış detalı</param>
        /// <returns>Validasiya nəticəsi</returns>
        public ValidationResult ValidateSatisDetali(SatisDetali detal)
        {
            var result = new ValidationResult { IsValid = true };
            var errors = new List<string>();

            try
            {
                if (detal == null)
                {
                    result.IsValid = false;
                    result.ErrorMessage = "Satış detalı boş ola bilməz";
                    return result;
                }

                // Məhsul ID yoxlaması
                if (detal.MehsulId <= 0)
                {
                    errors.Add("Məhsul ID-si düzgün deyil");
                }

                // Miqdar yoxlaması
                if (detal.Miqdar <= 0)
                {
                    errors.Add("Miqdar 0-dan böyük olmalıdır");
                }

                // Qiymət yoxlaması
                if (detal.VahidQiymeti <= 0)
                {
                    errors.Add("Vahid qiyməti 0-dan böyük olmalıdır");
                }

                if (errors.Any())
                {
                    result.IsValid = false;
                    result.ErrorMessage = string.Join("; ", errors);
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger?.LogError(new Exception("Satış detalı validasiya xətası", ex));
                result.IsValid = false;
                result.ErrorMessage = "Validasiya zamanı xəta baş verdi";
                return result;
            }
        }

        #endregion

        #region Ümumi Validasiya Metodları

        /// <summary>
        /// Email formatını yoxlayır
        /// </summary>
        /// <param name="email">Email ünvanı</param>
        /// <returns>Validasiya nəticəsi</returns>
        public ValidationResult ValidateEmail(string email)
        {
            var result = new ValidationResult { IsValid = true };

            if (string.IsNullOrWhiteSpace(email))
            {
                result.IsValid = false;
                result.ErrorMessage = SystemConstants.ValidationMessages.RequiredField;
                return result;
            }

            if (email.Length > 100)
            {
                result.IsValid = false;
                result.ErrorMessage = "Email maksimum 100 simvoldan ibarət ola bilər";
                return result;
            }

            var emailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            if (!emailRegex.IsMatch(email))
            {
                result.IsValid = false;
                result.ErrorMessage = SystemConstants.ValidationMessages.InvalidEmail;
                return result;
            }

            return result;
        }

        /// <summary>
        /// Telefon nömrəsini yoxlayır
        /// </summary>
        /// <param name="phoneNumber">Telefon nömrəsi</param>
        /// <returns>Validasiya nəticəsi</returns>
        public ValidationResult ValidatePhoneNumber(string phoneNumber)
        {
            var result = new ValidationResult { IsValid = true };

            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                result.IsValid = false;
                result.ErrorMessage = SystemConstants.ValidationMessages.RequiredField;
                return result;
            }

            // Azərbaycan telefon nömrəsi formatı
            var phoneRegex = new Regex(@"^(\+994|0)?(50|51|55|70|60|77|99|10|12)\d{7}$");
            if (!phoneRegex.IsMatch(phoneNumber.Replace(" ", "").Replace("-", "")))
            {
                result.IsValid = false;
                result.ErrorMessage = SystemConstants.ValidationMessages.InvalidPhoneNumber;
                return result;
            }

            return result;
        }

        /// <summary>
        /// Tarix formatını yoxlayır
        /// </summary>
        /// <param name="date">Tarix</param>
        /// <param name="allowFuture">Gələcək tarixə icazə verilsin</param>
        /// <returns>Validasiya nəticəsi</returns>
        public ValidationResult ValidateDate(DateTime date, bool allowFuture = false)
        {
            var result = new ValidationResult { IsValid = true };

            if (date == default(DateTime))
            {
                result.IsValid = false;
                result.ErrorMessage = SystemConstants.ValidationMessages.InvalidDate;
                return result;
            }

            if (!allowFuture && date > DateTime.Now)
            {
                result.IsValid = false;
                result.ErrorMessage = "Tarix gələcəkdə ola bilməz";
                return result;
            }

            if (date < new DateTime(1900, 1, 1))
            {
                result.IsValid = false;
                result.ErrorMessage = "Tarix çox köhnədir";
                return result;
            }

            return result;
        }

        /// <summary>
        /// Status-un düzgünlüyünü yoxlayır
        /// </summary>
        /// <param name="status">Status</param>
        /// <returns>Düzgündürsə true</returns>
        private bool IsValidStatus(string status)
        {
            return status == SystemConstants.Status.Active ||
                   status == SystemConstants.Status.Inactive ||
                   status == SystemConstants.Status.Deleted;
        }

        /// <summary>
        /// Ödəmə növünün düzgünlüyünü yoxlayır
        /// </summary>
        /// <param name="paymentType">Ödəmə növü</param>
        /// <returns>Düzgündürsə true</returns>
        private bool IsValidPaymentType(string paymentType)
        {
            var validTypes = new[] { "Nağd", "Kart", "Köçürmə", "Çek", "Borc" };
            return validTypes.Contains(paymentType);
        }

        #endregion

        #region IDisposable Implementation

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Managed resources
                    _logger?.LogInfo("ValidationService disposed");
                }
                _disposed = true;
            }
        }

        #endregion
    }
}