using AzAgroPOS.DAL.Helpers;
using AzAgroPOS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AzAgroPOS.DAL
{
    /// <summary>
    /// Təmir statusları cədvəli ilə bağlı bütün verilənlər bazası əməliyyatlarını həyata keçirir.
    /// </summary>
    public class TemirStatusuDAL
    {
        private readonly string _connectionString = DatabaseHelper.GetConnectionString();

        /// <summary>
        /// Bütün təmir statuslarının siyahısını gətirir.
        /// </summary>
        public List<TemirStatusu> GetAll()
        {
            var statuslar = new List<TemirStatusu>();
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM temir_statuslari ORDER BY siralama";
                var command = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            statuslar.Add(MapStatus(reader));
                        }
                    }
                }
                catch (Exception ex) { throw; }
            }
            return statuslar;
        }

        /// <summary>
        /// Verilmiş ID-yə görə tək bir statusu tapır.
        /// </summary>
        public TemirStatusu GetById(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM temir_statuslari WHERE id = @id";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    conn.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapStatus(reader);
                        }
                    }
                }
                catch (Exception ex) { throw; }
            }
            return null;
        }

        /// <summary>
        /// Verilmiş ada malik bir statusun mövcud olub-olmadığını yoxlayır.
        /// </summary>
        public bool Exists(string ad, int? id = null)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT COUNT(1) FROM temir_statuslari WHERE ad = @ad";
                if (id.HasValue)
                {
                    query += " AND id != @id";
                }
                var command = new SqlCommand(query, conn);
                command.Parameters.Add("@ad", SqlDbType.NVarChar).Value = ad;
                if (id.HasValue)
                {
                    command.Parameters.AddWithValue("@id", id.Value);
                }
                try
                {
                    conn.Open();
                    return (int)command.ExecuteScalar() > 0;
                }
                catch (Exception ex) { throw; }
            }
            return false;
        }

        /// <summary>
        /// Yeni təmir statusu əlavə edir.
        /// </summary>
        public int Add(TemirStatusu status)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO temir_statuslari (ad, siralama, icon_ad) VALUES (@ad, @siralama, @icon_ad); SELECT SCOPE_IDENTITY();";
                var command = new SqlCommand(query, conn);
                command.Parameters.Add("@ad", SqlDbType.NVarChar).Value = status.Ad;
                command.Parameters.Add("@siralama", SqlDbType.Int).Value = status.Siralama;
                command.Parameters.Add("@icon_ad", SqlDbType.NVarChar).Value = (object)status.IconAd ?? DBNull.Value;
                try
                {
                    conn.Open();
                    return Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex) { throw; }
            }
        }

        /// <summary>
        /// Mövcud təmir statusunu yeniləyir.
        /// </summary>
        public bool Update(TemirStatusu status)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = "UPDATE temir_statuslari SET ad = @ad, siralama = @siralama, icon_ad = @icon_ad WHERE id = @id";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", status.Id);
                command.Parameters.Add("@ad", SqlDbType.NVarChar).Value = status.Ad;
                command.Parameters.Add("@siralama", SqlDbType.Int).Value = status.Siralama;
                command.Parameters.Add("@icon_ad", SqlDbType.NVarChar).Value = (object)status.IconAd ?? DBNull.Value;
                try
                {
                    conn.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex) { throw; }
            }
        }

        /// <summary>
        /// Verilmiş statusu silir.
        /// </summary>
        public bool Delete(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM temir_statuslari WHERE id = @id";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    conn.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex) { throw; }
            }
        }

        /// <summary>
        /// Verilmiş statusun hər hansı bir təmirdə istifadə olunub-olunmadığını yoxlayır.
        /// </summary>
        public bool IsStatusUsedInRepairs(int statusId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = "SELECT COUNT(1) FROM temirler WHERE status_id = @statusId";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@statusId", statusId);
                try
                {
                    conn.Open();
                    return (int)command.ExecuteScalar() > 0;
                }
                catch (Exception ex) { throw; }
            }
            return false;
        }

        /// <summary>
        /// SqlDataReader-dən gələn məlumatı TemirStatusu obyektinə çevirir.
        /// </summary>
        private TemirStatusu MapStatus(SqlDataReader reader)
        {
            return new TemirStatusu
            {
                Id = (int)reader["id"],
                Ad = reader["ad"].ToString(),
                Siralama = (int)reader["siralama"],
                IconAd = reader["icon_ad"]?.ToString()
            };
        }
    }
}