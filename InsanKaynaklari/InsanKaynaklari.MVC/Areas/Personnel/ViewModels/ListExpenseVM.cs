using InsanKaynaklari.Domain.Enums;

namespace InsanKaynaklari.MVC.Areas.Personnel.ViewModels
{
    public class ListExpenseVM
    {
        public ExpenseType ExpenseType { get; set; }
        public string ExpenseAmount { get; set; }
        public Currency Currency { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime ReplyDate { get; set; }
        public string FolderPath { get; set; }
    }
}
