using IntegrityWeb.Constant;
using IntegrityWeb.Models;
using System;
using System.IO;

namespace IntegrityWeb.Helper
{
    public static class MailTemplateGenerator
    {
        public static string MailTemplate(string TemplateFileName, MailTemplateModel mt)
        {
            string FilePath = string.Empty;
            FilePath = System.Web.Hosting.HostingEnvironment.MapPath("~\\MailTemplate\\" + TemplateFileName);
            var mailTemplate = string.Empty;

            mailTemplate = ReadFile(FilePath).ToString();
            mailTemplate = mailTemplate.Replace("$$SiteURL$$", SiteConfigration.webURL);
            mailTemplate = mailTemplate.Replace("$$SiteLogo$$", SiteConfigration.webURL + SiteConfigration.LogoURL);
            mailTemplate = mailTemplate.Replace("$$SiteName$$", SiteConfigration.Name);
            mailTemplate = mailTemplate.Replace("$$Copyrights$$", SiteConfigration.Copyrights);
            mailTemplate = mailTemplate.Replace("$$SiteEmailAddress$$", SiteConfigration.ContactEmail);
            mailTemplate = mailTemplate.Replace("$$CustomerName$$", mt.CustomerName);
            mailTemplate = mailTemplate.Replace("$$CustomerEmail$$", mt.CustomerEmail);
            mailTemplate = mailTemplate.Replace("$$CustomerContactNo$$", mt.CustomerContactNo);
            mailTemplate = mailTemplate.Replace("$$CustomerAddress$$", mt.CustomerAddress);
            mailTemplate = mailTemplate.Replace("$$Message$$", mt.Message);
            mailTemplate = mailTemplate.Replace("$$RatingstarImage$$", System.Web.Hosting.HostingEnvironment.MapPath("~\\Images\\star\\" + mt.Ratingstar + ".png"));
            mailTemplate = mailTemplate.Replace("$$ReferralName$$", mt.ReferralName);
            mailTemplate = mailTemplate.Replace("$$ReferralEmail$$", mt.ReferralEmail);
            mailTemplate = mailTemplate.Replace("$$ReferralContactNo$$", mt.ReferralContactNo);
            mailTemplate = mailTemplate.Replace("$$ReferralToName$$", mt.ReferralToName);
            mailTemplate = mailTemplate.Replace("$$ReferralToEmail$$", mt.ReferralToEmail);
            mailTemplate = mailTemplate.Replace("$$ReferralToContactNo$$", mt.ReferralToContactNo);
            mailTemplate = mailTemplate.Replace("$$Budget$$", mt.Budget);
            return mailTemplate;
        }

        public static string ReadFile(string FileName)
        {
            try
            {
                using (StreamReader reader = File.OpenText(FileName))
                {
                    string fileContent = reader.ReadToEnd();
                    if (fileContent != null && fileContent != "")
                    {
                        return fileContent;
                    }
                }
            }
            catch (Exception ex)
            {
                //Log
                throw ex;
            }
            return null;
        }
    }
}