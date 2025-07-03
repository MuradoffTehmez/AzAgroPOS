// Fayl: AzAgroPOS.DAL/MehsulDAL.cs
using AzAgroPOS.DAL.Helpers;
using AzAgroPOS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AzAgroPOS.DAL
{
    public class MehsulDAL
    {
        private readonly string _connectionString = DatabaseHelper.GetConnectionString();

        public List<Mehsul> GetAll()
        {
            var mehsullar = new List<Mehsul>();
            // Verilənlər bazasında yaratdığınız View-dan istifadə edirik.
            // Bu, C# kodunu sadələşdirir, çünki JOIN əməliyyatları artıq bazada edilib.
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM vw_aktiv_mehsullar;";
                var command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            mehsullar.Add(new Mehsul
                            {
                                Id = (int)reader["id"],
                                Ad = reader["ad"].ToString(),
                                Barkod = reader["barkod"].ToString(),
                                KateqoriyaAdi = reader["kateqoriya"].ToString(),
                                VahidAdi = reader["vahid"].ToString(),
                                AlisQiymeti = (decimal)reader["alis_qiymeti"],
                                SatisQiymeti = (decimal)reader["satis_qiymeti"],
                                CariStok = (int)reader["cari_stok"],
                                MinimumStok = (int)reader["minimum_stok"],
                                Aktivdir = (bool)reader["aktivdir"]
                            });
                        }
                    }
                }
                catch (Exception ex) { throw; }
            }
            return mehsullar;
        }

        public int Add(Mehsul mehsul)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO mehsullar (ad, barkod, kateqoriya_id, vahid_id, alis_qiymeti, satis_qiymeti, minimum_stok, tedarukcu_id, tesvir, aktivdir) " +
                            "VALUES (@ad, @barkod, @kateqoriya_id, @vahid_id, @alis_qiymeti, @satis_qiymeti, @minimum_stok, @tedarukcu_id, @tesvir, @aktivdir); SELECT SCOPE_IDENTITY();";
                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ad", mehsul.Ad);
                command.Parameters.AddWithValue("@barkod", (object)mehsul.Barkod ?? DBNull.Value);
                command.Parameters.AddWithValue("@kateqoriya_id", mehsul.KateqoriyaId);
                command.Parameters.AddWithValue("@vahid_id", mehsul.VahidId);
                command.Parameters.AddWithValue("@alis_qiymeti", mehsul.AlisQiymeti);
                command.Parameters.AddWithValue("@satis_qiymeti", mehsul.SatisQiymeti);
                command.Parameters.AddWithValue("@minimum_stok", mehsul.MinimumStok);
                command.Parameters.AddWithValue("@tedarukcu_id", (object)mehsul.TedarukcuId ?? DBNull.Value);
                command.Parameters.AddWithValue("@tesvir", (object)mehsul.Tesvir ?? DBNull.Value);
                command.Parameters.AddWithValue("@aktivdir", mehsul.Aktivdir);

                try
                {
                    connection.Open();
                    // ExecuteScalar yeni yaradılan ID-ni qaytarır
                    return Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        // Update və Delete metodları da bura əlavə olunacaq
    }
}