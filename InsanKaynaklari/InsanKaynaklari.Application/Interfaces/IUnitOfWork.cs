using InsanKaynaklari.Application.Interfaces.Repositories.PersonnelExpenseRepo;
using InsanKaynaklari.Application.Interfaces.Repositories.UserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserReadRepository UserRead { get; }
        IUserWriteRepository UserWrite { get; }
        IExpenseWriteRepository ExpenseWrite { get; }
        IExpenseReadRepository ExpenseRead { get; }
    }
}
