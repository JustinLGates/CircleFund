using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ProjectController : ControllerBase
  {
    private readonly ProjectService _projectService;
    private readonly TicketService _ticketService;
    private readonly ProfileService _profileService;

    public ProjectController(ProjectService ProjectService, TicketService TicketService, ProfileService ProfileService)
    {
      _projectService = ProjectService;
      _ticketService = TicketService;
      _profileService = ProfileService;
    }



    [HttpPost("{projectId}/ticket")]
    [Authorize]
    public ActionResult<Ticket> Create(int projectId, [FromBody] Ticket ticket)
    {
      try
      {
        string nameIdentifier = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        Profile profile = _profileService.Get(nameIdentifier);
        ticket.CreatorEmail = nameIdentifier;
        ticket.CreatorId = profile.Id;
        ticket.ProjectId = projectId;
        bool userVerified = _projectService.verifyUser(projectId, profile.Id);
        if (nameIdentifier != null && userVerified)
        {
          return Ok(_ticketService.Create(ticket, projectId));
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

    [HttpPost("user/{userId}")]
    [Authorize]
    public ActionResult<UserProject> Create(int userId, [FromBody] UserProject userProject)
    {
      try
      {
        string nameIdentifier = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        if (nameIdentifier != null)
        {
          userProject.CreatorEmail = nameIdentifier;
          return Ok(_projectService.Create(userProject, userId));
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
    [HttpGet("{projectId}/ticket")]
    public ActionResult<Ticket> Get(int projectId)
    {
      try
      {
        string nameIdentifier = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        Profile profile = _profileService.Get(nameIdentifier);
        bool userVerified = _projectService.verifyUser(projectId, profile.Id);

        if (nameIdentifier != null && userVerified)
        {
          return Ok(_ticketService.Get(projectId));
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
    [HttpGet("{userId}")]
    public ActionResult<ProjectContributor> GetAll(int userId)
    {
      try
      {
        string nameIdentifier = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        if (nameIdentifier != null)
        {
          return Ok(_projectService.GetAll(nameIdentifier, userId));
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
    [HttpPut("{projectId}/ticket/{ticketId}")]
    public ActionResult<Ticket> Edit(int projectId, int ticketId, [FromBody] Ticket Ticket)
    {
      try
      {
        Ticket.TicketId = ticketId;
        string nameIdentifier = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        Profile profile = _profileService.Get(nameIdentifier);
        bool userVerified = _projectService.verifyUser(projectId, profile.Id);
        if (nameIdentifier != null && userVerified)
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
    [HttpPut("{id}")]
    public ActionResult<UserProject> Edit(int id, [FromBody] UserProject UserProject)
    {
      try
      {
        UserProject.ProjectId = id;
        string nameIdentifier = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        if (nameIdentifier != null)
        {
          UserProject.CreatorEmail = nameIdentifier;
          return Ok(value: _projectService.Edit(UserProject, nameIdentifier));
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
          return Ok(_projectService.Delete(id, nameIdentifier));
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