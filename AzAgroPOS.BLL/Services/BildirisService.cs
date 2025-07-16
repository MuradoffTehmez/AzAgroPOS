using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Media;

namespace AzAgroPOS.BLL.Services
{
    public class BildirisService : IDisposable
    {
        private readonly BildirisRepository _notificationRepository;
        private readonly BildirisAyariRepository _settingsRepository;
        private readonly IstifadeciRepository _userRepository;

        // Events for real-time notifications
        public event Action<Bildiris> NotificationCreated;
        public event Action<int, int> NotificationRead;
        public event Action<int> UserNotificationsCleared;

        public BildirisService()
        {
            _notificationRepository = new BildirisRepository();
            _settingsRepository = new BildirisAyariRepository();
            _userRepository = new IstifadeciRepository();
        }

        #region Notification Management

        public async Task<Bildiris> SendNotificationAsync(
            string title,
            string message,
            string notificationType = null,
            string priority = null,
            string moduleName = null,
            int? targetUserId = null,
            int? senderUserId = null,
            string action = null,
            string actionParameters = null,
            DateTime? expirationDate = null)
        {
            var notification = new Bildiris
            {
                Basliq = title,
                Mesaj = message,
                BildirisNovu = notificationType ?? Bildiris.BildirisNovleri.Melumat,
                Prioritet = priority ?? Bildiris.BildirisPrioritetleri.Orta,
                MenbeModulAdi = moduleName ?? Bildiris.BildirisModulleri.Sistem,
                HedefIstifadeciId = targetUserId,
                GonderenIstifadeciId = senderUserId,
                Emeliyyat = action,
                EmeliyyatParametrleri = actionParameters,
                SonGecerlilikTarixi = expirationDate,
                GonderimeTarixi = DateTime.Now
            };

            var createdNotification = await _notificationRepository.AddAsync(notification);

            // Process notification delivery
            await ProcessNotificationDeliveryAsync(createdNotification);

            // Trigger real-time event
            NotificationCreated?.Invoke(createdNotification);

            return createdNotification;
        }

        public async Task<Bildiris> SendSystemNotificationAsync(string title, string message, string priority = null)
        {
            return await SendNotificationAsync(
                title, 
                message, 
                Bildiris.BildirisNovleri.Sistem, 
                priority ?? Bildiris.BildirisPrioritetleri.Orta,
                Bildiris.BildirisModulleri.Sistem);
        }

        public async Task<Bildiris> SendErrorNotificationAsync(string title, string message, string moduleName = null)
        {
            return await SendNotificationAsync(
                title, 
                message, 
                Bildiris.BildirisNovleri.Xeta, 
                Bildiris.BildirisPrioritetleri.Yuksek,
                moduleName ?? Bildiris.BildirisModulleri.Sistem);
        }

        public async Task<Bildiris> SendWarningNotificationAsync(string title, string message, string moduleName = null)
        {
            return await SendNotificationAsync(
                title, 
                message, 
                Bildiris.BildirisNovleri.Xeberdarliq, 
                Bildiris.BildirisPrioritetleri.Orta,
                moduleName ?? Bildiris.BildirisModulleri.Sistem);
        }

        public async Task<Bildiris> SendSuccessNotificationAsync(string title, string message, string moduleName = null)
        {
            return await SendNotificationAsync(
                title, 
                message, 
                Bildiris.BildirisNovleri.Ugur, 
                Bildiris.BildirisPrioritetleri.Asagi,
                moduleName ?? Bildiris.BildirisModulleri.Sistem);
        }

        private async Task ProcessNotificationDeliveryAsync(Bildiris notification)
        {
            // Get relevant notification settings
            IEnumerable<BildirisAyari> relevantSettings;
            
            if (notification.HedefIstifadeciId.HasValue)
            {
                // Personal notification
                var userSettings = await _settingsRepository.GetByUserIdAsync(notification.HedefIstifadeciId.Value);
                relevantSettings = userSettings.Where(s => s.ModulAdi == notification.MenbeModulAdi && 
                                                         s.BildirisNovu == notification.BildirisNovu);
            }
            else
            {
                // Global notification
                relevantSettings = await _settingsRepository.GetSettingsForNotificationAsync(
                    notification.MenbeModulAdi, notification.BildirisNovu);
            }

            foreach (var setting in relevantSettings)
            {
                // Check if notification should be delivered based on settings
                if (!setting.BildirisFiltrKecer(notification.Mesaj, notification.Prioritet))
                    continue;

                if (!setting.HazirdaAktiv)
                    continue;

                // Send email notification if enabled
                if (setting.EmailBildirimi)
                {
                    await SendEmailNotificationAsync(notification, setting);
                }

                // Play sound if enabled
                if (setting.SesliSiqnal)
                {
                    PlayNotificationSound(setting.SesliSiqnalFayli);
                }

                // Desktop notification would be handled by the UI layer
            }
        }

        #endregion

        #region Notification Retrieval

        public async Task<IEnumerable<Bildiris>> GetUserNotificationsAsync(int userId, bool unreadOnly = false)
        {
            if (unreadOnly)
                return await _notificationRepository.GetUnreadByUserIdAsync(userId);
            else
                return await _notificationRepository.GetByUserIdAsync(userId);
        }

