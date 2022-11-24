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
        //Old Connection String Info
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
            var staff = e.SelectedItem as Staff;
            await Navigation.PushAsync(new Details(staff, _repo));
        }

        //ADD NAVIGATION
        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Insert(_repo));
        }

    }
}

//video tutorial https://www.youtube.com/watch?v=xNmIdFjXzl4&t=0s

      