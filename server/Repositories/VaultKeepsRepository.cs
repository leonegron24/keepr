using keepr.Interfaces;

namespace keepr.Repositories;

public class VaultKeepsRepository : IRepository<VaultKeep>
{
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
        _db = db;
    }

    public VaultKeep Create(VaultKeep rawData)
    {
        string sql = @"
        INSERT INTO
        vaultKeep(keep_id, vault_id, creator_id)
        Values(@KeepId, @VaultId, @CreatorId);

        SELECT
        vaultKeep.*,
        accounts.*
        FROM vaultKeep
        INNER JOIN accounts ON accounts.id = creator_id
        WHERE vaultKeep.id = LAST_INSERT_ID()
        GROUP BY vaultKeep.id;";

        VaultKeep vaultKeep = _db.Query(sql, (VaultKeep vaultKeep, Profile account) =>
        {
            vaultKeep.CreatorId = account.Id;
            return vaultKeep;
        }, rawData).SingleOrDefault();

        return vaultKeep;
    }

    public void Delete(int id)
    {
        string sql = @"DELETE FROM vaultKeep WHERE id = @id LIMIT 1;";

        int rowsAffected = _db.Execute(sql, new { id });

        if (rowsAffected != 1) throw new Exception($"{rowsAffected} were DELETED and that is bad");
    }

    public List<VaultKeep> GetAll()
    {
        throw new NotImplementedException();
    }

    public VaultKeep GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(VaultKeep updateData)
    {
        throw new NotImplementedException();
    }

    internal List<VaultKeepView> GetKeepsInVault(int vaultId)
    {
        string sql = @"
        SELECT keep.*, vaultKeep.id AS vaultKeepId, accounts.*
        FROM vaultKeep
        INNER JOIN keep ON keep.id = vaultKeep.keep_id
        INNER JOIN accounts ON accounts.id = keep.creator_id
        WHERE vaultKeep.vault_id = @vaultId;";

        List<VaultKeepView> keeps = _db.Query(sql, (VaultKeepView vaultKeepView, Profile account) =>
        {
            vaultKeepView.Creator = account;
            return vaultKeepView;
        }, new { vaultId }).ToList();

        return keeps;
    }

    internal VaultKeep GetVaultKeepById(int vaultKeepId)
    {
        string sql = @"
        SELECT vaultKeep.*, accounts.*
        FROM vaultKeep
        INNER JOIN accounts ON accounts.id = vaultKeep.creator_id
        WHERE vaultKeep.id = @vaultKeepId;";

        VaultKeep vaultKeep = _db.Query(sql, (VaultKeep vaultKeep, Profile account) =>
        {
            vaultKeep.CreatorId = account.Id;
            return vaultKeep;
        }, new { vaultKeepId }).SingleOrDefault();

        return vaultKeep;
    }
}

