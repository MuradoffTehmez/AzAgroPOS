using AzAgroPOS.DAL.Helpers;
using AzAgroPOS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AzAgroPOS.DAL
{
    /// <summary>
    /// Kateqoriyalar cədvəli ilə bağlı bütün verilənlər bazası əməliyyatlarını həyata keçirir.
    /// </summary>
    public class KateqoriyaDAL
    {
        private readonly string _connectionString = DatabaseHelper.GetConnectionString();

        /// <summary>
        /// Bütün aktiv kateqoriyaların siyahısını gətirir.
        /// </summary>
        public List<Kateqoriya> GetAll()
        {
            var kateqoriyalar = new List<Kateqoriya>();
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM kateqoriyalar WHERE aktivdir = 1 ORDER BY ad";
                var command = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            kateqoriyalar.Add(MapKateqoriya(reader));
                        }
                    }
                }
                catch (Exception ex) { throw; }
            }
            return kateqoriyalar;
        }

        /// <summary>
        /// Verilmiş ID-yə görə tək bir kateqoriyanı tapır.
        /// </summary>
        public Kateqoriya GetById(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM kateqoriyalar WHERE id = @id";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    conn.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapKateqoriya(reader);
                        }
                    }
                }
                catch (Exception ex) { throw; }
            }
            return null;
        }

        /// <summary>
        /// Verilmiş ada malik bir kateqoriyanın mövcud olub-olmadığını yoxlayır.
        /// Yeniləmə zamanı cari ID-ni yoxlamadan xaric etmək üçün istifadə olunur.
        /// </summary>
        public bool Exists(string ad, int? id = null)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT COUNT(1) FROM kateqoriyalar WHERE ad = @ad";
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
        /// Yeni kateqoriya əlavə edir.
        /// </summary>
        public int Add(Kateqoriya kateqoriya)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO kateqoriyalar (ad, tesvir, ana_kateqoriya_id, aktivdir) VALUES (@ad, @tesvir, @ana_kateqoriya_id, @aktivdir); SELECT SCOPE_IDENTITY();";
                var command = new SqlCommand(query, conn);
                command.Parameters.Add("@ad", SqlDbType.NVarChar).Value = kateqoriya.Ad;
                command.Parameters.Add("@tesvir", SqlDbType.NVarChar).Value = (object)kateqoriya.Tesvir ?? DBNull.Value;
                command.Parameters.Add("@ana_kateqoriya_id", SqlDbType.Int).Value = (object)kateqoriya.AnaKateqoriyaId ?? DBNull.Value;
                command.Parameters.Add("@aktivdir", SqlDbType.Bit).Value = kateqoriya.Aktivdir;
                try
                {
                    conn.Open();
                    return Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex) { throw; }
            }
        }

        /// <summary>
        /// Mövcud kateqoriyanı yeniləyir.
        /// </summary>
        public bool Update(Kateqoriya kateqoriya)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = "UPDATE kateqoriyalar SET ad = @ad, tesvir = @tesvir, ana_kateqoriya_id = @ana_kateqoriya_id, aktivdir = @aktivdir WHERE id = @id";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", kateqoriya.Id);
                command.Parameters.Add("@ad", SqlDbType.NVarChar).Value = kateqoriya.Ad;
                command.Parameters.Add("@tesvir", SqlDbType.NVarChar).Value = (object)kateqoriya.Tesvir ?? DBNull.Value;
                command.Parameters.Add("@ana_kateqoriya_id", SqlDbType.Int).Value = (object)kateqoriya.AnaKateqoriyaId ?? DBNull.Value;
                command.Parameters.Add("@aktivdir", SqlDbType.Bit).Value = kateqoriya.Aktivdir;
                try
                {
                    conn.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex) { throw; }
            }
        }

        /// <summary>
        /// Verilmiş kateqoriyanı silir.
        /// </summary>
        public bool Delete(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM kateqoriyalar WHERE id = @id";
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
        /// Verilmiş kateqoriyanın hər hansı bir məhsulda istifadə olunub-olunmadığını yoxlayır.
        /// </summary>
        public bool IsKateqoriyaUsedInProducts(int kateqoriyaId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = "SELECT COUNT(1) FROM mehsullar WHERE kateqoriya_id = @kateqoriyaId";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@kateqoriyaId", kateqoriyaId);
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
        /// SqlDataReader-dən gələn məlumatı Kateqoriya obyektinə çevirir.
        /// </summary>
        private Kateqoriya MapKateqoriya(SqlDataReader reader)
        {
            return new Kateqoriya
            {
                Id = (int)reader["id"],
                Ad = reader["ad"].ToString(),
                Tesvir = reader["tesvir"]?.ToString(),
                AnaKateqoriyaId = reader["ana_kateqoriya_id"] as int?,
                Aktivdir = (bool)reader["aktivdir"]
            };
        }
    }
}