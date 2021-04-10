using System;
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
    internal userProject Create(userProject projectData)
    {
      string sql = @"
        INSERT INTO project
            (name)
            VALUES
            (@Name);
            SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(sql, projectData);
      projectData.Id = id;
      return projectData;
    }
  }
}