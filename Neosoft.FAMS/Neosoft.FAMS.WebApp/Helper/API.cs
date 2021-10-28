using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Helper
{
    public static class API
    {
        public static class Login
        {
            public static string CheckUsernameAndPassword(string baseUri, string userName, string password) => $"{baseUri}/CheckUsernameAndPassword/{userName}/{password}";
        }
    }
}
