using InsanKaynaklari.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Application.Interfaces.Repositories.UserRepo
{
    public interface IUserReadRepository : IReadRepository<AppIdentityUser>
    {
        IQueryable<AppIdentityUser> UMGetAll();// using with usermanager
        IQueryable<AppIdentityUser> UMGetWhere(Expression<Func<AppIdentityUser, bool>> predicate);// using with usermanager
        Task<IList<AppIdentityUser>> UMGetAllByRoleAsync(string roleName);// using with usermanager
        Task<IEnumerable<AppIdentityUser>> UMGetWhereByRoleAsync(Func<AppIdentityUser, bool> predicate, string roleName);
        Task<AppIdentityUser> UMGetUserByIdAsync(string id);
        Task<AppIdentityUser> UMGetUserByNameAsync(string userName);
        Task<IEnumerable<string>> UMGetAllRolesByUserAsync(AppIdentityUser appIdentityUser);
        Task<bool> UMCheckPasswordAsync(AppIdentityUser appIdentityUser, string password);
        Task<AppIdentityUser> UMFindByEmailAsync(string email);       
        Task<IdentityResult> UMConfirmEmailAsync(AppIdentityUser user, string token);    
    }
}
