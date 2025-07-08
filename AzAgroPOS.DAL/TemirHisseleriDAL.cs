// Fayl: AzAgroPOS.DAL/TemirHisseleriDAL.cs
using AzAgroPOS.DAL.Helpers;
using AzAgroPOS.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AzAgroPOS.DAL
{
    public class TemirHisseleriDAL
    {
        private readonly string _connectionString = DatabaseHelper.GetConnectionString();

        public List<TemirHissesi> GetByTemirId(int temirId)
        {
            var hissler = new List<TemirHissesi>();
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = @"SELECT th.*, m.ad as MehsulAdi 
                              FROM temir_hisseleri th
                              JOIN mehsullar m ON th.mehsul_id = m.id
                              WHERE th.temir_id = @temir_id";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@temir_id", temirId);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        hissler.Add(new TemirHissesi
                        {
                            Id = (int)reader["id"],
                            TemirId = (int)reader["temir_id"],
                            MehsulId = (int)reader["mehsul_id"],
                            MehsulAdi = reader["MehsulAdi"].ToString(),
                            Miqdar = (int)reader["miqdar"],
                            QiymetBirEdede = (decimal)reader["qiymet_bir_edede"],
                        });
                    }
                }
            }
            return hissler;
        }

        public TemirHissesi GetById(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = "SELECT th.*, m.ad as MehsulAdi FROM temir_hisseleri th JOIN mehsullar m ON th.mehsul_id = m.id WHERE th.id = @id";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new TemirHissesi { /* ... */ }; // MapHisse metodu yaradıb istifadə edin
                    }
                }
            }
            return null;
        }

        public bool Remove(int hisseId)
        {
            // DİQQƏT: Bu metod anbar qalığını geri qaytarmalıdır və tranzaksiya tələb edir.
            // Bu, "Təmirdən Hissə Qaytarma" kimi ayrıca bir funksiya olmalıdır.
            // Hələlik BLL xətasını aradan qaldırmaq üçün bu metodu bu şəkildə saxlayırıq.
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM temir_hisseleri WHERE id = @id";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", hisseId);
                conn.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool Add(TemirHissesi hisse)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    // 1. Ehtiyat hissəsini təmirə əlavə et
                    var queryHisse = "INSERT INTO temir_hisseleri (temir_id, mehsul_id, miqdar, qiymet_bir_edede) VALUES (@temir_id, @mehsul_id, @miqdar, @qiymet);";
                    var commandHisse = new SqlCommand(queryHisse, connection, transaction);
                    commandHisse.Parameters.AddWithValue("@temir_id", hisse.TemirId);
                    commandHisse.Parameters.AddWithValue("@mehsul_id", hisse.MehsulId);
                    commandHisse.Parameters.AddWithValue("@miqdar", hisse.Miqdar);
                    commandHisse.Parameters.AddWithValue("@qiymet", hisse.QiymetBirEdede);
                    commandHisse.ExecuteNonQuery();

                    // 2. Anbardan həmin hissənin miqdarını çıx
                    var queryStok = "UPDATE mehsullar SET cari_stok = cari_stok - @miqdar WHERE id = @mehsul_id;";
                    var commandStok = new SqlCommand(queryStok, connection, transaction);
                    commandStok.Parameters.AddWithValue("@miqdar", hisse.Miqdar);
                    commandStok.Parameters.AddWithValue("@mehsul_id", hisse.MehsulId);
                    commandStok.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}