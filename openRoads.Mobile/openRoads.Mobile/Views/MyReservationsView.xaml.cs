using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using openRoads.Mobile.Converters;
using openRoads.Mobile.Helpers;
using openRoads.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace openRoads.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyReservationsView : ContentPage
    {
        private MyReservationsViewModel model = null;

        private readonly APIService _clientService = new APIService("Client");
        private readonly APIService _reservationService = new APIService("Reservation");
        private readonly APIService _vehicleService = new APIService("Vehicle");
        private readonly APIService _vehicleModelService = new APIService("VehicleModel");
        private readonly APIService _vehicleManufacturerService = new APIService("VehicleManufacturer");

        private int? selectedReservationId;

        public MyReservationsView()
        {
            InitializeComponent();

            BindingContext = model = new MyReservationsViewModel();


            backImage.Source = ImageSource.FromResource("openRoads.Mobile.Resources.backIcon.png");
            backImage.WidthRequest = 40;
            backImage.HeightRequest = 40;
            backImage.CornerRadius = 25;
            backImage.BackgroundColor = Color.White;

            SignOutBtn.Padding = new Thickness(3);
            SignOutBtn.CornerRadius = 3;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            await Helper.LoadUserImage(_clientService, userImg);
            
        }


        private void BackImage_OnClicked(object sender, EventArgs e)
        {
            Helper.BackImageOnClick();
        }

        private void UserImg_OnClicked(object sender, EventArgs e)
        {
            Helper.UserImgOnClick();
        }

        private void SignOutBtn_OnClicked(object sender, EventArgs e)
        {
            Helper.SignOut();
        }


        private async void ReservationButton_OnClicked(object sender, EventArgs e)
        {
            Xamarin.Forms.Button btn = sender as Button;
            if (int.TryParse(btn.AutomationId, out int reservationId))
                Application.Current.MainPage = new ReviewView(reservationId);
            else
            {
                await DisplayAlert("Error", "Something went wrong... Please try again later!", "OK");
            }
        }
    }
}