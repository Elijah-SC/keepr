




namespace keepr.Repositories;

public class KeepsRepository
{
  private readonly IDbConnection _db;

  public KeepsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Keep createKeep(KeepCreationDTO keepData, string creatorId)
  {
    string sql = @"
      INSERT INTO 
      keeps(name, description, img, creatorId)
      VALUES (@Name, @Description, @Img, @CreatorId);
      
      SELECT 
        keeps.*,
        accounts.*
      FROM
        keeps
        JOIN accounts ON accounts.id = keeps.creatorId
      WHERE 
        keeps.id = LAST_INSERT_ID();";

    return _db.Query(sql, (Keep k, Profile p) =>
    {
      k.Creator = p;
      return k;
    }, new
    {
      keepData.Name,
      keepData.Description,
      keepData.Img,
      creatorId
    }).FirstOrDefault();
  }

  internal void deleteKeep(int keepId)
  {
    string sql = @"
    Delete From keeps where id = @keepId Limit 1;";

    int rowsAffected = _db.Execute(sql, new { keepId });

    switch (rowsAffected)
    {
      case 0:
        throw new Exception("No Keeps were Deleted");
      case 1:
        break;
      default:
        throw new Exception($"{rowsAffected} were deleted, That is Not good");
    }

  }

  internal List<Keep> getAllKeeps()
  {
    string sql = @"
   SELECT 
      keeps.*, COUNT(
        vaultKeeps.keepId
      ) as kept,
      accounts.*
   FROM 
    keeps
    Join accounts ON accounts.id = keeps.creatorId
    LEFT OUTER JOIN vaultKeeps ON vaultKeeps.keepId = keeps.id
  GROUP BY
    keeps.id;";

    return _db.Query(sql, (Keep k, Profile p) =>
    {
      k.Creator = p;
      return k;
    }
    ).ToList();
  }

  internal Keep getKeepById(int keepId)
  {
    string sql = @"
    UPDATE keeps SET views = views + 1 WHERE keeps.id = @keepId;
    SELECT 
      keeps.*, COUNT(
        vaultKeeps.keepId
      ) as kept,
      accounts.*
    FROM 
      keeps
      Join accounts ON accounts.id = keeps.creatorId
      LEFT OUTER JOIN vaultKeeps ON vaultKeeps.keepId = keeps.id
    WHERE 
      keeps.id = @keepId
    GROUP BY
      keeps.id
    ;";

    return _db.Query(sql, (Keep k, Profile p) =>
    {
      k.Creator = p;
      return k;
    }, new { keepId }).FirstOrDefault();
  }

  internal List<Keep> getProfileKeeps(string profileId)
  {
    string sql = @"
    SELECT 
    keeps.*,
    accounts.*
    FROM keeps
    JOIN accounts ON accounts.id = keeps.creatorId
    WHERE keeps.creatorId = @profileId;";

    return _db.Query(sql, (Keep k, Profile p) =>
    {
      k.Creator = p;
      return k;
    }, new { profileId }).ToList();
  }

  internal void updateKeep(Keep keep)
  {
    string sql = @"
    UPDATE keeps
    Set 
      name = @Name, 
      description = @Description, 
      img = @Img
    Where 
      id = @id
    LIMIt 1;";

    int rowsAffected = _db.Execute(sql, keep);

    switch (rowsAffected)
    {
      case 0:
        throw new Exception("No Keeps were Updated");
      case 1:
        break;
      default:
        throw new Exception($"{rowsAffected} were updated, That is Not good");
    }
  }
}




