using InsanKaynaklari.Application.Interfaces;
using InsanKaynaklari.Application.Interfaces.Repositories.PersonnelExpenseRepo;
using InsanKaynaklari.Application.Interfaces.Repositories.UserRepo;
using InsanKaynaklari.Persistence.Context;

namespace InsanKaynaklari.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserReadRepository UserRead { get; }
        public IUserWriteRepository UserWrite { get; }

        public IExpenseWriteRepository ExpenseWrite { get; }
        public IExpenseReadRepository ExpenseRead { get; }
        

        private readonly InsanKaynaklariDb _dbContext;
        public UnitOfWork(IUserReadRepository userRead, IUserWriteRepository userWrite, InsanKaynaklariDb dbContext, IExpenseWriteRepository expenseWrite, IExpenseReadRepository expenseRead)
        {
            UserRead = userRead;
            UserWrite = userWrite;  
            _dbContext = dbContext;
            ExpenseWrite = expenseWrite;
            ExpenseRead = expenseRead;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
