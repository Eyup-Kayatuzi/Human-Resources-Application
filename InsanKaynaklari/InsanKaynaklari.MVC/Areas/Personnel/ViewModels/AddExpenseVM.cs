using InsanKaynaklari.Domain.Enums;
using InsanKaynaklari.MVC.CustomeValidations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace InsanKaynaklari.MVC.Areas.Personnel.ViewModels
{
    public class AddExpenseVM
    {
        public AddExpenseVM()
        {
            ExpenseTypes = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Konaklama", Value = ExpenseType.Konaklama.ToString()},
                    new SelectListItem {Text = "Ulaşım", Value = ExpenseType.Ulaşım.ToString()},
                    new SelectListItem {Text = "Yemek", Value = ExpenseType.Yemek.ToString()}
                };
            Currencies = new List<SelectListItem>()
            {
                new SelectListItem {Text = "₺", Value = Currency.TL.ToString()},
                    new SelectListItem {Text = "$", Value = Currency.USD.ToString()},
                    new SelectListItem {Text = "€", Value = Currency.EUR.ToString()}
            };
        }
        public ExpenseType ExpenseType { get; set; }
        public List<SelectListItem>? ExpenseTypes { get; set; }
        [Required(ErrorMessage = "Tutar kısmı boş bırakılamaz")]
        public string ExpenseAmount { get; set; } = null!;
        public Currency Currency { get; set; }
        public List<SelectListItem>? Currencies { get; set; }

        [Required(ErrorMessage = "Eklenti boş bırakılamaz")]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".pdf" }, ErrorMessage = "Lütfen JPEG,JPG, PNG veya PDF formatında bir dosya yükleyin.")]
        public IFormFile? NewPicturePath { get; set; }
    }
}
