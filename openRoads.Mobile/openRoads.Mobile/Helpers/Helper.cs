using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using openRoads.Mobile.Converters;
using openRoads.Mobile.Views;
using openRoads.Model;
using Xamarin.Forms;

namespace openRoads.Mobile.Helpers
{
    public static class Helper
    {
        public static async void SignOut()
        {
            if (await Application.Current.MainPage.DisplayAlert("Warning", "Are you sure you want to log out?", "Yes", "No"))
            {
                APIService.LoggedUserId = 0;
                Application.Current.MainPage = new LandingPageView();
            }
        }

        public static void BackImageOnClick()
        {
            Application.Current.MainPage = new VehicleOfferView();
        }

        public static void UserImgOnClick()
        {
            Application.Current.MainPage = new MyProfileTabbedView();
        }

        public static async Task LoadUserImage(APIService _service, ImageButton userImg)
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
    }
}
