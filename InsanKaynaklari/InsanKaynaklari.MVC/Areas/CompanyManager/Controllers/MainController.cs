using InsanKaynaklari.Application.Interfaces;
using InsanKaynaklari.Domain.Identity;
using InsanKaynaklari.MVC.Areas.CompanyManager.ViewModels;
using InsanKaynaklari.Persistence.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace InsanKaynaklari.MVC.Areas.CompanyManager.Controllers
{
    [Area("CompanyManager")]
    [Authorize(Roles = "sirketyoneticisi")]
    public class MainController : Controller
    {
        private readonly IWebHostEnvironment _WebHostEnvironment;
        private readonly IUserService _userService;
        public MainController(IWebHostEnvironment webHostEnvironment, IUserService userService)
        {
            _WebHostEnvironment = webHostEnvironment;
            _userService = userService; 
        }
        public async Task<IActionResult> HomePage()
        {
            var userName = User.Identity.Name; 
            var user = await _userService.UMGetUserByNameAsync(userName); 
            ViewBag.UserId = user.Id;
            if (user == null)
            {
                return NotFound();
            }
            var userViewModel = new MainPageVM
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
            var detailViewModel = new DetailPageVM
            {
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                LastName = user.LastName,
                SecondLastName = user.SecondLastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,           
                PicturePath=user.PicturePath,
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
        public async Task<IActionResult> EditPage(string id)
        {
            var user = await _userService.UMGetUserByIdAsync(id);

            var editPageVm = new EditPageVM { Address = user.Address, PhoneNumber = user.PhoneNumber};
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
            var userName = User.Identity.Name; 
            var user = await _userService.UMGetUserByNameAsync(userName); 
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
                    user.PicturePath = UploadFile(editPageVM.NewPicturePath); 
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
