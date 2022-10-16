using AirplaneSecure.Database;
using Microsoft.AspNetCore.Mvc;
using SecureCoding.Model;

namespace SecureCoding.Controler;

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

}
