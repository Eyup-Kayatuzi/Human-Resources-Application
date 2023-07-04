using InsanKaynaklari.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Application.Interfaces.Repositories.UserRepo
{
    public interface IUserWriteRepository : IWriteRepository<AppIdentityUser>
    {
        Task<SignInResult> SMPasswordSignInAsync(AppIdentityUser appIdentityUser, string password);
        Task SMLogoutAsync();
        Task<IdentityResult> UpdateAsync(AppIdentityUser loginedUser);
        Task<IdentityResult> CreateAsync(AppIdentityUser user, string password);
        Task<IdentityResult> AddToRoleAsync(AppIdentityUser user, string rol);
        
    }
}
