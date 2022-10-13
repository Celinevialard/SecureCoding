using Microsoft.AspNetCore.Mvc;

namespace SecureCoding.Controler;

public class TicketsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Details(int id)
    {
        return View();
    }

    public IActionResult Download()
    {
        return View();
    }
}
