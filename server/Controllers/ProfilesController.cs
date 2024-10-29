using System.Drawing;

namespace keepr.Controllers;

[ApiController, Route("api/[controller]")]
public class ProfilesController : ControllerBase
{
  private readonly ProfilesService _profilesService;
  private readonly Auth0Provider _auth0Provider;
  private readonly KeepsService _keepsService;
  private readonly VaultsService _vaultsService;
  public ProfilesController(ProfilesService profilesService, Auth0Provider auth0Provider, KeepsService keepsService, VaultsService vaultsService)
  {
    _profilesService = profilesService;
    _auth0Provider = auth0Provider;
    _keepsService = keepsService;
    _vaultsService = vaultsService;
  }

  [HttpGet("{profileId}")]
  public ActionResult<Profile> getProfileById(string profileId)
  {
    try
    {
      Profile profile = _profilesService.getProfileById(profileId);
      return Ok(profile);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpGet("{profileId}/keeps")]

  public ActionResult<List<Keep>> getProfileKeeps(string profileId)
  {

    try
    {
      List<Keep> keeps = _keepsService.getProfileKeeps(profileId);
      return Ok(keeps);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }

  }

  [HttpGet("{profileId}/vaults")]
  public async Task<ActionResult<List<Vault>>> getProfileVaults(string profileId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<Vault> vaults = _vaultsService.getProfileVaults(profileId, userInfo?.Id);
      return Ok(vaults);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

}
