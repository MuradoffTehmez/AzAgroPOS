using AzAgroPOS.DAL.Helpers;
using AzAgroPOS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AzAgroPOS.DAL
{
    /// <summary>
    /// Əməliyyat jurnalı ilə bağlı verilənlər bazası əməliyyatlarını həyata keçirir.
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
                    var query = @"INSERT INTO emeliyyat_jurnali 
                                (istifadeci_id, emeliyyat_novu, tesvir, tarix) 
                                VALUES (@istifadeci_id, @emeliyyat_novu, @tesvir, GETDATE())";
                    var command = new SqlCommand(query, connection);

                    command.Parameters.Add("@istifadeci_id", SqlDbType.Int).Value = log.IstifadeciId;
                    command.Parameters.Add("@emeliyyat_novu", SqlDbType.NVarChar).Value = log.EmeliyyatNovu;
                    command.Parameters.Add("@tesvir", SqlDbType.NVarChar).Value = log.Tesvir;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Xətanı loglamaq üçün əlavə edilə bilər
                System.Diagnostics.Debug.WriteLine("Audit Log Xətası: " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// İstifadəçi ID-sinə görə əməliyyat jurnalını gətirir.
        /// </summary>
        /// <param name="istifadeciId">İstifadəçi ID-si</param>
        /// <returns>Əməliyyat jurnalı siyahısı</returns>
        public List<EmeliyyatJurnali> GetByIstifadeciId(int istifadeciId)
        {
            var loglar = new List<EmeliyyatJurnali>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"SELECT ej.*, i.ad + ' ' + i.soyad as IstifadeciAdi 
                            FROM emeliyyat_jurnali ej
                            JOIN istifadeciler i ON ej.istifadeci_id = i.id
                            WHERE ej.istifadeci_id = @istifadeci_id
                            ORDER BY ej.tarix DESC";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@istifadeci_id", istifadeciId);

                try
                {
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
                                Tarix = (DateTime)reader["tarix"]
                            });
                        }
                    }
                }
                catch (Exception ex) { throw; }
            }
            return loglar;
        }

        /// <summary>
        /// Tarix aralığına görə əməliyyat jurnalını gətirir.
        /// </summary>
        /// <param name="startDate">Başlanğıc tarixi</param>
        /// <param name="endDate">Bitmə tarixi</param>
        /// <returns>Əməliyyat jurnalı siyahısı</returns>
        public List<EmeliyyatJurnali> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            var loglar = new List<EmeliyyatJurnali>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"SELECT ej.*, i.ad + ' ' + i.soyad as IstifadeciAdi 
                            FROM emeliyyat_jurnali ej
                            JOIN istifadeciler i ON ej.istifadeci_id = i.id
                            WHERE ej.tarix BETWEEN @start_date AND @end_date
                            ORDER BY ej.tarix DESC";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@start_date", startDate);
                command.Parameters.AddWithValue("@end_date", endDate);

                try
                {
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
                                Tarix = (DateTime)reader["tarix"]
                            });
                        }
                    }
                }
                catch (Exception ex) { throw; }
            }
            return loglar;
        }
    }
}