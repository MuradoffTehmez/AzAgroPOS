using AzAgroPOS.DAL.Helpers;
using AzAgroPOS.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AzAgroPOS.DAL
{
    public class KateqoriyaDAL
    {
        private readonly string _connectionString;

        public KateqoriyaDAL()
        {
            _connectionString = DatabaseHelper.GetConnectionString();
        }

        public List<Kateqoriya> GetAll()
        {
            var kateqoriyalar = new List<Kateqoriya>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT id, ad FROM kateqoriyalar WHERE aktivdir = 1 ORDER BY ad;";
                var command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            kateqoriyalar.Add(new Kateqoriya
                            {
                                Id = (int)reader["id"],
                                Ad = reader["ad"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return kateqoriyalar;
        }
    }
}