using Models;
using Repositories;

namespace Services
{
  public class FundraiserService
  {
    private readonly FundraiserRepo _fundraiserService;

    public FundraiserService(FundraiserRepo FundraiserService)
    {
      _fundraiserService = FundraiserService;
    }
    internal Fundraiser Create(Fundraiser Fundraiser)
    {
      return _fundraiserService.Create(Fundraiser);
    }

    internal Fundraiser Get(string nameIdentifier)
    {
      return _fundraiserService.Get(nameIdentifier);
    }
  }
}
