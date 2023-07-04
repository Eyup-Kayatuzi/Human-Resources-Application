using InsanKaynaklari.Application.Interfaces;
using InsanKaynaklari.Domain.Dtos;
using InsanKaynaklari.Domain.EMailManagement.Models;
using InsanKaynaklari.Domain.EMailManagement.Service;
using InsanKaynaklari.Domain.Enums;
using InsanKaynaklari.Domain.Identity;
using InsanKaynaklari.MVC.Areas.CompanyManager.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace InsanKaynaklari.MVC.Areas.CompanyManager.Controllers
{
    [Area("CompanyManager")]
    [Authorize(Roles = "sirketyoneticisi")]
    public class EmployeeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        private readonly IEmailService _emailService;
        private readonly IExpenseService _expenseService;
        private readonly IPasswordHasher<AppIdentityUser> _passwordHasher;
        public EmployeeController(IUserService userService, IWebHostEnvironment webHostEnvironment, IEmailService emailService, IExpenseService expenseService, IPasswordHasher<AppIdentityUser> password)
        {
            _userService = userService;
            _WebHostEnvironment = webHostEnvironment;
            _emailService= emailService;
            _expenseService = expenseService;
            _passwordHasher = password;
        }
        public IActionResult Index()
        {

            return View();
        }
        public async Task<IActionResult> ListOfExpenses()
        {

            var user = await _userService.UMGetUserByNameAsync(User.Identity.Name);
            var expenses = await _expenseService.GetWhereWithIncludeAsync(x => x.AppIdentityUser.CompanyInfo == user.CompanyInfo, y => y.AppIdentityUser);
            List<ListOfExpensesVM> listOfExpensesVM = expenses.Select(x => new ListOfExpensesVM
            {
                ExpensesId = x.Id,
                ApprovalStatus = x.ApprovalStatus,
                Currency = x.Currency,
                Department = x.AppIdentityUser.Department,
                ExpenseAmount = x.ExpenseAmount,
                ExpenseType = x.ExpenseType,
                FirstName = x.AppIdentityUser.FirstName,
                SecondName = x.AppIdentityUser.SecondName,
                FolderPath = x.FolderPath,
                LastName = x.AppIdentityUser.LastName,
                SecondLastName = x.AppIdentityUser.SecondLastName,
                ReplyDate = x.ReplyDate,
                RequestDate = x.RequestDate
            }).ToList();
            return View(listOfExpensesVM);

        }
        [HttpPost]
        public async Task<IActionResult> ListOfExpenses(ApprovalStatus approvalStatus, int id)
        {
            var targetValue = await _expenseService.GetFirstOrDefaultAsync(x => x.Id == id);
            targetValue.ApprovalStatus = approvalStatus;
			targetValue.ReplyDate = DateTime.Now;
            int returnVal = _expenseService.Save();
            if (returnVal > 0)
            {
                
            }
            else
            {
                ModelState.AddModelError(string.Empty, "İşlem esnasında bir hata oluştu");
                
            }
            return RedirectToAction("ListOfExpenses", "Employee");

        }

        public async Task<IActionResult> CreatePersonnel()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> CreatePersonnel(CreatePersonnelViewModel model)
		{
			if (ModelState.IsValid)
			{
				var checkForEmail = await _userService.UMFindUserByEmailAsync(model.Email);
				if (checkForEmail == null)
				{
					AppIdentityUser? employee = new AppIdentityUser
					{
						UserName = $"{model.FirstName}{model.SecondName}{model.LastName}{model.SecondLastName}",
						FirstName = model.FirstName,
						SecondName = model.SecondName,
						LastName = model.LastName,
						SecondLastName = model.SecondLastName,
						Email = model.Email,
						PhoneNumber = model.PhoneNumber,
						Department = model.Department,
						DateOfBirth = model.DateOfBirth,
						BirthPlace = model.BirthPlace,
						Tc = model.Tc,
						StartDateOfJob = model.StartDateOfJob,
						LeaveDateOfJob = model.LeaveDateOfJob ?? new DateTime(2050, 1, 1),
						IsActive = false,
						CompanyInfo = model.CompanyInfo,
						Profession = model.Profession,
						PicturePath = model.PicturePath,
						Address = model.Address,
						Salary = model.Salary,
						Gender = model.Gender,
						SpecificMail = model.FirstName + "." + model.LastName + "@bilgeadam.com",
						EmailConfirmed = true
					};
					var sonuc = await _userService.UMGetUserByNameAsync(employee.UserName);
					if (sonuc != null)
					{
						var forRandom = new Random();
						employee.UserName = employee.UserName + (forRandom.Next(10, 100)).ToString();
					}
					string password = _emailService.GenerateRandomPassword();
					var result = await _userService.UMCreateAsync(employee, password);
					if (result.Succeeded)
					{
						var resultOfAdding = await _userService.UMAddToRoleAsync(employee, "PERSONEL");
						await _userService.UMUpdateAsync(employee);
						if (resultOfAdding.Succeeded)
						{
							await SendMail(employee.Email);
							return RedirectToAction("ListEmployees");
						}
						else
						{
							ModelState.AddModelError(string.Empty, "Rol tanımlama esnasında bir hata meydana gelmiştir");
						}

					}
					else
					{
						foreach (var error in result.Errors)
						{
							ModelState.AddModelError(string.Empty, error.Description);
						}
					}
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Boyle bir mail sistemde kayıtlıdır.");
				}
			}
			foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors)) ;
			return View(model);
		}


		public async Task<IActionResult> ListEmployees()
		{
            #region Burak Bey kontrol et ve sil
            /*var employeeList = new EmployeeListVM
            {
                EmployeeList = new List<AppIdentityUser>()
            };
            var users = await _context.Users.ToListAsync();
            foreach (var user in users)
            {
                AppIdentityUser employee = new AppIdentityUser
                {
                    FirstName = user.FirstName,
                    SecondName = user.SecondName,
                    LastName = user.LastName,
                    SecondLastName = user.SecondLastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    PicturePath = user.PicturePath,
                    Department = user.Department
                };

                employeeList.EmployeeList.Add(employee);
            }
            return View(employeeList);*/
            #endregion
            var userName = User.Identity.Name; 
            var user = await _userService.UMGetUserByNameAsync(userName); 
            var employees = await _userService.UMGetWhereByRoleAsync(x => x.CompanyInfo == user.CompanyInfo, "personel");
			List<ListEmployeesVM> listEmployeesVMs = employees.Select(x => new ListEmployeesVM()
			{
				FirstName = x.FirstName,
				SecondName = x.SecondName,
				LastName = x.LastName,
				SecondLastName = x.SecondLastName,
				Email = x.Email,
				PhoneNumber = x.PhoneNumber,
				PicturePath = x.PicturePath,
				Department = x.Department
			}).ToList();

			return View(listEmployeesVMs);
		}
		private string UploadFile(IFormFile newValue)
		{
			string fileName = null;
			if (newValue != null)
			{
				string uploadDir = Path.Combine(_WebHostEnvironment.WebRootPath, "images");
				fileName = Guid.NewGuid().ToString() + "-" + newValue.FileName;
				string filePath = Path.Combine(uploadDir, fileName);
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					newValue.CopyTo(fileStream);
				}
			}
			return fileName;
		}
		public async Task<IActionResult> SendMail(string eMail)
		{
			AppIdentityUser loginedUser = await _userService.UMFindUserByEmailAsync(eMail);
			string resetPassword = _emailService.GenerateRandomPassword();
			if (loginedUser != null)
			{

				var emailMessage = new EMailMessage(new Dictionary<string, string>() { {"Insan Kaynakları","insankaynaklariproje123@gmail.com" }
				,{"ŞİFRE YENİLEME",loginedUser.Email.ToString() } }, "Şifre Yenilemesi Hk.", $"<h1>Merhaba</h1><p>Yeni employee kaydınız oluşturuldu. Kullanıcı Adınız:{loginedUser.UserName},Mail Adresiniz:{loginedUser.SpecificMail},Şifreniz:{resetPassword} Sisteme giriş yaparak yeni şifrenizi belirleyebilirsiniz.</p>");
				_emailService.SendEmail(emailMessage);
				loginedUser.PasswordHash = null;
				loginedUser.PasswordHash = _passwordHasher.HashPassword(loginedUser, resetPassword);
				loginedUser.IsActive = false;
				IdentityResult result = await _userService.UMUpdateAsync(loginedUser);
				await _userService.SaveDataBaseAsync();
				return StatusCode(StatusCodes.Status200OK, new Status() { StatusString = "Başarılı", Message = "Email başarıyla gönderildi!" });
			}
			else
			{
				return StatusCode(StatusCodes.Status404NotFound, new Status() { StatusString = "Başarısız", Message = "Email Bulunamadı!" });
			}
		}
	}


}
