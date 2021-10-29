using Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetAll;
using Neosoft.FAMS.Application.Responses;
using Neosoft.FAMS.WebApp.Helper;
using Neosoft.FAMS.WebApp.Models.CreatorModel;
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
    public class Creator : ICreator
    {
        #region private variables
        private static HttpClient _client = new HttpClient(new HttpClientHandler { AllowAutoRedirect = false });
        readonly string _baseUrl = "https://localhost:44330/";
        readonly string _path = "api/ContentCreator";
        #endregion
        public Creator()
        {
            if (_client.BaseAddress == null)
            {
                _client.BaseAddress = new Uri(_baseUrl);
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }
        public List<ContentCreatorDto> GetAllCreator()
        {
            var result= new List<ContentCreatorDto>();
            var uri = API.Creator.GetAllCreator(_baseUrl,_path);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<ContentCreatorDto>>(jsonDataStatus);
                result = data.ToList();
                return result;
            }
            return result;
        }
        public async Task<long> SaveCreatorDetail(CreatorRegisteration registeration)
        {
            long result = 0;
            var uri = API.Creator.SaveCreator(_baseUrl, _path);
            var content = JsonConvert.SerializeObject(registeration);
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
        public ContentCreatorDto GetCreatorById(long id)
        {
            var result = new ContentCreatorDto();
            var uri = API.Creator.GetCreatorById(_baseUrl, _path,id);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<ContentCreatorDto>(jsonDataStatus);
                return data;
            }
            return result;
        }
        public async Task<bool> UpdateCreatorDetail(CreatorRegisteration registeration)
        {
            bool result = false;
            var uri = API.Creator.SaveCreator(_baseUrl, _path);
            var content = JsonConvert.SerializeObject(registeration);
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
