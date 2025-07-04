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

        /// <summary>
        /// Bütün aktiv məhsulları, kateqoriya və vahid adları ilə birlikdə gətirir.
        /// </summary>
        public List<Mehsul> GetAll()
        {
            var mehsullar = new List<Mehsul>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"SELECT 
                                m.id, m.ad, m.barkod, 
                                m.kateqoriya_id, k.ad as KateqoriyaAdi, 
                                m.vahid_id, v.ad as VahidAdi, 
                                m.alis_qiymeti, m.satis_qiymeti, 
                                m.cari_stok, m.minimum_stok, m.aktivdir 
                              FROM mehsullar m
                              LEFT JOIN kateqoriyalar k ON m.kateqoriya_id = k.id
                              LEFT JOIN vahidler v ON m.vahid_id = v.id
                              WHERE m.silinib = 0";
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
                                KateqoriyaId = (int)reader["kateqoriya_id"],
                                KateqoriyaAdi = reader["KateqoriyaAdi"].ToString(),
                                VahidId = (int)reader["vahid_id"],
                                VahidAdi = reader["VahidAdi"].ToString(),
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

        /// <summary>
        /// Verilənlər bazasına yeni məhsul əlavə edir.
        /// </summary>
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
                    return Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Mövcud məhsulun məlumatlarını yeniləyir.
        /// </summary>
        public bool Update(Mehsul mehsul)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE mehsullar SET ad=@ad, barkod=@barkod, kateqoriya_id=@kateqoriya_id, vahid_id=@vahid_id, " +
                            "alis_qiymeti=@alis_qiymeti, satis_qiymeti=@satis_qiymeti, minimum_stok=@minimum_stok, " +
                            "tedarukcu_id=@tedarukcu_id, tesvir=@tesvir, aktivdir=@aktivdir, son_deyisiklik=GETDATE() WHERE id=@id";
                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", mehsul.Id);
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
                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Məhsulu verilənlər bazasından fiziki olaraq silmir,
        /// sadəcə "silinib" statusunu 1 olaraq təyin edir (Soft Delete).
        /// </summary>
        public bool Delete(int mehsulId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                // Məhsulu həm silinmiş işarələyirik, həm də deaktiv edirik.
                var query = "UPDATE mehsullar SET silinib = 1, aktivdir = 0, son_deyisiklik=GETDATE() WHERE id=@id";
                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", mehsulId);

                try
                {
                    connection.Open();
                    // Dəyişdirilmiş sətir sayı 0-dan böyükdürsə, deməli uğurludur.
                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}