using Repositories;
using Models;
using System;
using System.Collections.Generic;

namespace Services
{
  public class TicketService
  {
    private readonly TicketRepo _ticketRepo;

    public TicketService(TicketRepo TicketRepo)
    {
      _ticketRepo = TicketRepo;
    }
    internal Ticket Create(Ticket Ticket, int projectId)
    {
      return _ticketRepo.Create(Ticket, projectId);
    }

    internal IEnumerable<Ticket> Get(int projectIt)
    {
      return _ticketRepo.Get(projectIt);
    }

    internal Ticket GetById(int ticketId)
    {
      return _ticketRepo.GetById(ticketId);
    }

    internal Ticket Edit(Ticket ticket)
    {
      Ticket currentTicket = GetById(ticket.TicketId);

      if (ticket.FilePath == null) { ticket.FilePath = currentTicket.FilePath; }
      if (ticket.Setup == null) { ticket.Setup = currentTicket.Setup; }
      if (ticket.Steps == null) { ticket.Steps = currentTicket.Steps; }
      if (ticket.Verifications == null) { ticket.Verifications = currentTicket.Verifications; }
      if (ticket.PriorityLevel == null) { ticket.PriorityLevel = currentTicket.PriorityLevel; }
      if (ticket.Notes == null) { ticket.Notes = currentTicket.Notes; }
      if (ticket.Automate == false) { ticket.Automate = currentTicket.Automate; }
      if (ticket.IosStatus == null) { ticket.IosStatus = currentTicket.IosStatus; }
      if (ticket.AndroidStatus == null) { ticket.AndroidStatus = currentTicket.AndroidStatus; }
      if (ticket.webStatus == null) { ticket.webStatus = currentTicket.webStatus; }

      return _ticketRepo.Edit(ticket);
    }
    internal Boolean Delete(int Id, string Email)
    {
      return _ticketRepo.Delete(Id, Email);
    }
  }
}