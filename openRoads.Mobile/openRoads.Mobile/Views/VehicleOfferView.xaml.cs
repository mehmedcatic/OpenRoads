using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using openRoads.Mobile.Converters;
using openRoads.Mobile.ViewModels;
using openRoads.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace openRoads.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VehicleOfferView : ContentPage
    {
        private VehicleOfferViewModel model = null;

        private readonly APIService _service = new APIService("Client");

        public VehicleOfferView()
        {
            InitializeComponent();
            BindingContext = model = new VehicleOfferViewModel();

            StartDate.MinimumDate = DateTime.Now;
            EndDate.MinimumDate = DateTime.Now;

            StartDateLabel.Padding = new Thickness(0, 0, 10, 0);
            EndDateLabel.Padding = new Thickness(0, 0, 15, 0);

            SignOutBtn.Padding = new Thickness(3);
            SignOutBtn.CornerRadius = 3;
        }

        public VehicleOfferView(string msg = null)
        {
            InitializeComponent();
            BindingContext = model = new VehicleOfferViewModel();

            StartDate.MinimumDate = DateTime.Now;
            EndDate.MinimumDate = DateTime.Now;

            StartDateLabel.Padding = new Thickness(0, 0, 10, 0);
            EndDateLabel.Padding = new Thickness(0, 0, 15, 0);

            SignOutBtn.Padding = new Thickness(3);
            SignOutBtn.CornerRadius = 3;

            if (msg != null)
            {
                DisplayAlert("Success", "Your reservation has been successfully created! Check your e-mail for additional info.", "OK");
            }
        }

        private async Task LoadUser()
        {
            ClientModel user = await _service.GetById<ClientModel>(APIService.LoggedUserId);
            if (user != null)
            {
                if (user.ProfilePicture.Length != 0)
                {
                    ImageConverter converter = new ImageConverter();
                    userImg.Source = (ImageSource)converter.Convert(user.ProfilePicture, null, null, null);
                    userImg.HeightRequest = 45;
                    userImg.CornerRadius = 25;
                }
                else
                {
                    userImg.Source = ImageSource.FromResource("openRoads.Mobile.Resources.userAvatar.png");
                    userImg.HeightRequest = 45;
                    userImg.CornerRadius = 25;
                }
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            await LoadUser();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            if (StartDate.Date >= EndDate.Date)
            {
                await DisplayAlert("Warning", "Please select valid dates for the reservation!", "OK");
            }
            else
            {
                Xamarin.Forms.Button btn = sender as Button;
                if (int.TryParse(btn.AutomationId, out int vehicleId))
                    Application.Current.MainPage = new ReservationView(vehicleId, StartDate.Date, EndDate.Date);
            }
            

        }


        private void UserImg_OnClicked(object sender, EventArgs e)
        {
            DisplayAlert("Newst", "test", "OK");

        }

        private void SignOutBtn_OnClicked(object sender, EventArgs e)
        {
            APIService.LoggedUserId = 0;
            Application.Current.MainPage = new LandingPageView();
        }


        private bool IsReservationLongerThan28Days()
        {
            var startDate = StartDate.Date;
            var endDate = EndDate.Date;

            var daysCounter = 0;

            if (startDate.Year < endDate.Year)
            {
                if (startDate.Month == 12 && endDate.Month == 1)
                {
                    var daysInMonth = DateTime.DaysInMonth(startDate.Year, startDate.Month);
                 
                    for (int i = 0; i < endDate.Day; i++)
                    {
                        daysCounter++;
                    }

                    for (int i = daysInMonth; i >= startDate.Day; i--)
                    {
                        daysCounter++;
                    }

                    if (daysCounter > 28)
                        return true;
                }

                else
                    return true;
            }

            if (startDate.Year == endDate.Year && startDate.Month == endDate.Month)
            {
                for (int i = startDate.Day; i < endDate.Day; i++)
                {
                    daysCounter++;
                }

                if (daysCounter > 28)
                    return true;
            }

            if (startDate.Year == endDate.Year && startDate.Month < endDate.Month)
            {
                if ((endDate.Month - startDate.Month) > 1)
                    return true;

                var daysInMonth = DateTime.DaysInMonth(startDate.Year, startDate.Month);

                for (int i = 0; i < endDate.Day; i++)
                {
                    daysCounter++;
                }

                for (int i = daysInMonth; i >= startDate.Day; i--)
                {
                    daysCounter++;
                }

                if (daysCounter > 28)
                    return true;
            }

            return false;
        }

        private void StartDate_OnDateSelected(object sender, DateChangedEventArgs e)
        {
            model.SelectedDateFrom = StartDate.Date;
        }

        private async void EndDate_OnDateSelected(object sender, DateChangedEventArgs e)
        {
          
            if (StartDate.Date > EndDate.Date)
            {
                await DisplayAlert("Warning", "Start date can't be higher or equal than the end date!", "OK");
                StartDate.Date = DateTime.Now;
            }

            if (IsReservationLongerThan28Days())
            {
                await DisplayAlert("Alert", "If you need a vehicle rented for a period of more than 28 days contact out Customer Services office!", "OK");
                StartDate.Date = DateTime.Now;
                EndDate.Date = DateTime.Now;
            }
            else
                model.SelectedDateTo = EndDate.Date;
        }
    }
}