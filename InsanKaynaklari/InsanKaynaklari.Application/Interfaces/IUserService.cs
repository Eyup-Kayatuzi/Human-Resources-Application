using InsanKaynaklari.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Application.Interfaces
{
    public interface IUserService
    {
        Task<AppIdentityUser> UMGetUserByIdAsync(string id);
        Task<AppIdentityUser> UMGetUserByNameAsync(string userName);
        List<AppIdentityUser> UMGetAllUsers();
        Task<List<AppIdentityUser>> UMGetAllUsersAsync();
        Task<List<AppIdentityUser>> UMGetUsersWhereAsync(Expression<Func<AppIdentityUser, bool>> predicate);
        Task<List<AppIdentityUser>> UMGetAllUsersByRoleAsync(string roleName);
        Task<List<AppIdentityUser>> UMGetWhereByRoleAsync(Func<AppIdentityUser, bool> predicate, string roleName);
        Task<bool> SaveDataBaseAsync();
        Task<List<string>> UMGetAllRolesByUserAsync(AppIdentityUser appIdentityUser);
        Task<bool> UMCheckUserWithPasswordAsync(AppIdentityUser appIdentityUser, string password);
        Task<SignInResult> SMSignInWithPasswordAsync(AppIdentityUser appIdentityUser, string password);
        Task SMLogOffAsync();
        Task<AppIdentityUser> UMFindUserByEmailAsync(string email);     
        Task<IdentityResult> UMConfirmEmailAsync(AppIdentityUser user, string token);
        Task<IdentityResult> UMUpdateAsync(AppIdentityUser loginedUser);
        Task<IdentityResult> UMCreateAsync(AppIdentityUser user, string password);
        Task<IdentityResult> UMAddToRoleAsync(AppIdentityUser user, string rol);


    }
}
