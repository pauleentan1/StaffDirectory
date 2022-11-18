using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace StaffDirectory
{
    public partial class MainPage : ContentPage
    {
        const string srvrdbname = "ROIDB";
        const string srvrname = "192.168.0.103";
        const string srvrusername = "Abi";
        const string srvrpassword = "art12345";
        private Repository _repo;

        ObservableCollection<Staff> staffL = new ObservableCollection<Staff>();
        public ObservableCollection<Staff> StaffL { get { return staffL; } }
        public MainPage()
        {
            InitializeComponent();
            var repo = new Repository();
            var staffList = repo.GetStaff();
            _repo = repo;

            StaffView.ItemsSource = staffL;

            foreach (var staff in staffList)
            {
                staffL.Add(staff);
            }
        }

        //DETAILS -> UPDATE AND DELETE NAV
        async void StaffView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var product = e.SelectedItem as Staff;
            await Navigation.PushAsync(new Details(product, _repo));
        }

        //ADD NAVIGATION
        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Insert(_repo));
        }


        /**
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

                sql = "SELECT * FROM Staff";
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

        }**/
    }
}
    

