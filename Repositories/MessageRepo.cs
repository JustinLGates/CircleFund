using System.Data;
using Dapper;
using Models;
using System.Collections.Generic;

namespace Repositories
{
  public class MessageRepo
  {
    private readonly IDbConnection _db;

    public MessageRepo(IDbConnection db)
    {
      _db = db;
    }


    internal Message Create(Message MessageData)
    {
      string sql = @"
        INSERT INTO messages
            (name, body, email,phonenumber)
            VALUES
            (@Name, @Body, @Email, @PhoneNumber);
            SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(sql, MessageData);
      MessageData.Id = id;
      return MessageData;
    }

    internal IEnumerable<Message> Get(string nameIdentifier)
    {
      //NOTE nameIdentifier is avalabe if you want use a where statement in your sql to find only messages they sent
      //EXAMPLE:
      // string sql = "SELECT * FROM messages WHERE email = @Email";
      // return _db.Query<Message>(sql,new {nameIdentifier});

      string sql = "SELECT * FROM messages";
      return _db.Query<Message>(sql);
    }
  }
}