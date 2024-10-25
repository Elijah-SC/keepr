namespace keepr.Models;

public class VaultKeepCreationDTO
{
  public int KeepId { get; set; }
  public int VaultId { get; set; }
  public string CreatorId { get; set; }
}

public class VaultKeep : RepoItem<int>
{
  public int Id { get; set; }
  public int KeepId { get; set; }
  public int VaultId { get; set; }
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }
  public Keep Keep { get; set; }
  public Vault Vault { get; set; }

}