using System;
using System.Text;
using System.Windows.Forms;

namespace AzAgroPOS.BLL.Services
{
    public static class ErrorHandlingService
    {
        /// <summary>
        /// Logs error and shows user-friendly message
        /// </summary>
        /// <param name="ex">Exception that occurred</param>
        /// <param name="userFriendlyMessage">User-friendly message to display</param>
        /// <param name="showDetails">Whether to show technical details (only for admins)</param>
        public static void HandleError(Exception ex, string userFriendlyMessage, bool showDetails = false)
        {
            // Log the full exception details (would typically go to a logging service)
            LogError(ex);
            
            // Show user-friendly message
            string displayMessage = userFriendlyMessage;
            
            if (showDetails)
            {
                displayMessage += $"\n\nTexniki Detallar:\n{ex.Message}";
            }
            
            MessageBox.Show(displayMessage, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        /// <summary>
        /// Sanitizes error messages to remove sensitive information
        /// </summary>
        /// <param name="message">Original error message</param>
        /// <returns>Sanitized error message</returns>
        public static string SanitizeErrorMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
                return "Naməlum xəta baş verdi.";
                
            // Remove database connection strings
            if (message.Contains("connection"))
                return "Verilənlər bazası əlaqə xətası.";
                
            // Remove SQL-related errors
            if (message.Contains("SQL") || message.Contains("database"))
                return "Verilənlər bazası əməliyyat xətası.";
                
            // Remove file path information
            if (message.Contains("C:\\") || message.Contains("\\"))
                return "Sistem fayl əməliyyat xətası.";
                
            return message;
        }
        
        /// <summary>
        /// Logs error to system (would typically use proper logging framework)
        /// </summary>
        /// <param name="ex">Exception to log</param>
        private static void LogError(Exception ex)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ERROR:");
            sb.AppendLine($"Message: {ex.Message}");
            sb.AppendLine($"StackTrace: {ex.StackTrace}");
            
            if (ex.InnerException != null)
            {
                sb.AppendLine($"Inner Exception: {ex.InnerException.Message}");
            }
            
            // In production, this would write to a proper log file or logging service
            System.Diagnostics.Debug.WriteLine(sb.ToString());
        }
        
        /// <summary>
        /// Shows validation error message
        /// </summary>
        /// <param name="message">Validation error message</param>
        public static void ShowValidationError(string message)
        {
            MessageBox.Show(message, "Doğrulama Xətası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        
        /// <summary>
        /// Shows success message
        /// </summary>
        /// <param name="message">Success message</param>
        public static void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Uğur", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        /// <summary>
        /// Shows confirmation dialog
        /// </summary>
        /// <param name="message">Confirmation message</param>
        /// <param name="title">Dialog title</param>
        /// <returns>True if user confirmed</returns>
        public static bool ShowConfirmation(string message, string title = "Təsdiq")
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}