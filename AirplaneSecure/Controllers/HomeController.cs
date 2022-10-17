using AirplaneSecure.Database;
using Microsoft.AspNetCore.Mvc;
using SecureCoding.Model;

namespace SecureCoding.Controler;

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
    public IActionResult Login(AuthViewModel login)
    {
        // une fois le formulaire submit enregistrer dans la session le userID
        User user = UserDb.GetUser(login.UserName);
        //  controler mot de passe si ok passer en dessous
        HttpContext.Session.SetString("User", user.Id.ToString());

        return RedirectToAction("Index", "Tickets");
    }
}
