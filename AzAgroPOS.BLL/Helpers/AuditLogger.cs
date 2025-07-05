// Fayl: AzAgroPOS.BLL/Helpers/AuditLogger.cs
using AzAgroPOS.DAL;
using AzAgroPOS.Entities;

namespace AzAgroPOS.BLL.Helpers
{
    public static class AuditLogger
    {
        private static readonly EmeliyyatJurnaliDAL _logDal = new EmeliyyatJurnaliDAL();

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