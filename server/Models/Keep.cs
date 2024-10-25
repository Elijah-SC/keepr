namespace keepr.Models;

public class KeepCreationDTO
{
  public string Name { get; set; }
  public string Description { get; set; }
  public string Img { get; set; }
}



public class Keep : RepoItem<int>
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public string Img { get; set; }
  public int views { get; set; }
  public int saves { get; set; }
  public string creatorId { get; set; }
  public Profile creator { get; set; }
}
