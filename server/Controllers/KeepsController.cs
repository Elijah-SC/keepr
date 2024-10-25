namespace keepr.Controllers;

public class KeepsController
{
  private readonly KeepsService _keepsService;

  public KeepsController(KeepsService keepsService)
  {
    _keepsService = keepsService;
  }
}
