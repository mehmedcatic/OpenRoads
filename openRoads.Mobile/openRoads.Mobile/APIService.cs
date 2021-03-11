﻿using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using openRoads.Model;
using Xamarin.Forms;

namespace openRoads.Mobile
{
    public class APIService
    {
        public static string Username { get; set; }
        public static string Password { get; set; }
        
        public static int LoggedUserId { get; set; }

        private readonly string _route;

#if DEBUG
        private string _apiUrl = "http://localhost:59488/api";
#endif
#if RELEASE
        private string _apiUrl = "https://mywebsite.azure.com/api";
#endif

        public APIService(string route)
        {
            _route = route;
        }

       
        public async Task<T> Get<T>(object search)
        {
            var url = $"{_apiUrl}/{_route}";

            try
            {
                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.StatusCode == 403 || ex.StatusCode == 401)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid username or password!", "OK");
                }

                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "An error has occured...Please try again later!", "OK");
                }
                throw;
            }
        }

        public async Task<T> GetById<T>(object id)
        {
            var url = $"{_apiUrl}/{_route}/{id}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{_apiUrl}/{_route}";

            try
            {
                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.StatusCode != 403)
                {
                    var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                    var stringBuilder = new StringBuilder();
                    foreach (var error in errors)
                    {
                        stringBuilder.AppendLine($"{error.Key}, {string.Join(",", error.Value)}");
                    }

                    await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid username or password!", "OK");
                }
                return default(T);
            }

        }

        public async Task<T> Update<T>(int id, object request)
        {
            try
            {
                var url = $"{_apiUrl}/{_route}/{id}";

                return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.StatusCode != 403)
                {
                    var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                    var stringBuilder = new StringBuilder();
                    foreach (var error in errors)
                    {
                        stringBuilder.AppendLine($"{error.Key}, {string.Join(",", error.Value)}");
                    }
                    await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid username or password!", "OK");
                }
                return default(T);
            }

        }


        public async Task<T> Delete<T>(int id)
        {
            var url = $"{_apiUrl}/{_route}/{id}";


            try
            {
                return await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.StatusCode != 403)
                {
                    var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                    var stringBuilder = new StringBuilder();
                    foreach (var error in errors)
                    {
                        stringBuilder.AppendLine($"{error.Key}, {string.Join(",", error.Value)}");
                    }

                    await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid username or password!", "OK");
                }
                return default(T);
            }
        }
    }
}
