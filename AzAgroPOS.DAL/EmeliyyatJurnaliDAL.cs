using AzAgroPOS.DAL.Helpers;
using AzAgroPOS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AzAgroPOS.DAL
{
    /// <summary>
    /// Əməliyyat jurnalı ilə bağlı verilənlər bazası əməliyyatlarını həyata keçirir.
    /// Bu sinif audit log qeydlərinin yaradılması və sorğulanması üçün metodlar təqdim edir.
    /// </summary>
    public class EmeliyyatJurnaliDAL
    {
        private readonly string _connectionString = DatabaseHelper.GetConnectionString();

        /// <summary>
        /// Əməliyyat jurnalına yeni qeyd əlavə edir.
        /// </summary>
        /// <param name="log">Əlavə ediləcək jurnal qeydi</param>
        public void Add(EmeliyyatJurnali log)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    // DÜZƏLİŞ: Sorğudan "tarix" sütunu çıxarıldı (emeliyyat_tarixi DEFAULT GETDATE() ilə)
                    var query = @"INSERT INTO emeliyyat_jurnali 
                                (istifadeci_id, emeliyyat_novu, tesvir, ip_adresi) 
                                VALUES (@istifadeci_id, @emeliyyat_novu, @tesvir, @ip_adresi)";
                    var command = new SqlCommand(query, connection);

                    command.Parameters.Add("@istifadeci_id", SqlDbType.Int).Value = log.IstifadeciId;
                    command.Parameters.Add("@emeliyyat_novu", SqlDbType.NVarChar).Value = log.EmeliyyatNovu;
                    command.Parameters.Add("@tesvir", SqlDbType.NVarChar).Value = log.Tesvir;
                    command.Parameters.Add("@ip_adresi", SqlDbType.NVarChar).Value = (object)log.IpAdresi ?? DBNull.Value;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Audit Log Xətası: " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// İstifadəçi ID-sinə görə əməliyyat jurnalını gətirir.
        /// </summary>
        /// <param name="istifadeciId">Jurnal qeydləri axtarılacaq istifadəçinin ID-si</param>
        /// <returns>Əməliyyat jurnalı qeydlərinin siyahısı</returns>
        public List<EmeliyyatJurnali> GetByIstifadeciId(int istifadeciId)
        {
            var loglar = new List<EmeliyyatJurnali>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"SELECT ej.*, CONCAT(i.ad, ' ', i.soyad) as IstifadeciAdi 
                            FROM emeliyyat_jurnali ej
                            JOIN istifadeciler i ON ej.istifadeci_id = i.id
                            WHERE ej.istifadeci_id = @istifadeci_id
                            ORDER BY ej.emeliyyat_tarixi DESC";

                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@istifadeci_id", istifadeciId);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        loglar.Add(new EmeliyyatJurnali
                        {
                            Id = (int)reader["id"],
                            IstifadeciId = (int)reader["istifadeci_id"],
                            IstifadeciAdi = reader["IstifadeciAdi"].ToString(),
                            EmeliyyatNovu = reader["emeliyyat_novu"].ToString(),
                            Tesvir = reader["tesvir"].ToString(),
                            EmeliyyatTarixi = (DateTime)reader["emeliyyat_tarixi"],
                            IpAdresi = reader["ip_adresi"] != DBNull.Value ? reader["ip_adresi"].ToString() : null
                        });
                    }
                }
            }

            return loglar;
        }

        /// <summary>
        /// Tarix aralığına görə əməliyyat jurnalını gətirir.
        /// </summary>
        /// <param name="startDate">Axtarışın başlanğıc tarixi</param>
        /// <param name="endDate">Axtarışın bitmə tarixi</param>
        /// <returns>Əməliyyat jurnalı qeydlərinin siyahısı</returns>
        public List<EmeliyyatJurnali> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            var loglar = new List<EmeliyyatJurnali>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"SELECT ej.*, CONCAT(i.ad, ' ', i.soyad) as IstifadeciAdi 
                            FROM emeliyyat_jurnali ej
                            JOIN istifadeciler i ON ej.istifadeci_id = i.id
                            WHERE ej.emeliyyat_tarixi BETWEEN @start_date AND @end_date
                            ORDER BY ej.emeliyyat_tarixi DESC";

                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@start_date", startDate);
                command.Parameters.AddWithValue("@end_date", endDate);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        loglar.Add(new EmeliyyatJurnali
                        {
                            Id = (int)reader["id"],
                            IstifadeciId = (int)reader["istifadeci_id"],
                            IstifadeciAdi = reader["IstifadeciAdi"].ToString(),
                            EmeliyyatNovu = reader["emeliyyat_novu"].ToString(),
                            Tesvir = reader["tesvir"].ToString(),
                            EmeliyyatTarixi = (DateTime)reader["emeliyyat_tarixi"],
                            IpAdresi = reader["ip_adresi"] != DBNull.Value ? reader["ip_adresi"].ToString() : null
                        });
                    }
                }
            }

            return loglar;
        }

        /// <summary>
        /// Əməliyyat jurnalında çoxşaxəli axtarış edir.
        /// </summary>
        /// <param name="startDate">Axtarışın başlanğıc tarixi</param>
        /// <param name="endDate">Axtarışın bitmə tarixi</param>
        /// <param name="userId">Axtarılacaq istifadəçi ID-si (null və ya 0 olarsa, nəzərə alınmır)</param>
        /// <param name="keyword">Axtarış ifadəsi (əməliyyat növü və ya təsvirdə axtarılır)</param>
        /// <returns>Əməliyyat jurnalı qeydlərinin siyahısı</returns>
        public List<EmeliyyatJurnali> Search(DateTime startDate, DateTime endDate, int? userId = null, string keyword = null)
        {
            var logs = new List<EmeliyyatJurnali>();
            var queryBuilder = new StringBuilder(@"SELECT j.*, CONCAT(i.ad, ' ', i.soyad) as IstifadeciAdi 
                                               FROM emeliyyat_jurnali j 
                                               JOIN istifadeciler i ON j.istifadeci_id = i.id 
                                               WHERE j.emeliyyat_tarixi BETWEEN @startDate AND @endDate");

            if (userId.HasValue && userId > 0)
            {
                queryBuilder.Append(" AND j.istifadeci_id = @userId");
            }
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                queryBuilder.Append(" AND (j.emeliyyat_novu LIKE @keyword OR j.tesvir LIKE @keyword)");
            }
            queryBuilder.Append(" ORDER BY j.emeliyyat_tarixi DESC");

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(queryBuilder.ToString(), connection);
                command.Parameters.AddWithValue("@startDate", startDate);
                command.Parameters.AddWithValue("@endDate", endDate);

                if (userId.HasValue && userId > 0)
                {
                    command.Parameters.AddWithValue("@userId", userId.Value);
                }
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                }

                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            logs.Add(new EmeliyyatJurnali
                            {
                                Id = (int)reader["id"],
                                IstifadeciId = (int)reader["istifadeci_id"],
                                IstifadeciAdi = reader["IstifadeciAdi"].ToString(),
                                EmeliyyatNovu = reader["emeliyyat_novu"].ToString(),
                                Tesvir = reader["tesvir"].ToString(),
                                EmeliyyatTarixi = (DateTime)reader["emeliyyat_tarixi"],
                                IpAdresi = reader["ip_adresi"] != DBNull.Value ? reader["ip_adresi"].ToString() : null
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Əməliyyat jurnalında axtarış edilərkən xəta baş verdi.", ex);
                }
            }

            return logs;
        }
    }
}