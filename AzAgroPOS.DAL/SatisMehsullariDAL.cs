// Fayl: AzAgroPOS.DAL/SatisMehsullariDAL.cs
using AzAgroPOS.DAL.Helpers;
using AzAgroPOS.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AzAgroPOS.DAL
{
    public class SatisMehsullariDAL
    {
        private readonly string _connectionString = DatabaseHelper.GetConnectionString();

        public List<SatisMehsulu> GetBySatisId(int satisId)
        {
            var mehsullar = new List<SatisMehsulu>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT sm.*, m.ad as MehsulAdi FROM satis_mehsullari sm JOIN mehsullar m ON sm.mehsul_id = m.id WHERE sm.satis_id = @satis_id";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@satis_id", satisId);
                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var satisMehsulu = new SatisMehsulu
                            {
                                Id = (int)reader["id"],
                                SatisId = (int)reader["satis_id"],
                                MehsulId = (int)reader["mehsul_id"],
                                MehsulAdi = reader["MehsulAdi"].ToString(),
                                Miqdar = (int)reader["miqdar"],
                                QiymetBirEdede = (decimal)reader["qiymet_bir_edede"],
                                EndirimMeblegi = (decimal)reader["endirim_meblegi"]
                            };
                            mehsullar.Add(satisMehsulu);
                        }
                    }
                }
                catch (Exception ex) { throw; }
            }
            return mehsullar;
        }

        public SatisMehsulu GetById(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = "SELECT sm.*, m.ad as MehsulAdi FROM satis_mehsullari sm JOIN mehsullar m ON sm.mehsul_id = m.id WHERE sm.id = @id";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    conn.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new SatisMehsulu { /* ... Map metodu ilə doldurun ... */ };
                        }
                    }
                }
                catch (Exception ex) { throw; }
            }
            return null; // <-- XƏTANIN HƏLLİ: Bütün yollar bir dəyər qaytarmalıdır.
        }

        public bool Add(SatisMehsulu satisMehsulu)
        {
            throw new NotImplementedException("Bu funksionallıq ayrıca 'Satışa Düzəliş' modulunda yazılacaq.");
        }

        public bool Remove(int satisMehsulId)
        {
            throw new NotImplementedException("Bu funksionallıq ayrıca 'Satışdan Qaytarma' modulunda yazılacaq.");
        }
    }
}