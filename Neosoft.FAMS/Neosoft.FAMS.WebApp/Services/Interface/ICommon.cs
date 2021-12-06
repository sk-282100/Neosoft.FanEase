using Neosoft.FAMS.WebApp.Models.CommonViewModel;
using System.Collections.Generic;
using Neosoft.FAMS.Application.Features.ContentCreator.Queries.GetMappedData;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Services.Interface
{
    public interface ICommon
    {
        public bool checkForEmail(string email);
        List<ListViewModel> GetCountryList();
        List<ListViewModel> GetStateList(int CountryId);
        List<ListViewModel> GetCityList(int StateId);
        long GetPhoneCode(int countryId);
        List<AdvertisementViewModel> GetAdvertisement();
        Task<string> GetToken(string userName, string password);

    }
}
