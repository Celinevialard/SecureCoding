namespace AirplaneSecure.Database
{
    public interface ITicketDb
    {
        Ticket GetTicket(int id);
        List<Ticket> GetTickets(int userId);
    }
}