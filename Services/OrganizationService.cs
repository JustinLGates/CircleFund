using Repositories;
using Models;

namespace Services
{
  public class OrganizationService
  {
    private readonly OrganizationRepo _OrganizationService;

    public OrganizationService(OrganizationRepo OrganizationService)
    {
      _OrganizationService = OrganizationService;
    }
    internal Organization Create(Organization Organization)
    {
      return _OrganizationService.Create(Organization);
    }

    internal Organization Get(string userIdentifier)
    {
      return _OrganizationService.Get(userIdentifier);
    }

  }
}