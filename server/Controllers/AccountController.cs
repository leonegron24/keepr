namespace keepr.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly Auth0Provider _auth0Provider;

  public AccountController(AccountService accountService, Auth0Provider auth0Provider)
  {
    _accountService = accountService;
    _auth0Provider = auth0Provider;
  }

  [HttpGet]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateAccount(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("vaults")]
  public async Task<ActionResult<List<Vault>>> GetMyVaults()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<Vault> vaults = _accountService.GetMyVaults(userInfo.Id);
      return Ok(vaults);

    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut]
  public async Task<ActionResult<Account>> EditAccount([FromBody] Account editData)
  {
    Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
    Account updatedAccount = _accountService.EditAccount(editData, userInfo.Id);
    return Ok(updatedAccount);
  }
}
