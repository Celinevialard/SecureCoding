using AirplaneNotSecure.Database;
using Microsoft.AspNetCore.Mvc;
using AirplaneNotSecure.Models;
using System.Diagnostics;
using System.IO;

namespace AirplaneNotSecure.Controler;

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

    [HttpPost]
    public IActionResult Action(string info)
    {
        string path = "Process\\Process.exe";
        Process proc = new Process();
        proc.StartInfo.UseShellExecute = false;
        proc.StartInfo.RedirectStandardOutput = true;
        proc.StartInfo.CreateNoWindow = true;
        proc.StartInfo.FileName = "cmd.exe";
        proc.StartInfo.Arguments = "/C"+path +" -"+ info;
        proc.Start();
        string output = proc.StandardOutput.ReadLine();
        while (!proc.StandardOutput.EndOfStream)
        {
            output += proc.StandardOutput.ReadLine();
        }
        var stat = proc.ExitCode;
        return View(new StringViewModel()
        {
            Info = output
        });
    }

}
