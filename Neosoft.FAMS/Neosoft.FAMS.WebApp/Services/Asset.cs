using Microsoft.AspNetCore.Http;
using Neosoft.FAMS.Application.Features.Advertisement.Commands.CampaignAdvertisement;
using Neosoft.FAMS.Application.Features.Advertisement.Commands.Create;
using Neosoft.FAMS.Application.Features.Advertisement.Commands.Delete;
using Neosoft.FAMS.Application.Features.Advertisement.Commands.Update;
using Neosoft.FAMS.Application.Features.Advertisement.Queries.GetAll;
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

namespace Neosoft.FAMS.WebApp.Services
{
    public class Asset : IAsset
    {
        #region private variables
        private static HttpClient _client = new HttpClient(new HttpClientHandler { AllowAutoRedirect = false });
        readonly string _baseUrl = "https://localhost:44330/";
        readonly string _path = "api/Advertisement";
        #endregion

        private HttpContext httpContext;
        public Asset()
        {
            if (_client.BaseAddress == null)
            {
                _client.BaseAddress = new Uri(_baseUrl);
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }
        public async Task<long> SaveAssetDetail(CreateAdvertisementCommand createAdvertisementCommand)
        {
            long result = 0;
            var uri = API.Asset.SaveAsset(_baseUrl, _path);
            var content = JsonConvert.SerializeObject(createAdvertisementCommand);
            HttpResponseMessage response = await _client.PostAsync(uri, new StringContent(content, Encoding.Default,
                          "application/json"));
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Response<long>>(jsonDataStatus);
                result = data.Data;
                MappingViewModel.AdvertisementId = result;
                if (MappingViewModel.CampaignId > 0)
                {
                    AddMappedData();
                }
                return result;
            }
            return result;
        }


        public List<AdvertisementListQueryDto> GetAllAsset()
        {
            var result = new List<AdvertisementListQueryDto>();
            var uri = API.Asset.GetAllAsset(_baseUrl, _path);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<AdvertisementListQueryDto>>(jsonDataStatus);
                result = data.ToList();
                return result;
            }
            return result;
        }
        public void AddMappedData()
        {

            var addCampaignAdvertisement = new AddCampaignAdvertisementCommand();
            addCampaignAdvertisement.AdvertisementId = MappingViewModel.AdvertisementId;
            addCampaignAdvertisement.CampaignId = MappingViewModel.CampaignId;
            addCampaignAdvertisement.VideoId = MappingViewModel.VideoId;
            addCampaignAdvertisement.CreatedBy = MappingViewModel.CreatedBy;/*long.Parse(HttpContext.Session.GetString("ContentCreatorId"));*/
            addCampaignAdvertisement.CreatedOn = DateTime.Now;

            var id = AddCampaignAdvertiseMappedData(addCampaignAdvertisement);

        }
        public async Task<long> AddCampaignAdvertiseMappedData(AddCampaignAdvertisementCommand command)
        {
            long result = 0;
            var uri = API.Asset.SaveCampaignAdvertisementMappedData(_baseUrl, _path);
            var content = JsonConvert.SerializeObject(command);
            HttpResponseMessage response = await _client.PostAsync(uri, new StringContent(content, Encoding.Default,
                "application/json"));
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Response<long>>(jsonDataStatus);
                result = data.Data;
                return result;
            }
            return result;
        }

        public AdvertisementListQueryDto GetAssetById(long id)
        {
            var result = new AdvertisementListQueryDto();
            var uri = API.Asset.GetAssetById(_baseUrl, _path, id);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<AdvertisementListQueryDto>(jsonDataStatus);
                return data;
            }
            return result;
        }

        public async Task<bool> UpdateAssetDetail(UpdateAdvertisementCommand update)
        {
            bool result = false;
            var uri = API.Asset.SaveAsset(_baseUrl, _path);
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

        public async Task<bool> DeleteAsset(DeleteAdvertisementCommand command)
        {
            var uri = API.Asset.DeleteAsset(_baseUrl, _path, command.AdvertisementId);
            HttpResponseMessage response = await _client.DeleteAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Response<bool>>(jsonDataStatus);
                return data.Data;
            }
            return false;
        }

        public List<AdvertisementListQueryDto> GetAllMappedAsset(long campaignId)
        {
            var result = new AdvertisementListQueryDto();
            var uri = API.Asset.GetAllMapeedAssetById(_baseUrl, _path, campaignId);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            var data=new List<AdvertisementListQueryDto>();
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<List<AdvertisementListQueryDto>>(jsonDataStatus);
                return data;
            }
            return data;
        }
    }
}
