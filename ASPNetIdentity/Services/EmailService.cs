using Microsoft.AspNet.Identity;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace ASPNetIdentity.Services
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            await configSendGridAsync(message);
        }

        private async Task configSendGridAsync(IdentityMessage message)
        {
            var myMessage = new SendGridMessage();

            var apiKey = ConfigurationManager.AppSettings["MyKey"];

            myMessage.AddTo(message.Destination);
            myMessage.From = new EmailAddress("olawolexyoni@gmail.com", "Olawole Oni");
            myMessage.Subject = message.Subject;
            myMessage.PlainTextContent = message.Body;
            myMessage.HtmlContent = message.Body;

            // Create a web transport for sending Email
            var client = new SendGridClient(apiKey);
            if (client != null)
            {
                var response = await client.SendEmailAsync(myMessage);
            }
            else
            {
                await Task.FromResult(0);
            }
            

            
            
 
        }

        private class Web
        {
            private NetworkCredential credentials;

            public Web(NetworkCredential credentials)
            {
                this.credentials = credentials;
            }
        }
    }
}