        public async Task<int> GetUnreadCountAsync(int userId)
        {
            return await _notificationRepository.GetUnreadCountByUserIdAsync(userId);
        }

        public async Task<IEnumerable<Bildiris>> GetRecentNotificationsAsync(int userId, int count = 10)
        {
            return await _notificationRepository.GetRecentNotificationsAsync(userId, count);
        }

        public async Task<Bildiris> GetNotificationByIdAsync(int id)
        {
            return await _notificationRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Bildiris>> GetNotificationsByTypeAsync(string notificationType)
        {
            return await _notificationRepository.GetByTypeAsync(notificationType);
        }

        public async Task<IEnumerable<Bildiris>> GetNotificationsByModuleAsync(string moduleName)
        {
            return await _notificationRepository.GetByModuleAsync(moduleName);
        }

        public async Task<IEnumerable<Bildiris>> SearchNotificationsAsync(string searchTerm, int? userId = null)
        {
            return await _notificationRepository.SearchAsync(searchTerm, userId);
        }

        #endregion

        #region Notification Actions

        public async Task<bool> MarkAsReadAsync(int notificationId, int userId)
        {
            var result = await _notificationRepository.MarkAsReadAsync(notificationId, userId);
            if (result)
            {
                NotificationRead?.Invoke(notificationId, userId);
            }
            return result;
        }

        public async Task<bool> MarkAsUnreadAsync(int notificationId, int userId)
        {
            return await _notificationRepository.MarkAsUnreadAsync(notificationId, userId);
        }

        public async Task<int> MarkAllAsReadAsync(int userId)
        {
            var count = await _notificationRepository.MarkAllAsReadAsync(userId);
            if (count > 0)
            {
                UserNotificationsCleared?.Invoke(userId);
            }
            return count;
        }

        public async Task DeleteNotificationAsync(int notificationId)
        {
            await _notificationRepository.DeleteAsync(notificationId);
        }

        #endregion

        #region Settings Management

        public async Task<IEnumerable<BildirisAyari>> GetUserSettingsAsync(int userId)
        {
            return await _settingsRepository.GetByUserIdAsync(userId);
        }

        public async Task<BildirisAyari> GetUserSettingAsync(int userId, string moduleName, string notificationType)
        {
            return await _settingsRepository.GetByUserAndModuleAsync(userId, moduleName, notificationType);
        }

        public async Task<BildirisAyari> UpdateUserSettingAsync(int userId, string moduleName, string notificationType, BildirisAyari settings)
        {
            return await _settingsRepository.CreateOrUpdateSettingAsync(userId, moduleName, notificationType, settings);
        }

        public async Task<bool> SetDefaultSettingsAsync(int userId)
        {
            return await _settingsRepository.SetDefaultsForUserAsync(userId);
        }

        public async Task<bool> EnableNotificationsAsync(int userId, string moduleName, string notificationType)
        {
            return await _settingsRepository.EnableNotificationsForUserAsync(userId, moduleName, notificationType);
        }

        public async Task<bool> DisableNotificationsAsync(int userId, string moduleName, string notificationType)
        {
            return await _settingsRepository.DisableNotificationsForUserAsync(userId, moduleName, notificationType);
        }

        #endregion

        #region Background Tasks

        public async Task ProcessAutoReadNotificationsAsync()
        {
            await _notificationRepository.ProcessAutoReadNotificationsAsync();
        }

        public async Task CleanupOldNotificationsAsync()
        {
            var userSettings = await _settingsRepository.GetAllAsync();
            var distinctCleanupDays = userSettings.Where(s => s.OtomatikSil)
                                                 .Select(s => s.OtomatikSilmeGunu)
                                                 .Distinct();

            foreach (var days in distinctCleanupDays)
            {
                await _notificationRepository.DeleteOldNotificationsAsync(days);
            }
        }

        #endregion

        #region Email Notifications

        private async Task SendEmailNotificationAsync(Bildiris notification, BildirisAyari setting)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(setting.IstifadeciId);
                if (user == null || string.IsNullOrEmpty(user.Email))
                    return;

                using (var client = new SmtpClient())
                {
                    // Email configuration would come from system settings
                    client.Host = "smtp.gmail.com"; // This should be configurable
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("noreply@azagropos.com", "password"); // This should be configurable

                    var mail = new MailMessage
                    {
                        From = new MailAddress("noreply@azagropos.com", "AzAgroPOS Sistemi"),
                        Subject = $"[AzAgroPOS] {notification.Basliq}",
                        Body = GenerateEmailBody(notification),
                        IsBodyHtml = true
                    };

                    mail.To.Add(user.Email);
                    
                    await client.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                // Log email sending error
                Console.WriteLine($"Email göndərmə xətası: {ex.Message}");
            }
        }

