using RG_Store.BLL.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RG_Store.BLL.Service.Implementation
{
    public class EmailService :IEmailService
    {
        public void SendEmail(string to, string subject, string body)
        {
            var smtpClient = new SmtpClient("smtp.outlook.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("rg_storeproject@outlook.com", "123456789/."),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("rg_storeproject@outlook.com"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(to);

            smtpClient.Send(mailMessage);
        }
    }
}
