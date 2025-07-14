using AzAgroPOS.BLL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AzAgroPOS.BLL.Services
{
    public class ErrorHandlingService : IErrorHandlingService
    {
        private readonly ILogger _logger;
        private readonly IUserContext _userContext;

        public ErrorHandlingService(ILogger logger, IUserContext userContext)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
        }

        // Static methods for backward compatibility
        public static void HandleError(Exception ex, string userFriendlyMessage, bool isCritical = false)
        {
            if (ex == null)
                throw new ArgumentNullException(nameof(ex));

            if (string.IsNullOrWhiteSpace(userFriendlyMessage))
                throw new ArgumentException("User message cannot be empty", nameof(userFriendlyMessage));

            // Simple static version - just show the message
            MessageBox.Show(userFriendlyMessage, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowValidationError(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Message cannot be empty", nameof(message));

            MessageBox.Show(message, "Doğrulama Xətası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowSuccess(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Message cannot be empty", nameof(message));

            MessageBox.Show(message, "Uğur", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool ShowConfirmation(string message, string title = "Təsdiq")
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Message cannot be empty", nameof(message));

            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
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
            LogError(ex, isCritical);

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

        /// <summary>
        /// Shows validation error message
        /// </summary>
        public void ShowValidationError(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Message cannot be empty", nameof(message));

            MessageBox.Show(message,
                "Doğrulama Xətası",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Shows success message
        /// </summary>
        public void ShowSuccess(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Message cannot be empty", nameof(message));

            MessageBox.Show(message,
                "Uğur",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// Shows confirmation dialog
        /// </summary>
        public bool ShowConfirmation(string message, string title = "Təsdiq")
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Message cannot be empty", nameof(message));

            return MessageBox.Show(message,
                title,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
        }

        #region Private Methods

        private void LogError(Exception ex, bool isCritical)
        {
            try
            {
                var logMessage = BuildLogMessage(ex, isCritical);
                _logger.LogError(logMessage);

                // Also write to debug output for development
                Debug.WriteLine(logMessage);
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

            MessageBox.Show(displayMessage.ToString(),
                "Xəta",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
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

    public interface IErrorHandlingService
    {
        void HandleError(Exception ex, string userFriendlyMessage, bool isCritical = false);
        string SanitizeErrorMessage(string message);
        void ShowValidationError(string message);
        void ShowSuccess(string message);
        bool ShowConfirmation(string message, string title = "Təsdiq");
    }
}