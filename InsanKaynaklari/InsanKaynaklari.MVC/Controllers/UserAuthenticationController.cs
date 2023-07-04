using InsanKaynaklari.Application.Interfaces;
using InsanKaynaklari.Application.Interfaces.Repositories.UserRepo;
using InsanKaynaklari.Domain.Dtos;
using InsanKaynaklari.Domain.EMailManagement.Models;
using InsanKaynaklari.Domain.EMailManagement.Service;
using InsanKaynaklari.Domain.Identity;
using InsanKaynaklari.MVC.ViewModels;
using InsanKaynaklari.Persistence.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;

namespace InsanKaynaklari.MVC.Controllers
{
	public class UserAuthenticationController : Controller
	{
		private readonly IUserAuthenticationService _service;
		private readonly IEmailService _emailService;
		private readonly IUserService _userService;
		private readonly IPasswordHasher<AppIdentityUser> _passwordHasher;
		public UserAuthenticationController(IUserAuthenticationService service, IEmailService emailService, IUserService userService, IPasswordHasher<AppIdentityUser> passwordHasher, UserManager<AppIdentityUser> userManager)
		{
			_service = service;
			_emailService = emailService;
			_userService = userService;
			_passwordHasher = passwordHasher;
		}
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginVM model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			LoginDto dtoModel = new LoginDto() { UserName = model.UserName, Password = model.Password };
			var result = await _service.LoginAsync(dtoModel);
			AppIdentityUser loginedUser = await _userService.UMGetUserByNameAsync(dtoModel.UserName);
			if (loginedUser !=null)
			{
				List<string> roles = await _userService.UMGetAllRolesByUserAsync(loginedUser);
				if (result.StatusString == "1")
				{
					if (loginedUser.IsActive == true)
					{
						if (roles[0] == "personel")
						{
							return RedirectToAction("HomePage", "Main", new { area = "Personnel" });
						}
						else if (roles[0] == "sirketyoneticisi")
						{
							return RedirectToAction("HomePage", "Main", new { area = "CompanyManager" });
						}
						else
						{
							return Redirect(nameof(Login));
						}
					}
					else if (loginedUser.IsActive == false)
					{
						return RedirectToAction("passwordchange", "UserAuthentication");
					}
					else
					{
						return StatusCode(StatusCodes.Status200OK, new Status() { StatusString = "Başarısız", Message = "EmailConfirmed Bulunamadı!" });
					}
				}
				else
				{
					TempData["msg"] = result.Message;
					return Redirect(nameof(Login));
				}
			}
			else
			{
				TempData["msg"] = "We cannot find logined user!";
				return Redirect(nameof(Login));
			}
			
		}
		[Authorize]
		public async Task<IActionResult> Logout()
		{
			await _service.LogoutAsync();
			return RedirectToAction(nameof(Login));
		}
		public IActionResult ForgotPassword()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> ForgotPassword(ForgotPasswordDTo forgotPasswordDTo)
		{
			if (ModelState.IsValid)
			{
				var user = await _userService.UMFindUserByEmailAsync(forgotPasswordDTo.EMailAddress);
				if (user != null)
				{
					await SendMail(user.Email);
					return RedirectToAction(nameof(PasswordChange));
				}
				TempData["msg"] = "We cannot find this e-mail address in our database";
				return RedirectToAction(nameof(ForgotPassword));
			}
			else
			{
				return View(forgotPasswordDTo);
			}
		}
		public async Task<IActionResult> PasswordChange()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> PasswordChange(ForgotPasswordDTo forgotPasswordDTo)
		{
			var loginedUser = await _userService.UMFindUserByEmailAsync(forgotPasswordDTo.EMailAddress);
			if (loginedUser != null)
			{
				if (forgotPasswordDTo.NewPassword == forgotPasswordDTo.ReNewPassword)
				{
					var result = _passwordHasher.VerifyHashedPassword(loginedUser, loginedUser.PasswordHash, forgotPasswordDTo.OldPassword);
					if (result == PasswordVerificationResult.Success)
					{
						loginedUser.PasswordHash = _passwordHasher.HashPassword(loginedUser, forgotPasswordDTo.NewPassword);
						loginedUser.IsActive = true;
						await _userService.UMUpdateAsync(loginedUser);
						await _userService.SaveDataBaseAsync();
					}
					else
					{
						TempData["msg"] = "Your OldPassword is Incorrect !";
						return View();

					}
				}
				else
				{
					TempData["msg"] = "Your new password and renew password is not matched !";
					return View();
				}

			}
			else
			{
				TempData["msg"] = "We cannot find this e-mail address in our database";
				return View();
			}
			return RedirectToAction(nameof(Login));
		}
		public async Task<IActionResult> SendMail(string eMail)
		{
			AppIdentityUser loginedUser = await _userService.UMFindUserByEmailAsync(eMail);
			string resetPassword = _emailService.GenerateRandomPassword();
			if (loginedUser != null)
			{
				if (loginedUser.EmailConfirmed = true)
				{
					var emailMessage = new EMailMessage(new Dictionary<string, string>() { {"Insan Kaynakları","insankaynaklariproje123@gmail.com" }
				,{"ŞİFRE YENİLEME",loginedUser.Email.ToString() } }, "Şifre Yenilemesi Hk.", $"<h1>Merhaba</h1><p>Şifrenizi yenilemek için {resetPassword} şifreyi eski şifre kısmına yazınız. </p>");
					_emailService.SendEmail(emailMessage);
					loginedUser.PasswordHash = _passwordHasher.HashPassword(loginedUser, resetPassword);
					IdentityResult result = await _userService.UMUpdateAsync(loginedUser);
					await _userService.SaveDataBaseAsync();
					return StatusCode(StatusCodes.Status200OK, new Status() { StatusString = "Başarılı", Message = "Email başarıyla gönderildi!" });
				}
				else if (loginedUser.EmailConfirmed = false)
				{
					var emailMessage = new EMailMessage(new Dictionary<string, string>() { {"Insan Kaynakları","insankaynaklariproje123@gmail.com" }
				,{"ŞİFRE YENİLEME",loginedUser.Email.ToString() } }, "Şifre Yenilemesi Hk.", $"<h1>Merhaba</h1><p>Yeni employee kaydınız oluşturuldu. Kullanıcı Adınız:{loginedUser.UserName},Mail Adresiniz:{loginedUser.Email},Şifreniz:{resetPassword} Sisteme giriş yaparak yeni şifrenizi belirleyebilirsiniz.</p>");
					_emailService.SendEmail(emailMessage);
					loginedUser.PasswordHash = _passwordHasher.HashPassword(loginedUser, resetPassword);
					IdentityResult result = await _userService.UMUpdateAsync(loginedUser);
					await _userService.SaveDataBaseAsync();
					return StatusCode(StatusCodes.Status200OK, new Status() { StatusString = "Başarılı", Message = "Email başarıyla gönderildi!" });
				}
				else
				{
					return StatusCode(StatusCodes.Status404NotFound, new Status() { StatusString = "Başarısız", Message = "Status is not found !" });
				}

				//loginedUser.PasswordHash = ComputeHash(resetPassword);
				#region eski
				//await _userWriteRepository.UpdateAsync(loginedUser);
				#endregion

			}
			else
			{
				return StatusCode(StatusCodes.Status404NotFound, new Status() { StatusString = "Başarısız", Message = "Email Bulunamadı!" });
			}
		}
		[HttpGet("EmailConfirmation")]
		public async Task<IActionResult> ConfirmEmail(string token, string email)
		{
			#region eski
			//var user = await _userManager.FindByEmailAsync(email);
			#endregion
			var user = await _userService.UMFindUserByEmailAsync(email);

			if (user != null)
			{
				#region eski
				//var result = await _userManager.ConfirmEmailAsync(user, token);
				#endregion
				var result = await _userService.UMConfirmEmailAsync(user, token);

				if (result.Succeeded)
				{
					return StatusCode(StatusCodes.Status200OK, new Status() { StatusString = "Onaylama başarılı!", Message = "Kullanıcının maili onaylandı!" });
				}
				else
				{
					return StatusCode(StatusCodes.Status400BadRequest, new Status() { StatusString = "Onaylama başarısız!", Message = "Kullanıcının token bilgisi yanlıştır!" });
				}
			}
			else
			{
				return StatusCode(StatusCodes.Status404NotFound, new Status() { StatusString = "Kullanıcı sistemde bulunmamaktadır!", Message = "Kullanıcı bulunamadı!" });
			}
		}
		public static string ComputeHash(string password)
		{
			using (SHA256 sha256 = SHA256.Create())
			{
				byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
				StringBuilder builder = new StringBuilder();

				for (int i = 0; i < hashedBytes.Length; i++)
				{
					builder.Append(hashedBytes[i].ToString("x2")); // x2, her byte'ı iki haneli onaltılık formatta temsil etmek için kullanılır.
				}

				return builder.ToString();
			}
		}
		public static bool VerifyPassword(string password, string hashedPassword)
		{
			string hashedInput = ComputeHash(password);
			return StringComparer.OrdinalIgnoreCase.Compare(hashedInput, hashedPassword) == 0;
		}
	}
}
