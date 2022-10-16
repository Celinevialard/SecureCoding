using AirplaneSecure.Database;
using Microsoft.AspNetCore.Mvc;
using SecureCoding.Model;

namespace SecureCoding.Controler;

public class UserController : Controller
{
    IUserDb UserDb { get; set; }

    public UserController(IUserDb userDb)
    {
        UserDb = userDb;
    }

    [HttpGet]
    public IActionResult ChangePassword()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ChangePassword(UserPwdViewModel userPassword)
    {
        if (HttpContext.Session.GetString("User") == null)
        {
            return RedirectToAction("Login", "Home");
        }
        int userId = int.Parse(HttpContext.Session.GetString("User"));
        User user = UserDb.GetUser(userId);
        user.Password = userPassword.Password;
        UserDb.UpdateUser(user);
        return RedirectToAction("Index", "Tickets");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        return View();
    }

    [HttpPost]
    public IActionResult Edit(UserViewModel user)
    {
        return View();
    }
}
