using Neosoft.FAMS.Application.Features.VideoPage.Query.GetAllVideoStatistics;
using Neosoft.FAMS.WebApp.Helper;
using Neosoft.FAMS.WebApp.Services.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Neosoft.FAMS.WebApp.Services
{
    public class VideoStatistics : IVideoStatistics
    {
        #region private variables
        private static HttpClient _client = new HttpClient(new HttpClientHandler { AllowAutoRedirect = false });
        readonly string _baseUrl = "https://localhost:44330/";
        readonly string _path = "api/VideoPage";
        public VideoStatistics()
        {

            #endregion
            if (_client.BaseAddress == null)
            {
                _client.BaseAddress = new Uri(_baseUrl);
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }
        /// <summary>
        /// Author:Raj Bhosale
        /// Date:15/11/2021
        /// Reason: Getting Likes,Dislikes,View And Share Counts
        /// </summary>
        /// <param name="videoId"></param>
        /// <returns></returns>
        public List<long> StatsGetById(long videoId)
        {
            //https://localhost:44330/api/VideoPage/6?api-version=1
            var result = new List<long>();
            var uri = API.VideoStatistics.GetStatsById(_baseUrl, _path,videoId);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<long>>(jsonDataStatus);
                return data;
            }
            return result;

        }
        public  bool CheckClickBy(long videoId,long viewerId)
        {
            var uri = API.VideoStatistics.CheckClickBy(_baseUrl, _path,videoId,viewerId);
            HttpResponseMessage response =  _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<bool>(jsonDataStatus);
                return data;
            }
            return false;
        }
    }
}
