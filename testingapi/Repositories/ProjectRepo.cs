using System.Data;
using Dapper;
using Models;
using System.Collections.Generic;

namespace Repositories
{
  public class ProjectRepo
  {
    private readonly IDbConnection _db;
    public ProjectRepo(IDbConnection db)
    {
      _db = db;
    }

    internal UserProject Create(UserProject userProject, int creatorId)
    {
      string sqlCreateProject = @"
        INSERT INTO userProject
            (name, creatorEmail)
            VALUES
            (@Name, @CreatorEmail);
            SELECT LAST_INSERT_ID();
            ";
      int projectId = _db.ExecuteScalar<int>(sqlCreateProject, userProject);

      userProject.ProjectId = projectId;
      string creatorEmail = userProject.CreatorEmail;
      string role = "owner";

      string sqlAddAsOwner = @"
        INSERT INTO projectContributors
            (projectId, role, userId)
            VALUES
            (@projectId, @role, @creatorId);
            SELECT LAST_INSERT_ID();
            ";
      _db.Execute(sqlAddAsOwner, new { projectId, role, creatorId });

      return userProject;
    }

    internal IEnumerable<ProjectContributor> Getall(string userIdentifier, int userId)
    {
      string sql = @"
      SELECT * 
      FROM userProject
      INNER JOIN projectContributors  
      ON userProject.projectId =  projectContributors.projectId ;
";
      return _db.Query<ProjectContributor>(sql, new { userId, userIdentifier });
    }

    internal UserProject GetById(int projectId, string userIdentifier)
    {
      string sql = @"
      SELECT * 
      FROM userProject 
      WHERE projectId = @ProjectId; ";
      return _db.QueryFirstOrDefault<UserProject>(sql, new { projectId, userIdentifier });
    }

    internal bool verifyProjectUser(int ProjectId, int UserId)
    {
      string sql = @"
      SELECT * 
      FROM projectContributors  
      WHERE projectId = @ProjectId && userId = @UserId ; ";
      return _db.QueryFirstOrDefault<int>(sql, new { ProjectId, UserId }) == 1;
    }

    internal UserProject Edit(UserProject orgData)
    {
      string sql = @"
        UPDATE userProject
        SET name = @Name
        WHERE projectId = @ProjectId && creatorEmail = @CreatorEmail;
        SELECT name 
        FROM userProject
        WHERE projectId = @ProjectId && creatorEmail = @CreatorEmail;
            ";
      return _db.QueryFirstOrDefault<UserProject>(sql, orgData);
    }

    internal bool Delete(int ProjectId, string CreatorEmail)
    {
      string sql = @" 
      DELETE 
      FROM userProject
      WHERE projectId = @ProjectId && creatorEmail = @CreatorEmail;";
      return _db.Execute(sql, new { ProjectId, CreatorEmail }) == 1;
    }
  }
}