        private string GenerateEmailBody(Bildiris notification)
        {
            return $@"
                <html>
                <body style='font-family: Arial, sans-serif;'>
                    <div style='max-width: 600px; margin: 0 auto; padding: 20px;'>
                        <div style='background-color: {notification.BildirisRengi}; color: white; padding: 15px; text-align: center;'>
                            <h2>{notification.Basliq}</h2>
                        </div>
                        <div style='background-color: #f9f9f9; padding: 20px; border: 1px solid #ddd;'>
                            <p><strong>Modul:</strong> {notification.MenbeModulAdi}</p>
                            <p><strong>Tip:</strong> {notification.BildirisNovu}</p>
                            <p><strong>Prioritet:</strong> {notification.Prioritet}</p>
                            <p><strong>Tarix:</strong> {notification.GonderimeTarixi:dd.MM.yyyy HH:mm}</p>
                            <hr>
                            <div style='line-height: 1.6;'>
                                {notification.Mesaj}
                            </div>
                        </div>
                        <div style='text-align: center; padding: 15px; font-size: 12px; color: #666;'>
                            Bu bildiriş AzAgroPOS sistemi tərəfindən avtomatik göndərilmişdir.
                        </div>
                    </div>
                </body>
                </html>";
        }

        #endregion

        #region Sound Notifications

        private void PlayNotificationSound(string soundFile = null)
        {
            try
            {
                if (!string.IsNullOrEmpty(soundFile) && System.IO.File.Exists(soundFile))
                {
                    var player = new SoundPlayer(soundFile);
                    player.Play();
                }
                else
                {
                    // Play default system sound
                    SystemSounds.Beep.Play();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Səs çalma xətası: {ex.Message}");
            }
        }

        #endregion

        #region Statistics and Reports

        public async Task<Dictionary<string, object>> GetNotificationStatisticsAsync()
        {
            var typeStats = await _notificationRepository.GetNotificationStatisticsByTypeAsync();
            var moduleStats = await _notificationRepository.GetNotificationStatisticsByModuleAsync();
            var priorityStats = await _notificationRepository.GetNotificationStatisticsByPriorityAsync();

            var allNotifications = await _notificationRepository.GetAllAsync();
            var totalNotifications = allNotifications.Count();
            var unreadNotifications = allNotifications.Count(n => !n.Oxundu);
            var todayNotifications = allNotifications.Count(n => n.GonderimeTarixi.Date == DateTime.Today);

            return new Dictionary<string, object>
            {
                { "TotalNotifications", totalNotifications },
                { "UnreadNotifications", unreadNotifications },
                { "TodayNotifications", todayNotifications },
                { "TypeStatistics", typeStats },
                { "ModuleStatistics", moduleStats },
                { "PriorityStatistics", priorityStats }
            };
        }

        public async Task<Dictionary<string, object>> GetUserNotificationPreferencesAsync(int userId)
        {
            return await _settingsRepository.GetUserNotificationPreferencesAsync(userId);
        }

        #endregion

        #region Module-specific Notification Helpers

        public async Task<Bildiris> SendSalesNotificationAsync(string title, string message, int? userId = null)
        {
            return await SendNotificationAsync(title, message, 
                Bildiris.BildirisNovleri.Melumat, 
                Bildiris.BildirisPrioritetleri.Orta,
                Bildiris.BildirisModulleri.Satis, userId);
        }

        public async Task<Bildiris> SendWarehouseNotificationAsync(string title, string message, int? userId = null)
        {
            return await SendNotificationAsync(title, message, 
                Bildiris.BildirisNovleri.Melumat, 
                Bildiris.BildirisPrioritetleri.Orta,
                Bildiris.BildirisModulleri.Anbar, userId);
        }

        public async Task<Bildiris> SendShiftNotificationAsync(string title, string message, int? userId = null)
        {
            return await SendNotificationAsync(title, message, 
                Bildiris.BildirisNovleri.Melumat, 
                Bildiris.BildirisPrioritetleri.Orta,
                Bildiris.BildirisModulleri.Novbe, userId);
        }

        public async Task<Bildiris> SendBackupNotificationAsync(string title, string message, string priority = null)
        {
            return await SendNotificationAsync(title, message, 
                Bildiris.BildirisNovleri.Sistem, 
                priority ?? Bildiris.BildirisPrioritetleri.Orta,
                Bildiris.BildirisModulleri.Backup);
        }

        public async Task<Bildiris> SendLowStockNotificationAsync(string productName, int currentStock, int minStock)
        {
            return await SendWarningNotificationAsync(
                "Aşağı Stok Xəbərdarlığı",
                $"{productName} məhsulunun stoku aşağıdır. Hazırkı stok: {currentStock}, Minimum stok: {minStock}",
                Bildiris.BildirisModulleri.Anbar);
        }

        public async Task<Bildiris> SendDebtOverdueNotificationAsync(string customerName, decimal amount, DateTime dueDate)
        {
            return await SendErrorNotificationAsync(
                "Gecikmiş Borc Xəbərdarlığı",
                $"{customerName} müştərisinin {amount:C} məbləğində borcu {dueDate:dd.MM.yyyy} tarixində ödənilməli idi.",
                Bildiris.BildirisModulleri.Borc);
        }

        #endregion

        public void Dispose()
        {
            _notificationRepository?.Dispose();
            _settingsRepository?.Dispose();
            _userRepository?.Dispose();
        }
    }
}