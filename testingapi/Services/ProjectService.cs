using Repositories;
using Models;
using System;
using System.Collections.Generic;
namespace Services
{
  public class ProjectService
  {
    private readonly ProjectRepo _projectRepo;

    public ProjectService(ProjectRepo ProjectRepo)
    {
      _projectRepo = ProjectRepo;
    }

    internal UserProject Create(UserProject userProject, int creatorId)
    {
      return _projectRepo.Create(userProject, creatorId);
    }

    internal IEnumerable<ProjectContributor> GetAll(string userIdentifier, int userId)
    {
      return _projectRepo.Getall(userIdentifier, userId);
    }

    internal UserProject getById(UserProject userProject, string userIdentifier)
    {
      return _projectRepo.GetById(userProject.ProjectId, userIdentifier);
    }

    internal bool verifyUser(int projectId, int userId)
    {
      return _projectRepo.verifyProjectUser(projectId, userId);
    }

    internal UserProject Edit(UserProject UserProject, string userIdentifier)
    {
      UserProject currentUserProject = getById(UserProject, userIdentifier);

      if (UserProject.Name == null) { UserProject.Name = currentUserProject.Name; }

      return _projectRepo.Edit(UserProject);
    }

    internal Boolean Delete(int Id, string Email)
    {
      return _projectRepo.Delete(Id, Email);
    }
  }
}