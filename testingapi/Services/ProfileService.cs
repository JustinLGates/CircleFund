using Repositories;
using Models;
using System;

namespace Services
{
  public class ProfileService
  {
    private readonly ProfileRepo _profileRepo;

    public ProfileService(ProfileRepo ProfileRepo)
    {
      _profileRepo = ProfileRepo;
    }

    internal Profile Create(Profile Profile)
    {
      return _profileRepo.Create(Profile);
    }

    internal Profile Get(string userIdentifier)
    {
      return _profileRepo.Get(userIdentifier);
    }

    internal Profile Edit(Profile Profile)
    {
      Profile currentProfile = Get(Profile.Email);

      if (Profile.Name == null) { Profile.Name = currentProfile.Name; }

      return _profileRepo.Edit(Profile);
    }
    internal Boolean Delete(int Id, string Email)
    {
      return _profileRepo.Delete(Id, Email);
    }
  }
}