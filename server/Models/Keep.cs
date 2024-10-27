using System.ComponentModel.DataAnnotations;

namespace keepr.Models;

public class KeepCreationDTO : RepoItem<int>
{
  [MinLength(1), MaxLength(100)] public string Name { get; set; }
  [MinLength(5), MaxLength(1000)] public string Description { get; set; }
  [MaxLength(1000)] public string Img { get; set; }
}



public class Keep : RepoItem<int>
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public string Img { get; set; }
  public int Views { get; set; }
  public int Kept { get; set; }
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }
}


public class KeepDTO : Keep
{
  public int VaultKeepId { get; set; }
}