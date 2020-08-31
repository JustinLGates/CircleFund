using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class MessagesController : ControllerBase
  {
    private readonly MessageService _MessageService;
    public MessagesController(MessageService messageService)
    {
      _MessageService = messageService;
    }
    //NOTE Anyone can access this controller route
    [HttpPost]
    public ActionResult<Message> Create([FromBody] Message message)
    {
      try
      {
        return Ok(_MessageService.Create(message));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    //NOTE locked down only a loged in user can access this controller route
    [Authorize]
    [HttpGet]
    public ActionResult<IEnumerable<Message>> Get()
    {
      try
      {
        var nameIdentifier = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (nameIdentifier != null)
        {
          return Ok(_MessageService.Get(nameIdentifier.Value));
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