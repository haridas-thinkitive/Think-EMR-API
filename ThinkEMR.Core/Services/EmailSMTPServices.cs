using MimeKit;
using MailKit.Net.Smtp;
using ThinkEMR_Care.DataAccess.Models.EmailConfig;
using ThinkEMR_Care.DataAccess.Models;
using ThinkEMR_Care.Core.Services.Interface;

namespace ThinkEMR_Care.Core.Services
{
    public class EmailSMTPServices : IEmailSMTP
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailSMTPServices(EmailConfiguration emailConfiguration)
        {
            _emailConfig = emailConfiguration;
        }

        public async Task SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            await Send(emailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", _emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };

            return emailMessage;
        }

        private async Task Send(MimeMessage mailMessage)
        {
            using var client = new SmtpClient();
            try
            {
                await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync(_emailConfig.Username, _emailConfig.Password);
                await client.SendAsync(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                await client.DisconnectAsync(true);
            }
        }
    }

}
