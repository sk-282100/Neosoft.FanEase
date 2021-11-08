using Neosoft.FAMS.Application.Features.Viewer.Commands.Create;
using Neosoft.FAMS.Application.Features.Viewer.Queries.GetAll;
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

namespace Neosoft.FAMS.WebApp.Services
{
    public class Viewer : IViewer
    {
        #region private variables
        private static HttpClient _client = new HttpClient(new HttpClientHandler { AllowAutoRedirect = false });
        readonly string _baseUrl = "https://localhost:44330/";
        readonly string _path = "api/Viewer";
        #endregion
        public Viewer()
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
        /// Date: 27-10-2021
        /// Reason: It will give List of all viewers
        /// </summary>
        /// <returns></returns>
        public List<ViewerDto> GetAllViewer()
        {
            var result = new List<ViewerDto>();
            var uri = API.Viewer.GetAllViewer(_baseUrl, _path);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<ViewerDto>>(jsonDataStatus);
                result = data.ToList();
                return result;
            }
            return result;
        }

        /// <summary>
        /// Author: Kajal Padhiyar
        /// Date: 25-10-2021
        /// Reason: It will add new viewer and returns ViewerId
        /// </summary>
        /// <param name="viewerCreateCommand"></param>
        /// <returns></returns>
        public async Task<long> SaveViewer(ViewerCreateCommand viewerCreateCommand)
        {
            var uri = API.Viewer.SaveViewer(_baseUrl,_path);
            long _id=0;
            var content = JsonConvert.SerializeObject(viewerCreateCommand);
            HttpResponseMessage response = await _client.PostAsync(uri, new StringContent(content, Encoding.Default,
                           "application/json"));
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<Response<long>>(jsonDataStatus);
                _id = result.Data;
            }
            return _id;
        }

        public ViewerDto GetViewerByEmail(string username)
        {
            var result = new ViewerDto();
            var uri = API.Viewer.GetViewerByEmail(_baseUrl, _path, username);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<ViewerDto>(jsonDataStatus);
                return data;
            }
            return result;
        }
    }
}
