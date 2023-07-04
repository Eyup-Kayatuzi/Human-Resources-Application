using InsanKaynaklari.Application.Interfaces;
using InsanKaynaklari.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Persistence.Concretes
{
    public class ExpenseService : IExpenseService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ExpenseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> AddAsync(PersonnelExpense entity)
        {
            return await _unitOfWork.ExpenseWrite.AddAsync(entity);
        }

        public async Task<List<PersonnelExpense>> GetWhereAsync(Expression<Func<PersonnelExpense, bool>> predicate)
        {
            return await _unitOfWork.ExpenseRead.GetWhere(predicate).ToListAsync();
        }

        public async Task<List<PersonnelExpense>> GetWhereWithIncludeAsync(Expression<Func<PersonnelExpense, bool>> predicate, Expression<Func<PersonnelExpense, object>> predicate2)
        {
            return await _unitOfWork.ExpenseRead.GetWhereWithInclude(predicate, predicate2).ToListAsync();
        }
        public async Task<PersonnelExpense> GetFirstOrDefaultAsync(Expression<Func<PersonnelExpense, bool>> predicate)
        {

            return await _unitOfWork.ExpenseRead.GetFirstOrDefaultAsync(predicate);
        }

        public int Save()
        {
            return _unitOfWork.ExpenseWrite.Save(); 
        }
    }
}
