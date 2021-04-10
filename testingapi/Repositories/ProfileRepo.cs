using System.Data;
using Dapper;
using Models;

namespace Repositories
{
  public class ProfileRepo
  {
    private readonly IDbConnection _db;
    public ProfileRepo(IDbConnection db)
    {
      _db = db;
    }

    internal Profile Create(Profile ProfileData)
    {
      string sql = @"
        INSERT INTO profile
            (name, email)
            VALUES
            (@Name, @Email);
            SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(sql, ProfileData);
      ProfileData.Id = id;
      return ProfileData;
    }

    internal Profile Get(string userIdentifier)
    {
      string sql = "SELECT * FROM profile WHERE email = @userIdentifier ";
      return _db.QueryFirstOrDefault<Profile>(sql, new { userIdentifier });
    }

    internal Profile Edit(Profile profileData)
    {
      string sql = @"
        UPDATE profile
        SET
            name = @Name
        WHERE id = @Id;
        SELECT * FROM profile WHERE  id = @Id && email = @Email;
            ";
      return _db.QueryFirstOrDefault<Profile>(sql, profileData);
    }

    internal bool Delete(int Id, string Email)
    {
      string sql = " SELECT FROM profile WHERE id = @Id && email = @Email";
      return _db.Execute(sql, new { Id, Email }) == 1;
    }
  }
}