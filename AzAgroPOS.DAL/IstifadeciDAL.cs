// Fayl: AzAgroPOS.DAL/IstifadeciDAL.cs
using AzAgroPOS.Entities;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace AzAgroPOS.DAL
{
    public class IstifadeciDAL
    {
        private readonly string _connectionString;

        public IstifadeciDAL()
        {
            // App.config faylından bağlantı sətrini oxuyuruq
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public object ConfigurationManager { get; }

        /// <summary>
        /// Verilmiş istifadəçi adına görə verilənlər bazasından istifadəçini tapır.
        /// </summary>
        /// <param name="istifadeciAdi">Axtarılan istifadəçinin adı.</param>
        /// <returns>Tapılarsa Istifadeci obyekti, tapılmazsa null qaytarır.</returns>
        public Istifadeci GetByUsername(string istifadeciAdi)
        {
            Istifadeci istifadeci = null;

            // 'using' bloku bağlantının avtomatik bağlanmasını təmin edir.
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // SQL Injection hücumlarına qarşı parametrləşdirilmiş sorğu istifadə edirik.
                string query = "SELECT id, ad, soyad, istifadeci_adi, parol_hash, parol_salt, rol_id, aktivdir, son_giris_tarixi, yaradilma_tarixi, deaktivasiya_tarixi " +
                               "FROM istifadeciler WHERE istifadeci_adi = @istifadeci_adi";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@istifadeci_adi", istifadeciAdi);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Əgər nəticə varsa (istifadəçi tapılıbsa)
                        if (reader.Read())
                        {
                            // Reader-dən gələn məlumatları Istifadeci obyektinə doldururuq.
                            istifadeci = new Istifadeci
                            {
                                Id = (int)reader["id"],
                                Ad = reader["ad"].ToString(),
                                Soyad = reader["soyad"].ToString(),
                                IstifadeciAdi = reader["istifadeci_adi"].ToString(),
                                ParolHash = reader["parol_hash"].ToString(),
                                ParolSalt = reader["parol_salt"].ToString(),
                                RolId = (int)reader["rol_id"],
                                Aktivdir = (bool)reader["aktivdir"],
                                // DBNull-a qarşı yoxlama
                                SonGirisTarixi = reader["son_giris_tarixi"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["son_giris_tarixi"],
                                YaradilmaTarixi = (DateTime)reader["yaradilma_tarixi"],
                                DeaktivasiyaTarixi = reader["deaktivasiya_tarixi"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["deaktivasiya_tarixi"]
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Real tətbiqdə burada xətaları log faylına yazmaq vacibdir.
                    Console.WriteLine(ex.Message);
                }
            }

            return istifadeci;
        }

        // Gələcəkdə istifadəçiləri əlavə etmək, redaktə etmək və silmək üçün metodlar da bura yazılacaq.
        // public void Add(Istifadeci istifadeci) { ... }
        // public void Update(Istifadeci istifadeci) { ... }
    }
}