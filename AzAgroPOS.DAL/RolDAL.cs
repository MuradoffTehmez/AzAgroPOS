using AzAgroPOS.DAL.Helpers;
using AzAgroPOS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AzAgroPOS.DAL
{
    /// <summary>
    /// Rollar cədvəli ilə bağlı bütün verilənlər bazası əməliyyatlarını həyata keçirir.
    /// </summary>
    public class RolDAL
    {
        private readonly string _connectionString = DatabaseHelper.GetConnectionString();

        /// <summary>
        /// Bütün rolların siyahısını gətirir.
        /// </summary>
        public List<Rol> GetAll()
        {
            var roller = new List<Rol>();
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM rollar ORDER BY id";
                var command = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roller.Add(MapRol(reader));
                        }
                    }
                }
                catch (Exception ex) { throw; }
            }
            return roller;
        }

        /// <summary>
        /// Verilmiş ID-yə görə tək bir rolu tapır.
        /// </summary>
        public Rol GetById(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM rollar WHERE id = @id";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    conn.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapRol(reader);
                        }
                    }
                }
                catch (Exception ex) { throw; }
            }
            return null;
        }

        /// <summary>
        /// Verilmiş ada malik bir rolun mövcud olub-olmadığını yoxlayır.
        /// </summary>
        public bool Exists(string ad, int? id = null)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT COUNT(1) FROM rollar WHERE ad = @ad";
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
        /// Yeni rol əlavə edir.
        /// </summary>
        public int Add(Rol rol)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO rollar (ad, tesvir) VALUES (@ad, @tesvir); SELECT SCOPE_IDENTITY();";
                var command = new SqlCommand(query, conn);
                command.Parameters.Add("@ad", SqlDbType.NVarChar).Value = rol.Ad;
                command.Parameters.Add("@tesvir", SqlDbType.NVarChar).Value = (object)rol.Tesvir ?? DBNull.Value;
                try
                {
                    conn.Open();
                    return Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex) { throw; }
            }
        }

        /// <summary>
        /// Mövcud rolu yeniləyir.
        /// </summary>
        public bool Update(Rol rol)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = "UPDATE rollar SET ad = @ad, tesvir = @tesvir, son_deyisiklik = GETDATE() WHERE id = @id";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", rol.Id);
                command.Parameters.Add("@ad", SqlDbType.NVarChar).Value = rol.Ad;
                command.Parameters.Add("@tesvir", SqlDbType.NVarChar).Value = (object)rol.Tesvir ?? DBNull.Value;
                try
                {
                    conn.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex) { throw; }
            }
        }

        /// <summary>
        /// Verilmiş rolu silir.
        /// </summary>
        public bool Delete(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM rollar WHERE id = @id";
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
        /// Verilmiş rolun hər hansı bir istifadəçiyə təyin edilib-edilmədiyini yoxlayır.
        /// </summary>
        public bool IsRoleAssignedToUsers(int rolId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = "SELECT COUNT(1) FROM istifadeciler WHERE rol_id = @rolId";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@rolId", rolId);
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
        /// SqlDataReader-dən gələn məlumatı Rol obyektinə çevirir.
        /// </summary>
        private Rol MapRol(SqlDataReader reader)
        {
            return new Rol
            {
                Id = (int)reader["id"],
                Ad = reader["ad"].ToString(),
                Tesvir = reader["tesvir"]?.ToString(),
                YaradilmaTarixi = (DateTime)reader["yaradilma_tarixi"],
                SonDeyisiklik = reader["son_deyisiklik"] as DateTime?
            };
        }
    }
}