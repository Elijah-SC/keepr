



namespace keepr.Repositories;

public class VaultKeepsRepository
{
  private readonly IDbConnection _db;

  public VaultKeepsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal VaultKeep createVaultKeep(VaultKeepCreationDTO creationData, string creatorId)
  {
    string sql = @"
    INSERT INTO 
    vaultKeeps(vaultId, keepId, creatorId)
    Values(@VaultId, @KeepId, @CreatorId);
    SELECT * FROM vaultKeeps WHERE id = LAST_INSERT_ID();";

    return _db.Query<VaultKeep>(sql, new
    {
      creationData.KeepId,
      creationData.VaultId,
      creatorId
    }).FirstOrDefault();
  }

  internal void deleteVaultKeep(int vaultKeepId)
  {
    string sql = @"DELETE FROM vaultKeeps WHERE id = @vaultKeepId LIMIT 1;";
    int rowsAffected = _db.Execute(sql, new { vaultKeepId });
    switch (rowsAffected)
    {
      case 0:
        throw new Exception("The Vault Keep relation ship was not deleted");
      case 1:
        break;
      default:
        throw new Exception($"{rowsAffected} VaultKeep RelationShips were deleted, Thats not good");
    }
  }

  internal List<KeepDTO> getKeepsInVault(int vaultId)
  {
    string sql = @"
    SELECT
    vaultKeeps.*,
    keeps.*,
    accounts.*
    FROM vaultKeeps
    JOIN keeps ON keeps.id = vaultKeeps.keepId
    JOIN accounts ON accounts.id = keeps.creatorId
    WHERE vaultKeeps.vaultId = @vaultId;";

    return _db.Query(sql, (VaultKeep vaultKeep, KeepDTO keepDTO, Profile p) =>
    {
      keepDTO.Creator = p;
      keepDTO.VaultKeepId = vaultKeep.Id;
      return keepDTO;
    }, new { vaultId }).ToList();
  }

  internal VaultKeep getVaultKeepById(int vaultKeepId)
  {
    string sql = @"
      SELECT * FROM vaultKeeps WHERE id = @vaultKeepId;";
    return _db.Query<VaultKeep>(sql, new { vaultKeepId }).FirstOrDefault();
  }
}




