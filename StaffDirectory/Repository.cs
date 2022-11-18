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
        const string srvrdbname = "StoreDB";
        const string srvrname = "192.168.1.132";
        const string srvrusername = "shaun";
        const string srvrpassword = "123456";
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
            using (var command = new SqlCommand("SELECT * FROM Products", connection))
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
                            Position = Convert.ToDouble(reader.GetDecimal(2)),
                            Department = reader.GetString(3).ToUpper()
                        };
                        staffList.Add(aStaff);

                    }
                }
            }
            return staffList;
        }
        #endregion

        #region Update Product
        public int UpdateProduct(Staff p)
        {
            int result = 0;
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand())
            {
                command.CommandText = "UPDATE Products SET Name=@Name,Position=@Position,Department=@Department WHERE Id = @id";
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
        public int InsertProduct(Staff p)
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
        public int DeleteProduct(Staff p)
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
