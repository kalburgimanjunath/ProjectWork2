using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectWork.Entities;
using System.Net.Mail;
using System.Net.Mime;
using System;

namespace ProjectWork.Services
{
   public class EmailSenderService: IEmailSenderService
    {
        public async Task sendMail(EmailMessage message)
        {
            try { 
            #region formatter
            string text = string.Format("Please click on this link to {0}: {1}", message.Subject, message.Body);
            //string html = "Please confirm your account by clicking this link: <a href=\"" + message.Body + "\">link</a><br/>";

            //html += HttpUtility.HtmlEncode(@"Or click on the copy the following link on the browser:" + message.Body);
            #endregion

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("galibgaurav@gmail.com");
            msg.To.Add(new MailAddress(message.Destination));
            msg.Subject = message.Subject;
            msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
            //msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32(25));
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("galibgaurav@gmail.com", "letsdoit@1234");
            smtpClient.Credentials = credentials;
            smtpClient.EnableSsl = false;
            await smtpClient.SendMailAsync(msg);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
