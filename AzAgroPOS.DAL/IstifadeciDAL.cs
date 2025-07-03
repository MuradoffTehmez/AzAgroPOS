using AzAgroPOS.DAL.Helpers;
using AzAgroPOS.Entities;
using System;
using System.Data.SqlClient;

namespace AzAgroPOS.DAL
{
    public class IstifadeciDAL
    {
        private readonly string _connectionString;

        public IstifadeciDAL()
        {
            _connectionString = DatabaseHelper.GetConnectionString();
        }

        public Istifadeci GetByUsername(string istifadeciAdi)
        {
            Istifadeci istifadeci = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT id, ad, soyad, istifadeci_adi, parol_hash, parol_salt, rol_id, aktivdir, son_giris_tarixi, yaradilma_tarixi, deaktivasiya_tarixi " +
                               "FROM istifadeciler WHERE istifadeci_adi = @istifadeci_adi";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@istifadeci_adi", istifadeciAdi);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
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
                                SonGirisTarixi = reader["son_giris_tarixi"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["son_giris_tarixi"],
                                YaradilmaTarixi = (DateTime)reader["yaradilma_tarixi"],
                                DeaktivasiyaTarixi = reader["deaktivasiya_tarixi"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["deaktivasiya_tarixi"]
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while getting user by username.", ex);
                }
            }
            return istifadeci;
        }
    }
}