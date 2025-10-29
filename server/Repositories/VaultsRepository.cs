using keepr.Interfaces;

public class VaultsRepository : IRepository<Vault>
{
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
        _db = db;
    }

    public Vault Create(Vault rawData)
    {
        string sql = @"
        INSERT INTO
        vault(name, description, img, is_private, creator_id)
        Values(@Name, @Description, @Img, @IsPrivate, @CreatorId);

        SELECT
        vault.*,
        accounts.*
        FROM vault
        INNER JOIN accounts ON accounts.id = vault.creator_id
        WHERE vault.id = LAST_INSERT_ID()
        GROUP BY vault.id;";

        Vault vault = _db.Query(sql, (Vault vault, Profile account) =>
        {
            vault.Creator = account;
            return vault;
        }, rawData).SingleOrDefault();

        return vault;
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<Vault> GetAll()
    {
        throw new NotImplementedException();
    }

    public Vault GetById(int id)
    {
        string sql = @"
        SELECT
        vault.*,
        accounts.*
        FROM vault
        INNER JOIN accounts ON accounts.id = vault.creator_id
        WHERE vault.id = @id;";

        Vault vault = _db.Query(sql, (Vault vault, Profile account) =>
        {
            vault.Creator = account;
            return vault;
        }, new { id }).SingleOrDefault();

        return vault;
    }

    public void Update(Vault updateData)
    {
        throw new NotImplementedException();
    }
}

