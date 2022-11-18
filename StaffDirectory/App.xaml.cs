using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StaffDirectory
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            //SETUP NAVIGATION CONTEXT
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
