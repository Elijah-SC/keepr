using System.ComponentModel.DataAnnotations;

namespace keepr.Models;

public class ProfileUpdateDTO
{
  [MinLength(1), MaxLength(100)] public string Name { get; set; }
  [MinLength(1), MaxLength(1000)] public string Picture { get; set; }
  [MaxLength(1000)] public string CoverImg { get; set; }
}


public class Profile : RepoItem<string>
{
  public string Id { get; set; }
  public string Name { get; set; }
  public string Picture { get; set; }
  public string CoverImg { get; set; }

}