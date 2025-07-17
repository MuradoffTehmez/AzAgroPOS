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

        /// <summary>
        /// Mərkəzləşdirilmiş İcazə Sistemi - Magic strings-dən imtina
        /// </summary>
        public static class Permissions
        {
            // Admin tam icazələri
            public const string AdminAccess = "Admin.FullAccess";
            public const string SystemSettings = "System.Settings";
            public const string UserManagement = "User.Management";
            public const string RoleManagement = "Role.Management";

            // Müştəri (Customer) İcazələri
            public static class Musteri
            {
                public const string View = "Musteri.Goruntule";
                public const string Create = "Musteri.ElaveEt";
                public const string Edit = "Musteri.RedakteEt";
                public const string Delete = "Musteri.Sil";
                public const string Export = "Musteri.IxracEt";
                public const string ViewDebt = "Musteri.BorcGoruntule";
                public const string ManageDebt = "Musteri.BorcIdareEt";
            }

            // Məhsul (Product) İcazələri
            public static class Mehsul
            {
                public const string View = "Mehsul.Goruntule";
                public const string Create = "Mehsul.ElaveEt";
                public const string Edit = "Mehsul.RedakteEt";
                public const string Delete = "Mehsul.Sil";
                public const string Export = "Mehsul.IxracEt";
                public const string ManageStock = "Mehsul.StokIdareEt";
                public const string ViewPrice = "Mehsul.QiymetGoruntule";
                public const string EditPrice = "Mehsul.QiymetRedakteEt";
            }

            // Satış (Sales) İcazələri
            public static class Satis
            {
                public const string View = "Satis.Goruntule";
                public const string Create = "Satis.ElaveEt";
                public const string Edit = "Satis.RedakteEt";
                public const string Delete = "Satis.Sil";
                public const string Cancel = "Satis.IptalEt";
                public const string Refund = "Satis.GeriQaytar";
                public const string ViewReports = "Satis.HesabatGoruntule";
                public const string Export = "Satis.IxracEt";
            }

            // Anbar (Warehouse) İcazələri
            public static class Anbar
            {
                public const string View = "Anbar.Goruntule";
                public const string Create = "Anbar.ElaveEt";
                public const string Edit = "Anbar.RedakteEt";
                public const string Delete = "Anbar.Sil";
                public const string ManageStock = "Anbar.StokIdareEt";
                public const string StockTransfer = "Anbar.StokTransfer";
                public const string ViewMovements = "Anbar.HereketGoruntule";
                public const string StockReport = "Anbar.StokHesabati";
            }

            // Tədarükçü (Supplier) İcazələri
            public static class Tedarukcu
            {
                public const string View = "Tedarukcu.Goruntule";
                public const string Create = "Tedarukcu.ElaveEt";
                public const string Edit = "Tedarukcu.RedakteEt";
                public const string Delete = "Tedarukcu.Sil";
                public const string ViewPayments = "Tedarukcu.OdemeGoruntule";
                public const string ManagePayments = "Tedarukcu.OdemeIdareEt";
            }

            // Alış (Purchase) İcazələri
            public static class Alis
            {
                public const string View = "Alis.Goruntule";
                public const string Create = "Alis.ElaveEt";
                public const string Edit = "Alis.RedakteEt";
                public const string Delete = "Alis.Sil";
                public const string Approve = "Alis.TesdiqEt";
                public const string ViewReports = "Alis.HesabatGoruntule";
                public const string CreateOrder = "Alis.SifarisYarat";
                public const string ManageInvoice = "Alis.SenedIdareEt";
            }

            // Tamir (Repair) İcazələri
            public static class Tamir
            {
                public const string View = "Tamir.Goruntule";
                public const string Create = "Tamir.ElaveEt";
                public const string Edit = "Tamir.RedakteEt";
                public const string Delete = "Tamir.Sil";
                public const string ChangeStatus = "Tamir.StatusDeyis";
                public const string AssignWorker = "Tamir.IsciTeyinEt";
                public const string ViewHistory = "Tamir.TarixceGoruntule";
                public const string Analytics = "Tamir.Analitika";
            }

            // İstifadəçi (User) İcazələri
            public static class Istifadeci
            {
                public const string View = "Istifadeci.Goruntule";
                public const string Create = "Istifadeci.ElaveEt";
                public const string Edit = "Istifadeci.RedakteEt";
                public const string Delete = "Istifadeci.Sil";
                public const string ChangePassword = "Istifadeci.SifreDeyi";
                public const string ViewActivity = "Istifadeci.FealiyyetGoruntule";
                public const string ManagePermissions = "Istifadeci.IcazeIdareEt";
            }

            // Hesabat (Reports) İcazələri
            public static class Hesabat
            {
                public const string ViewSales = "Hesabat.SatisGoruntule";
                public const string ViewFinancial = "Hesabat.MaliGoruntule";
                public const string ViewInventory = "Hesabat.InventarGoruntule";
                public const string ViewCustomer = "Hesabat.MusteriGoruntule";
                public const string Export = "Hesabat.IxracEt";
                public const string Print = "Hesabat.Cap";
                public const string Schedule = "Hesabat.Planla";
            }

            // Mali (Financial) İcazələri
            public static class Mali
            {
                public const string ViewCashFlow = "Mali.PulAxiniGoruntule";
                public const string ManageCashFlow = "Mali.PulAxiniIdareEt";
                public const string ViewExpenses = "Mali.XercGoruntule";
                public const string ManageExpenses = "Mali.XercIdareEt";
                public const string ViewProfitLoss = "Mali.MenfeetZererGoruntule";
                public const string ViewTaxes = "Mali.VergiGoruntule";
                public const string ManageTaxes = "Mali.VergiIdareEt";
            }

            // Sistem (System) İcazələri
            public static class Sistem
            {
                public const string ViewLogs = "Sistem.LogGoruntule";
                public const string ManageBackup = "Sistem.BackupIdareEt";
                public const string ManageSettings = "Sistem.AyarIdareEt";
                public const string ViewSystemInfo = "Sistem.InfoGoruntule";
                public const string ManageDatabase = "Sistem.VebaseIdareEt";
                public const string ManagePrinters = "Sistem.PrinterIdareEt";
            }

            // Printer və Çap İcazələri
            public static class Printer
            {
                public const string View = "Printer.Goruntule";
                public const string Configure = "Printer.Konfiqure";
                public const string Test = "Printer.Test";
                public const string ViewLogs = "Printer.LogGoruntule";
                public const string ManageLogs = "Printer.LogIdareEt";
            }
        }
    }
}