using BarberShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BarberShop.ViewModelsHome;

namespace BarberShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult LogIn()
        {
            return View(new VMLogin());
        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult LogIn(VMLogin login)
        {
            User user = DataLayer.Data.Users.FirstOrDefault(u => u.Email == login.Email && u.Password == login.Password);
            if (user == null)
            {
                login.Feedback = "פרטים שגויים";
                login.Color = "red";
                return View(login);
            }

            DataLayer.Data.GetUser = user;

            if (user is Manager)
            {
                login.Feedback = "מנהל נכנס למערכת";
                login.Color = "green";
                return View(login);
            }
            login.Feedback = "ספר נכנס למערכת";
            login.Color = "yellow";
            return View(login);
        }


        public IActionResult Index()
        {
            DataLayer data =  DataLayer.Data;
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