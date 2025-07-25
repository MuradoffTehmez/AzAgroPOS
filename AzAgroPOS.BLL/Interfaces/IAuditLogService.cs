using AzAgroPOS.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzAgroPOS.BLL.Interfaces
{
    public interface IAuditLogService : IDisposable
    {
        void Log(string modul, int? entityId, string emeliyyat, string detal, int? istifadeciId);
        Task LogAsync(string modul, int? entityId, string emeliyyat, string detal, int? istifadeciId);
        void LogAction(string module, string action, int? entityId, string details, int? userId = null);
        void LogError(string message, Exception exception);
        Task LogErrorAsync(string message, Exception exception);
        IEnumerable<AuditLog> GetLogs(int? istifadeciId = null, string modul = null, DateTime? startDate = null, DateTime? endDate = null);
        Task<IEnumerable<AuditLog>> GetLogsAsync(int? istifadeciId = null, string modul = null, DateTime? startDate = null, DateTime? endDate = null);
        void ClearOldLogs(int days = 90);
    }
}