namespace Neosoft.FAMS.WebApp.Helper
{
    public static class API
    {
        public static class Login
        {
            public static string CheckUsernameAndPassword(string baseUri, string path) => $"{baseUri}{path}/CheckUsernameAndPassword?api-version=1";
            public static string SavePassword(string baseUri,string path) => $"{baseUri}{path}/ResetPassword?api-version=1";
            public static string SaveOTP(string baseUri, string path, string username) => $"{baseUri}{path}/checkUsername?EmailAddress={username}&api-version=1";
            public static string CheckOTP(string baseUri, string path, string username, string otp) => $"{baseUri}{path}/CheckOtp?Username={username}&Otp={otp}&api-version=1";
            public static string ForgotPassword(string baseUri, string path) => $"{baseUri}{path}/ForgotPassword?api-version=1";

        }
        public static class User
        {
            public static string GetAllUserList(string baseUri) => $"{baseUri}/GetAllUserList?api-version=1";
            public static string SaveUser(string baseUri) => $"{baseUri}/SaveUser?api-version=1";
        }
        public static class Viewer
        {
            public static string GetAllViewer(string baseUri, string path) => $"{baseUri}{path}?api-version=1";
            public static string GetEmailUrl(string baseUri, string path, string email) => $"{baseUri}{path}/getViewerByEmail?username={email}?api-version=1";
            public static string SaveViewer(string baseUri, string path) => $"{baseUri}{path}?api-version=1";
            public static string GetViewerByEmail(string baseUri, string path, string username) => $"{baseUri}{path}/getViewerByEmail?username={username}?api-version=1";
            public static string GetTopLikedVideos(string baseUri, string path) => $"{baseUri}{path}/GetTopLikes?api-version=1";

        }
        public static class Creator
        {
            public static string GetAllCreator(string baseUri, string path) => $"{baseUri}{path}?api-version=1";
            public static string SaveCreator(string baseUri, string path) => $"{baseUri}{path}?api-version=1";
            public static string GetCreatorById(string baseUri, string path, long id) => $"{baseUri}{path}/{id}?api-version=1";

            public static string GetCreatorByEmail(string baseUri, string path, string username) => $"{baseUri}{path}/getCreatorByEmail?username={username}?api-version=1";
            public static string DeleteCreator(string baseUri, string path, long id) => $"{baseUri}{path}/{id}?api-version=1";
        }
        public static class Common
        {
            public static string GetAdvertisementUrl(string baseUri,long id) => $"{baseUri}api/ContentCreator/GetAllById/{id}?api-version=1";
            public static string GetEmailUrl(string baseUri, string email) => $"{baseUri}api/ContentCreator/getCreatorByEmail?username={email}?api-version=1";
            public static string GetPhoneCodeUrl(string baseUri, string path, int id) => $"{baseUri}{path}/GetCountryPhoneCode/{id}?api-version=1";
            public static string GetCountryList(string path) => $"{path}/GetCountryList?api-version=1";
            public static string GetStateList(string path, int id) => $"{path}/GetStateList?countryId={id}&api-version=1";
            public static string GetCityList(string path, int id) => $"{path}/GetCityList?stateId={id}&api-version=1";

        }
        public static class Video
        {
            public static string GetAllVideoList(string baseUri, string path) => $"{baseUri}{path}?api-version=1";

            public static string CreateVideo(string baseUri, string path) => $"{baseUri}{path}?api-version=1";

            public static string SaveVideo(string baseUri, string path) => $"{baseUri}{path}?api-version=1";
            public static string VideoGetById(string baseUrl, string path, long id) =>
                $"{baseUrl}{path}/{id}?api-version=1";
            public static string VideosByContentCreator(string baseUrl, string path, long id) =>
                $"{baseUrl}{path}/{id}?api-version=1";
            public static string DeleteVideo(string baseUri, string path, long id) => $"{baseUri}{path}/{id}?api-version=1";

            /*https://localhost:44330/api/Video/CreatorVideosById/1?api-version=1*/
            public static string GetCreatorVideoListById(string baseUrl, string path, long id) =>
                $"{baseUrl}{path}/CreatorVideosById/{id}?api-version=1";
        }
        public static class VideoStatistics
        {
            public static string  GetStatsById(string baseUri,string path,long videoId) => $"{baseUri}{path}/{videoId}?api-version=1";
            //https://localhost:44330/api/VideoPage/id?viewerId=10&videoId=6&api-version=1
            public static string CheckClickBy(string baseUri, string path, long videoId,long viewerId) => $"{baseUri}{path}/id?viewerId={viewerId}&videoId={videoId}&api-version=1";
            //https://localhost:44330/Likes/6?viewerId=5&api-version=1
            public static string GetLikes(string baseUri,long videoId,long viewerId) => $"{baseUri}Likes/{videoId}?viewerId={viewerId}&api-version=1";
            public static string GetDislikes(string baseUri,long videoId, long viewerId) => $"{baseUri}Dislikes/{videoId}?viewerId={viewerId}&api-version=1";
            public static string GetViews(string baseUri,long videoId, long viewerId) => $"{baseUri}Views/{videoId}?viewerId={viewerId}&api-version=1";
            //https://localhost:44330/IsLikedById/49/1?api-version=1

