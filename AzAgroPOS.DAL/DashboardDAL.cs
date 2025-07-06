using AzAgroPOS.DAL.Helpers;
using AzAgroPOS.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AzAgroPOS.DAL
{
    public class DashboardDAL
    {
        private readonly string _connectionString = DatabaseHelper.GetConnectionString();

        public DashboardStats GetDashboardStats()
        {
            var stats = new DashboardStats();
            var query = @"
                SELECT 
                    (SELECT COUNT(id) FROM satislar WHERE CONVERT(date, satis_tarixi) = CONVERT(date, GETDATE())) as BugunkuSatisSayi,
                    (SELECT ISNULL(SUM(yekun_mebleg), 0) FROM satislar WHERE CONVERT(date, satis_tarixi) = CONVERT(date, GETDATE())) as BugunkuSatisMeblegi,
                    (SELECT COUNT(id) FROM temirler WHERE status_id != (SELECT id FROM temir_statuslari WHERE ad = 'Təhvil verildi')) as AktivTemirSayi,
                    (SELECT COUNT(id) FROM mehsullar WHERE cari_stok <= minimum_stok AND minimum_stok > 0) as KritikStokdaMehsulSayi";

            using (var conn = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            stats.BugunkuSatisSayi = (int)reader["BugunkuSatisSayi"];
                            stats.BugunkuSatisMeblegi = (decimal)reader["BugunkuSatisMeblegi"];
                            stats.AktivTemirSayi = (int)reader["AktivTemirSayi"];
                            stats.KritikStokdaMehsulSayi = (int)reader["KritikStokdaMehsulSayi"];
                        }
                    }
                }
                catch (Exception ex) { throw; }
            }
            return stats;
        }
        // DashboardDAL.cs sinifinin içinə əlavə edin

        /// <summary>
        /// Son 7 günün satış məbləğlərini tarixə görə qruplaşdıraraq qaytarır.
        /// </summary>
        public Dictionary<DateTime, decimal> GetSalesForLast7Days()
        {
            var dailySales = new Dictionary<DateTime, decimal>();
            using (var conn = new SqlConnection(_connectionString))
            {
                // SQL Server-in GETDATE() funksiyası ilə son 7 günü dinamik olaraq hesablayırıq
                var query = @"
            SELECT
                CAST(satis_tarixi AS DATE) as SatisGunu,
                SUM(yekun_mebleg) as CemiMebleg
            FROM satislar
            WHERE satis_tarixi >= DATEADD(day, -7, GETDATE())
            GROUP BY CAST(satis_tarixi AS DATE)
            ORDER BY SatisGunu;";

                var command = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dailySales.Add((DateTime)reader["SatisGunu"], (decimal)reader["CemiMebleg"]);
                        }
                    }
                }
                catch (Exception ex) { throw; }
            }
            return dailySales;
        }
    }
}