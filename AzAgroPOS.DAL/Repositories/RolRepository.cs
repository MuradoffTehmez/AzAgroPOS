using AzAgroPOS.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace AzAgroPOS.DAL.Repositories
{
    public class RolRepository
    {
        // Verilənlər bazasına qoşulma sətrini App.config-dən oxumaq üçün
        private readonly string _connectionString;

        public RolRepository()
        {
            // Konstruktorda App.config faylından qoşulma sətrini götürürük.
            //_connectionString = ConfigurationManager.ConnectionStrings["AzAgroPOS_DB_Conn"].ConnectionString;
        }

        // Bütün rolları siyahı şəklində qaytaran metod
        public List<Rol> GetAll()
        {
            var roller = new List<Rol>();

            // 'using' bloku qoşulmanın hər zaman avtomatik bağlanmasını təmin edir. Bu, çox vacibdir.
            using (var connection = new SqlConnection(_connectionString))
            {
                // SQL sorğusunu hazırlayırıq
                var command = new SqlCommand("SELECT Id, Ad, YaradilmaTarixi FROM dbo.Rol", connection);

                // Qoşulmanı açırıq
                connection.Open();

                // Sorğunu icra edib nəticələri oxumaq üçün 'DataReader' istifadə edirik
                using (var reader = command.ExecuteReader())
                {
                    // Nəticə olduğu müddətcə dövr edirik
                    while (reader.Read())
                    {
                        // Hər bir sətir üçün yeni bir Rol obyekti yaradırıq
                        var rol = new Rol
                        {
                            // Məlumatları oxuyub obyektin xassələrinə mənimsədirik
                            Id = Convert.ToInt32(reader["Id"]),
                            Ad = reader["Ad"].ToString(),
                            // DBNull-u yoxlayırıq, çünki tarix NULL ola bilər
                            YaradilmaTarixi = reader["YaradilmaTarixi"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["YaradilmaTarixi"])
                        };
                        roller.Add(rol);
                    }
                }
            }

            return roller;
        }

        // Gələcəkdə digər metodlar (GetById, Add, Update, Delete) bura əlavə ediləcək...
    }
}