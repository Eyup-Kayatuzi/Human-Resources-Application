using InsanKaynaklari.Domain.EMailManagement.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using MimeKit.Text;
using System.Text;
using System.Threading.Tasks;
using InsanKaynaklari.Domain.EMailManagement.Models;
using InsanKaynaklari.Domain.Dtos;
using InsanKaynaklari.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace InsanKaynaklari.Domain.EMailManagement.Service
{
    public class EMailService : IEmailService
    {
        private readonly EMailConfig _emailConfig;
        private readonly EMailService _emailService;
        
		public EMailService(EMailConfig eMailConfig)
        {
            _emailConfig = eMailConfig;
        }
        public void SendEmail(EMailMessage mailMessage)
        {
            var eMailMessage = CreateEmailMessage(mailMessage);
            Send(eMailMessage);
        }

        private void Send(MimeMessage eMailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.Username, _emailConfig.Password);
                    client.Send(eMailMessage);
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private MimeMessage CreateEmailMessage(EMailMessage mailMessage)
        {
            MimeMessage eMailMessage = new MimeMessage();
            eMailMessage.From.Add(new MailboxAddress("İnsan Kaynakları", _emailConfig.From));
            eMailMessage.To.AddRange(mailMessage.To);
            eMailMessage.Subject = mailMessage.Subject;
            eMailMessage.Body = new TextPart(TextFormat.Html) { Text = mailMessage.Body };
            return eMailMessage;
        }

        public string GenerateRandomPassword()
        {
            string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder sb = new StringBuilder();
            Random rand = new Random();

            while (sb.Length < 7)
            {
                int index = rand.Next(allowedChars.Length);
                sb.Append(allowedChars[index]);
            }

            return sb.ToString();
        }
	}
}
