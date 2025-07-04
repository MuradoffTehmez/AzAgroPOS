// Fayl: AzAgroPOS.DAL/TemirDAL.cs
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
        public int Add(Temir temir)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO temirler (musteri_id, cihaz_adi, marka, model, seriya_nomresi, problem_tesviri, status_id, temirci_id) " +
                            "VALUES (@musteri_id, @cihaz_adi, @marka, @model, @seriya_nomresi, @problem_tesviri, @status_id, @temirci_id); SELECT SCOPE_IDENTITY();";
                var command = new SqlCommand(query, connection);
                command.Parameters.Add("@musteri_id", SqlDbType.Int).Value = temir.MusteriId;
                command.Parameters.Add("@cihaz_adi", SqlDbType.NVarChar).Value = temir.CihazAdi;
                command.Parameters.Add("@marka", SqlDbType.NVarChar).Value = (object)temir.Marka ?? DBNull.Value;
                command.Parameters.Add("@model", SqlDbType.NVarChar).Value = (object)temir.Model ?? DBNull.Value;
                command.Parameters.Add("@seriya_nomresi", SqlDbType.NVarChar).Value = (object)temir.SeriyaNomresi ?? DBNull.Value;
                command.Parameters.Add("@problem_tesviri", SqlDbType.NVarChar).Value = temir.ProblemTesviri;
                command.Parameters.Add("@status_id", SqlDbType.Int).Value = temir.StatusId;
                command.Parameters.Add("@temirci_id", SqlDbType.Int).Value = (object)temir.TemirciId ?? DBNull.Value;

                connection.Open();
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        // GetAll, Update, Delete metodları növbəti addımlarda əlavə olunacaq
    }
}