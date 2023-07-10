using CinemaTicketSystem.Domain;
using CinemaTicketSystem.Domain.DomainModels;
using CinemaTicketSystem.Service.Interface;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketSystem.Service.Implementation
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;

        public EmailService(EmailSettings settings)
        {
            _settings = settings;
        }

        public async Task SendEmailAsync(List<EmailMessage> allMails)
        {
            List<MimeMessage> messages = new List<MimeMessage>();

            foreach (var item in allMails)
            {
                var emailMessage = new MimeMessage
                {
                    Sender = new MailboxAddress(_settings.SendersName,
                    _settings.SmtpUserName),
                    Subject = item.Subject
                };

                emailMessage.From.Add(new MailboxAddress(
                    _settings.EmailDisplayName,
                    _settings.SmtpUserName));

                emailMessage.Body = new TextPart(TextFormat.Plain)
                {
                    Text = item.Content
                };

                emailMessage.To.Add(new MailboxAddress(item.Subject, item.MailTo)); // ?

                messages.Add(emailMessage);
            }

            // Creating a connection with the SMTP server:

            try
            {
                using (var smtp = new MailKit.Net.Smtp.SmtpClient())
                {
                    var socketOption = _settings.EnableSsl ? SecureSocketOptions.StartTls : SecureSocketOptions.Auto;

                    await smtp.ConnectAsync(_settings.SmtpServer, _settings.SmptServerPort, socketOption);

                    // Once we connected, now we need to authorize:
                    if (string.IsNullOrEmpty(_settings.SmtpUserName))
                    {
                        await smtp.AuthenticateAsync(_settings.SmtpUserName, _settings.SmtpPassword);
                    }

                    // And now to send the message

                    foreach (var item in messages)
                    {
                        await smtp.SendAsync(item);
                    }

                    // When we finish sending all the messages. Time to disconnect from the mail service

                    await smtp.DisconnectAsync(true);

                }

            }
            catch (SmtpException ex)
            {
                throw ex;
            }
        }
    }
}
