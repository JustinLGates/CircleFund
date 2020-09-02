using Repositories;
using Models;
using System;

namespace Services
{
  public class OrganizationService
  {
    private readonly OrganizationRepo _OrganizationRepo;

    public OrganizationService(OrganizationRepo OrganizationRepo)
    {
      _OrganizationRepo = OrganizationRepo;
    }
    internal Organization Create(Organization Organization)
    {
      return _OrganizationRepo.Create(Organization);
    }

    internal Organization Get(string userIdentifier)
    {
      return _OrganizationRepo.Get(userIdentifier);
    }

    internal Organization Edit(Organization newOrg)
    {
      Organization currentOrg = Get(newOrg.Email);
      // if any info is not sent use existing to update values
      if (newOrg.State == null) { newOrg.State = currentOrg.State; }
      if (newOrg.City == null) { newOrg.City = currentOrg.City; }
      if (newOrg.Address == null) { newOrg.Address = currentOrg.Address; }
      if (newOrg.Name == null) { newOrg.Name = currentOrg.Name; }
      if (newOrg.Email == null) { newOrg.Email = currentOrg.Email; }
      if (newOrg.PhoneNumber == null) { newOrg.PhoneNumber = currentOrg.PhoneNumber; }
      if (newOrg.LogoUrl == null) { newOrg.LogoUrl = currentOrg.LogoUrl; }
      return _OrganizationRepo.Edit(newOrg);
    }
    internal Boolean Delete(int Id, string Email)
    {
      return _OrganizationRepo.Delete(Id, Email);
    }
  }
}