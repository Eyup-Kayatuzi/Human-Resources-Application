using InsanKaynaklari.Domain.EMailManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Domain.EMailManagement.Service
{
    public interface IEmailService
    {
        void SendEmail(EMailMessage mailMessage);
        string GenerateRandomPassword();       

	}
}
