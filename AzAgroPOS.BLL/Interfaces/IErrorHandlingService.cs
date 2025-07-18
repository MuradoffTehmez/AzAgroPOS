using System;
using System.Threading.Tasks;
using AzAgroPOS.BLL.Interfaces;

namespace AzAgroPOS.BLL.Interfaces
{
    public interface IErrorHandlingService
    {
        // Existing synchronous methods
        void HandleError(Exception ex, string userFriendlyMessage, bool isCritical = false);
        void LogError(Exception ex, string message = "");
        void LogWarning(string message);
        void LogInfo(string message);
        void ShowUserMessage(string message, bool isError = false);
        void ShowCriticalError(string message);
        string GetUserFriendlyMessage(Exception ex);
        
        // New async methods for modern MVP presenters
        Task HandleErrorAsync(Exception ex, string userFriendlyMessage, bool isCritical = false);
        Task LogErrorAsync(Exception ex, string message = "");
        Task LogWarningAsync(string message);
        Task LogInfoAsync(string message);
        Task ShowUserMessageAsync(string message, bool isError = false);
        Task ShowCriticalErrorAsync(string message);
        
        // Validation and business logic error handling
        Task<bool> HandleValidationErrorAsync(string message);
        Task<bool> HandleBusinessLogicErrorAsync(string message);
        Task ShowSuccessAsync(string message);
    }
}