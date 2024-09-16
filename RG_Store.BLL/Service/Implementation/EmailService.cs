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
    public class EmailService : IEmailService
    {
        public void SendEmail(string to, string subject, string body)
        {
            var smtpClient = new SmtpClient("smtp.outlook.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("RG_StoreProject@outlook.com", "123456789/."),
                EnableSsl = true,
            };

            smtpClient.Send("RG_StoreProject@outlook.com", to, subject, body);
        }
    }
}
