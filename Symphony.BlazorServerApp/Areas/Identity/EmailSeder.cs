using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace Symphony.BlazorServerApp.Areas.Identity
{
    public class EmailSeder : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            throw new System.NotImplementedException();
        }
    }
}