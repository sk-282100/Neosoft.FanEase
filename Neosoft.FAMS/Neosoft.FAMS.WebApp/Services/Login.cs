using Neosoft.FAMS.Application.Features.Login.Queries;
using Neosoft.FAMS.WebApp.Helper;
using Neosoft.FAMS.WebApp.Services.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Services
{
    public class Login : ILogin
    {
        #region private variables
        private static HttpClient _client = new HttpClient(new HttpClientHandler { AllowAutoRedirect = false });
        readonly string _baseUrl ="";
        readonly string _path = "";
        #endregion
        public Login()
        {
            if (_client.BaseAddress == null)
            {
                _client.BaseAddress = new Uri(_baseUrl);
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }
        public int CheckUsernameAndPassword(string userName, string password) {
            var uri = API.Login.CheckUsernameAndPassword(_path, userName, password);
            LoginQuery _loginQuery = new LoginQuery();
            _loginQuery.Password = password;
            _loginQuery.UserName = userName;
            var content = JsonConvert.SerializeObject(_loginQuery);
            //HttpResponseMessage response = _client.GetAsync(uri,new StringContent(content, Encoding.Default,
            //    "application/json")).Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    var jsonDataProviders = response.Content.ReadAsStringAsync().Result;
            //}
            return 0;
        }
    }
}
