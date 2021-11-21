using Microsoft.AspNetCore.Http;
using Neosoft.FAMS.WebApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Neosoft.FAMS.Application.Features.AdminDashboard.Queries.GetAll;
using Neosoft.FAMS.WebApp.Helper;
using Newtonsoft.Json;

namespace Neosoft.FAMS.WebApp.Services
{
    public class AdminDashboard : IAdminDashboard
    {
        #region private variables
        private static HttpClient _client = new HttpClient(new HttpClientHandler { AllowAutoRedirect = false });
        readonly string _baseUrl = "https://localhost:44330/";
        readonly string _path = "api/AdminDashboard";
        #endregion

        private HttpContext httpContext;
        public AdminDashboard()
        {
            if (_client.BaseAddress == null)
            {
                _client.BaseAddress = new Uri(_baseUrl);
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }
        public List<long> GetAdminStats()
        {
            var result = new List<long>();
            var uri = API.AdminDashboard.GetAdminStats(_baseUrl,_path);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<long>>(jsonDataStatus);
                return data;
            }
            return result;
        }

        public List<GetTopVideoDto> GetTopVideo()
        {
            var result = new List<GetTopVideoDto>();
            var uri = API.AdminDashboard.GetTopVideos(_baseUrl, _path);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<GetTopVideoDto>>(jsonDataStatus);
                return data;
            }
            return result;
        }

        public List<string> GetTopCampaignName()
        {
            var result = new List<string>();
            var uri = API.AdminDashboard.GetTopCampaign(_baseUrl, _path);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<string>>(jsonDataStatus);
                return data;
            }
            return result;
        }
    }
}
