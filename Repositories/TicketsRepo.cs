using System.Data;
using Dapper;
using Models;

namespace Repositories
{
  public class TicketsRepo
  {
    private readonly IDbConnection _db;
    public TicketsRepo(IDbConnection db)
    {
      _db = db;
    }
    internal Ticket Create(Ticket TicketData)
    {
      string sql = @"
        INSERT INTO Ticket
            (name, email, phoneNumber,logoUrl, city, state, address)
            VALUES
            (@Name, @Email, @PhoneNumber, @LogoUrl, @City, @State, @Address);
            SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(sql, TicketData);
      TicketData.Id = id;
      return TicketData;
    }

    internal Ticket Edit(Ticket orgData)
    {
      string sql = @"
        UPDATE Ticket
        SET
            name = @Name,
            email = @Email,
            phoneNumber = @PhoneNumber,
            logoUrl = @LogoUrl,
            city = @City,
            state = @State,
            address= @Address
        WHERE id = @Id;
        SELECT * FROM Ticket WHERE  id = @Id && email = @Email;
            ";
      return _db.QueryFirstOrDefault<Ticket>(sql, orgData);
    }

    internal Ticket Get(string userIdentifier)
    {
      string sql = "SELECT * FROM Ticket WHERE email = @userIdentifier ";
      return _db.QueryFirstOrDefault<Ticket>(sql, new { userIdentifier });
    }

    internal bool Delete(int Id, string Email)
    {
      string sql = " SELECT FROM Ticket WHERE id = @Id && email = @Email";
      return _db.Execute(sql, new { Id, Email }) == 1;
    }
  }
}