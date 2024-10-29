



namespace keepr.Services;

public class KeepsService
{
  private readonly KeepsRepository _keepsRepository;
  public KeepsService(KeepsRepository keepsRepository)
  {
    _keepsRepository = keepsRepository;
  }

  internal Keep createKeep(KeepCreationDTO keepData, string creatorId)
  {
    return _keepsRepository.createKeep(keepData, creatorId);
  }


  internal List<Keep> getAllKeeps()
  {
    return _keepsRepository.getAllKeeps();
  }

  internal Keep getKeepById(int keepId)
  {
    Keep keep = _keepsRepository.getKeepById(keepId);
    if (keep == null)
    {
      throw new Exception($"Invalid Id {keepId}");
    }
    return keep;
  }

  internal Keep updateKeep(KeepCreationDTO updateData, int keepId, string userId)
  {
    Keep keep = getKeepById(keepId);
    if (keep.CreatorId != userId)
    {
      throw new Exception("Invalid Credentials");
    }

    keep.Name = updateData.Name ?? keep.Name;
    keep.Description = updateData.Description ?? keep.Description;
    keep.Img = updateData.Img ?? keep.Img;

    _keepsRepository.updateKeep(keep);

    return keep;
  }
  internal string deleteKeep(int keepId, string userId)
  {
    Keep keep = getKeepById(keepId);
    if (keep.CreatorId != userId)
    {
      throw new Exception("Invalid Credentials");
    }

    _keepsRepository.deleteKeep(keepId);

    return "Keep was Deleted";
  }

  internal List<Keep> getProfileKeeps(string profileId)
  {
    return _keepsRepository.getProfileKeeps(profileId);
  }
}
