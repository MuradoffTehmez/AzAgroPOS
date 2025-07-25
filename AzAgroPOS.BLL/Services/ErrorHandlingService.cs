using AzAgroPOS.BLL.Interfaces;
using AzAgroPOS.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzAgroPOS.BLL.Services
{
    public class ErrorHandlingService : IErrorHandlingService
    {
        private readonly ILoggerService _logger;
        private readonly IUserContext _userContext;

        public ErrorHandlingService(ILoggerService logger, IUserContext userContext)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
        }

        // Static methods for backward compatibility
        public static void HandleErrorStatic(Exception ex, string userFriendlyMessage, bool isCritical = false)
        {
            if (ex == null)
                throw new ArgumentNullException(nameof(ex));

            if (string.IsNullOrWhiteSpace(userFriendlyMessage))
                throw new ArgumentException("User message cannot be empty", nameof(userFriendlyMessage));

            // Simple static version - just show the message
            Console.WriteLine($"ERROR: {userFriendlyMessage ?? ex.Message}");
        }

        public static void ShowValidationError(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Message cannot be empty", nameof(message));

            Console.WriteLine($"VALIDATION ERROR: {message}");
        }

        public static void ShowSuccess(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Message cannot be empty", nameof(message));

            Console.WriteLine($"SUCCESS: {message}");
        }

        public static bool ShowConfirmation(string message, string title = "Təsdiq")
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Message cannot be empty", nameof(message));

            Console.WriteLine($"CONFIRMATION NEEDED: {message}");
            return true; // BLL layer-də həmişə true qaytarır
        }

        /// <summary>
        /// Handles errors with logging and user-friendly messages
        /// </summary>
        /// <param name="ex">Exception that occurred</param>
        /// <param name="userFriendlyMessage">User-friendly message to display</param>
        /// <param name="isCritical">Whether the error is critical</param>
        public void HandleError(Exception ex, string userFriendlyMessage, bool isCritical = false)
        {
            if (ex == null)
                throw new ArgumentNullException(nameof(ex));

            if (string.IsNullOrWhiteSpace(userFriendlyMessage))
                throw new ArgumentException("User message cannot be empty", nameof(userFriendlyMessage));

            // Log the error
            LogErrorInternal(ex, isCritical);

            // Show user-friendly message
            ShowErrorMessage(userFriendlyMessage, ex, _userContext.IsAdmin);
        }

        /// <summary>
        /// Sanitizes error messages to remove sensitive information
        /// </summary>
        public string SanitizeErrorMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
                return "Naməlum xəta baş verdi.";

            // Define sensitive patterns to remove
            var sensitivePatterns = new[]
            {
                "connection string",
                "password=",
                "user id=",
                "C:\\",
                "D:\\",
                "Server=",
                "Database="
            };

            foreach (var pattern in sensitivePatterns)
            {
                if (message.IndexOf(pattern, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return GetGenericErrorMessage(message);
                }
            }

            return message;
        }

        public void LogError(Exception ex, string message = "")
        {
            try
            {
                if (!string.IsNullOrEmpty(message))
                {
                    var combinedException = new Exception($"{message}: {ex.Message}", ex);
                    _logger.LogError(combinedException);
                }
                else
                {
                    _logger.LogError(ex);
                }
            }
            catch (Exception logEx)
            {
                // Fallback logging
                System.Diagnostics.Debug.WriteLine($"Logging failed: {logEx.Message}");
            }
        }

        public void LogWarning(string message)
        {
            try
            {
                _logger.LogWarning(message);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Warning logging failed: {ex.Message}");
            }
        }

        public void LogInfo(string message)
        {
            try
            {
                _logger.LogInfo(message);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Info logging failed: {ex.Message}");
            }
        }

        public void ShowUserMessage(string message, bool isError = false)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Message cannot be empty", nameof(message));

            var title = isError ? "ERROR" : "INFO";
            Console.WriteLine($"{title}: {message}");
        }

        public void ShowCriticalError(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Message cannot be empty", nameof(message));

            Console.WriteLine($"CRITICAL ERROR: {message}");
        }

        public string GetUserFriendlyMessage(Exception ex)
        {
            return SanitizeErrorMessage(ex?.Message ?? "Naməlum xəta baş verdi.");
        }

        #region Async Methods for Modern MVP

        /// <summary>
        /// Async version of HandleError for MVP presenters
        /// </summary>
        public async Task HandleErrorAsync(Exception ex, string userFriendlyMessage, bool isCritical = false)
        {
            await Task.Run(() => HandleError(ex, userFriendlyMessage, isCritical));
        }

        /// <summary>
        /// Async version of LogError
        /// </summary>
        public async Task LogErrorAsync(Exception ex, string message = "")
        {
            await Task.Run(() => LogError(ex, message));
        }

        /// <summary>
        /// Async version of LogWarning
        /// </summary>
        public async Task LogWarningAsync(string message)
        {
            await Task.Run(() => LogWarning(message));
        }

        /// <summary>
        /// Async version of LogInfo
        /// </summary>
        public async Task LogInfoAsync(string message)
        {
            await Task.Run(() => LogInfo(message));
        }

        /// <summary>
        /// Async version of ShowUserMessage
        /// </summary>
        public async Task ShowUserMessageAsync(string message, bool isError = false)
        {
            await Task.Run(() => ShowUserMessage(message, isError));
        }

        /// <summary>
        /// Async version of ShowCriticalError
        /// </summary>
        public async Task ShowCriticalErrorAsync(string message)
        {
            await Task.Run(() => ShowCriticalError(message));
        }

        /// <summary>
        /// Handle validation errors with user-friendly messages
        /// </summary>
        public async Task<bool> HandleValidationErrorAsync(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Message cannot be empty", nameof(message));

            await LogWarningAsync($"Validation Error: {message}");
            await ShowUserMessageAsync($"Yoxlama xətası: {message}", true);
            return false;
        }

        /// <summary>
        /// Handle business logic errors
        /// </summary>
        public async Task<bool> HandleBusinessLogicErrorAsync(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Message cannot be empty", nameof(message));

            await LogWarningAsync($"Business Logic Error: {message}");
            await ShowUserMessageAsync($"Biznes məntiqi xətası: {message}", true);
            return false;
        }

        /// <summary>
        /// Show success message
        /// </summary>
        public async Task ShowSuccessAsync(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Message cannot be empty", nameof(message));

            await LogInfoAsync($"Success: {message}");
            await ShowUserMessageAsync(message, false);
        }

        #endregion

        #region Private Methods

        private void LogErrorInternal(Exception ex, bool isCritical)
        {
            try
            {
                if (isCritical)
                {
                    var criticalEx = new Exception($"CRITICAL: {ex.Message}", ex);
                    _logger.LogError(criticalEx);
                }
                else
                {
                    _logger.LogError(ex);
                }

                // Also write to debug output for development
                Debug.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {(isCritical ? "CRITICAL " : "")}ERROR: {ex.Message}");
            }
            catch (Exception loggingEx)
            {
                Debug.WriteLine($"Failed to log error: {loggingEx}");
            }
        }

        private string BuildLogMessage(Exception ex, bool isCritical)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {(isCritical ? "CRITICAL " : "")}ERROR:");
            sb.AppendLine($"Message: {SanitizeErrorMessage(ex.Message)}");
            sb.AppendLine($"Type: {ex.GetType().Name}");
            sb.AppendLine($"StackTrace: {ex.StackTrace}");

            if (ex.InnerException != null)
            {
                sb.AppendLine($"Inner Exception: {SanitizeErrorMessage(ex.InnerException.Message)}");
                sb.AppendLine($"Inner StackTrace: {ex.InnerException.StackTrace}");
            }

            // Add contextual information
            sb.AppendLine($"User: {_userContext.UserId} ({_userContext.Username})");
            sb.AppendLine($"Machine: {Environment.MachineName}");

            return sb.ToString();
        }

        private void ShowErrorMessage(string userMessage, Exception ex, bool isAdmin)
        {
            var displayMessage = new StringBuilder(userMessage);

            if (isAdmin)
            {
                displayMessage.AppendLine("\n\nTexniki Detallar:");
                displayMessage.AppendLine($"• Xəta növü: {ex.GetType().Name}");
                displayMessage.AppendLine($"• Mesaj: {SanitizeErrorMessage(ex.Message)}");

                if (ex.InnerException != null)
                {
                    displayMessage.AppendLine($"• Daxili xəta: {SanitizeErrorMessage(ex.InnerException.Message)}");
                }
            }

            Console.WriteLine($"ERROR DETAIL: {displayMessage}");
        }

        private string GetGenericErrorMessage(string originalMessage)
        {
            if (originalMessage.IndexOf("connection", StringComparison.OrdinalIgnoreCase) >= 0)
                return "Verilənlər bazası əlaqə xətası.";

            if (originalMessage.IndexOf("SQL", StringComparison.OrdinalIgnoreCase) >= 0 ||
                originalMessage.IndexOf("database", StringComparison.OrdinalIgnoreCase) >= 0)
                return "Verilənlər bazası əməliyyat xətası.";

            if (originalMessage.Contains("\\") || originalMessage.Contains("/"))
                return "Sistem fayl əməliyyat xətası.";

            if (originalMessage.IndexOf("network", StringComparison.OrdinalIgnoreCase) >= 0)
                return "Şəbəkə əlaqə xətası.";

            return "Sistem xətası baş verdi.";
        }

        #endregion
    }
}