using Microsoft.AspNetCore.Http;

namespace keepr.Controllers;

[ApiController, Route("api/[controller]")]
public class KeepsController : ControllerBase
{
  private readonly KeepsService _keepsService;
  private readonly Auth0Provider _auth0Provider;

  public KeepsController(KeepsService keepsService, Auth0Provider auth0Provider)
  {
    _keepsService = keepsService;
    _auth0Provider = auth0Provider;
  }

  [Authorize, HttpPost]
  public async Task<ActionResult<Keep>> createKeep([FromBody] KeepCreationDTO keepData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Keep keep = _keepsService.createKeep(keepData, userInfo.Id);
      return Ok(keep);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet]
  public ActionResult<List<Keep>> getAllKeeps()
  {
    try
    {
      List<Keep> keeps = _keepsService.getAllKeeps();
      return Ok(keeps);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }

  }
  [HttpGet("{keepId}")]
  public ActionResult<Keep> getKeepById(int keepId)
  {
    try
    {
      Keep keep = _keepsService.getKeepById(keepId);
      return keep;
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [Authorize, HttpPut("{keepId}")]
  public async Task<ActionResult<Keep>> updateKeep([FromBody] KeepCreationDTO updateData, int keepId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Keep keep = _keepsService.updateKeep(updateData, keepId, userInfo.Id);
      return Ok(keep);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [Authorize, HttpDelete("{keepId}")]

  public async Task<ActionResult<string>> deleteKeep(int keepId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      string Message = _keepsService.deleteKeep(keepId, userInfo.Id);
      return Message;
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}
