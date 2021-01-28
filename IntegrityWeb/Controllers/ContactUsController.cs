using IntegrityWeb.Constant;
using IntegrityWeb.Helper;
using IntegrityWeb.Models;
using System;
using System.Configuration;
using System.Net.Mail;
using System.Web.Mvc;

namespace IntegrityWeb.Controllers
{
    public class ContactUsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(string name, string company, string email, string phone, string budget, string comments)
        {
            try
            {
                string SMTPUserName = ConfigurationManager.AppSettings["SMTPUserName"];
                string FromMailPassword = ConfigurationManager.AppSettings["SMTPPassword"];
                string ToMailId = ConfigurationManager.AppSettings["ContactEmail"];
                string Host = ConfigurationManager.AppSettings["SMTPHost"];
                int Port = Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPort"]);
                bool EnableSSL = Convert.ToBoolean(ConfigurationManager.AppSettings["SMTPEnableSSL"]);

                //string Body = "<b>Name</b> : " + name + "<br/>" + "<b>Email</b> : " + email + "<br/>" + "<b>Company Name</b> : " + company + "<br/>" + "<b>Phone Number</b> : " + phone + "<br/>" + "<b>Budget</b> : " + budget + "<br/>" + "<b>Message</b> : " + comments;

                MailTemplateModel mtCustomer = new MailTemplateModel
                {
                    CustomerContactNo = phone,
                    CustomerEmail = email,
                    CustomerName = name,
                    Message = comments,
                    Budget = budget
                };
                string AdminMailBody = MailTemplateGenerator.MailTemplate("ContactUsAdmin.html", mtCustomer);
                string CustomerMailBody = MailTemplateGenerator.MailTemplate("ContactUsCustomer.html", mtCustomer);

                MailMessage Adminmail = new MailMessage();
                SmtpClient AdminSmtpServer = new SmtpClient(Host);
                AdminSmtpServer.UseDefaultCredentials = false;
                Adminmail.From = new MailAddress(SMTPUserName);
                Adminmail.To.Add(ToMailId);
                Adminmail.Subject = "Business inquiry from " + SiteConfigration.Name;
                Adminmail.IsBodyHtml = true;
                Adminmail.Body = AdminMailBody;
                AdminSmtpServer.Port = Port;
                AdminSmtpServer.Credentials = new System.Net.NetworkCredential(SMTPUserName, FromMailPassword);
                AdminSmtpServer.EnableSsl = EnableSSL;
                AdminSmtpServer.Send(Adminmail);

                MailMessage Customermail = new MailMessage();
                SmtpClient CustomerSmtpServer = new SmtpClient(Host);
                CustomerSmtpServer.UseDefaultCredentials = false;
                Customermail.From = new MailAddress(SMTPUserName);
                Customermail.To.Add(email);
                Customermail.Subject = "Business inquiry for " + SiteConfigration.Name;
                Customermail.IsBodyHtml = true;
                Customermail.Body = CustomerMailBody;
                CustomerSmtpServer.Port = Port;
                CustomerSmtpServer.Credentials = new System.Net.NetworkCredential(SMTPUserName, FromMailPassword);
                CustomerSmtpServer.EnableSsl = EnableSSL;
                CustomerSmtpServer.Send(Customermail);
                return Json("Request submitted successfully. Integrity team will contact you as soon as possible.");
            }
            catch (Exception ex)
            {
                return Json("Email error : " + ex.Message);
            }
        }
    }
}