






using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace keepr.Repositories;

public class VaultsRepository
{
  private readonly IDbConnection _db;

  public VaultsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Vault createVault(VaultCreationDTO vaultData, string creatorId)
  {
    string sql = @"
    INSERT INTO 
      vaults(name, description, img, isPrivate, creatorId)
      VALUES(@Name, @Description, @Img, @IsPrivate, @CreatorId);
      
    Select 
      vaults.*,
      accounts.*
    From 
      vaults
    JOIN 
      accounts ON accounts.Id = vaults.creatorId
    WHERE 
      vaults.id = LAST_INSERT_ID();";

    return _db.Query(sql, (Vault v, Profile p) =>
    {
      v.creator = p;
      return v;
    }, new
    {
      vaultData.Description,
      vaultData.name,
      vaultData.IsPrivate,
      vaultData.Img,
      creatorId
    }).FirstOrDefault();
  }

  internal Vault getVaultById(int vaultId)
  {
    string sql = @"
    Select 
    vaults.*,
    accounts.*
    FROM vaults
    JOIN accounts ON accounts.id = vaults.creatorId
    WHERE vaults.id = @vaultId;";

    return _db.Query(sql, (Vault v, Profile p) =>
    {
      v.creator = p;
      return v;
    }, new { vaultId }).FirstOrDefault();
  }

  internal void updateVault(Vault vault, int vaultId)
  {
    string sql = @"
    UPDATE vaults
    SET
    name = @Name, 
    img = @Img, 
    description = @Description, 
    isPrivate = @IsPrivate
    WHERE id = @vaultId 
    LIMIT 1;";

    int rowsAffected = _db.Execute(sql, new
    {
      vaultId,
      vault.Description,
      vault.name,
      vault.Img,
      vault.IsPrivate
    });

    switch (rowsAffected)
    {
      case 0:
        throw new Exception("No Vaults were updated");
      case 1:
        break;
      default:
        throw new Exception($"{rowsAffected} were updated, Thats not Good");
    }
  }
}




