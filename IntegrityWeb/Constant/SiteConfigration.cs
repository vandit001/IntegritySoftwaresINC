using System.Configuration;

namespace IntegrityWeb.Constant
{
    public static class SiteConfigration
    {
        public static string Name = ConfigurationSettings.AppSettings["Name"].ToString();
        public static string SortName = ConfigurationSettings.AppSettings["SortName"].ToString();
        public static string LogoURL = ConfigurationSettings.AppSettings["LogoURL"].ToString();
        public static string smallLogoURL = ConfigurationSettings.AppSettings["smallLogoURL"].ToString();
        public static string FaviconURL = ConfigurationSettings.AppSettings["FaviconURL"].ToString();
        public static string SiteVersion = ConfigurationSettings.AppSettings["SiteVersion"].ToString();
        public static string Copyrights = ConfigurationSettings.AppSettings["Copyrights"].ToString();
        public static string DevelopedBy = ConfigurationSettings.AppSettings["DevelopedBy"].ToString();
        public static string DevelopedByURL = ConfigurationSettings.AppSettings["DevelopedByURL"].ToString();
        public static string PageSize = ConfigurationSettings.AppSettings["PageSize"].ToString();
        public static string ContactEmail = ConfigurationSettings.AppSettings["ContactEmail"].ToString();
        public static string webURL = ConfigurationSettings.AppSettings["webURL"].ToString();
        public static string ContactNo = ConfigurationSettings.AppSettings["ContactNo"].ToString();
        
        public static string LinkedINURL = ConfigurationSettings.AppSettings["LinkedINURL"].ToString();
        public static string FaceBookURL = ConfigurationSettings.AppSettings["FaceBookURL"].ToString();
        public static string TwitterURL = ConfigurationSettings.AppSettings["TwitterURL"].ToString();
        public static string GoogleURL = ConfigurationSettings.AppSettings["GoogleURL"].ToString();
        public static string InstagramURL = ConfigurationSettings.AppSettings["InstagramURL"].ToString();
        public static string PinterestURL = ConfigurationSettings.AppSettings["PinterestURL"].ToString();

        public static string Address1Line1 = ConfigurationSettings.AppSettings["Address1Line1"].ToString();
        public static string Address1Line2 = ConfigurationSettings.AppSettings["Address1Line2"].ToString();
    }
}