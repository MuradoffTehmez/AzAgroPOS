using AzAgroPOS.DAL.Helpers;
using AzAgroPOS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AzAgroPOS.DAL
{
    /// <summary>
    /// İstifadəçilərlə bağlı verilənlər bazası əməliyyatlarını həyata keçirir.
    /// </summary>
    public class IstifadeciDAL
    {
        private readonly string _connectionString = DatabaseHelper.GetConnectionString();

        /// <summary>
        /// İstifadəçi adına görə istifadəçi məlumatlarını gətirir.
        /// </summary>
        /// <param name="istifadeciAdi">İstifadəçi adı</param>
        /// <returns>İstifadəçi obyekti</returns>
        public Istifadeci GetByUsername(string istifadeciAdi)
        {
            Istifadeci istifadeci = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"SELECT i.*, r.ad as RolAdi 
                               FROM istifadeciler i 
                               JOIN rollar r ON i.rol_id = r.id 
                               WHERE i.istifadeci_adi = @istifadeci_adi";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@istifadeci_adi", istifadeciAdi);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            istifadeci = MapIstifadeci(reader);
                        }
                    }
                }
                catch (Exception ex) { throw new Exception("İstifadəçi tapılarkən xəta.", ex); }
            }
            return istifadeci;
        }

        /// <summary>
        /// Bütün istifadəçilərin siyahısını gətirir.
        /// </summary>
        /// <returns>İstifadəçilər siyahısı</returns>
        public List<Istifadeci> GetAll()
        {
            var istifadeciler = new List<Istifadeci>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT i.*, r.ad as RolAdi FROM istifadeciler i JOIN rollar r ON i.rol_id = r.id";
                var command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            istifadeciler.Add(MapIstifadeci(reader));
                        }
                    }
                }
                catch (Exception ex) { throw; }
            }
            return istifadeciler;
        }

        /// <summary>
        /// Müəyyən rola malik istifadəçiləri gətirir.
        /// </summary>
        /// <param name="roleName">Rol adı</param>
        /// <returns>İstifadəçilər siyahısı</returns>
        public List<Istifadeci> GetAllByRole(string roleName)
        {
            var istifadeciler = new List<Istifadeci>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"SELECT i.id, i.ad, i.soyad FROM istifadeciler i 
                            JOIN rollar r ON i.rol_id = r.id 
                            WHERE r.ad = @roleName AND i.aktivdir = 1";
                var command = new SqlCommand(query, connection);
                command.Parameters.Add("@roleName", SqlDbType.NVarChar).Value = roleName;
                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            istifadeciler.Add(new Istifadeci
                            {
                                Id = (int)reader["id"],
                                Ad = reader["ad"].ToString(),
                                Soyad = reader["soyad"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex) { throw; }
            }
            return istifadeciler;
        }

        /// <summary>
        /// Yeni istifadəçi əlavə edir.
        /// </summary>
        /// <param name="istifadeci">Əlavə ediləcək istifadəçi</param>
        /// <returns>Yaradılan istifadəçinin ID-si</returns>
        public int Add(Istifadeci istifadeci)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"INSERT INTO istifadeciler 
                            (ad, soyad, istifadeci_adi, parol_hash, parol_salt, rol_id, aktivdir) 
                            VALUES (@ad, @soyad, @istifadeci_adi, @parol_hash, @parol_salt, @rol_id, @aktivdir); 
                            SELECT SCOPE_IDENTITY();";
                var command = new SqlCommand(query, connection);
                AddParameters(command, istifadeci);
                try
                {
                    connection.Open();
                    return Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex) { throw; }
            }
        }

        /// <summary>
        /// Mövcud istifadəçinin məlumatlarını yeniləyir.
        /// </summary>
        /// <param name="istifadeci">Yenilənəcək istifadəçi</param>
        /// <returns>Yeniləmənin uğurlu olub-olmadığı</returns>
        public bool Update(Istifadeci istifadeci)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = string.IsNullOrWhiteSpace(istifadeci.ParolHash)
                    ? @"UPDATE istifadeciler SET 
                        ad=@ad, soyad=@soyad, istifadeci_adi=@istifadeci_adi, 
                        rol_id=@rol_id, aktivdir=@aktivdir 
                        WHERE id=@id"
                    : @"UPDATE istifadeciler SET 
                        ad=@ad, soyad=@soyad, istifadeci_adi=@istifadeci_adi, 
                        parol_hash=@parol_hash, parol_salt=@parol_salt, 
                        rol_id=@rol_id, aktivdir=@aktivdir 
                        WHERE id=@id";

                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", istifadeci.Id);
                AddParameters(command, istifadeci);
                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex) { throw; }
            }
        }

        /// <summary>
        /// İstifadəçini deaktiv edir (silir).
        /// </summary>
        /// <param name="istifadeciId">Deaktiv ediləcək istifadəçi ID-si</param>
        /// <returns>Əməliyyatın uğurlu olub-olmadığı</returns>
        public bool Delete(int istifadeciId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"UPDATE istifadeciler SET 
                            aktivdir = 0, deaktivasiya_tarixi = GETDATE() 
                            WHERE id=@id";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", istifadeciId);
                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex) { throw; }
            }
        }

        /// <summary>
        /// İstifadəçi adının artıq mövcud olub-olmadığını yoxlayır.
        /// </summary>
        /// <param name="istifadeciAdi">Yoxlanılacaq istifadəçi adı</param>
        /// <returns>Mövcud olub-olmadığı</returns>
        public bool Exists(string istifadeciAdi)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT COUNT(1) FROM istifadeciler WHERE istifadeci_adi = @istifadeci_adi";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@istifadeci_adi", istifadeciAdi);

                try
                {
                    connection.Open();
                    return (int)command.ExecuteScalar() > 0;
                }
                catch (Exception ex) { throw; }
            }
        }

        /// <summary>
        /// Rolun istifadəçilərə təyin edilib-edilmədiyini yoxlayır.
        /// </summary>
        /// <param name="rolId">Yoxlanılacaq rol ID-si</param>
        /// <returns>Təyin edilib-edilmədiyi</returns>
        public bool IsRoleAssignedToUsers(int rolId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT COUNT(1) FROM istifadeciler WHERE rol_id = @rol_id AND aktivdir = 1";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@rol_id", rolId);

                try
                {
                    connection.Open();
                    return (int)command.ExecuteScalar() > 0;
                }
                catch (Exception ex) { throw; }
            }
        }

        #region Köməkçi metodlar
        private void AddParameters(SqlCommand command, Istifadeci istifadeci)
        {
            command.Parameters.Add("@ad", SqlDbType.NVarChar).Value = istifadeci.Ad;
            command.Parameters.Add("@soyad", SqlDbType.NVarChar).Value = istifadeci.Soyad;
            command.Parameters.Add("@istifadeci_adi", SqlDbType.NVarChar).Value = istifadeci.IstifadeciAdi;
            command.Parameters.Add("@rol_id", SqlDbType.Int).Value = istifadeci.RolId;
            command.Parameters.Add("@aktivdir", SqlDbType.Bit).Value = istifadeci.Aktivdir;

            if (!string.IsNullOrWhiteSpace(istifadeci.ParolHash))
            {
                command.Parameters.Add("@parol_hash", SqlDbType.NVarChar).Value = istifadeci.ParolHash;
                command.Parameters.Add("@parol_salt", SqlDbType.NVarChar).Value = istifadeci.ParolSalt;
            }
        }

        private Istifadeci MapIstifadeci(SqlDataReader reader)
        {
            return new Istifadeci
            {
                Id = (int)reader["id"],
                Ad = reader["ad"].ToString(),
                Soyad = reader["soyad"].ToString(),
                IstifadeciAdi = reader["istifadeci_adi"].ToString(),
                ParolHash = reader["parol_hash"].ToString(),
                ParolSalt = reader["parol_salt"].ToString(),
                RolId = (int)reader["rol_id"],
                RolAdi = ColumnExists(reader, "RolAdi") ? reader["RolAdi"].ToString() : string.Empty,
                Aktivdir = (bool)reader["aktivdir"],
                SonGirisTarixi = reader["son_giris_tarixi"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["son_giris_tarixi"],
                YaradilmaTarixi = (DateTime)reader["yaradilma_tarixi"],
                DeaktivasiyaTarixi = reader["deaktivasiya_tarixi"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["deaktivasiya_tarixi"]
            };
        }

        private bool ColumnExists(SqlDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}