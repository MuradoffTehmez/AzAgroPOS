// Fayl: AzAgroPOS.DAL/EmeliyyatJurnaliDAL.cs
using AzAgroPOS.DAL.Helpers;
using AzAgroPOS.Entities;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AzAgroPOS.DAL
{
    public class EmeliyyatJurnaliDAL
    {
        private readonly string _connectionString = DatabaseHelper.GetConnectionString();

        public void Add(EmeliyyatJurnali log)
        {
            
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var query = "INSERT INTO emeliyyat_jurnali (istifadeci_id, emeliyyat_novu, tesvir) VALUES (@istifadeci_id, @emeliyyat_novu, @tesvir)";
                    var command = new SqlCommand(query, connection);
                    command.Parameters.Add("@istifadeci_id", SqlDbType.Int).Value = log.IstifadeciId;
                    command.Parameters.Add("@emeliyyat_novu", SqlDbType.NVarChar).Value = log.EmeliyyatNovu;
                    command.Parameters.Add("@tesvir", SqlDbType.NVarChar).Value = log.Tesvir;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Xətanı bir fayla və ya Windows Event Log-a yazmaq daha yaxşıdır.
                // Hələlik sadəcə Debug pəncərəsində göstəririk.
                System.Diagnostics.Debug.WriteLine("Audit Log Xətası: " + ex.Message);
            }
        }

        // Jurnala baxış pəncərəsi üçün axtarış metodu növbəti addımda yazılacaq.
    }
}