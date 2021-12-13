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
        /// <summary>
        /// Author : Kajal Padhiyar <br></br>
        /// Date : 29/10/2021 <br></br>
        /// Reason :  It will add new advertisement detail
        /// </summary>
        /// <param name="createAdvertisementCommand"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Author : Kajal Padhiyar <br></br>
        /// Date : 29/10/2021 <br></br>
        /// Reason : It will fetch all advertisement detail
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Author : Aman Sharma <br></br>
        /// Date : 25/11/2021 <br></br>
        /// Reason : It will add video,campaign and advertisement mapped data
        /// </summary>
        public void AddMappedData()
        {
            var addCampaignAdvertisement = new AddCampaignAdvertisementCommand();
            addCampaignAdvertisement.AdvertisementId = MappingViewModel.AdvertisementId;
            addCampaignAdvertisement.CampaignId = MappingViewModel.CampaignId;
            addCampaignAdvertisement.VideoId = MappingViewModel.VideoId;
            addCampaignAdvertisement.CreatedBy = MappingViewModel.CreatedBy;
            addCampaignAdvertisement.CreatedOn = DateTime.Now;

            var id = AddCampaignAdvertiseMappedData(addCampaignAdvertisement);

        }
        /// <summary>
        /// Author : Aman Sharma <br></br>
        /// Date : 25/11/2021 <br></br>
        /// Reason : It will add Campaign and advertisement that are linked into Campaign-Advertisement mapped table
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Author : Kajal Padhiyar <br></br>
        /// Date : 25/11/2021 <br></br>
        /// Reason : It will fetch advertisement detail by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Author : Kajal Padhiyar <br></br>
        /// Date : 26/10/2021 <br></br>
        /// Reason : It will update advertisement detail
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Author : Kajal Padhiyar <br></br>
        /// Date : 26/10/2021 <br></br>
        /// Reason : It will delete advertisement by Id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Author : Aman Sharma <br></br>
        /// Date : 26/11/2021 <br></br>
        /// Reason : It will fetch advertisement details that are linked with Campaign by campaign Id
        /// </summary>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        public List<AdvertisementListQueryDto> GetAllMappedAsset(long campaignId)
        {
            var result = new List<AdvertisementListQueryDto>();
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
