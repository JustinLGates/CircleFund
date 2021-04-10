using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testingapi;
using Microsoft.AspNetCore.Authorization;

namespace Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ProjectController : ControllerBase
  {

    [Authorize]
    [HttpGet]
    public Project Get()
    {
      Project project = new Project();
      project.Name = "test";
      return project;
    }
  }
}
