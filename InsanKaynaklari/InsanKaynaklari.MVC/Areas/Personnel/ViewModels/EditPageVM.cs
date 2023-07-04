using InsanKaynaklari.MVC.CustomeValidations;
using System.ComponentModel.DataAnnotations;

namespace InsanKaynaklari.MVC.Areas.Personnel.ViewModels
{
    public class EditPageVM
    {
        public string? PicturePath { get; set; }
        [Required(ErrorMessage = "Adres kısmı boş bırakılamaz")]
        public string Address { get; set; } = null!;
        [RegularExpression(@"^(05\d{9})$", ErrorMessage = "Geçerli bir  telefon numarası giriniz.")]
        public string PhoneNumber { get; set; } = null!;
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" }, ErrorMessage = "Lütfen JPEG,JPG veya PNG formatında bir dosya yükleyin.")]
        public IFormFile? NewPicturePath { get; set; }
    }
}
