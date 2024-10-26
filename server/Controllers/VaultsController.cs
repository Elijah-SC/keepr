namespace keepr.Controllers;

[ApiController, Route("api/[controller]")]
public class VaultsController : ControllerBase
{
  private readonly VaultsService _vaultsService;
  private readonly Auth0Provider _auth0Provider;

  public VaultsController(VaultsService vaultsService, Auth0Provider auth0Provider)
  {
    _vaultsService = vaultsService;
    _auth0Provider = auth0Provider;
  }

  [Authorize, HttpPost]
  public async Task<ActionResult<Vault>> createVault([FromBody] VaultCreationDTO vaultData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Vault vault = _vaultsService.createVault(vaultData, userInfo.Id);
      return vault;
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{vaultId}")]

  public async Task<ActionResult<Vault>> getVaultById(int vaultId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Vault vault = _vaultsService.getVaultById(vaultId, userInfo?.Id);
      return vault;
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
  [Authorize, HttpPut("{vaultId}")]
  public async Task<ActionResult<Vault>> updateVault([FromBody] VaultCreationDTO updateData, int vaultId)
  {
    Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
    Vault vault = _vaultsService.updateVault(updateData, vaultId, userInfo.Id);
    return vault;
  }
}
