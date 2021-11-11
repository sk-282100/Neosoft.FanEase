using Neosoft.FAMS.WebApp.Models.CommonViewModel;
using System.Collections.Generic;

namespace Neosoft.FAMS.WebApp.Services.Interface
{
    public interface ICommon
    {
        public bool checkForEmail(string email);
        List<ListViewModel> GetCountryList();
        List<ListViewModel> GetStateList(int CountryId);
        List<ListViewModel> GetCityList(int StateId);
        long GetPhoneCode(int countryId);

    }
}
