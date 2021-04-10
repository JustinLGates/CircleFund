using System.Data;
using Dapper;
using Models;

namespace Repositories
{
  public class TicketRepo
  {

    private readonly IDbConnection _db;
    public TicketRepo(IDbConnection db)
    {
      _db = db;
    }
    internal Ticket Create(Ticket TicketData)
    {
      string sql = @"
        INSERT INTO ticket
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
        UPDATE ticket
        SET
      testName = @ TestName,
      priorityLevel = @ PriorityLevel,
      assignedTo = @ AssignedTo
      setup = @ Setup
      steps = @ Steps
      verifications = @ Verifications
      automate = @ Automate
      relatedFeature = @ RelatedFeature
      jiraticket = @ JiraTicket
      notes = @ Notes
      filePath = @ FilePath
      webStatus = @ WebStatus
      iosStatus = @ IosStatus
      androidStatus = @ AndroidStatus
        WHERE id = @Id;
        SELECT * FROM ticket WHERE  id = @Id && email = @Email;
            ";
      return _db.QueryFirstOrDefault<Ticket>(sql, orgData);
    }

    internal Ticket Get(string userIdentifier)
    {
      string sql = "SELECT * FROM ticket WHERE creatorEmail = @userIdentifier ";
      return _db.QueryFirstOrDefault<Ticket>(sql, new { userIdentifier });
    }

    internal bool Delete(int Id, string Email)
    {
      string sql = " SELECT FROM ticket WHERE id = @Id && creatorEmail = @CreatorEmail";
      return _db.Execute(sql, new { Id, Email }) == 1;
    }
  }
}

