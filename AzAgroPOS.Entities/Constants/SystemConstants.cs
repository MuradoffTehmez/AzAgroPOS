namespace AzAgroPOS.Entities.Constants
{
    /// <summary>
    /// Magic strings aradan qaldırılması üçün sistem sabitləri
    /// AŞAĞI PRİORİTET: Kod təmizliyi və maintainability
    /// </summary>
    public static class SystemConstants
    {
        public static class Status
        {
            public const string Active = "Aktiv";
            public const string Inactive = "Deaktiv";
            public const string Deleted = "Silindi";
        }

        public static class RepairStatus
        {
            public const string Received = "Received";
            public const string InProgress = "InProgress";
            public const string Ready = "Ready";
            public const string Delivered = "Delivered";
            public const string Cancelled = "Cancelled";
        }

        public static class RepairStatusAzerbaijani
        {
            public const string Received = "Qəbul Edildi";
            public const string InProgress = "İşlənir";
            public const string Ready = "Hazır";
            public const string Delivered = "Təhvil Verildi";
            public const string Cancelled = "İptal";
        }

        public static class Priority
        {
            public const string Low = "Low";
            public const string Medium = "Medium";
            public const string High = "High";
            public const string Urgent = "Urgent";
        }

        public static class PriorityAzerbaijani
        {
            public const string Low = "Aşağı";
            public const string Medium = "Orta";
            public const string High = "Yüksək";
            public const string Urgent = "Təcili";
        }

        public static class DebtStatus
        {
            public const string Open = "Açıq";
            public const string PartiallyPaid = "Qismən Ödənilmiş";
            public const string FullyPaid = "Tam Ödənilmiş";
            public const string Overdue = "Gecikmiş";
        }

        public static class Roles
        {
            public const string Administrator = "Administrator";
            public const string Manager = "Manager";
            public const string Worker = "Worker";
            public const string Cashier = "Cashier";
            public const string Accountant = "Accountant";
        }

        public static class StepStatus
        {
            public const string Waiting = "Gözləyir";
            public const string InProgress = "İşlənir";
            public const string Completed = "Bitdi";
            public const string Cancelled = "İptal";
        }

        public static class DatabaseOperations
        {
            public const string Create = "CREATE";
            public const string Read = "READ";
            public const string Update = "UPDATE";
            public const string Delete = "DELETE";
        }

        public static class LogLevels
        {
            public const string Info = "INFO";
            public const string Warning = "WARNING";
            public const string Error = "ERROR";
            public const string Debug = "DEBUG";
        }

        public static class EntityNames
        {
            public const string Musteri = "Musteri";
            public const string Mehsul = "Mehsul";
            public const string Satis = "Satis";
            public const string Istifadeci = "Istifadeci";
            public const string Authentication = "Authentication";
            public const string TamirIsi = "TamirIsi";
            public const string Anbar = "Anbar";
        }

        public static class FileExtensions
        {
            public const string Excel = ".xlsx";
            public const string Pdf = ".pdf";
            public const string Word = ".docx";
            public const string Text = ".txt";
            public const string Csv = ".csv";
            public const string Json = ".json";
        }

        public static class DateFormats
        {
            public const string StandardDate = "yyyy-MM-dd";
            public const string DisplayDate = "dd.MM.yyyy";
            public const string FullDateTime = "yyyy-MM-dd HH:mm:ss";
            public const string TimeOnly = "HH:mm";
        }

        public static class CurrencyFormats
        {
            public const string Azerbaijani = "₼{0:N2}";
            public const string USD = "${0:N2}";
            public const string EUR = "€{0:N2}";
        }

        public static class ValidationMessages
        {
            public const string RequiredField = "Bu sahə mütləqdir";
            public const string InvalidEmail = "Email formatı düzgün deyil";
            public const string InvalidPassword = "Şifrə zəif və ya düzgün deyil";
            public const string InvalidPhoneNumber = "Telefon nömrəsi düzgün deyil";
            public const string InvalidDate = "Tarix formatı düzgün deyil";
            public const string DuplicateEntry = "Bu məlumat artıq mövcuddur";
        }

        public static class UserActions
        {
            public const string Login = "LOGIN";
            public const string Logout = "LOGOUT";
            public const string PasswordReset = "PASSWORD_RESET";
            public const string ProfileUpdate = "PROFILE_UPDATE";
            public const string LoginFailed = "LOGIN_FAILED";
            public const string LoginSuccess = "LOGIN_SUCCESS";
        }

        public static class ApplicationSettings
        {
            public const string DefaultLanguage = "az-AZ";
            public const string DefaultCurrency = "AZN";
            public const string DefaultPageSize = "20";
            public const string MaxFileSize = "10485760"; // 10MB
            public const string SessionTimeout = "30"; // minutes
        }

        public static class ConfigurationKeys
        {
            public const string ConnectionString = "DefaultConnection";
            public const string LoggingLevel = "LoggingLevel";
            public const string EnableAuditing = "EnableAuditing";
            public const string BackupPath = "BackupPath";
            public const string ReportPath = "ReportPath";
        }
    }
}