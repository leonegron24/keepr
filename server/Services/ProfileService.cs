
namespace keepr.Services;

public class ProfileService
{
    private readonly ProfileRepository _repo;

    public ProfileService(ProfileRepository repo)
    {
        _repo = repo;
    }

    internal Profile GetUserProfile(string profileId)
    {
        Profile profile = _repo.GetUserProfile(profileId);
        if (profile == null) throw new Exception($"There is not such profile with Id of: {profileId}");
        return profile;
    }

    internal List<Keep> GetUsersKeeps(string profileId)
    {
        Profile profile = GetUserProfile(profileId);
        List<Keep> keeps = _repo.GetUsersKeeps(profileId);
        return keeps;
    }

    internal List<Vault> GetUsersVaults(string profileId, string userId)
    {
        Profile profile = GetUserProfile(profileId);
        List<Vault> vaults = _repo.GetUsersVaults(profileId);
        if (profile.Id == userId)
        {
            return vaults;
        }
        return vaults.FindAll(vaults => vaults.IsPrivate == false);
    }

    internal List<Vault> GetUsersVaults(string profileId)
    {
        Profile profile = GetUserProfile(profileId);
        List<Vault> vaults = _repo.GetUsersVaults(profileId);
        return vaults.FindAll(vaults => vaults.IsPrivate == false);
    }
}
