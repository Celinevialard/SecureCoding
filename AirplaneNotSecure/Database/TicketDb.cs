using Microsoft.Data.SqlClient;

namespace AirplaneNotSecure.Database;

public class TicketDb : ITicketDb
{
    private string ConnectionString { get; }
    public TicketDb()
    {
        ConnectionString = "Data Source=153.109.124.35;Initial Catalog=SecureCodingJulienneCelineTheo;Encrypt=false;User ID=6231db;Password=Pwd46231.";
    }

    public List<Ticket> GetTickets(int userId)
    {
        List<Ticket> results = null;

        try
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                string query = @"SELECT * FROM Ticket 
							WHERE IdUser = @userId";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (results == null)
                            results = new List<Ticket>();

                        results.Add(ReadTicket(dr));

                    }
                }
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        return results;
    }

    public Ticket GetTicket(int id)
    {
        Ticket result = null;

        try
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                string query = @"SELECT * FROM Ticket 
							WHERE IdTicket = @id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        result = ReadTicket(dr);
                    }
                }
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        return result;
    }

    private Ticket ReadTicket(SqlDataReader dr)
    {
        Ticket ticket = new Ticket();

        ticket.Id = (int)dr["IdTicket"];
        ticket.Name = (string)dr["Name"];

        return ticket;
    }
}
