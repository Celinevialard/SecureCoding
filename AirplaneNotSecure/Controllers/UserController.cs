using AirplaneNotSecure.Database;
using AirplaneNotSecure.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirplaneSecure.Controler;

public class UserController : Controller
{
    IUserDb UserDb { get; set; }

    public UserController(IUserDb userDb)
    {
        UserDb = userDb;
    }
    public IActionResult Details()
    {
        if (HttpContext.Session.GetString("User") == null)
        {
            return RedirectToAction("Login", "Home");
        }
        int userId = int.Parse(HttpContext.Session.GetString("User"));
        User user = UserDb.GetUser(userId);

        return View(new UserViewModel() { Firstname = user.Firstname, Lastname = user.Lastname }) ;
    }

    [HttpGet]
    public IActionResult ChangePassword()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ChangePassword(UserPwdViewModel userPassword)
    {
        if (!ModelState.IsValid)
            return View(userPassword);
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
        if (HttpContext.Session.GetString("User") == null)
        {
            return RedirectToAction("Login", "Home");
        }
        int userId = int.Parse(HttpContext.Session.GetString("User"));
        User user = UserDb.GetUser(userId);
        return View(new UserViewModel()
        {
            Lastname = user.Lastname,
            Firstname = user.Firstname
        });
    }

    [HttpPost]
    public IActionResult Edit(UserViewModel userVM)
    {
        if(!ModelState.IsValid)
            return View(userVM);
        if (HttpContext.Session.GetString("User") == null)
        {
            return RedirectToAction("Login", "Home");
        }
        int userId = int.Parse(HttpContext.Session.GetString("User"));
        User user = UserDb.GetUser(userId);
        user.Lastname = userVM.Lastname;
        user.Firstname = userVM.Firstname;
        UserDb.UpdateUser(user);
        return RedirectToAction("Details");
    }
}
