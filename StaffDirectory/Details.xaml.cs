using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
        }
        //Update
        async void Button_Clicked(object sender, EventArgs e)
        {
            _staffDetails.Name = NameUpdate.Text;
            _staffDetails.Position = PositionUpdate.Text;
            _staffDetails.Department = DepartmentUpdated.Text;

            try
            {
                _repo.UpdateStaff(_staffDetails);
                await Navigation.PushAsync(new MainPage());
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
                    await Navigation.PushAsync(new MainPage());
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