using AirplaneSecure.Database;
using AirplaneSecure.Models;
using AirplaneSecure.Utils;
using Microsoft.AspNetCore.Mvc;

namespace AirplaneSecure.Controler;

//[RequireHttps]
public class UserController : Controller
{
    IUserDb UserDb { get; set; }

    public UserController(IUserDb userDb)
    {
        UserDb = userDb;
    }
    public IActionResult Details()
    {
        int userId = HttpContext.Session.GetUserId();

        if (userId == 0)
            return RedirectToAction("Login", "Home");

        User user = UserDb.GetUser(userId);

        return View(new UserViewModel() { Firstname = user.Firstname, Lastname = user.Lastname });
    }

    [HttpGet]
    public IActionResult ChangePassword()
    {
        int userId = HttpContext.Session.GetUserId();

        if (userId == 0)
            return RedirectToAction("Login", "Home");

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ChangePassword(UserPwdViewModel userPassword)
    {
        int userId = HttpContext.Session.GetUserId();

        if (userId == 0)
            return RedirectToAction("Login", "Home");

        User user = UserDb.GetUser(userId);
        user.Password = UserDb.HashPassword($"{userPassword.Password}{user.Salt}");
        UserDb.UpdateUser(user);
        return RedirectToAction("Index", "Tickets");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        int userId = HttpContext.Session.GetUserId();

        if (userId == 0)
            return RedirectToAction("Login", "Home");

        User user = UserDb.GetUser(userId);
        return View(new UserViewModel()
        {
            Lastname = user.Lastname,
            Firstname = user.Firstname
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(UserViewModel userVM)
    {
        if (!ModelState.IsValid)
            return View(userVM);
        int userId = HttpContext.Session.GetUserId();

        if (userId == 0)
            return RedirectToAction("Login", "Home");
        
        User user = UserDb.GetUser(userId);
        user.Lastname = userVM.Lastname;
        user.Firstname = userVM.Firstname;
        UserDb.UpdateUser(user);
        return RedirectToAction("Details");
    }
}
