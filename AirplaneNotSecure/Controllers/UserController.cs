﻿using AirplaneNotSecure.Database;
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
    public IActionResult Index()
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