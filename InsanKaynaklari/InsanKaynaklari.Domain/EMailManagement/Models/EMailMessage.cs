using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Domain.EMailManagement.Models
{
    public class EMailMessage
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public EMailMessage(IDictionary<string,string> to,string subject,string body)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(recipient => new MailboxAddress(recipient.Key,recipient.Value)));
            Subject = subject;
            Body = body;
        }
    }
}
