using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using openRoads.Mobile.Converters;
using openRoads.Mobile.Helpers;
using openRoads.Mobile.ViewModels;
using openRoads.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace openRoads.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReservationView : ContentPage
    {
        private ReservationViewModel model = null;

        private int _vehicleId;
        private DateTime _startDate;
        private DateTime _endDate;

        private readonly APIService _vehicleService = new APIService("Vehicle");
        private readonly APIService _clientService = new APIService("Client");

        public ReservationView(int vehicleId, DateTime startDate, DateTime endDate)
        {
            InitializeComponent();

            _vehicleId = vehicleId;
            _startDate = startDate;
            _endDate = endDate;

            BindingContext = model = new ReservationViewModel(_vehicleId, _startDate, _endDate);

            
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

        private void SignOutBtn_OnClicked(object sender, EventArgs e)
        {
            Helper.SignOut();
        }

        private void UserImg_OnClicked(object sender, EventArgs e)
        {
            Helper.UserImgOnClick();
        }

        private void BackImage_OnClicked(object sender, EventArgs e)
        {
            Helper.BackImageOnClick();
        }

        private async void Picker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var insurance = (InsuranceModel) InsurancePicker.SelectedItem;
            int daysDiff = 0;


            if (_startDate.Year == _endDate.Year && _startDate.Month == _endDate.Month)
                daysDiff = _endDate.Day - _startDate.Day + 1;


            if (_startDate.Year == _endDate.Year && _startDate.Month < _endDate.Month)
            {
                var daysInMonth = DateTime.DaysInMonth(_startDate.Year, _startDate.Month);
                var counter = 0;
                for (int i = 0; i < _endDate.Day; i++)
                {
                    counter++;
                }

                for (int i = daysInMonth; i >= _startDate.Day; i--)
                {
                    counter++;
                }

                daysDiff = counter;
            }

            var vehicle = await _vehicleService.GetById<Model.VehicleModel>(_vehicleId);
            var totalPrice = (daysDiff * vehicle.PriceByDay) + insurance.Price;
            var vehiclePrice = daysDiff * vehicle.PriceByDay;
            
            model.TotalPrice = $"{totalPrice}KM";
            model.VehicleRentalPrice = $"{vehiclePrice}KM";
            model.InsurancePrice = $"{insurance.Price}KM";

        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            bool valid = true;
            if (model.SelectedInsuranceType == null)
            {
                await DisplayAlert("Warning", "Please select insurance type.", "OK");
                valid = false;
            }
            if (valid && !inPersonCB.IsChecked && !creditCardCB.IsChecked)
            {
                await DisplayAlert("Warning", "Please select payment option.", "OK");
                valid = false;
            }

            if (valid && inPersonCB.IsChecked && creditCardCB.IsChecked)
            {
                await DisplayAlert("Warning", "Please select only one payment option.", "OK");
                valid = false;
            }

            if(valid)
                model.CreateReservationCommand.Execute(null);
        }
    }
}