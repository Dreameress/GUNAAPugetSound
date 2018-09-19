using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUNAAPugetSound.Services
{
    public class EmailSender : IEmailSender, Microsoft.AspNetCore.Identity.UI.Services.IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Task.CompletedTask;
        }
    }
}
