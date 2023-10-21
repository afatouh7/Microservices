using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ordering.Application.Contracts.Infrastructure;
using Ordering.Application.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        public EmailService(IOptions<EmaillSettings> emaillSettings, ILogger<EmailService> logger)
        {
            _emaillSettings = emaillSettings.Value;
            _logger = logger;
        }

        public EmaillSettings _emaillSettings { get; set; }
        public ILogger<EmailService> _logger { get; set; }

        public async Task<bool> SendEmail(Emaill emaill)
        {
            var client = new SendGridClient(_emaillSettings.ApiKey);

            var subject = emaill.Subject;
            var to =new  EmailAddress(emaill.To);
            var emailBody = emaill.Body;
            var from = new EmailAddress
            {
                Email = _emaillSettings.FromAddress,
                Name = _emaillSettings.FromName
            };
            var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
            var response = await client.SendEmailAsync(sendGridMessage);
            _logger.LogInformation("Email sent");
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK) return true;

            _logger.LogError("Email sening failed");
            return false;

        }
    }
}
