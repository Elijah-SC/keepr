namespace keepr.Controllers;

[ApiController, Route("api/[controller]")]
public class VaultKeepsController : ControllerBase
{
  public VaultKeepsController(VaultKeepsService vaultKeepsService, Auth0Provider auth0Provider)
  {
    _vaultKeepsService = vaultKeepsService;
    _auth0Provider = auth0Provider;
  }
  private readonly VaultKeepsService _vaultKeepsService;
  private readonly Auth0Provider _auth0Provider;

  [Authorize, HttpPost]
  public async Task<ActionResult<VaultKeep>> createVaultKeep([FromBody] VaultKeepCreationDTO creationData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      VaultKeep vaultKeep = _vaultKeepsService.createVaultKeep(creationData, userInfo.Id);
      return vaultKeep;
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [Authorize, HttpDelete("{vaultKeepId}")]
  public async Task<ActionResult<string>> deleteVaultKeep(int vaultKeepId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return _vaultKeepsService.deleteVaultKeep(vaultKeepId, userInfo?.Id);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}