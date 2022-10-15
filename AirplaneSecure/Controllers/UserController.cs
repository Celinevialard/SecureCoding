using Microsoft.AspNetCore.Mvc;
using SecureCoding.Model;

namespace SecureCoding.Controler;

public class UserController : Controller
{
    [HttpGet]
    public IActionResult ChangePassword()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ChangePassword(string password)
    {
        return View();
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
