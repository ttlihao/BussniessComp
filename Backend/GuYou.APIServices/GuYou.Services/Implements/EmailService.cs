﻿using GuYou.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Mail;

namespace GuYou.Services.Implements
{
    public class EmailService : IEmailService
    {
        private readonly SmtpClient _smtpClient;
        private readonly string _senderEmail;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IConfiguration configuration, ILogger<EmailService> logger)
        {
            _senderEmail = configuration["EmailSettings:Sender"]
                ?? throw new ArgumentException("Email Sender is not configured.");
            var password = configuration["EmailSettings:Password"];
            var host = configuration["EmailSettings:Host"];
            var port = int.Parse(configuration["EmailSettings:Port"]
                ?? throw new ArgumentException("Email port is not configured."));

            _smtpClient = new SmtpClient(host, port)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_senderEmail, password)
            };

            _logger = logger;
        }

        public async Task<bool> SendEmailAsync(IEnumerable<string> toList, string subject, string body)
        {
            try
            {
                foreach (var to in toList)
                {
                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(_senderEmail),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = true // Enable HTML content
                    };
                    mailMessage.To.Add(to);

                    await _smtpClient.SendMailAsync(mailMessage);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send email.");
                return false;
            }

            return true;
        }
    }
}
