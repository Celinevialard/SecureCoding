using AirplaneSecure.Database;
using Microsoft.AspNetCore.Mvc;
using AirplaneSecure.Model;
using System.Diagnostics;
using System.IO;

namespace AirplaneSecure.Controler;

public class TicketsController : Controller
{
    ITicketDb TicketDb { get; set; }

    public TicketsController(ITicketDb ticketDb)
    {
        TicketDb = ticketDb;
    }
    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("User") == null)
        {
            return RedirectToAction("Login", "Home");
        }
        int userId = int.Parse(HttpContext.Session.GetString("User"));
        List<Ticket> tickets = TicketDb.GetTickets(userId);
        
        return View(new TicketListViewModel { 
            Tickets = tickets}
        );
    }

    public IActionResult Details(int id, string url )
    {
        Ticket ticket = TicketDb.GetTicket(id);

        return View(new TicketViewModel()
        {
            Id = id,
            Name = ticket.Name
        }); 
    }

    public IActionResult Action(string param)
    {
        string path = "./Process.jar";
        Process proc = new Process();
        proc.StartInfo.FileName = path;
        proc.StartInfo.Arguments = param;
        proc.Start();
        string output = proc.StandardOutput.ReadToEnd();
        proc.WaitForExit();
        var stat = proc.ExitCode;
        return View(output);
    }

}
