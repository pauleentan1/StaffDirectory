using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StaffDirectory
{
    public partial class MainPage : ContentPage
    {
        const string srvrdbname = "StoreDB";
        const string srvrname = "192.168.1.132";
        const string srvrusername = "shaun";
        const string srvrpassword = "123456";

        ObservableCollection<Staff> productL = new ObservableCollection<Staff>();
        public ObservableCollection<Staff> staffL { get { return staffL; } }
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                #region Old Test Code 1
                string sqlconn = $"Data Source={srvrname};Initial Catalog={srvrdbname};User ID={srvrusername};Password={srvrpassword}";
                SqlConnection sqlConnection = new SqlConnection(sqlconn);
                sqlConnection.Open();

                SqlCommand command;
                SqlDataReader dataReader;
                string sql, output = "";

                sql = "SELECT * FROM Products";
                command = new SqlCommand(sql, sqlConnection);

                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    output = output + "ID: " + dataReader.GetValue(0) + " Name: " + dataReader.GetValue(1) + "\n";
                    //product.Add(new Products() { Id = Convert.ToInt32(dataReader.GetValue(0)), Product = dataReader.GetValue(1).ToString(), Price = Convert.ToDouble(dataReader.GetValue(2)), Code = dataReader.GetValue(3).ToString().ToUpper() });
                }

                Change.Text = output.ToString();
                #endregion

                #region Old Test Code 2
                //dataReader.Close();
                //command.Dispose();
                //sqlConnection.Close();

                //Old CODE 2
                //var repo = new Repository();
                //var productList = repo.GetProduct();
                //string th = "";

                //foreach (var product in productList)
                //{
                //   th = product.Product;
                //}

                //Change.Text = th;
                #endregion

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw;
            }

        }
    }
}
    

