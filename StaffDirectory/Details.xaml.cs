using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Reflection;

namespace StaffDirectory
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Details : ContentPage
    {

        private Repository _repo;
        private Staff staffD;
        private Staff _staffDetails;

        public Details(Staff staffSend, Repository repo)
        {
            InitializeComponent();
            _repo = repo;
            
            staffD = staffSend;
            _staffDetails = staffSend;

            DetailsId.Text = staffD.Id.ToString(); //int to string
            DetailsStaffName.Text = staffD.Name;
            DetailsDepartment.Text = staffD.Department;
            DetailsPosition.Text = staffD.Position;
            DetailsPhone.Text = staffD.Phone.ToString(); //int to string
            DetailsAddress.Text = staffD.Address;
        }

        //Update
        async void Button_Clicked(object sender, EventArgs e)
        {
            _staffDetails.Name = NameUpdate.Text;
            _staffDetails.Position = PositionUpdate.Text;
            _staffDetails.Department = DepartmentUpdated.Text;
            _staffDetails.Phone = PhoneUpdate.Text;
            _staffDetails.Address = AddressUpdate.Text;

            try
            {
                _repo.UpdateStaff(_staffDetails);
                await Navigation.PushAsync(new ProfilePage());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Delete
        async void Button_Clicked_1(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("DELETE STAFF", "Are you sure you want to delete?", "Yes", "No");
            if (answer == true)
            {
                try
                {
                    _repo.DeleteStaff(_staffDetails);
                    await Navigation.PushAsync(new ProfilePage());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                await DisplayAlert("Resolved", "You did not delete: " + _staffDetails.Name, "Ok");
            }
        }
    }
}