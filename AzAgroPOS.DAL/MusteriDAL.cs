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
                // Axtarış sözünü həm ad, həm soyad, həm də telefonda axtarırıq
                var query = "SELECT id, ad, soyad, telefon, cari_nisye_borcu FROM musteriler " +
                            "WHERE (ad + ' ' + soyad LIKE @term) OR (telefon LIKE @term)";
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
    }
}