            public static string likeStatus(string baseUri, long videoId, long viewerId) => $"{baseUri}IsLikedById/{videoId}/{viewerId}?api-version=1";

        } 
        public static class Campaign
        {

            public static string GetAllCampaign(string baseUri, string path) => $"{baseUri}{path}?api-version=1";
            public static string SaveCampaign(string baseUri, string path) => $"{baseUri}{path}?api-version=1";
            public static string GetCampaignById(string baseUri, string path, long id) => $"{baseUri}{path}/{id}?api-version=1";
            public static string DeleteCampaign(string baseUri, string path, long id) => $"{baseUri}{path}/{id}?api-version=1";
            public static string GetMappedVideoIdCampaign(string baseUri,long id) => $"{baseUri}api/Advertisement/GetMappedVideoById/{id}?api-version=1";



        }

        public static class Asset
        {
            public static string GetAllAsset(string baseUri, string path) => $"{baseUri}{path}?api-version=1";
            public static string SaveAsset(string baseUri, string path) => $"{baseUri}{path}?api-version=1";
            public static string GetAssetById(string baseUri, string path, long id) => $"{baseUri}{path}/{id}?api-version=1";
            public static string SaveCampaignAdvertisementMappedData(string baseUri, string path) => $"{baseUri}{path}/AddCampaignAdvertiseData?api-version=1";

            public static string DeleteAsset(string baseUri, string path, long id) => $"{baseUri}{path}/{id}?api-version=1";
            public static string GetAllMapeedAssetById(string baseUri, string path, long id) => $"{baseUri}{path}/GetMappedAdvertisedById/{id}?api-version=1";
        }
        public static class Template
        {
            public static string TemplateVideoMap(string baseUri, string path) => $"{baseUri}{path}?api-version=1";
            public static string GetAllTemplate(string baseUri, string path) => $"{baseUri}{path}?api-version=1";
            public static string GetTemplate(string baseUri, string path,long id) => $"{baseUri}{path}/{id}?api-version=1";

            public static string GetAllAdvertiseByVideoId(string baseUri, string path, long id) => $"{baseUri}{path}/VideoAdvertisementByVideoId{id}?api-version=1";

        }

        public static class AdminDashboard
        {
            public static string GetAdminStats(string baseUri,string path) => $"{baseUri}{path}?api-version=1";
            public static string GetTopVideos(string baseUri, string path) => $"{baseUri}{path}/GetTopVideos?api-version=1";
            //https://localhost:44330/api/AdminDashboard/GetTopCampaign?api-version=1
            public static string GetTopCampaign(string baseUri,string path) => $"{baseUri}{path}/GetTopCampaign?api-version=1";
           
            public static string GetYearlyStats(string baseUri, string path,long year) => $"{baseUri}{path}/GetYearlyStatistics?years={year}&api-version=1";
            public static string GetYearlyLiveStats(string baseUri, string path, long year) => $"{baseUri}{path}/GetYearlyLiveStatistics?years={year}&api-version=1";

        }

        public static class CreatorDashboard
        {
            public static string GetCreatorStats(string baseUri, string path,long id) => $"{baseUri}{path}/{id}?api-version=1";
            public static string GetCreatorVideoStats(string baseUri,long id) => $"{baseUri}VideoStatistics/{id}?api-version=1";
            public static string GetTopVideos(string baseUri, string path,long id) => $"{baseUri}{path}/GetTopVideos/{id}?api-version=1";
            public static string GetTopCampaign(string baseUri, string path,long id) => $"{baseUri}{path}/GetTopCampaign/{id}?api-version=1";
            public static string GetYearlyStats(string baseUri, string path,long id, long year) => $"{baseUri}{path}/GetYearlyStatistics/{id}?years={year}&api-version=1";

            public static string GetYearlyLiveStats(string baseUri, string path,long id, long year) => $"{baseUri}{path}/GetYearlyLiveStatistics/{id}?years={year}&api-version=1";
        }
    }
}
