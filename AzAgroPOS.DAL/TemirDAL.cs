using AzAgroPOS.DAL.Helpers;
using AzAgroPOS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AzAgroPOS.DAL
{
    public class TemirDAL
    {
        private readonly string _connectionString = DatabaseHelper.GetConnectionString();

        public List<Temir> GetAll()
        {
            var temirler = new List<Temir>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"SELECT 
                                t.*,
                                m.ad + ' ' + m.soyad as MusteriAdi,
                                ts.ad as StatusAdi,
                                ISNULL(i.ad + ' ' + i.soyad, 'Təyin edilməyib') as TemirciAdi
                              FROM temirler t
                              JOIN musteriler m ON t.musteri_id = m.id
                              JOIN temir_statuslari ts ON t.status_id = ts.id
                              LEFT JOIN istifadeciler i ON t.temirci_id = i.id
                              ORDER BY t.qebul_tarixi DESC";
                var command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            temirler.Add(MapTemir(reader));
                        }
                    }
                }
                catch (Exception ex) { throw; }
            }
            return temirler;
        }

        public int Add(Temir temir)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO temirler (musteri_id, cihaz_adi, marka, model, seriya_nomresi, problem_tesviri, status_id, temirci_id, qebul_tarixi) " +
                            "VALUES (@musteri_id, @cihaz_adi, @marka, @model, @seriya_nomresi, @problem_tesviri, @status_id, @temirci_id, @qebul_tarixi); SELECT SCOPE_IDENTITY();";
                var command = new SqlCommand(query, connection);

                command.Parameters.Add("@musteri_id", SqlDbType.Int).Value = temir.MusteriId;
                command.Parameters.Add("@cihaz_adi", SqlDbType.NVarChar).Value = temir.CihazAdi;
                command.Parameters.Add("@marka", SqlDbType.NVarChar).Value = (object)temir.Marka ?? DBNull.Value;
                command.Parameters.Add("@model", SqlDbType.NVarChar).Value = (object)temir.Model ?? DBNull.Value;
                command.Parameters.Add("@seriya_nomresi", SqlDbType.NVarChar).Value = (object)temir.SeriyaNomresi ?? DBNull.Value;
                command.Parameters.Add("@problem_tesviri", SqlDbType.NVarChar).Value = temir.ProblemTesviri;
                command.Parameters.Add("@status_id", SqlDbType.Int).Value = temir.StatusId;
                command.Parameters.Add("@temirci_id", SqlDbType.Int).Value = (object)temir.TemirciId ?? DBNull.Value;
                command.Parameters.Add("@qebul_tarixi", SqlDbType.DateTime).Value = DateTime.Now;

                try
                {
                    connection.Open();
                    return Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex) { throw; }
            }
        }

        public bool Update(Temir temir)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE temirler SET musteri_id=@musteri_id, cihaz_adi=@cihaz_adi, marka=@marka, model=@model, " +
                            "seriya_nomresi=@seriya_nomresi, problem_tesviri=@problem_tesviri, status_id=@status_id, temirci_id=@temirci_id " +
                            "WHERE id=@id";
                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", temir.Id);
                command.Parameters.Add("@musteri_id", SqlDbType.Int).Value = temir.MusteriId;
                command.Parameters.Add("@cihaz_adi", SqlDbType.NVarChar).Value = temir.CihazAdi;
                command.Parameters.Add("@marka", SqlDbType.NVarChar).Value = (object)temir.Marka ?? DBNull.Value;
                command.Parameters.Add("@model", SqlDbType.NVarChar).Value = (object)temir.Model ?? DBNull.Value;
                command.Parameters.Add("@seriya_nomresi", SqlDbType.NVarChar).Value = (object)temir.SeriyaNomresi ?? DBNull.Value;
                command.Parameters.Add("@problem_tesviri", SqlDbType.NVarChar).Value = temir.ProblemTesviri;
                command.Parameters.Add("@status_id", SqlDbType.Int).Value = temir.StatusId;
                command.Parameters.Add("@temirci_id", SqlDbType.Int).Value = (object)temir.TemirciId ?? DBNull.Value;

                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex) { throw; }
            }
        }

        public bool Delete(int temirId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM temirler WHERE id=@id";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", temirId);
                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex) { throw; }
            }
        }

        private Temir MapTemir(SqlDataReader reader)
        {
            return new Temir
            {
                Id = (int)reader["id"],
                MusteriId = (int)reader["musteri_id"],
                CihazAdi = reader["cihaz_adi"].ToString(),
                Marka = reader["marka"].ToString(),
                Model = reader["model"].ToString(),
                SeriyaNomresi = reader["seriya_nomresi"].ToString(),
                ProblemTesviri = reader["problem_tesviri"].ToString(),
                QebulTarixi = (DateTime)reader["qebul_tarixi"],
                StatusId = (int)reader["status_id"],
                TemirciId = reader["temirci_id"] as int?,
                MusteriAdi = reader["MusteriAdi"].ToString(),
                StatusAdi = reader["StatusAdi"].ToString(),
                TemirciAdi = reader["TemirciAdi"].ToString()
            };
        }

        public bool CompleteRepair(int temirId, decimal yekunXerc)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                // Təmiri tamamlanmış statusuna keçiririk (Məsələn, status ID=6 "Təhvil verildi")
                // və yekun qiyməti, faktiki tamamlama tarixini qeyd edirik.
                var query = "UPDATE temirler SET yekun_baxim_xerci = @yekun_xerc, status_id = 6, faktiki_tamamlama_tarixi = GETDATE() WHERE id = @id";
                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@yekun_xerc", yekunXerc);
                command.Parameters.AddWithValue("@id", temirId);

                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        // TemirDAL.cs sinifinin içinə əlavə edin

        /// <summary>
        /// Verilmiş ID-yə görə tək bir təmiri tapır.
        /// </summary>
        public Temir GetById(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                // GetAll metodundakı kimi JOIN-li sorğu istifadə edirik ki, bütün adlar gəlsin
                var query = @"SELECT 
                        t.*,
                        m.ad + ' ' + m.soyad as MusteriAdi,
                        ts.ad as StatusAdi,
                        ISNULL(i.ad + ' ' + i.soyad, 'Təyin edilməyib') as TemirciAdi
                      FROM temirler t
                      JOIN musteriler m ON t.musteri_id = m.id
                      JOIN temir_statuslari ts ON t.status_id = ts.id
                      LEFT JOIN istifadeciler i ON t.temirci_id = i.id
                      WHERE t.id = @id";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    conn.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapTemir(reader);
                        }
                    }
                }
                catch (Exception ex) { throw; }
            }
            return null;
        }

    }
}