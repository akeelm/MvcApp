using System.Configuration;

namespace MvcApp.Services
{
    /// <summary>
    /// Site contstants and any ConfigurationManager.
    /// </summary>
    public static class SiteInfo
    {
        public const string FORGOT_PASSWORD_LINK = "/Account/ForgotPassword/";
        public const string PROFILE_IMAGE_PATH = "/Images/Profiles/";
        public const int PROFILE_IMAGE_SMALL_SIZE = 50;

        public static string SiteName()
        {
            return ConfigurationManager.AppSettings["SiteName"];
        }

    }
}