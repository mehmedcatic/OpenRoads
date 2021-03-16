using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using openRoads.Mobile.Services;
using openRoads.Mobile.Views;
using Rg.Plugins;
using Rg.Plugins.Popup;
using Rg;

namespace openRoads.Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
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
