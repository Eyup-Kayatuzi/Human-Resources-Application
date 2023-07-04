using InsanKaynaklari.Domain.Enums;

namespace InsanKaynaklari.MVC.Areas.CompanyManager.ViewModels
{
    public class ListOfExpensesVM
    {
        public int ExpensesId { get; set; }  
        public string FirstName { get; set; } = null!;
        public string? SecondName { get; set; }
        public string LastName { get; set; } = null!;
        public string? SecondLastName { get; set; }
        public string Department { get; set; } = null!;
        public DateTime RequestDate { get; set; }
        public DateTime ReplyDate { get; set; }
        public string FolderPath { get; set; }
        public Currency Currency { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public string ExpenseAmount { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
    }
}
