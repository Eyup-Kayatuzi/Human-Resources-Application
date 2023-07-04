using System.ComponentModel.DataAnnotations;

namespace InsanKaynaklari.MVC.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Bu kısım Boş Bırakılamaz")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Bu kısım Boş Bırakılamaz")]
        public string Password { get; set; }
    }
}
