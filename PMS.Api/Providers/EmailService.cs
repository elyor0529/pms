using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using SendGrid;
using System.Diagnostics;
using PMS.Api.Helpers;

namespace PMS.Api.Providers
{

    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            await SendGridHelper.SendAsync(message, new MailAddress("levdeo@hotmail.com"));
        }
    }
}