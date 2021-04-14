using System.Data;
using Dapper;
using Models;
using System.Collections.Generic;
namespace Repositories
{
  public class TicketRepo
  {

    private readonly IDbConnection _db;
    public TicketRepo(IDbConnection db)
    {
      _db = db;
    }
    internal Ticket Create(Ticket TicketData, int ProjectId)
    {
      TicketData.ProjectId = ProjectId;
      string sql = @"
        INSERT INTO ticket
            (creatorEmail, creatorId, testName, priorityLevel, assignedTo, setup, steps, verifications, automate, relatedFeature, jiraTicket, notes, filePath, webStatus, androidStatus, iosStatus, projectId)
            VALUES
            (@CreatorEmail, @creatorId, @TestName, @PriorityLevel, @AssignedTo, @Setup, @Steps, @Verifications, @Automate, @RelatedFeature, @JiraTicket, @Notes, @FilePath, @WebStatus, @AndroidStatus, @IosStatus, @ProjectId);
            SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(sql, (TicketData));
      TicketData.TicketId = id;
      return TicketData;
    }

    internal Ticket Edit(Ticket Ticket)
    {
      string sql = @"
      UPDATE ticket
        SET
        testName = @TestName,
        priorityLevel = @PriorityLevel,
        assignedTo = @AssignedTo,
        setup = @Setup,
        steps = @Steps,
        verifications = @Verifications,
        automate = @Automate,
        relatedFeature = @RelatedFeature,
        jiraticket = @JiraTicket,
        notes = @Notes,
        filePath = @FilePath,
        webStatus = @WebStatus,
        iosStatus = @IosStatus,
        androidStatus = @AndroidStatus
        WHERE ticketId = @TicketId;
      SELECT *
      FROM ticket 
      WHERE  ticketId = @TicketId;
            ";
      return _db.QueryFirstOrDefault<Ticket>(sql, Ticket);
    }

    internal IEnumerable<Ticket> Get(int ProjectId)
    {
      string sql = "SELECT * FROM ticket WHERE projectId = @ProjectId ";
      return _db.Query<Ticket>(sql, new { ProjectId });
    }

    internal Ticket GetById(int TicketId)
    {
      string sql = "SELECT * FROM ticket WHERE ticketId = @TicketId ";
      return _db.QueryFirstOrDefault<Ticket>(sql, new { TicketId });
    }

    internal bool Delete(int Id, string Email)
    {
      string sql = " SELECT FROM ticket WHERE id = @Id && creatorEmail = @CreatorEmail";
      return _db.Execute(sql, new { Id, Email }) == 1;
    }
  }
}

