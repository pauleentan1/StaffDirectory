using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace StaffDirectory
{
    public class Repository
    {
        #region Connection String
        const string srvrdbname = "ROIDB";
        const string srvrname = "192.168.0.103";
        const string srvrusername = "Abi";
        const string srvrpassword = "art12345";
        private string _connectionString;
        public Repository()
        {
            _connectionString = $"Data Source={srvrname};Initial Catalog={srvrdbname};User ID={srvrusername};Password={srvrpassword}";
        }
        #endregion

        #region Get Staff
        public IEnumerable<Staff> GetStaff()
        {
            var staffList = new List<Staff>();
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("SELECT * FROM Staff", connection))
            {
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var aStaff = new Staff
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Position = reader.GetString(2),
                            Department = reader.GetString(3)
                        };
                        staffList.Add(aStaff);

                    }
                }
            }
            return staffList;
        }
        #endregion

        #region Update Staff
        public int UpdateStaff(Staff p)
        {
            int result = 0;
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand())
            {
                command.CommandText = "UPDATE Staff SET Name=@Name,Position=@Position,Department=@Department WHERE Id = @id";
                command.Parameters.AddWithValue("@id", p.Id);
                command.Parameters.AddWithValue("@Name", p.Name);
                command.Parameters.AddWithValue("@Position", p.Position);
                command.Parameters.AddWithValue("@Department", p.Department);

                command.Connection = connection;
                connection.Open();
                result = command.ExecuteNonQuery();
            }
            return result;
        }
        #endregion

        #region Insert Staff
        public int InsertStaff(Staff p)
        {
            int result = 0;
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand())
            {
                command.CommandText = "INSERT INTO Staff VALUES (@Name,@Position,@Department)";
                //command.Parameters.AddWithValue("@id", p.Id);
                command.Parameters.AddWithValue("@Name", p.Name);
                command.Parameters.AddWithValue("@Position", p.Position);
                command.Parameters.AddWithValue("@Department", p.Department);
                command.Connection = connection;
                connection.Open();
                result = command.ExecuteNonQuery();
            }
            return result;
        }
        #endregion

        #region Delete Staff
        public int DeleteStaff(Staff p)
        {
            int result = 0;
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand())
            {
                command.CommandText = "DELETE FROM Staff WHERE Id=@id";
                command.Parameters.AddWithValue("@id", p.Id);
                command.Connection = connection;
                connection.Open();
                result = command.ExecuteNonQuery();
            }
            return result;
        }
        #endregion
    }
}
