using InsanKaynaklari.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Application.Interfaces
{
    public interface IExpenseService
    {
        Task<bool> AddAsync(PersonnelExpense entity);
        Task<List<PersonnelExpense>> GetWhereAsync(Expression<Func<PersonnelExpense, bool>> predicate);
        Task<List<PersonnelExpense>> GetWhereWithIncludeAsync(Expression<Func<PersonnelExpense, bool>> predicate, Expression<Func<PersonnelExpense, object>> predicate2);
        Task<PersonnelExpense> GetFirstOrDefaultAsync(Expression<Func<PersonnelExpense, bool>> predicate);
        int Save();
    }
}
