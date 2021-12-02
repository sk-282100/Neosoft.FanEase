﻿using Neosoft.FAMS.Application.Features.VideoPage.Query.GetAllVideoStatistics;
using Neosoft.FAMS.WebApp.Helper;
using Neosoft.FAMS.WebApp.Services.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

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
        /// Author: Raj Bhosale
        /// Date: 20-11-2021
        /// Reason: It will update and Return Likes and Dislikes of a Particular Video
        /// </summary>
        /// <returns></returns>
        public List<long> GetLikes(long id,long viewerId)
        {
            var result = new List<long>();
            var uri = API.VideoStatistics.GetLikes(_baseUrl,id,viewerId);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var deserializedata = JsonConvert.DeserializeObject<List<long>>(jsonDataStatus);
                return deserializedata;
            }
            return result;
        }
        /// <summary>
        /// Author: Raj Bhosale
        /// Date: 20-11-2021
        /// Reason: It will Update and Return Likes and Dislikes of a Particular Video
        /// </summary>
        /// <returns></returns>

        public List<long> GetDislikes(long id, long viewerId)
        {
            var result = new List<long>();
            var uri = API.VideoStatistics.GetDislikes(_baseUrl, id, viewerId);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var deserializedata = JsonConvert.DeserializeObject<List<long>>(jsonDataStatus);
                return deserializedata;
            }
            return result;
        }
        /// <summary>
        /// Author: Raj Bhosale
        /// Date: 20-11-2021
        /// Reason: It will Return Views of a Particular Video
        /// </summary>
        /// <returns></returns>
        public long GetViews(long id, long viewerId)
        {
            long result = 0;
            var uri = API.VideoStatistics.GetViews(_baseUrl,  id, viewerId);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var deserializedata = JsonConvert.DeserializeObject<long>(jsonDataStatus);
                var data = deserializedata;
                return data;
            }
            return result;
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
        /// <summary>
        /// Author: Raj Bhosale
        /// Date: 20-11-2021
        /// Reason: It will check whether data is present in videoStatistics, if not it will create it
        /// </summary>
        /// <returns></returns>
        public bool CheckClickBy(long videoId,long viewerId)
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
        /// <summary>
        /// Author: Raj Bhosale
        /// Date: 20-11-2021
        /// Reason: It will Return Likes Status of a Particular Video
        /// </summary>
        /// <returns></returns>
        public bool? LikeStatus(long videoId,long viewerId)
        {
            //https://localhost:44330/IsLikedById/87/12?api-version=1;
            var uri = API.VideoStatistics.likeStatus(_baseUrl, videoId, viewerId);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<bool?>(jsonDataStatus);
                return data;
            }
            return false;

        }
    }
}
