using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Text;

namespace ICT4Rails.Logic
{
    public class Mailing
    {
        public Mailing()
        {
            
        }

        public void mail(string adress, string message, string titel)
        {
            SmtpClient client = new SmtpClient
            {
                Port = 587,
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential("railpst18@gmail.com", "Proftaakpts18")
            };

            MailMessage mm = new MailMessage("railpst18@gmail.com", adress, titel, message)
            {
                BodyEncoding = Encoding.UTF8,
                DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            };

            client.Send(mm);
        }
    }
}