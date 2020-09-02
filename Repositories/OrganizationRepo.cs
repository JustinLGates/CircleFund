using System;
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

    internal Organization Edit(Organization orgData)
    {
      string sql = @"
        UPDATE userOrganization
        SET
            name = @Name,
            email = @Email,
            phoneNumber = @PhoneNumber,
            logoUrl = @LogoUrl,
            city = @City,
            state = @State,
            address= @Address
        WHERE id = @Id;
        SELECT * FROM userOrganization WHERE  id = @Id && email = @Email;
            ";
      return _db.QueryFirstOrDefault<Organization>(sql, orgData);
    }

    internal Organization Get(string userIdentifier)
    {
      string sql = "SELECT * FROM userOrganization WHERE email = @userIdentifier ";
      return _db.QueryFirstOrDefault<Organization>(sql, new { userIdentifier });
    }

    internal bool Delete(int Id, string Email)
    {
      string sql = " SELECT FROM userOrganization WHERE id = @Id && email = @Email";
      return _db.Execute(sql, new { Id, Email }) == 1;
    }
  }
}