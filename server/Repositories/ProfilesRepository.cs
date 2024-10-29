
namespace keepr.Repositories;

public class ProfilesRepository
{
  private readonly IDbConnection _db;

  public ProfilesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Profile getProfileById(string profileId)
  {
    string sql = @"SELECT * FROM accounts where accounts.Id = @profileId;";

    return _db.Query<Profile>(sql, new { profileId }).FirstOrDefault();
  }
}




