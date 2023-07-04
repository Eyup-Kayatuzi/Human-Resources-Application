using InsanKaynaklari.Application.Interfaces.Repositories.UserRepo;
using InsanKaynaklari.Domain.Identity;
using InsanKaynaklari.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Persistence.Repositories.UserRepo
{
    public class UserWriteRepository : WriteRepository<AppIdentityUser>, IUserWriteRepository
    {
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly SignInManager<AppIdentityUser> _signInManager;
        public UserWriteRepository(InsanKaynaklariDb context, UserManager<AppIdentityUser> userManager, SignInManager<AppIdentityUser> signInManager) : base(context)
        {
            _userManager = userManager;
            _signInManager = signInManager; 
        }
        public async Task SMLogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<SignInResult> SMPasswordSignInAsync(AppIdentityUser appIdentityUser, string password)
        {
            return await _signInManager.PasswordSignInAsync(appIdentityUser, password, false, true);
        }

        public async Task<IdentityResult> UpdateAsync(AppIdentityUser loginedUser)
        {
            return await _userManager.UpdateAsync(loginedUser);
        }
        public async Task<IdentityResult> CreateAsync(AppIdentityUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> AddToRoleAsync(AppIdentityUser user, string rol)
        {
            return await _userManager.AddToRoleAsync(user, rol);
        }
    }
}
