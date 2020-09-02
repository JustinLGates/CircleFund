using Models;
using Repositories;

namespace Services
{
  public class FundraiserService
  {
    private readonly FundraiserRepo _fundraiserRepo;

    public FundraiserService(FundraiserRepo FundraiserRepo)
    {
      _fundraiserRepo = FundraiserRepo;
    }
    internal Fundraiser Create(Fundraiser Fundraiser)
    {
      return _fundraiserRepo.Create(Fundraiser);
    }

    internal Fundraiser Get(string nameIdentifier)
    {
      return _fundraiserRepo.Get(nameIdentifier);
    }
    internal Fundraiser GetById(int Id)
    {
      return _fundraiserRepo.GetById(Id);
    }
    internal Fundraiser Edit(Fundraiser newFundraiser)
    {
      Fundraiser currentFundraiser = GetById(newFundraiser.Id);

      if (newFundraiser.Goal == null) { newFundraiser.Goal = currentFundraiser.Goal; }
      if (newFundraiser.CurrentAmount == null) { newFundraiser.CurrentAmount = currentFundraiser.CurrentAmount; }
      if (newFundraiser.Active == currentFundraiser.Active) { newFundraiser.Active = currentFundraiser.Active; }
      if (newFundraiser.Link == null) { newFundraiser.Link = currentFundraiser.Link; }
      if (newFundraiser.Title == null) { newFundraiser.Title = currentFundraiser.Title; }
      if (newFundraiser.Description == null) { newFundraiser.Description = currentFundraiser.Description; }

      return _fundraiserRepo.Edit(newFundraiser);
    }
    internal bool Delete(int Id, string Email)
    {
      return _fundraiserRepo.Delete(Id, Email);
    }
  }
}
