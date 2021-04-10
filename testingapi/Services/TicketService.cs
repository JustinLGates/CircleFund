using Repositories;
using Models;
using System;

namespace Services
{
  public class TicketService
  {
    private readonly TicketRepo _ticketRepo;

    public TicketService(TicketRepo TicketRepo)
    {
      _ticketRepo = TicketRepo;
    }
    internal Ticket Create(Ticket Ticket)
    {
      return _ticketRepo.Create(Ticket);
    }

    internal Ticket Get(string userIdentifier)
    {
      return _ticketRepo.Get(userIdentifier);
    }

    internal Ticket Edit(Ticket ticket)
    {
      Ticket currentTicket = Get(ticket.creatorEmail);

      if (ticket.filepath == null) { ticket.filepath = currentTicket.filepath; }
      if (ticket.setup == null) { ticket.setup = currentTicket.setup; }
      if (ticket.steps == null) { ticket.steps = currentTicket.steps; }
      if (ticket.verifications == null) { ticket.verifications = currentTicket.verifications; }
      if (ticket.priorityLevel == null) { ticket.priorityLevel = currentTicket.priorityLevel; }
      if (ticket.notes == null) { ticket.notes = currentTicket.notes; }
      if (ticket.automate == false) { ticket.automate = currentTicket.automate; }
      if (ticket.iosStatus == null) { ticket.iosStatus = currentTicket.iosStatus; }
      if (ticket.androidStatus == null) { ticket.androidStatus = currentTicket.androidStatus; }
      if (ticket.webStatus == null) { ticket.webStatus = currentTicket.webStatus; }

      return _ticketRepo.Edit(ticket);
    }
    internal Boolean Delete(int Id, string Email)
    {
      return _ticketRepo.Delete(Id, Email);
    }
  }
}