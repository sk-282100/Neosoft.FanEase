using Neosoft.FAMS.Application.Responses;
using Neosoft.FAMS.Domain.Entities;
using Neosoft.FAMS.WebApp.Helper;
using Neosoft.FAMS.WebApp.Models.CommonViewModel;
using Neosoft.FAMS.WebApp.Services.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetAll;

namespace Neosoft.FAMS.WebApp.Services
{
    public class Common : ICommon
    {
        #region private variables
        private static HttpClient _client = new HttpClient(new HttpClientHandler { AllowAutoRedirect = false });
        readonly string _baseUrl = "https://localhost:44330/";
        readonly string _path = "api/Common";
        private readonly string _pathofCC = "api/Video/Videos";
        #endregion
        public Common()
        {
            if (_client.BaseAddress == null)
            {
                _client.BaseAddress = new Uri(_baseUrl);
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        public bool checkForEmail(string email)
        {
            var uri = API.Common.GetEmailUrl(_baseUrl,email);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var deserializedata = JsonConvert.DeserializeObject<ContentCreatorDto>(jsonDataStatus);
                if (deserializedata != null)
                    return true;
            }
            return false;
        }
        public long GetPhoneCode(int countryId)
        {
            long result = 0;
            var uri = API.Common.GetPhoneCodeUrl(_baseUrl,_path,countryId);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var deserializedata = JsonConvert.DeserializeObject<long>(jsonDataStatus);
                return deserializedata;
            }
            return result;
        }
        public List<ListViewModel> GetCountryList()
        {
            IEnumerable<ListViewModel> result=null;
            var uri = API.Common.GetCountryList( _path);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var deserializedata = JsonConvert.DeserializeObject<Response<IEnumerable<Country>>>(jsonDataStatus);
                 result =
                 from data in deserializedata.Data.ToList()
                 select new ListViewModel { id = data.CountryId,text= data.CountryName };
            }
            return result.ToList();
        }
        public List<ListViewModel> GetStateList(int CountryId)
        {
            IEnumerable<ListViewModel> result = null;
            var uri = API.Common.GetStateList(_path,CountryId);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var deserializedata = JsonConvert.DeserializeObject<Response<IEnumerable<States>>>(jsonDataStatus);
                result =
                    from data in deserializedata.Data.ToList()
                    select new ListViewModel { id = data.Id, text = data.Name };
            }
            return result.ToList();
        }

        public List<ListViewModel> GetCityList(int StateId)
        {
            IEnumerable<ListViewModel> result = null;
            var uri = API.Common.GetCityList(_path, StateId);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var deserializedata = JsonConvert.DeserializeObject<Response<IEnumerable<City>>>(jsonDataStatus);
                result =
                    from data in deserializedata.Data.ToList()
                    select new ListViewModel { id = data.Id, text = data.Name };
            }
            return result.ToList();
        }
    }
}
