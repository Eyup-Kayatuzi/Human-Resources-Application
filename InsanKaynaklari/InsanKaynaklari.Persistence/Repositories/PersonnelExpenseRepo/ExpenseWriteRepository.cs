using InsanKaynaklari.Application.Interfaces.Repositories.PersonnelExpenseRepo;
using InsanKaynaklari.Domain.Entities;
using InsanKaynaklari.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Persistence.Repositories.PersonnelExpenseRepo
{
    public class ExpenseWriteRepository : WriteRepository<PersonnelExpense>, IExpenseWriteRepository
    {
        public ExpenseWriteRepository(InsanKaynaklariDb context) : base(context)
        {
        }
    }
}
