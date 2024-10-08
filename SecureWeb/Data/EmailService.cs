using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SecureWeb.Models;

namespace SecureWeb.Data
{
    public class EmailService
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public void SendEmail(string to, string subject, string body)
        {
            using (var client = new SmtpClient(_smtpSettings.Host, _smtpSettings.Port))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password);

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_smtpSettings.From),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(to);

                try
                {
                    client.Send(mailMessage);
                    Console.WriteLine("Email sent successfully."); 
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}"); 
                }
            }
        }
    }
}