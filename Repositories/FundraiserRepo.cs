using System;
using System.Data;
using Dapper;
using Models;

namespace Repositories
{
  public class FundraiserRepo
  {
    private readonly IDbConnection _db;
    public FundraiserRepo(IDbConnection db)
    {
      _db = db;
    }
    internal Fundraiser Create(Fundraiser FundraiserData)
    {
      string sql = @"
        INSERT INTO userFundraiser
            (active, title, description, link, goal, currentAmount, organizationId)
            VALUES
            (@Active, @Title, @Description, @Link, @Goal, @CurrentAmount, @OrganizationId);
            SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(sql, FundraiserData);
      FundraiserData.Id = id;
      return FundraiserData;
    }

    internal Fundraiser GetById(int Id)
    {
      string sql = @"
     SELECT * FROM userFundraiser WHERE id = @Id";
      return _db.QueryFirstOrDefault(sql, new { Id });
    }

    internal Fundraiser Get(string nameIdentifier)
    {
      string sql = "SELECT * FROM userFundraiser WHERE id = @nameIdentifier";
      return _db.QueryFirstOrDefault<Fundraiser>(sql, new { nameIdentifier });
    }

    internal Fundraiser Edit(Fundraiser newFundraiser)
    {
      string sql = @"
        UPDATE userFundraiser
        SET
            goal = @Goal,
            currentAmount = @CurrentAmount,
            active = @Active,
            link = @Link,
            title = @Title,
            description = @Description,
        WHERE id = @Id;
        SELECT * FROM userFundraiser WHERE  id = @Id && email = @Email;
            ";
      return _db.ExecuteScalar<Fundraiser>(sql, newFundraiser);
    }

    internal bool Delete(int Id, string Email)
    {
      bool Value = false;
      string sql = @"
     UPDATE userFundraiser 
     SET active = @Value
      WHERE id = @Id && email = Email;
     ";
      return _db.Execute(sql, new { Value, Id, Email }) == 1;
    }
  }
}