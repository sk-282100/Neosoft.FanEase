using Neosoft.FAMS.Application.Features.Video.Command.Create;
using Neosoft.FAMS.Application.Features.Video.Queries.GetAll;
using Neosoft.FAMS.Application.Responses;
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
using Neosoft.FAMS.Application.Features.Video.Commands.Update;
using Neosoft.FAMS.WebApp.Models;

namespace Neosoft.FAMS.WebApp.Services
{
    public class Video : IVideo
    {
        #region private variables
        private static HttpClient _client = new HttpClient(new HttpClientHandler { AllowAutoRedirect = false });
        readonly string _baseUrl = "https://localhost:44330/";
        readonly string _path = "api/Video";
        private readonly string _pathofCC = "api/Video/Videos";
        #endregion
        public Video()
        {
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
        /// Date:27/10/2021
        /// Reason: Getting All Videos
        /// </summary>
        /// <returns></returns>

        public List<VideoGetAllDto> GetAllVideoList()
        {
            var result = new List<VideoGetAllDto>();
            var uri = API.Video.GetAllVideoList(_baseUrl, _path);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<VideoGetAllDto>>(jsonDataStatus);
                result = data.ToList();
                return result;
            }
            return result;
        }
        /// <summary>
        /// Author:Raj Bhosale
        /// Date:27/10/2021
        /// Reason:Saving Video Details
        /// </summary>
        /// <param name="videocreateCommand"></param>
        /// <returns></returns>
        public async Task<long> CreateVideo(VideoCreateCommand videocreateCommand)
        {
            var uri = API.Video.CreateVideo(_baseUrl,_path);
            long result = 0;
            var content = JsonConvert.SerializeObject(videocreateCommand);
            HttpResponseMessage response = await _client.PostAsync(uri, new StringContent(content, Encoding.Default,
                           "application/json"));
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Response<long>>(jsonDataStatus);
                result = (long) data.Data;
                MappingViewModel.VideoId = result;
            }
            return result;
        }

        public List<VideoGetAllDto> VideosCreatedByContentCreator(long id)
        {
            var result = new List<VideoGetAllDto>();
            var uri = API.Video.VideosByContentCreator(_baseUrl, _pathofCC,id);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<VideoGetAllDto>>(jsonDataStatus);
                result = data.ToList();
                return result;
            }
            return result;
        }
        public VideoGetAllDto VideoGetById(long id)
        {
            var result = new VideoGetAllDto();
            var uri = API.Video.VideoGetById(_baseUrl, _path, id);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<VideoGetAllDto>(jsonDataStatus);
                return data;
            }
            return result;
        }
        /// <summary>
        /// Author:Raj Bhosale
        /// Date:01/11/2021
        /// Reason TO update Video By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> UpdateVideoDetail(UpdateVideoByIdCommand update)
        {
            bool result = false;
            var uri = API.Video.SaveVideo(_baseUrl, _path);
            var content = JsonConvert.SerializeObject(update);
            HttpResponseMessage response = await _client.PutAsync(uri, new StringContent(content, Encoding.Default,
                "application/json"));
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Response<bool>>(jsonDataStatus);
                result = data.Data;
                return result;
            }
            return result;
        }


    }
}
