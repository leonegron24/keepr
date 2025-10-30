


namespace keepr.Repositories;

public class ProfileRepository
{
    private readonly IDbConnection _db;

    public ProfileRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Profile GetUserProfile(string profileId)
    {
        string sql = @"
        SELECT accounts.*
        FROM accounts
        WHERE accounts.id = @profileId;";

        Profile profile = _db.Query<Profile>(sql, new { profileId }).SingleOrDefault();

        return profile;
    }

    internal List<Keep> GetUsersKeeps(string profileId)
    {
        string sql = @"
        SELECT keep.*, accounts.*
        FROM keep
        INNER JOIN accounts ON accounts.id = keep.creator_id
        WHERE keep.creator_id = @profileId;";

        List<Keep> keeps = _db.Query(sql, (Keep keep, Profile account) =>
        {
            keep.Creator = account;
            return keep;
        }, new { profileId }).ToList();

        return keeps;
    }

    internal List<Vault> GetUsersVaults(string profileId)
    {
        string sql = @"
        SELECT vault.*, accounts.*
        FROM vault
        INNER JOIN accounts ON accounts.id = vault.creator_id
        WHERE vault.creator_id = @profileId;";

        List<Vault> vaults = _db.Query(sql, (Vault vault, Profile account) =>
        {
            vault.Creator = account;
            return vault;
        }, new { profileId }).ToList();

        return vaults;
    }
}

