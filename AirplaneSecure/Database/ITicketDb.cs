namespace AirplaneSecure.Database
{
    public interface ITicketDb
    {
        Ticket GetTicket(int id, int userId);
        List<Ticket> GetTickets(int userId);
    }
}