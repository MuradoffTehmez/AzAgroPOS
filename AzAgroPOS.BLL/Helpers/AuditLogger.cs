using AzAgroPOS.DAL;
using AzAgroPOS.Entities;

namespace AzAgroPOS.BLL.Helpers
{
    /// <summary>
    /// Sistemdəki vacib əməliyyatları mərkəzləşdirilmiş şəkildə jurnala yazmaq üçün köməkçi sinif.
    /// </summary>
    public static class AuditLogger
    {
        private static readonly EmeliyyatJurnaliDAL _logDal = new EmeliyyatJurnaliDAL();

        /// <summary>
        /// Jurnala yeni bir qeyd əlavə edir.
        /// </summary>
        /// <param name="istifadeciId">Əməliyyatı edən istifadəçinin ID-si.</param>
        /// <param name="emeliyyatNovu">Əməliyyatın növü (məs. "Yeni Satış").</param>
        /// <param name="tesvir">Əməliyyat haqqında detallı məlumat.</param>
        public static void Log(int istifadeciId, string emeliyyatNovu, string tesvir)
        {
            var logEntry = new EmeliyyatJurnali
            {
                IstifadeciId = istifadeciId,
                EmeliyyatNovu = emeliyyatNovu,
                Tesvir = tesvir
            };
            _logDal.Add(logEntry);
        }
    }
}