using System;

namespace AzAgroPOS.BLL.Interfaces
{
    public interface IErrorHandlingService
    {
        void HandleError(Exception ex, string userFriendlyMessage, bool isCritical = false);
        void LogError(Exception ex, string message = "");
        void LogWarning(string message);
        void LogInfo(string message);
        void ShowUserMessage(string message, bool isError = false);
        void ShowCriticalError(string message);
        string GetUserFriendlyMessage(Exception ex);
    }
}