


namespace keepr.Services;

public class VaultKeepsService
{
  private readonly VaultKeepsRepository _repository;
  private readonly VaultsService _vaultsService;

  public VaultKeepsService(VaultKeepsRepository repository, VaultsService vaultsService)
  {
    _repository = repository;
    _vaultsService = vaultsService;
  }

  internal VaultKeep createVaultKeep(VaultKeepCreationDTO creationData, string creatorId)
  {
    Vault vault = _vaultsService.getVaultById(creationData.VaultId);
    if (vault.CreatorId != creatorId)
    {
      throw new Exception("Invalid Credentials");
    }
    return _repository.createVaultKeep(creationData, creatorId);
  }

  internal ActionResult<string> deleteVaultKeep(int vaultKeepId, string userId)
  {
    VaultKeep vaultKeep = getVaultKeepById(vaultKeepId);
    if (vaultKeep.CreatorId != userId)
    {
      throw new Exception("Invalid Credentials");
    }

    _repository.deleteVaultKeep(vaultKeepId);

    return "VaultKeep relationship was deleted";
  }
  internal VaultKeep getVaultKeepById(int vaultKeepId)
  {
    VaultKeep vaultKeep = _repository.getVaultKeepById(vaultKeepId);
    if (vaultKeep == null)
    {
      throw new Exception($"invalid Id {vaultKeepId}");
    }
    return vaultKeep;
  }

  internal List<KeepDTO> getKeepsInVault(int vaultId, string userId)
  {
    Vault vault = _vaultsService.getVaultById(vaultId);
    if (vault.IsPrivate == true && vault.CreatorId != userId)
    {
      throw new Exception("Invalid Credentials");
    }
    return _repository.getKeepsInVault(vaultId);
  }
}
