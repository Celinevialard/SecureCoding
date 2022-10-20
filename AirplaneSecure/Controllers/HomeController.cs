using AirplaneSecure.Database;
using AirplaneSecure.Model;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace AirplaneSecure.Controler;

[RequireHttps]
public class HomeController : Controller
{
    IUserDb UserDb { get; set; }

    public HomeController(IUserDb userDb)
    {
        UserDb = userDb;
    }
    
    public IActionResult Home()
    {
        return RedirectToAction("Index", "Tickets");
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

            var salt = DateTime.Now.ToString();

            var hashedPassword = UserDb.HashPassword($"{login.Password}{salt}");

            if (hashedPassword == user.Password)
            {
                HttpContext.Session.SetString("User", user.Id.ToString());

                return RedirectToAction("Index", "Tickets");
            }

            ModelState.AddModelError(string.Empty, "Invalid user or password");
        }
        return View(login);
    }

}
