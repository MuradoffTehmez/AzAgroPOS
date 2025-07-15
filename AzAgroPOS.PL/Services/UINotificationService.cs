using System;
using System.Windows.Forms;
using AzAgroPOS.BLL.Services;

namespace AzAgroPOS.PL.Services
{
    public interface IUINotificationService
    {
        void ShowError(string message, string title = "Xəta");
        void ShowWarning(string message, string title = "Xəbərdarlıq");
        void ShowSuccess(string message, string title = "Uğur");
        void ShowInfo(string message, string title = "Məlumat");
        bool ShowConfirmation(string message, string title = "Təsdiq");
        void HandleError(Exception ex, string userFriendlyMessage, bool isCritical = false);
    }

    public class UINotificationService : IUINotificationService
    {
        public void ShowError(string message, string title = "Xəta")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowWarning(string message, string title = "Xəbərdarlıq")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void ShowSuccess(string message, string title = "Uğur")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowInfo(string message, string title = "Məlumat")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool ShowConfirmation(string message, string title = "Təsdiq")
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public void HandleError(Exception ex, string userFriendlyMessage, bool isCritical = false)
        {
            // Log the error using the centralized service
            ErrorHandlingService.HandleErrorStatic(ex, userFriendlyMessage, isCritical);
            
            // Show user-friendly message
            if (isCritical)
            {
                ShowError($"{userFriendlyMessage}\n\nProqram bağlanacaq.", "Kritik Xəta");
                Application.Exit();
            }
            else
            {
                ShowError(userFriendlyMessage);
            }
        }
    }
}