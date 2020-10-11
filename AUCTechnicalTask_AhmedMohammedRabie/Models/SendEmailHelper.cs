using AUCTechnicalTask_AhmedMohammedRabie.DL.Enums;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AUCTechnicalTask_AhmedMohammedRabie.Models
{
    public class SendEmailHelper
    {
        public void sendEmailConfirmation(string Email , ApplyingStatus applyingStatus)
        {
            var apiKey = ConfigurationManager.AppSettings["RESALTY_SENDGRID_KEY"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(ConfigurationManager.AppSettings["emailService:Account"], "Ahmed Mohamed Rabie");
            var subject = "test";//message.Subject;
            var to = new EmailAddress(Email);
            var plainTextContent = "";
            string htmlContent = "";
            if (applyingStatus== ApplyingStatus.Accepted)
            {
                htmlContent = "<html> <head></head> <body>  <h1 style=\"font-size:30px;padding-right:30px;padding-left:30px\">Congratulations Admin Approve your request on scholarship </h1><p style=\"font-size:17px;padding-right:30px;padding-left:30px\"> please visit our website .</p>  </body> </html>";

            }
            else
                htmlContent = "<html> <head></head> <body>  <h1 style=\"font-size:30px;padding-right:30px;padding-left:30px\">sorry to approve that Admin reject your request on scholarship </h1><p style=\"font-size:17px;padding-right:30px;padding-left:30px\"> please visit our website and try again hard luck .</p>  </body> </html>";

            //var htmlContent = "<html>   <head></head>  <body>  <h1 style=\"font-size:30px;padding-right:30px;padding-left:30px\">  Confirm your email address</h1>      <p style=\"font-size:17px;padding-right:30px;padding-left:30px\">  Hello! We just need to verify that <strong><a href=\"#\"\">{0}</a></strong> is your email address, and then we’ll help you find your workspaces.\t</p>  <p><strong> Thanks to install your mobile app using the below link:</strong>\t</p> <p> <strong><a href=\"https://play.google.com/store/apps/details?id=org.nativescript.Field\"\">FieldCTRL App Link </a></strong>.\t</p>   <a   href=\"{1}\" style=\"min-width: 196px;   border-top: 13px solid;  border-bottom: 13px solid;   border-right: 24px solid;  border-left: 24px solid;    border-color: #0b80f9;    border-radius: 4px;  background-color: #0b80f9;    color: #ffffff;   font-size: 18px;    line-height: 18px;     word-break: break-word;    display: inline-block; text-align: center;  font-weight: 900;text-decoration: none!important;\"> Confirm Email Address   </a>  <p style=\"font-size:17px;padding-right:30px;padding-left:30px;margin-top:40px;margin-bottom:30px\">  <strong>Password</strong><br>  {2}</p>  </body></html>";
            // htmlContent.Replace("{0}", "http://localhost:54816/api/User/ConfirmEmail" + "?Email=" + to);
            //string.Format(htmlContent, "http://localhost:54816/api/User/ConfirmEmail" + "?Email="+to);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            if (client != null)
            {
                 client.SendEmailAsync(msg);
            }
            else
            {
                Trace.TraceError("Failed to Send Message");
                // Task.FromResult(0);
            }
        }
    }
}