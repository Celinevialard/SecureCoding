﻿using AirplaneSecure.Database;

namespace AirplaneSecure.Model;

public class TicketListViewModel
{
    public List<Ticket> Tickets { get; set; }

}
public class TicketViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }

}