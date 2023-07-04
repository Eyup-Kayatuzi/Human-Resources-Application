using InsanKaynaklari.Application.Interfaces.Repositories.UserRepo;
using InsanKaynaklari.Domain.Identity;
using InsanKaynaklari.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Persistence.Repositories.UserRepo
{
    public class UserReadRepository : ReadRepository<AppIdentityUser>, IUserReadRepository
    {
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly SignInManager<AppIdentityUser> _signInManager;
        public UserReadRepository(InsanKaynaklariDb context, UserManager<AppIdentityUser> userManager) : base(context)
        {
            _userManager = userManager;
        }
        public IQueryable<AppIdentityUser> UMGetAll() // using with usermanager
        {
            return _userManager.Users;
        }

        public async Task<IList<AppIdentityUser>> UMGetAllByRoleAsync(string roleName)
        {
            return await _userManager.GetUsersInRoleAsync(roleName);
        }

        public async Task<AppIdentityUser> UMGetUserByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<AppIdentityUser> UMGetUserByNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public IQueryable<AppIdentityUser> UMGetWhere(Expression<Func<AppIdentityUser, bool>> predicate)
        {
            return _userManager.Users.Where(predicate);
        }

        public async Task<IEnumerable<AppIdentityUser>> UMGetWhereByRoleAsync(Func<AppIdentityUser, bool> predicate, string roleName)
        {
            return (await _userManager.GetUsersInRoleAsync(roleName)).Where(predicate);
        }
        public async Task<IEnumerable<string>> UMGetAllRolesByUserAsync(AppIdentityUser appIdentityUser)
        {
            return await _userManager.GetRolesAsync(appIdentityUser);  
        }

        public async Task<bool> UMCheckPasswordAsync(AppIdentityUser appIdentityUser, string password)
        {
            return (await _userManager.CheckPasswordAsync(appIdentityUser, password));
        }

        public async Task<AppIdentityUser> UMFindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IdentityResult> UMConfirmEmailAsync(AppIdentityUser user, string token)
        {
            return await _userManager.ConfirmEmailAsync(user, token);
        }
	}
}
