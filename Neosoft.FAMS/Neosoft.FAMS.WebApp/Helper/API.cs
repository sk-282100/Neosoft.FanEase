using Neosoft.FAMS.Application.Features.Viewer.Commands.Create;
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
            public static string CheckUsernameAndPassword(string baseUri, string userName, string password) => $"{baseUri}/CheckUsernameAndPassword?username={userName}&password={password}&api-version=1";
            public static string SavePassword(string baseUri, string path, string username, string password, string newPassword) => $"{baseUri}{path}/ResetPassword?EmailAddress={username}&Password={password}&NewPassword={newPassword}&api-version=1";

        }
        public static class User
        {
            public static string GetAllUserList(string baseUri) => $"{baseUri}/GetAllUserList?api-version=1";
            public static string SaveUser(string baseUri) => $"{baseUri}/SaveUser?api-version=1";
        }
        public static class Viewer
        {
            public static string GetAllViewer(string baseUri, string path) => $"{baseUri}{path}?api-version=1";
            public static string SaveViewer(string baseUri, string path) => $"{baseUri}{path}?api-version=1";
        }
        public static class Creator
        {
            public static string GetAllCreator(string baseUri,string path) => $"{baseUri}{path}?api-version=1";
        }
    }
}
