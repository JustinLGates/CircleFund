
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

  public class FundraiserController : ControllerBase
  {
    private readonly FundraiserService _FundraiserService;

    public FundraiserController(FundraiserService FundraiserService)
    {
      _FundraiserService = FundraiserService;
    }
    [Authorize]
    [HttpPost]
    public ActionResult<Fundraiser> Create([FromBody] Fundraiser Fundraiser)
    {
      try
      {
        string nameIdentifier = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        if (nameIdentifier != null)
        {
          // Fundraiser.Email = nameIdentifier;
          return Ok(_FundraiserService.Create(Fundraiser));
        }
        else
        {
          throw new UnauthorizedAccessException("Unothorized");
        }
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpGet]
    public ActionResult<Fundraiser> Get()
    {
      try
      {
        string nameIdentifier = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        if (nameIdentifier != null)
        {
          return Ok(_FundraiserService.Get(nameIdentifier));
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
    public ActionResult<Fundraiser> Edit(int id, [FromBody] Fundraiser Organization)
    {
      try
      {
        Organization.Id = id;
        string nameIdentifier = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        if (nameIdentifier != null)
        {
          return Ok(value: _FundraiserService.Edit(Organization));
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
    //NOTE this route is used to archive a user should never fully delete this information
    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<Boolean> Delete(int id)
    {
      try
      {
        string nameIdentifier = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        if (nameIdentifier != null)
        {
          return Ok(_FundraiserService.Delete(id, nameIdentifier));
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
