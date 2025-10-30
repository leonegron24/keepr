namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase
{
    private readonly ProfileService _profileService;
    private readonly Auth0Provider _auth0Provider;

    public ProfilesController(ProfileService profileService, Auth0Provider auth0Provider)
    {
        _profileService = profileService;
        _auth0Provider = auth0Provider;
    }

    [HttpGet("{profileId}")]
    public ActionResult<Profile> GetUserProfile(string profileId)
    {
        try
        {
            Profile profile = _profileService.GetUserProfile(profileId);
            return Ok(profile);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{profileId}/keeps")]
    public ActionResult<List<Keep>> GetUserKeeps(string profileId)
    {
        try
        {
            List<Keep> keeps = _profileService.GetUsersKeeps(profileId);
            return Ok(keeps);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{profileId}/vaults")]
    public async Task<ActionResult<List<Vault>>> GetUsersVaults(string profileId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            List<Vault> vaults = _profileService.GetUsersVaults(profileId, userInfo?.Id);
            return Ok(vaults);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
