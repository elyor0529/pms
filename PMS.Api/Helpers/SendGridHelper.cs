using Microsoft.AspNet.Identity;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace PMS.Api.Helpers
{
    public class SendGridHelper
    {
        public static async Task SendAsync(IdentityMessage message, MailAddress from)
        {
            var myMessage = new SendGridMessage();

            myMessage.AddTo(message.Destination);
            myMessage.From = from;
            myMessage.Subject = message.Subject;
            myMessage.Text = message.Body;
            myMessage.Html = message.Body;

            myMessage.DisableClickTracking();

            // Create a Web transport for sending email. 
            var transportWeb = new Web(ConfigurationManager.AppSettings["SendGridKey"]);

            // Send the email.
            if (transportWeb != null)
            {
                await transportWeb.DeliverAsync(myMessage);
            }
            else
            {
                await Task.FromResult(0);
            }
        }
    }
}