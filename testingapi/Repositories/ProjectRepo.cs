using System.Data;
using Dapper;
using Models;

namespace Repositories
{
  public class ProjectRepo
  {
    private readonly IDbConnection _db;
    public ProjectRepo(IDbConnection db)
    {
      _db = db;
    }

    internal UserProject Create(UserProject userProject)
    {
      string sql = @"
        INSERT INTO userProject
            (name, creatorEmail)
            VALUES
            (@Name, @CreatorEmail);
            SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(sql, userProject);
      userProject.Id = id;
      return userProject;
    }

    internal UserProject Get(string userIdentifier)
    {
      // get all where userIdentifier is in the userProject_contributors table...
      string sql = "SELECT * FROM userProject WHERE email = @userIdentifier ";
      return _db.QueryFirstOrDefault<UserProject>(sql, new { userIdentifier });
    }

    internal UserProject Edit(UserProject orgData)
    {
      string sql = @"
        UPDATE userProject
        SET
            name = @Name,
        WHERE id = @Id;
        SELECT * FROM userProject WHERE  id = @Id && creatorEmail = @CreatorEmail;
            ";
      return _db.QueryFirstOrDefault<UserProject>(sql, orgData);
    }

    internal bool Delete(int Id, string Email)
    {
      string sql = " SELECT FROM userProject WHERE id = @Id && creatorEmail = @CreatorEmail";
      return _db.Execute(sql, new { Id, Email }) == 1;
    }
  }
}