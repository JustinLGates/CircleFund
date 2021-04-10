using Repositories;
using Models;
using System;

namespace Services
{
  public class ProjectService
  {
    private readonly ProjectRepo _projectRepo;

    public ProjectService(ProjectRepo ProjectRepo)
    {
      _projectRepo = ProjectRepo;
    }

    internal UserProject Create(UserProject userProject)
    {
      return _projectRepo.Create(userProject);
    }

    internal UserProject Get(string userIdentifier)
    {
      return _projectRepo.Get(userIdentifier);
    }

    internal UserProject Edit(UserProject UserProject)
    {
      UserProject currentUserProject = Get(UserProject.CreatorEmail);

      if (UserProject.Name == null) { UserProject.Name = currentUserProject.Name; }

      return _projectRepo.Edit(UserProject);
    }

    internal Boolean Delete(int Id, string Email)
    {
      return _projectRepo.Delete(Id, Email);
    }
  }
}