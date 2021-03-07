using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using openRoads.Mobile.Views;
using openRoads.Model;
using openRoads.Model.Requests;
using Xamarin.Forms;

namespace openRoads.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("Client");

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());
        }
        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public ICommand LoginCommand { get; set; }

        async Task Login()
        {
            IsBusy = true;
            APIService.Username = Username;
            APIService.Password = Password;

            try
            {
                ClientSearchRequest request = new ClientSearchRequest
                {
                    Username = Username
                };
                var obj = await _service.Get<dynamic>(request);

                if (obj == null)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid username or password!", "OK");
                    IsBusy = false;
                }
                else
                {
                    Application.Current.MainPage = new MainPage();
                    IsBusy = false;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
