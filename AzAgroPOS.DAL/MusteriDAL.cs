// Fayl: AzAgroPOS.DAL/MusteriDAL.cs
using AzAgroPOS.DAL.Helpers;
using AzAgroPOS.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AzAgroPOS.DAL
{
    public class MusteriDAL
    {
        private readonly string _connectionString = DatabaseHelper.GetConnectionString();

        public List<Musteri> SearchByNameOrPhone(string searchTerm)
        {
            var musteriler = new List<Musteri>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT id, ad, soyad, telefon, cari_nisye_borcu FROM musteriler " +
                            "WHERE ad LIKE @term OR soyad LIKE @term OR telefon LIKE @term";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@term", "%" + searchTerm + "%");
                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            musteriler.Add(new Musteri
                            {
                                Id = (int)reader["id"],
                                Ad = reader["ad"].ToString(),
                                Soyad = reader["soyad"].ToString(),
                                Telefon = reader["telefon"].ToString(),
                                CariNisyeBorcu = (decimal)reader["cari_nisye_borcu"]
                            });
                        }
                    }
                }
                catch (Exception ex) { throw; }
            }
            return musteriler;
        }
        public void UpdateNisyeBorcu(int musteriId, decimal elaveOlunanBorc, SqlConnection connection, SqlTransaction transaction)
        {
            var query = "UPDATE musteriler SET cari_nisye_borcu = cari_nisye_borcu + @elave_olunan_borc WHERE id = @id;";
            var command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@elave_olunan_borc", elaveOlunanBorc);
            command.Parameters.AddWithValue("@id", musteriId);
            command.ExecuteNonQuery();
        }

    }
}