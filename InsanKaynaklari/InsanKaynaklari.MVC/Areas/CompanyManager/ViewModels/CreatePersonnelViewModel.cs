using InsanKaynaklari.MVC.CustomeValidations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace InsanKaynaklari.MVC.Areas.CompanyManager.ViewModels
{
    public class CreatePersonnelViewModel
    {
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; } = null!;

        public string? SecondName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; } = null!;

        public string? SecondLastName { get; set; }

        //burada validation kullanıldı
        
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = null!; // bug

        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; } = null!;

        public string PicturePath
        {
            get
            {
                if (Gender == "Male")
                {
                    return "20180125_001_1_.jpg";
                }
                else if (Gender == "Female")
                {
                    return "20180129_002.jpg";
                }
                else
                {
                    return null;
                }
            }
        }

        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Birth Place is required")]
        public string BirthPlace { get; set; } = null!;

        [Required(ErrorMessage = "TC is required")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "TC must be 11 digits")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only numbers are allowed for TC")]
        public string Tc { get; set; } = null!;

        [Required(ErrorMessage = "Start Date of Job is required")]
        public DateTime StartDateOfJob { get; set; }
        public DateTime? LeaveDateOfJob { get; set; }

        [Required(ErrorMessage = "IsActive is required")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Company Info is required")]
        public string CompanyInfo { get; set; } = null!;

        [Required(ErrorMessage = "Profession is required")]
        public string Profession { get; set; } = null!;

        [Required(ErrorMessage = "Department is required")]
        public string Department { get; set; } = null!;

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; } = null!;

        [Required(ErrorMessage = "Salary is required")]
        public string Salary { get; set; } = null!; // bug

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; } = null!;
    }
}
