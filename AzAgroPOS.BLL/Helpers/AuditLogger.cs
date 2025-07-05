using AzAgroPOS.DAL;
using AzAgroPOS.Entities;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace AzAgroPOS.BLL.Helpers
{
    /// <summary>
    /// Sistemdəki vacib əməliyyatları mərkəzləşdirilmiş şəkildə jurnala yazmaq üçün köməkçi sinif.
    /// </summary>
    public static class AuditLogger
    {
        private static readonly EmeliyyatJurnaliDAL _logDal = new EmeliyyatJurnaliDAL();

        /// <summary>
        /// Jurnala yeni bir qeyd əlavə edir. IP ünvanı avtomatik olaraq təyin edilir.
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
                Tesvir = tesvir,
                IpAdresi = GetLocalIPAddress() // IP ünvanını avtomatik alırıq
            };
            _logDal.Add(logEntry);
        }

        /// <summary>
        /// Proqramın işlədiyi kompüterin lokal IPv4 ünvanını tapır.
        /// </summary>
        /// <returns>Lokal IP ünvanı.</returns>
        private static string GetLocalIPAddress()
        {
            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ip.ToString();
                    }
                }
            }
            catch (Exception)
            {
                return "IP Tapılmadı";
            }
            return "IP Tapılmadı";
        }
    }
}