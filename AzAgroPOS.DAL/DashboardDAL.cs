using AzAgroPOS.DAL.Helpers;
using AzAgroPOS.Entities;
using System;
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
    }
}