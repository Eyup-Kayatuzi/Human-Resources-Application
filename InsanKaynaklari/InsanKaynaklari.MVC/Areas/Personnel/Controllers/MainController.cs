using InsanKaynaklari.Application.Interfaces;
using InsanKaynaklari.Domain.Entities;
using InsanKaynaklari.Domain.Enums;
using InsanKaynaklari.MVC.Areas.Personnel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace InsanKaynaklari.MVC.Areas.Personnel.Controllers
{
    [Area("Personnel")]
    [Authorize]
    public class MainController : Controller
    {
        private readonly IWebHostEnvironment _WebHostEnvironment;
        private readonly IUserService _userService;
        private readonly IExpenseService _expenseService;
        public MainController(IWebHostEnvironment webHostEnvironment, IUserService userService, IExpenseService expenseService)
        {
            _WebHostEnvironment = webHostEnvironment;
            _userService = userService;
            _expenseService = expenseService;   
        }
        public async Task<IActionResult> HomePage()
        {
            var userName = User.Identity.Name; // Mevcut kimlik doğrulanmış kullanıcının kullanıcı adını alın
            var user = await _userService.UMGetUserByNameAsync(userName); // Kullanıcı adına göre kullanıcıyı alın
            if (user == null)
            {
                return NotFound();
            }
            ViewBag.UserId = user.Id;
            var userViewModel = new HomePageVM
            {
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                LastName = user.LastName,
                SecondLastName = user.SecondLastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Profession = user.Profession,
                Department = user.Department,
                Address = user.Address,
                Gender = user.Gender,
                PhotoFileName = user.PicturePath
            };

            return View(userViewModel);

        }
        public async Task<IActionResult> DetailPage(string id)
        {
            var user = await _userService.UMGetUserByIdAsync(id);
            ViewBag.UserId = user.Id;
            if (user == null)
            {
                return NotFound();
            }

            var detailViewModel = new ViewModels.DetailPageVM
			{
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                LastName = user.LastName,
                SecondLastName = user.SecondLastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                PicturePath = user.PicturePath,
                DateOfBirth = user.DateOfBirth,
                BirthPlace = user.BirthPlace,
                Tc = user.Tc,
                StartDateOfJob = user.StartDateOfJob,
                LeaveDateOfJob = user.LeaveDateOfJob,
                IsActive = user.IsActive,
                CompanyInfo = user.CompanyInfo,
                Profession = user.Profession,
                Department = user.Department,
                Address = user.Address,
                Gender = user.Gender
            };

            return View(detailViewModel);
        }
        public async Task<IActionResult> AddExpense() {
            var model = new AddExpenseVM();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddExpense(AddExpenseVM addExpenseVM)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.UMGetUserByNameAsync(User.Identity.Name);       // Bu kisim degistirilecek
        
                PersonnelExpense expenseInfo = new()
                {
                    ExpenseType = addExpenseVM.ExpenseType,
                    ExpenseAmount = addExpenseVM.ExpenseAmount,
                    Currency = addExpenseVM.Currency,
                    ApprovalStatus = ApprovalStatus.OnayBekliyor,
                    RequestDate = DateTime.Now,
                    ReplyDate = DateTime.MinValue,
                    FolderPath = UploadFile(addExpenseVM.NewPicturePath),
                    AppIdentityUserId = user.Id
                };
                bool resultOfProcess = await _expenseService.AddAsync(expenseInfo);
                if (resultOfProcess)
                {
                    return RedirectToAction("HomePage");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Ekleme sırasında hata meydana gelmiştir");
                }
            }
            return View(addExpenseVM);
        }
        public async Task<IActionResult> ListExpenses()
        {
            //var user = await _userService.UMGetUserByNameAsync("EyupKayatuzi"); // ilerleyen kisimlarda bu alan degistirilecektir.
            var user = await _userService.UMGetUserByNameAsync(User.Identity.Name);
            var expenses = await _expenseService.GetWhereAsync(x => x.AppIdentityUserId == user.Id);
            List<ListExpenseVM> listExpenseVMs = expenses.Select(x => new ListExpenseVM
            {
                ApprovalStatus = x.ApprovalStatus,
                RequestDate = x.RequestDate,
                Currency = x.Currency,
                ExpenseAmount = x.ExpenseAmount,
                FolderPath = x.FolderPath,
                ExpenseType = x.ExpenseType,
                ReplyDate = x.ReplyDate,
            }).ToList();
            return View(listExpenseVMs);
        }
        public async Task<IActionResult> EditPage(string id) // Burada test amacıyla AppIdentityUser modeli kullanilmistir. İlerleyen kisimlarda duzeltilecektir.
        {
            #region eski
            //var user = await _userManager.FindByIdAsync(id);
            #endregion
            var user = await _userService.UMGetUserByIdAsync(id);

            var editPageVm = new EditPageVM { Address = user.Address, PhoneNumber = user.PhoneNumber };
            if (user.PicturePath == null)
            {
                if (user.Gender == "Male")
                {
                    editPageVm.PicturePath = "20180125_001_1_.jpg";
                }
                else if (user.Gender == "Female")
                {
                    editPageVm.PicturePath = "20180129_002.jpg";
                }
            }
            else
            {
                editPageVm.PicturePath = user.PicturePath;
            }

            return View(editPageVm);
        }
        [HttpPost]
        public async Task<IActionResult> EditPage(EditPageVM editPageVM)
        {
            var userName = User.Identity.Name; // Mevcut kimlik doğrulanmış kullanıcının kullanıcı adını alın
            var user = await _userService.UMGetUserByNameAsync(userName); // Kullanıcı adına göre kullanıcıyı alın
            if (ModelState.IsValid == true)
            {

                user.PhoneNumber = editPageVM.PhoneNumber;
                user.Address = editPageVM.Address;
                if (user.PicturePath == null && editPageVM.NewPicturePath == null)
                {
                    if (user.Gender == "Male")
                    {
                        user.PicturePath = "20180125_001_1_.jpg";
                    }
                    else if (user.Gender == "Female")
                    {
                        user.PicturePath = "20180129_002.jpg";
                    }
                }
                else if (editPageVM.NewPicturePath != null)
                {
                    user.PicturePath = UploadFile(editPageVM.NewPicturePath); //editPageVM.PicturePath;
                }
                else
                {

                }
                await _userService.SaveDataBaseAsync();
                return RedirectToAction("HomePage");
            }
            else
            {
                editPageVM.PicturePath = user.PicturePath;
                var errors = ViewData.ModelState.Where(n => n.Value.Errors.Count > 0).ToList();
                return View(editPageVM);
            }

        }
        [HttpPost]
        public string GetPicturePath(IFormFile newValue)
        {
            return UploadFile(newValue);
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
    }
}
