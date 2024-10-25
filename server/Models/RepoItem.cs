namespace keepr.Models;

public class RepoItem<T>
{
  T Id { get; set; }
  DateTime createdAt { get; set; }
  DateTime updatedAt { get; set; }
}