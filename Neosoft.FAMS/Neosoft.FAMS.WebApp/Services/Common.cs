using Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetAll;
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
using Neosoft.FAMS.WebApp.Models;
using Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetMappedData;
using System.Threading.Tasks;
using System.Text;

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
        public async Task<string> GetToken(string userName,string password)
        {
            string pass = EncryptionDecryption.EncryptString(password);
            Domain.Entities.Login _login = new Domain.Entities.Login();
            _login.Password = EncryptionDecryption.EncryptString(password);
            _login.Username = userName;

            string result=string.Empty;
            var uri = API.Common.GetToken(_baseUrl);
            var content = JsonConvert.SerializeObject(_login);
            HttpResponseMessage response = await _client.PostAsync(uri, new StringContent(content, Encoding.Default,
                          "application/json"));
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<string>(jsonDataStatus);
                return data;
            }
            return result;
        }

        /// <summary>
        /// Author : Aman Sharma <br></br>
        /// Date : 18/11/2021 <br></br>
        /// Reason :  It will get advertisements detail that creator has added in their current video.
        /// </summary>
        /// <returns></returns>
        public List<AdvertisementViewModel> GetAdvertisement()
        {
            IEnumerable<AdvertisementViewModel> result = null;
            var uri = API.Common.GetAdvertisementUrl(_baseUrl,MappingViewModel.VideoId);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var deserializedata = JsonConvert.DeserializeObject<MappedDto>(jsonDataStatus);
                result =
                    from data in deserializedata.AdvertisementDetail.ToList()
                    select new AdvertisementViewModel
                    {
                        AdvertisementId = data.AdvertisementId,Title = data.Title,
                        Description = data.Description,ImagePath = data.ImagePath,VideoPath = data.VideoPath
                    };
            }
            return result.ToList();
        }

        /// <summary>
        /// Author : Aman Sharma <br></br>
        /// Date : 15/11/2021 <br></br>
        /// Reason :  It will check email is already exist or not.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>true or false.</returns>
        public bool checkForEmail(string email)
        {
            var uri = API.Common.GetEmailUrl(_baseUrl, email);
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

        /// <summary>
        /// Author : Aman Sharma,Kajal Padhiyar<br></br>
        /// Date : 12/11/2021<br></br>
        /// Reason : It will fetch phone code based on country ID
        /// </summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Phone code</returns>
        public long GetPhoneCode(int countryId)
        {
            long result = 0;
            var uri = API.Common.GetPhoneCodeUrl(_baseUrl, _path, countryId);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var deserializedata = JsonConvert.DeserializeObject<long>(jsonDataStatus);
                return deserializedata;
            }
            return result;
        }

        /// <summary>
        /// Author : Aman Sharma,Kajal Padhiyar<br></br>
        /// Date : 12/11/2021<br></br>
        /// Reason : It will get list of country
        /// </summary>
        /// <returns></returns>
        public List<ListViewModel> GetCountryList()
        {
            IEnumerable<ListViewModel> result = null;
            var uri = API.Common.GetCountryList(_path);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var deserializedata = JsonConvert.DeserializeObject<Response<IEnumerable<Country>>>(jsonDataStatus);
                result =
                from data in deserializedata.Data.ToList()
                select new ListViewModel { id = data.CountryId, text = data.CountryName };
            }
            return result.ToList();
        }

        /// <summary>
        /// Author : Aman Sharma,Kajal Padhiyar<br></br>
        /// Date : 12/11/2021<br></br>
        /// Reason : It will get list of states based on country ID
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        public List<ListViewModel> GetStateList(int CountryId)
        {
            IEnumerable<ListViewModel> result = null;
            var uri = API.Common.GetStateList(_path, CountryId);
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

        /// <summary>
        /// Author : Aman Sharma,Kajal Padhiyar<br></br>
        /// Date : 12/11/2021<br></br>
        /// Reason : It will get list of city based on State ID
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>
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
