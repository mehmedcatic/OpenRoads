using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using openRoads.Mobile.Services;
using openRoads.Mobile.Views;

namespace openRoads.Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            //MainPage = new MainPage();
            //MainPage = new LoginPage();
            MainPage = new LandingPageView();
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
