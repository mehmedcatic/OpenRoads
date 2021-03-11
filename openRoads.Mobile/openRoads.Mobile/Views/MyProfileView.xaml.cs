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
    public partial class MyProfileView : ContentPage
    {
        private MyProfileViewModel model = null;

        private readonly APIService _clientService = new APIService("Client");

        public MyProfileView()
        {
            InitializeComponent();

            BindingContext = model = new MyProfileViewModel();


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
            await LoadClientPicture();
            await Helper.LoadUserImage(_clientService, userImg);
        }

        private async Task LoadClientPicture()
        {
            var client = await _clientService.GetById<ClientModel>(APIService.LoggedUserId);
            if (client != null)
            {
                if (client.ProfilePicture.Length != 0)
                {
                    ImageConverter converter = new ImageConverter();
                    UserImage.Source = (ImageSource) converter.Convert(client.ProfilePicture, null, null, null);
                    UserImage.HeightRequest = 45;
                }
                else
                {
                    UserImage.Source = ImageSource.FromResource("openRoads.Mobile.Resources.userAvatar.png");
                    UserImage.WidthRequest = 400;
                }
            }
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

        private void Button_OnClicked(object sender, EventArgs e)
        {
            //DODATI EDIT PROFILE PRIKAZ
            throw new NotImplementedException();
        }
    }
}