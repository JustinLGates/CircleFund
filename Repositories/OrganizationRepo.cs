using System.Data;
using Dapper;
using Models;

namespace Repositories
{
  public class OrganizationRepo
  {
    private readonly IDbConnection _db;
    public OrganizationRepo(IDbConnection db)
    {
      _db = db;
    }
    internal Organization Create(Organization OrganizationData)
    {
      string sql = @"
        INSERT INTO userOrganization
            (name, email, phoneNumber,logoUrl, city, state, address)
            VALUES
            (@Name, @Email, @PhoneNumber, @LogoUrl, @City, @State, @Address);
            SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(sql, OrganizationData);
      OrganizationData.Id = id;
      return OrganizationData;
    }
    internal Organization Get(string userIdentifier)
    {
      string sql = "SELECT * FROM userOrganization WHERE email = @userIdentifier";
      return _db.QueryFirstOrDefault<Organization>(sql, new { userIdentifier });
    }
  }
}