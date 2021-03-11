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
                var obj = await _service.Get<List<ClientModel>>(request);

                if (obj == null)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid username or password!", "OK");
                }
                else
                {
                    for (int i = 0; i < obj.Count; i++)
                    {
                        APIService.LoggedUserId = obj[i].ClientId;
                    }
                    Application.Current.MainPage = new VehicleOfferView();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
