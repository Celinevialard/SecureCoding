using Microsoft.AspNetCore.Mvc;
using SecureCoding.Model;

namespace SecureCoding.Controler;

public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        // afficher formulaire
        return View();
    }

    [HttpPost]
    public IActionResult Login(AuthViewModel login)
    {
        // une fois le formulaire submit
        return View();
    }
}
