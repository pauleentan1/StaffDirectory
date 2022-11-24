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
    public partial class Insert : ContentPage
    {
        private Repository _repo;
        private Staff staffInsert;
        public Insert(Repository repo)
        {
            InitializeComponent();
            _repo = repo;
            var staf = new Staff();
            staffInsert = staf;
        }

        //Insert
        async void Button_Clicked(object sender, EventArgs e)
        {

            staffInsert.Name = NameInsert.Text;
            staffInsert.Position = PositionInsert.Text;
            staffInsert.Department = DepartmentInsert.Text;
            staffInsert.Phone = PhoneInsert.Text;
            staffInsert.Address = AddressInsert.Text;

            try
            {
                _repo.InsertStaff(staffInsert);
                await Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}