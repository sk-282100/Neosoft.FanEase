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

    }
}
