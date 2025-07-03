using AzAgroPOS.DAL.Helpers;
using AzAgroPOS.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AzAgroPOS.DAL
{
    public class VahidDAL
    {
        private readonly string _connectionString;

        public VahidDAL()
        {
            _connectionString = DatabaseHelper.GetConnectionString();
        }

        public List<Vahid> GetAll()
        {
            var vahidler = new List<Vahid>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT id, ad, qisaltma FROM vahidler ORDER BY ad;";
                var command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            vahidler.Add(new Vahid
                            {
                                Id = (int)reader["id"],
                                Ad = reader["ad"].ToString(),
                                Qisaltma = reader["qisaltma"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return vahidler;
        }
    }
}