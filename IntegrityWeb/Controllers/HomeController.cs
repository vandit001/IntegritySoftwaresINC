using System;
using System.Configuration;
using System.Net.Mail;
using System.Web.Mvc;

namespace IntegrityWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ScheduleMeeting(string name, string email, string phone, string meetdate)
        {
            try
            {
                string FromMailId = ConfigurationManager.AppSettings["SMTPUserName"];
                string FromMailPassword = ConfigurationManager.AppSettings["SMTPPassword"];
                string ToMailId = ConfigurationManager.AppSettings["SMTPMailTo"];
                string Host = ConfigurationManager.AppSettings["SMTPHost"];
                int Port = Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPort"]);
                bool EnableSSL = Convert.ToBoolean(ConfigurationManager.AppSettings["SMTPEnableSSL"]);

                string Body = "<b>Name</b> : " + name + "<br/>" + "<b>Email</b> : " + email + "<br/>" + "<b>Phone Number</b> : " + phone + "<br/>" + "<b>Meeting Datetime</b> : " + meetdate;

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(Host);
                mail.From = new MailAddress(FromMailId);
                mail.To.Add(ToMailId);
                mail.Subject = "Meeting Schedule request from Integrity";
                mail.IsBodyHtml = true;
                mail.Body = Body;
                SmtpServer.Port = Port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(FromMailId, FromMailPassword);
                SmtpServer.EnableSsl = EnableSSL;
                SmtpServer.Send(mail);
                return Json("Meeting Schedule request submitted successfully. Integrity team will contact you as soon as possible.");
            }
            catch (Exception ex)
            {
                return Json("Email error : " + ex.Message);
            }
        }
    }
}