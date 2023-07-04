using InsanKaynaklari.Application.Interfaces;
using InsanKaynaklari.Domain.Dtos;
using InsanKaynaklari.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace InsanKaynaklari.Persistence.Concretes
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly IUserService _userService;
        public UserAuthenticationService(IUserService userService)
        {
            _userService = userService; 
        }
        public async Task<Status> LoginAsync(LoginDto model)
        {
            var status = new Status();
            var user = await _userService.UMGetUserByNameAsync(model.UserName);
            if (user == null)
            {
                status.StatusString = "0";
                status.Message = "Invalid username";
                return status;
            }
            var isValidPassword = await _userService.UMCheckUserWithPasswordAsync(user, model.Password);
            if (!isValidPassword)
            {
                status.StatusString = "0";
                status.Message = "Invalid password";
                return status;
            }
            var signInResult = await _userService.SMSignInWithPasswordAsync(user, model.Password);
            if (signInResult.Succeeded)
            {
                status.StatusString = "1";
                status.Message = "Logged in successfully";
                return status;
            }
            else if (signInResult.IsLockedOut)
            {
                status.StatusString = "0";
                status.Message = "User locked out";
                return status;
            }
            else
            {
                status.StatusString = "0";
                status.Message = "Error logging in";
                return status;
            }
        }
        public async Task LogoutAsync()
        {
            await _userService.SMLogOffAsync();
        }
        //public async Task<Status> RegistrationAsync(UserDto model)
        //{
        //    var status = new Status();
        //    var userExists = await _userManager.FindByNameAsync(model.UserName);
        //    if (userExists != null)
        //    {
        //        status.StatusCode = 0;
        //        status.Message = "User already exists";
        //        return status;
        //    }
        //    User user = new User
        //    {
        //        SecurityStamp = Guid.NewGuid().ToString(),
        //        UserName = model.UserName,
        //        Email = model.Email,
        //        Name = model.Name,
        //        EmailConfirmed = true,
        //    };
        //    var result = await _userManager.CreateAsync(user, model.Password);
        //    if (!result.Succeeded)
        //    {
        //        status.StatusCode = 0;
        //        status.Message = "User creation failed";
        //        return status;
        //    }
        //    if (!await _roleManager.RoleExistsAsync(model.Role))
        //        await _roleManager.CreateAsync(new IdentityRole(model.Role));
        //    if (await _roleManager.RoleExistsAsync(model.Role))
        //    {
        //        await _userManager.AddToRoleAsync(user, model.Role);
        //    }
        //    status.StatusCode = 1;
        //    status.Message = "User has registered successfully";
        //    return status;
        //}
    }
}
