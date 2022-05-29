using Authentications.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Authentications.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        string name = "";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string username)
        {
            string state = HttpContext.Session.GetString("Authenticated");
            if (state != "true")
            {
                return RedirectToAction("Login");
            }


            return View();

        }
        public IActionResult Privacy()
        {
            string state = HttpContext.Session.GetString("Authenticated");
            if (state != "true")
            {
                return RedirectToAction("Login");
            }
            

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Authenticated");
            return RedirectToAction("Login");
        }


        public IActionResult Login(LoginFormData loginValues)
        {
            if (loginValues == null)
            {
                return View();
            }

            if (loginValues.UserName == "admin" && loginValues.Password == "123")
            {
                HttpContext.Session.SetString("Authenticated", "true");
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}