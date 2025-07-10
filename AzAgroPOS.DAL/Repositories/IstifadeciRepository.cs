using AzAgroPOS.Entities.Domain;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace AzAgroPOS.DAL.Repositories
{
    public class IstifadeciRepository
    {
        private readonly string _connectionString;

        public IstifadeciRepository()
        {
            //_connectionString = ConfigurationManager.ConnectionStrings["AzAgroPOS_DB_Conn"].ConnectionString;
        }

        public Istifadeci GetByEmail(string email)
        {
            Istifadeci istifadeci = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                // SQL Injection-dan qorunmaq üçün @email parametrindən istifadə edirik
                var command = new SqlCommand("SELECT * FROM dbo.Istifadeci WHERE Email = @Email", connection);
                command.Parameters.AddWithValue("@Email", email);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read()) // Əgər nəticə varsa (istifadəçi tapılıbsa)
                    {
                        istifadeci = new Istifadeci
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Ad = reader["Ad"].ToString(),
                            Soyad = reader["Soyad"].ToString(),
                            Email = reader["Email"].ToString(),
                            ParolHash = reader["ParolHash"].ToString(),
                            RolId = reader["RolId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["RolId"]),
                            TemaId = reader["TemaId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["TemaId"]),
                            Status = reader["Status"].ToString()
                        };
                    }
                }
            }

            return istifadeci;
        }
    }
}