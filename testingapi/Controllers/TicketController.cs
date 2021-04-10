using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class Ticketcontroller : ControllerBase
  {
    private readonly TicketService _ticketService;
    public Ticketcontroller(TicketService TicketService)
    {
      _ticketService = TicketService;
    }

    [HttpPost]
    [Authorize]
    public ActionResult<Ticket> Create([FromBody] Ticket Ticket)
    {
      try
      {
        string nameIdentifier = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        if (nameIdentifier != null)
        {
          Ticket.creatorEmail = nameIdentifier;
          return Ok(_ticketService.Create(Ticket));
        }
        else
        {
          throw new UnauthorizedAccessException("Unauthorized");
        }
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpGet]
    public ActionResult<Ticket> Get()
    {
      try
      {
        string nameIdentifier = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        if (nameIdentifier != null)
        {
          return Ok(_ticketService.Get(nameIdentifier));
        }
        else
        {
          throw new UnauthorizedAccessException("Unauthorized");
        }
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPut("{id}")]
    public ActionResult<Ticket> Edit(int id, [FromBody] Ticket Ticket)
    {
      try
      {
        Ticket.Id = id;
        string nameIdentifier = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        if (nameIdentifier != null)
        {
          return Ok(value: _ticketService.Edit(Ticket));
        }
        else
        {
          throw new UnauthorizedAccessException("Unauthorized");
        }
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<Boolean> Delete(int id)
    {
      try
      {
        string nameIdentifier = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        if (nameIdentifier != null)
        {
          return Ok(_ticketService.Delete(id, nameIdentifier));
        }
        else
        {
          throw new UnauthorizedAccessException("Unauthorized");
        }
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}