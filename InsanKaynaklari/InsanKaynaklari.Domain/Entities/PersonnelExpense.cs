using InsanKaynaklari.Domain.Enums;
using InsanKaynaklari.Domain.Identity;

namespace InsanKaynaklari.Domain.Entities
{
    public class PersonnelExpense
    {
        public int Id { get; set; } 
        public ExpenseType ExpenseType { get; set; } 
        public string ExpenseAmount { get; set; }   
        public Currency Currency { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }    
        public DateTime RequestDate { get; set; }    
        public DateTime ReplyDate { get; set; }    
        public string FolderPath { get; set; }  
        public string AppIdentityUserId { get; set; } 
        public AppIdentityUser AppIdentityUser { get; set; }
    }
}
