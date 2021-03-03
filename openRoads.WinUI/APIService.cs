using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using openRoads.Model;

namespace openRoads.WinUI
{
    public class APIService
    {
        private readonly string _route;

        public static string Username { get; set; }
        public static string Password { get; set; }


        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object search)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}";

            if (search != null)
            {
                url += "?";
                url += await search.ToQueryString();
            }

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }

        public async Task<T> GetById<T>(object id)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}";

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

                    MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("You don't have permission to perform this action!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return default(T);
            }

        }

        public async Task<T> Update<T>(int id, object request)
        {
            try
            {
                var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";

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

                    MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("You don't have permission to perform this action!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return default(T);
            }

        }


        public async Task<T> Delete<T>(int id)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";

            //return await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<T>();

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

                    MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("You don't have permission to perform this action!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return default(T);
            }
        }
    }
}
