using Neosoft.FAMS.Domain.Entities;
using Neosoft.FAMS.WebApp.Models.CommonViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Services.Interface
{
    public interface ICommon
    {
        List<ListViewModel> GetCountryList();
        List<ListViewModel> GetStateList(int CountryId);
        List<ListViewModel> GetCityList(int StateId);

    }
}
