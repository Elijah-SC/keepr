
namespace keepr.Services;

public class ProfilesService
{
  private readonly ProfilesRepository _profilesRepository;

  public ProfilesService(ProfilesRepository profilesRepository)
  {
    _profilesRepository = profilesRepository;
  }

  internal Profile getProfileById(string profileId)
  {
    return _profilesRepository.getProfileById(profileId);
  }
}
