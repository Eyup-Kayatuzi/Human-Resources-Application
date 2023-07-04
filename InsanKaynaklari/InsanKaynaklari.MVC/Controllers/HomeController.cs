using InsanKaynaklari.Application.Interfaces;
using InsanKaynaklari.Domain.Dtos;
using InsanKaynaklari.Domain.EMailManagement.Models;
using InsanKaynaklari.Domain.EMailManagement.Service;
using InsanKaynaklari.Domain.Identity;
using InsanKaynaklari.MVC.Models;
using InsanKaynaklari.Persistence.Concretes;
using InsanKaynaklari.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InsanKaynaklari.MVC.Controllers
{
    public class HomeController : Controller
    {             
        public HomeController()
        {    
            
           
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}