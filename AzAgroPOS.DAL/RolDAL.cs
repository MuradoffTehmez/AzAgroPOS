using AzAgroPOS.DAL.Helpers;
using AzAgroPOS.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AzAgroPOS.DAL
{
    public class RolDAL
    {
        private readonly string _connectionString = DatabaseHelper.GetConnectionString();

        public List<Rol> GetAll()
        {
            var roller = new List<Rol>();
            using (var conn = new SqlConnection(_connectionString))
            {
                var query = "SELECT id, ad FROM rollar ORDER BY id";
                var command = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roller.Add(new Rol { Id = (int)reader["id"], Ad = reader["ad"].ToString() });
                        }
                    }
                }
                catch (Exception ex) { throw; }
            }
            return roller;
        }
    }
}