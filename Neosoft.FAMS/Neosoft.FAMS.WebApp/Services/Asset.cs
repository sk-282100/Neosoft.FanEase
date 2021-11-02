using Neosoft.FAMS.Application.Features.Advertisement.Commands.CampaignAdvertisement;
using Neosoft.FAMS.Application.Features.Advertisement.Commands.Create;
using Neosoft.FAMS.Application.Features.Advertisement.Queries.GetAll;
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
using Microsoft.AspNetCore.Http;
using Neosoft.FAMS.WebApp.Models;

namespace Neosoft.FAMS.WebApp.Services
{
    public class Asset: IAsset
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
    }
}
