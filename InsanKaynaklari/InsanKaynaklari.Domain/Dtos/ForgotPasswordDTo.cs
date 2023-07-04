using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Domain.Dtos
{
    public class ForgotPasswordDTo
    {
        [Required(ErrorMessage = "EMail Address is required!")]
        [EmailAddress(ErrorMessage = "Pls write to your EMail address!")]
        public string EMailAddress { get; set; }    
        public string? NewPassword { get; set; }
        public string? ReNewPassword { get; set; }
        public string? OldPassword { get; set; }       
    }
}
