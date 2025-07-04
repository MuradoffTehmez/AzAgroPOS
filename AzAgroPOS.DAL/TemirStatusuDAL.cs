// Fayl: AzAgroPOS.DAL/TemirStatusuDAL.cs
using AzAgroPOS.DAL.Helpers;
using AzAgroPOS.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AzAgroPOS.DAL
{
    public class TemirStatusuDAL
    {
        private readonly string _connectionString = DatabaseHelper.GetConnectionString();
        public List<TemirStatusu> GetAll()
        {
            var statuslar = new List<TemirStatusu>();
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = "SELECT id, ad FROM temir_statuslari ORDER BY siralama";
                var command = new SqlCommand(query, conn);
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        statuslar.Add(new TemirStatusu { Id = (int)reader["id"], Ad = reader["ad"].ToString() });
                    }
                }
            }
            return statuslar;
        }
    }
}