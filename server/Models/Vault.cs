namespace keepr.Models;

public class VaultCreationDTO
{
  public string name { get; set; }
  public string Description { get; set; }
  public string Img { get; set; }
  public bool IsPrivate { get; set; }
}

public class Vault : RepoItem<int>
{
  public int Id { get; set; }
  public string name { get; set; }
  public string Description { get; set; }
  public string Img { get; set; }
  public bool IsPrivate { get; set; }
  public string creatorId { get; set; }
  public Profile creator { get; set; }
}