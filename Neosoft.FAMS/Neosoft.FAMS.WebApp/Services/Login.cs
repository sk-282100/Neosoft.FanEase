using Neosoft.FAMS.Application.Features.Events.Login.Commands;
using Neosoft.FAMS.Application.Features.Login.Commands;
using Neosoft.FAMS.Application.Features.Login.Commands.ForgotPassword;
using Neosoft.FAMS.Application.Features.Login.Queries;
using Neosoft.FAMS.WebApp.Helper;
using Neosoft.FAMS.WebApp.Services.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Neosoft.FAMS.WebApp.Services
{
    public class Login : ILogin
    {
        #region private variables
        private static HttpClient _client = new HttpClient(new HttpClientHandler { AllowAutoRedirect = false });
        readonly string _baseUrl = "https://localhost:44330/";
        readonly string _path = "api/Login";
        #endregion
        public Login()
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
        /// Author: Shankar Kadam
        /// Date: 29-10-2021
        /// Reason: To validate user credential and get user role
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<Domain.Entities.Login> CheckUsernameAndPassword(string userName, string password)
        {
            //var uri = API.Login.CheckUsernameAndPassword(_path, userName, password);
            
            string pass = EncryptionDecryption.EncryptString(password);
            Domain.Entities.Login _login = new Domain.Entities.Login();
            _login.Password = EncryptionDecryption.EncryptString(password);
            _login.Username = userName;
            var content = JsonConvert.SerializeObject(_login);
            var uri = API.Login.CheckUsernameAndPassword(_baseUrl, _path);
            HttpResponseMessage response = await _client.PostAsync(uri, new StringContent(content, Encoding.Default,
               "application/json"));


            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<Domain.Entities.Login>(jsonDataStatus);
                return result;
            }
            return null;
        }

        /// <summary>
        /// Author: Sana Haju
        /// Date: 27-10-2021
        /// Reason: To Reset Password using oldPassword and newPassword
        /// </summary>
        /// <param name="resetPasswordCommand"></param>
        /// <returns></returns>

        public async Task<bool> SavePassword(ResetPasswordCommand resetPasswordCommand)
        {
            bool result = false;
            resetPasswordCommand.Password = EncryptionDecryption.EncryptString(resetPasswordCommand.Password);
            resetPasswordCommand.newPassword = EncryptionDecryption.EncryptString(resetPasswordCommand.newPassword);
            var content = JsonConvert.SerializeObject(resetPasswordCommand);
            var uri = API.Login.SavePassword(_baseUrl, _path);
            HttpResponseMessage response = await _client.PostAsync(uri, new StringContent(content, Encoding.Default,
                "application/json"));
            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var res = JsonConvert.DeserializeObject<bool>(jsonDataStatus);
                return res;
            }
            return false;

        }

        /// <summary>
        /// Author: Sana Haju
        /// Date: 27-10-2021
        /// Reason: To check valid Username & send OTP to valid emailId
        /// </summary>
        /// <param name="checkUsernameCommand"></param>
        /// <returns></returns>

        public async Task<bool> SaveOTP(CheckUsernameCommand checkUsernameCommand)
        {
            bool result = false;
            var uri = API.Login.SaveOTP(_baseUrl, _path, checkUsernameCommand.UserName);
            HttpResponseMessage response = _client.GetAsync(uri).Result;

            if (response.IsSuccessStatusCode)
            {
                result = bool.Parse(response.Content.ReadAsStringAsync().Result);
            }
            return result;

        }

        /// <summary>
        /// Author: Sana Haju
        /// Date: 27-10-2021
        /// Reason: To check valid OTP
        /// </summary>
        /// <param name="checkOtpQuery"></param>
        /// <returns></returns>
        public async Task<int> CheckOTP(CheckOtpQuery checkOtpQuery)
        {
            int result = 0;
            var uri = API.Login.CheckOTP(_baseUrl, _path, checkOtpQuery.Username, checkOtpQuery.Otp);
            HttpResponseMessage response = _client.GetAsync(uri).Result;

            if (response.IsSuccessStatusCode)
            {
                result = Convert.ToInt32(response.Content.ReadAsStringAsync().Result);

            }
            return result;
        }


        /// <summary>
        /// Author: Sana Haju
        /// Date: 15-11-2021
        /// Reason: If User Forgot Password,Will be Able to Reset Password
        /// </summary>
        /// <param name="forgotPasswordCommand"></param>
        /// <returns></returns>
        public async Task<bool> ForgotPassword(ForgotPasswordCommand forgotPasswordCommand)
        {
            bool result = false;
            forgotPasswordCommand.newPassword = EncryptionDecryption.EncryptString(forgotPasswordCommand.newPassword);
            var content = JsonConvert.SerializeObject(forgotPasswordCommand);
            var uri = API.Login.ForgotPassword(_baseUrl, _path);
            HttpResponseMessage response = await _client.PostAsync(uri, new StringContent(content, Encoding.Default,
                "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var jsonDataStatus = response.Content.ReadAsStringAsync().Result;
                var res = JsonConvert.DeserializeObject<bool>(jsonDataStatus);
                return res;
            }
            return false;
        }
    }
}
