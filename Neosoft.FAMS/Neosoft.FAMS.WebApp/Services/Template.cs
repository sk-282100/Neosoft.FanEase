using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Neosoft.FAMS.Application.Features.Template.Queries;
using Neosoft.FAMS.Application.Features.Viewer.Queries.GetAll;
using Neosoft.FAMS.WebApp.Helper;
using Neosoft.FAMS.WebApp.Services.Interface;
using Newtonsoft.Json;

namespace Neosoft.FAMS.WebApp.Services
{
    public class Template: Itemplate
    {
        #region private variables
        private static HttpClient _client = new HttpClient(new HttpClientHandler { AllowAutoRedirect = false });
        readonly string _baseUrl = "https://localhost:44330/";
        readonly string _path = "api/Template";
        #endregion
        public Template()
        {
            if (_client.BaseAddress == null)
            {
                _client.BaseAddress = new Uri(_baseUrl);
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }
        public List<TemplateListDto> GetAllTemplate()
        {
            var result = new List<TemplateListDto>();
            var uri = API.Template.GetAllTemplate(_baseUrl, _path);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<TemplateListDto>>(jsonDataStatus);
                result = data.ToList();
                return result;
            }
            return result;
        }
        public TemplateListDto GetTemplate(long id)
        {
            var uri = API.Template.GetTemplate(_baseUrl, _path,id);
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<TemplateListDto>(jsonDataStatus);
                return data;
            }
            return null;
        }
    }
}
