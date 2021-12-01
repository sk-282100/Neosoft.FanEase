using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Neosoft.FAMS.Application.Features.ContentCreatorDashboard.Queries.GetCreatorStatisticById;
using Neosoft.FAMS.Application.Features.ContentCreatorDashboard.Queries.TopCampaign;
using Neosoft.FAMS.Application.Features.ContentCreatorDashboard.Queries.TopVideo;
using Neosoft.FAMS.WebApp.Helper;
using Neosoft.FAMS.WebApp.Services.Interface;
using Newtonsoft.Json;

namespace Neosoft.FAMS.WebApp.Services
{
    public class CreatorDashboard:ICreatorDashboard
    {
        #region private variables
        private static HttpClient _client = new HttpClient(new HttpClientHandler { AllowAutoRedirect = false });
        readonly string _baseUrl = "https://localhost:44330/";
        readonly string _path = "api/ContentCreatorDashboard";
        #endregion

        private HttpContext httpContext;
        public CreatorDashboard()
        {
            if (_client.BaseAddress == null)
            {
                _client.BaseAddress = new Uri(_baseUrl);
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }
        public List<long> GetCreatorStats(long id)
        {
            var result = new List<long>();
            var uri = API.CreatorDashboard.GetCreatorStats(_baseUrl,_path,id);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<long>>(jsonDataStatus);
                return data;
            }
            return result;
        }

        
        public List<long> GetCreatorVideoStats(long id)
        {
            var result = new List<long>();
            var uri = API.CreatorDashboard.GetCreatorVideoStats(_baseUrl,id);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<long>>(jsonDataStatus);
                return data;
            }
            return result;
        }

        public List<GetTopVideoDto> GetTopVideo(long id)
        {
            var result = new List<GetTopVideoDto>();
            var uri = API.CreatorDashboard.GetTopVideos(_baseUrl, _path,id);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<GetTopVideoDto>>(jsonDataStatus);
                return data;
            }
            return result;
        }

        public List<GetTopCampaignDto> GetTopCampaignName(long id)
        {
            var result = new List<GetTopCampaignDto>();
            var uri = API.CreatorDashboard.GetTopCampaign(_baseUrl, _path,id);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<GetTopCampaignDto>>(jsonDataStatus);
                return data;
            }
            return result;
        }

        public List<long> GetYearlyStatistics(long id,long year)
        {
            var result = new List<long>();
            var uri = API.CreatorDashboard.GetYearlyStats(_baseUrl, _path,id, year);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<long>>(jsonDataStatus);
                return data;
            }
            return result;
        }

        public List<long> GetYearlyLiveStatistics(long id,long year)
        {
            var result = new List<long>();
            var uri = API.CreatorDashboard.GetYearlyLiveStats(_baseUrl, _path,id, year);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<long>>(jsonDataStatus);
                return data;
            }
            return result;
        }

    }
}

