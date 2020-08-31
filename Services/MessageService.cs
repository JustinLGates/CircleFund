using Repositories;
using Models;
using System.Collections.Generic;

namespace Services
{
  public class MessageService
  {
    private readonly MessageRepo _repo;
    public MessageService(MessageRepo repo)
    {
      _repo = repo;
    }

    internal object Create(Message message)
    {
      return _repo.Create(message);
    }

    internal IEnumerable<Message> Get(string nameIdentifier)
    {
      return _repo.Get(nameIdentifier);
    }
  }

}