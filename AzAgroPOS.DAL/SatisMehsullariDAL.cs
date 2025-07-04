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
                // Məhsulun adını da gətirmək üçün JOIN istifadə edirik
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
                                Miqdar = (int)reader["miqdar"],
                                QiymetBirEdede = (decimal)reader["qiymet_bir_edede"],
                                EndirimMeblegi = (decimal)reader["endirim_meblegi"]
                                // MehsulAdi xüsusiyyəti SatisMehsulu entity-sində yoxdur, onu SatisCartItem-ə bənzər ayrı bir modeldə saxlamaq olar
                                // Hələlik sadə saxlayırıq.
                            };
                            mehsullar.Add(satisMehsulu);
                        }
                    }
                }
                catch (Exception ex) { throw; }
            }
            return mehsullar;
        }
    }
}