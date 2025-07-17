using AzAgroPOS.DAL.Interfaces;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.Entities.Constants;
using AzAgroPOS.BLL.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.BLL.Services
{
    /// <summary>
    /// Verilənlər bazasının təhlükəsiz şifrə formatına keçirilməsi üçün migration servisi
    /// KRİTİK TƏHLÜKƏSİZLİK PROBLEMİ #1-in həlli - Köhnə şifrələrin migrate edilməsi
    /// </summary>
    public class DatabaseMigrationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerService _logger;
        private readonly PasswordSecurityService _passwordSecurityService;

        public DatabaseMigrationService(IUnitOfWork unitOfWork, ILoggerService logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _passwordSecurityService = new PasswordSecurityService();
        }

        /// <summary>
        /// Köhnə şifrə formatındakı istifadəçiləri təhlükəsiz formata keçirir
        /// XƏBƏRDARLIQ: Bu metod yalnız bir dəfə çağrılmalıdır!
        /// </summary>
        /// <returns>Migration nəticəsi</returns>
        public async Task<MigrationResult> MigratePasswordsToSecureFormatAsync()
        {
            var result = new MigrationResult();
            
            try
            {
                _logger.LogInfo("=== Password Security Migration Started ===");

                // BCrypt.Net package-dən istifadə edərək köhnə şifrələri müvəqqəti olaraq doğrula
                var allUsers = _unitOfWork.Istifadeciler.GetAll().ToList();
                
                foreach (var user in allUsers)
                {
                    // Əgər artıq yeni formatda hash və salt varsa, skip et
                    if (user.PasswordHash != null && user.PasswordSalt != null)
                    {
                        result.AlreadyMigrated++;
                        continue;
                    }

                    // Köhnə sistemdə default şifrə yaradırıq
                    // BU YALNIZ MİGRATİON ÜÇÜN - İSTEHSAL MÜHITINDƏ REAL ŞİFRƏLƏR OLACAQ
                    string defaultPassword = GenerateDefaultPassword(user);
                    
                    // Yeni təhlükəsiz format
                    _passwordSecurityService.CreatePasswordHash(defaultPassword, out byte[] passwordHash, out byte[] passwordSalt);
                    
                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                    user.SonParolDeyismeTarixi = DateTime.Now;
                    user.Status = SystemConstants.Status.Active; // Aktiv et
                    
                    // Köhnə ParolHash sahəsini null et (əgər mövcuddursa)
                    // user.ParolHash = null; // Bu sahə artıq silinəcək
                    
                    _unitOfWork.Istifadeciler.Update(user);
                    result.SuccessfulMigrations++;
                    
                    _logger.LogInfo($"İstifadəçi migrate edildi: {user.Email} - Default şifrə: {defaultPassword}");
                }

                await _unitOfWork.CompleteAsync();
                
                result.IsSuccess = true;
                result.Message = $"Migration tamamlandı. {result.SuccessfulMigrations} istifadəçi migrate edildi, {result.AlreadyMigrated} istifadəçi artıq migrate edilmişdi.";
                
                _logger.LogInfo("=== Password Security Migration Completed Successfully ===");
                _logger.LogInfo(result.Message);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Migration zamanı xəta: {ex.Message}";
                result.Exception = ex;
                
                _logger.LogError("Password migration xətası", ex);
            }

            return result;
        }

        /// <summary>
        /// İstifadəçi üçün default şifrə yaradır
        /// BU YALNIZ MİGRATİON ÜÇÜN - İSTEHSAL MÜHITINDƏ DƏYIŞDIRILMƏLIDIR
        /// </summary>
        /// <param name="user">İstifadəçi</param>
        /// <returns>Default şifrə</returns>
        private string GenerateDefaultPassword(Istifadeci user)
        {
            // Təhlükəsiz default şifrə yaradırıq
            var baseName = user.Ad?.ToLower().Replace(" ", "") ?? "user";
            var year = DateTime.Now.Year;
            
            // Nümunə: ali2024! (Real mühitdə daha mürəkkəb olmalıdır)
            return $"{baseName}{year}!";
        }

        /// <summary>
        /// Şifrə migration-un statusunu yoxlayır
        /// </summary>
        /// <returns>Migration vəziyyəti</returns>
        public MigrationStatus CheckMigrationStatus()
        {
            try
            {
                var allUsers = _unitOfWork.Istifadeciler.GetAll();
                var totalUsers = allUsers.Count();
                var migratedUsers = allUsers.Count(u => u.PasswordHash != null && u.PasswordSalt != null);
                var oldFormatUsers = totalUsers - migratedUsers;

                return new MigrationStatus
                {
                    TotalUsers = totalUsers,
                    MigratedUsers = migratedUsers,
                    OldFormatUsers = oldFormatUsers,
                    IsMigrationComplete = oldFormatUsers == 0,
                    MigrationPercentage = totalUsers > 0 ? (double)migratedUsers / totalUsers * 100 : 0
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Migration status yoxlama xətası", ex);
                return new MigrationStatus
                {
                    TotalUsers = 0,
                    MigratedUsers = 0,
                    OldFormatUsers = 0,
                    IsMigrationComplete = false,
                    MigrationPercentage = 0,
                    Error = ex.Message
                };
            }
        }
    }

    /// <summary>
    /// Migration nəticəsi
    /// </summary>
    public class MigrationResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int SuccessfulMigrations { get; set; }
        public int AlreadyMigrated { get; set; }
        public Exception Exception { get; set; }
    }

    /// <summary>
    /// Migration statusu
    /// </summary>
    public class MigrationStatus
    {
        public int TotalUsers { get; set; }
        public int MigratedUsers { get; set; }
        public int OldFormatUsers { get; set; }
        public bool IsMigrationComplete { get; set; }
        public double MigrationPercentage { get; set; }
        public string Error { get; set; }
    }
}