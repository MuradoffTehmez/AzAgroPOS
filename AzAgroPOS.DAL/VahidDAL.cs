using AzAgroPOS.DAL.Helpers;
using AzAgroPOS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AzAgroPOS.DAL
{
    /// <summary>
    /// Ölçü vahidləri cədvəli ilə bağlı bütün verilənlər bazası əməliyyatlarını həyata keçirir.
    /// </summary>
    public class VahidDAL
    {
        private readonly string _connectionString = DatabaseHelper.GetConnectionString();

        /// <summary>
        /// Bütün ölçü vahidlərinin siyahısını gətirir.
        /// </summary>
        public List<Vahid> GetAll()
        {
            var vahidler = new List<Vahid>();
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM vahidler ORDER BY ad";
                var command = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            vahidler.Add(MapVahid(reader));
                        }
                    }
                }
                catch (Exception ex) { throw; }
            }
            return vahidler;
        }

        /// <summary>
        /// Verilmiş ID-yə görə tək bir ölçü vahidini tapır.
        /// </summary>
        public Vahid GetById(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM vahidler WHERE id = @id";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    conn.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapVahid(reader);
                        }
                    }
                }
                catch (Exception ex) { throw; }
            }
            return null;
        }

        /// <summary>
        /// Verilmiş ada malik bir vahidin mövcud olub-olmadığını yoxlayır.
        /// </summary>
        public bool Exists(string ad, int? id = null)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT COUNT(1) FROM vahidler WHERE ad = @ad";
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
        /// Yeni ölçü vahidi əlavə edir.
        /// </summary>
        public int Add(Vahid vahid)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO vahidler (ad, qisaltma) VALUES (@ad, @qisaltma); SELECT SCOPE_IDENTITY();";
                var command = new SqlCommand(query, conn);
                command.Parameters.Add("@ad", SqlDbType.NVarChar).Value = vahid.Ad;
                command.Parameters.Add("@qisaltma", SqlDbType.NVarChar).Value = (object)vahid.Qisaltma ?? DBNull.Value;
                try
                {
                    conn.Open();
                    return Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex) { throw; }
            }
        }

        /// <summary>
        /// Mövcud ölçü vahidini yeniləyir.
        /// </summary>
        public bool Update(Vahid vahid)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = "UPDATE vahidler SET ad = @ad, qisaltma = @qisaltma WHERE id = @id";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", vahid.Id);
                command.Parameters.Add("@ad", SqlDbType.NVarChar).Value = vahid.Ad;
                command.Parameters.Add("@qisaltma", SqlDbType.NVarChar).Value = (object)vahid.Qisaltma ?? DBNull.Value;
                try
                {
                    conn.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex) { throw; }
            }
        }

        /// <summary>
        /// Verilmiş ölçü vahidini silir.
        /// </summary>
        public bool Delete(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM vahidler WHERE id = @id";
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
        /// Verilmiş vahidin hər hansı bir məhsulda istifadə olunub-olunmadığını yoxlayır.
        /// </summary>
        public bool IsVahidUsedInProducts(int vahidId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = "SELECT COUNT(1) FROM mehsullar WHERE vahid_id = @vahidId";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@vahidId", vahidId);
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
        /// SqlDataReader-dən gələn məlumatı Vahid obyektinə çevirir.
        /// </summary>
        private Vahid MapVahid(SqlDataReader reader)
        {
            return new Vahid
            {
                Id = (int)reader["id"],
                Ad = reader["ad"].ToString(),
                Qisaltma = reader["qisaltma"]?.ToString()
            };
        }
    }
}