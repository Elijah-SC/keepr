




namespace keepr.Services;

public class VaultsService
{
  private readonly VaultsRepository _repository;

  public VaultsService(VaultsRepository repository)
  {
    _repository = repository;
  }

  internal Vault createVault(VaultCreationDTO vaultData, string creatorId)
  {
    Vault vault = _repository.createVault(vaultData, creatorId);
    return vault;
  }

  internal Vault getVaultById(int vaultId, string userId)
  {
    Vault vault = getVaultById(vaultId);
    if (vault.IsPrivate == true && vault.creatorId != userId)
    {
      throw new Exception("invalid Credentials");
    }
    return vault;
  }
  internal Vault getVaultById(int vaultId)
  {
    Vault vault = _repository.getVaultById(vaultId);
    if (vault == null)
    {
      throw new Exception($"{vaultId} invalid Id");
    }
    return vault;
  }

  internal Vault updateVault(VaultCreationDTO updateData, int vaultId, string userId)
  {
    Vault vault = getVaultById(vaultId);
    if (vault.creatorId != userId)
    {
      throw new Exception("Invalid Credentials");
    }

    vault.name = updateData.name ?? vault.name;
    vault.Description = updateData.Description ?? vault.Description;
    vault.Img = updateData.Img ?? vault.Img;
    vault.IsPrivate = updateData.IsPrivate ?? vault.IsPrivate;

    _repository.updateVault(vault, vaultId);
    return vault;
  }
}
