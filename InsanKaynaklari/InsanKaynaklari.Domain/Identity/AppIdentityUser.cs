using InsanKaynaklari.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Domain.Identity
{
    public class AppIdentityUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string? SecondName { get; set; }
        public string LastName { get; set; } = null!;
        public string? SecondLastName { get; set; }
        public string PicturePath { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }  
        public string BirthPlace { get; set; } = null!;
        public string Tc { get; set; } = null!;
        public DateTime StartDateOfJob { get; set; }
        public DateTime LeaveDateOfJob { get; set; }
        public bool IsActive { get; set; }  
        public string CompanyInfo { get; set; } = null!;// suan icin sirket adi
        public string Profession { get; set; } = null!; // meslegi
        public string Department { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Salary { get; set; } = null!; // minimum askeri
        public string Gender { get; set; } = null!;
        public string? SpecificMail { get; set; }
        public List<PersonnelExpense> PersonnelExpenses { get; set; } = new();
    }
}
