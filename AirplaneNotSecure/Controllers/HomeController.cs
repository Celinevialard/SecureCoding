using AirplaneNotSecure.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AirplaneNotSecure.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            // afficher formulaire
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(AuthViewModel login)
        {
            if (ModelState.IsValid)
            {
                User user = UserDb.GetUser(login.UserName);


                if (login.Password == user.Password)
                {
                    HttpContext.Session.SetString("User", user.Id.ToString());

                    return RedirectToAction("Index", "Tickets");
                }

                ModelState.AddModelError(string.Empty, "Invalid user or password");
            }
            return View(login);
        }
    }
}