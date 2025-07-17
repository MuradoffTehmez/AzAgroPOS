using System;

namespace AzAgroPOS.BLL.Interfaces
{
    /// <summary>
    /// Loglama əməliyyatları üçün interfeys
    /// Xətaları və sistem hadisələrini qeydə almaq üçün istifadə olunur
    /// </summary>
    public interface ILoggerService
    {
        /// <summary>
        /// Exception-ı log faylına yazır
        /// </summary>
        /// <param name="ex">Qeydə alınacaq exception</param>
        void LogError(Exception ex);
        
        /// <summary>
        /// İnformasiya məlumatını log faylına yazır
        /// </summary>
        /// <param name="message">Log mesajı</param>
        void LogInfo(string message);
        
        /// <summary>
        /// Xəbərdarlıq məlumatını log faylına yazır
        /// </summary>
        /// <param name="message">Xəbərdarlıq mesajı</param>
        void LogWarning(string message);
    }
}