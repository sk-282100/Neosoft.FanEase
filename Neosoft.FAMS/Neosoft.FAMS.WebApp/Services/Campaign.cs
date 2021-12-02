using Neosoft.FAMS.Application.Features.Campaign.Commands.Create;
using Neosoft.FAMS.Application.Features.Campaign.Queries.GetAll;
using Neosoft.FAMS.Application.Responses;
using Neosoft.FAMS.WebApp.Helper;
using Neosoft.FAMS.WebApp.Models;
using Neosoft.FAMS.WebApp.Services.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Neosoft.FAMS.Application.Features.Campaign.Commands.Delete;
using Neosoft.FAMS.Application.Features.Campaign.Commands.Update;

namespace Neosoft.FAMS.WebApp.Services
{
    public class Campaign : ICampaign
    {
        #region private variables
        private static HttpClient _client = new HttpClient(new HttpClientHandler { AllowAutoRedirect = false });
        readonly string _baseUrl = "https://localhost:44330/";
        readonly string _path = "api/CampaignDetail";
        #endregion
        public Campaign()
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
        /// Author: Kajal Padhiyar
        /// Date: 15-11-2021
        /// Reason: Returns list of Live Campaigns.
        /// </summary>
        /// <returns>Returns list of Live Campaigns.</returns>
        public List<CampaignGetAllDto> GetAllCampaign()
        {
            var result = new List<CampaignGetAllDto>();
            var uri = API.Campaign.GetAllCampaign(_baseUrl, _path);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<CampaignGetAllDto>>(jsonDataStatus);
                result = data.ToList();
                return result;
            }
            return result;
        }

        /// <summary>
        /// Author: Kajal Padhiyar
        /// Date: 15-11-2021
        /// Reason: Add new campaign.
        /// </summary>
        /// <param name="campaignCreateCommand"></param>
        /// <returns>Id of new campaign.</returns>

        public async Task<long> SaveCampaignDetail(CampaignCreateCommand campaignCreateCommand)
        {
            long result = 0;
            var uri = API.Campaign.SaveCampaign(_baseUrl, _path);
            var content = JsonConvert.SerializeObject(campaignCreateCommand);
            HttpResponseMessage response = await _client.PostAsync(uri, new StringContent(content, Encoding.Default,
                "application/json"));
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Response<long>>(jsonDataStatus);
                result = data.Data;
                MappingViewModel.CampaignId = result;
                return result;
            }
            return result;
        }

        /// <summary>
        /// Author: Kajal Padhiyar
        /// Date: 15-11-2021
        /// Reason: Get a particular campaign.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Details of a particular campaign</returns>
        public CampaignGetAllDto GetCampaignById(long id)
        {
            var result = new CampaignGetAllDto();
            var uri = API.Asset.GetAssetById(_baseUrl, _path, id);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<CampaignGetAllDto>(jsonDataStatus);
                return data;
            }
            return result;
        }

        /// <summary>
        /// Author: Kajal Padhiyar
        /// Date: 15-11-2021
        /// Reason: Update a particular campaign details.
        /// </summary>
        /// <param name="update"></param>
        /// <returns>true or false</returns>
        public async Task<bool> UpdateCampaignDetail(UpdateCampaignCommand update)
        {
            bool result = false;
            var uri = API.Campaign.SaveCampaign(_baseUrl, _path);
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

        /// <summary>
        /// Author: Kajal Padhiyar
        /// Date: 15-11-2021
        /// Reason: Update a campaign.
        /// </summary>
        /// <param name="command"></param>
        /// <returns>true or false</returns>
        public async Task<bool> DeleteCampaign(DeleteCampaignByIdCommand command)
        {
            var uri = API.Campaign.DeleteCampaign(_baseUrl, _path, command.CampaignId);
            HttpResponseMessage response = await _client.DeleteAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Response<bool>>(jsonDataStatus);
                return data.Data;
            }
            return false;
        }

        /// <summary>
        /// Author: Aman sharma and Kajal Padhiyar
        /// Date: 15-11-2021
        /// Reason: Get video id of a particular campaign from mapping table.
        /// </summary>
        /// <param name="campaignId"></param>
        /// <returns>Video id</returns>
        public long GetMappedVideoIdCampaign(long campaignId)
        {
            var uri = API.Campaign.GetMappedVideoIdCampaign(_baseUrl, campaignId);
            HttpResponseMessage response =  _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<long>(jsonDataStatus);
                MappingViewModel.VideoId = data;
                return data;
            }
            return 0;
        }
    }
}
