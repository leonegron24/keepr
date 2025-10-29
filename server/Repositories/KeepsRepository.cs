using keepr.Interfaces;

namespace keepr.Repositories;

public class KeepsRepository : IRepository<Keep>
{
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
        _db = db;
    }

    public Keep Create(Keep keepData)
    {
        string sql = @"
        INSERT INTO 
        keep(name, description, img, creator_id)
        Values(@Name, @Description, @Img, @CreatorId);

        SELECT
        keep.*,
        COUNT(vaultKeep.id) AS kept,
        accounts.*
        FROM keep
        INNER JOIN accounts ON accounts.id = keep.creator_id
        LEFT JOIN vaultKeep ON vaultKeep.keep_id = keep.id
        WHERE keep.id = LAST_INSERT_ID()
        GROUP BY keep.id;";

        Keep keep = _db.Query(sql, (Keep keep, Profile account) =>
        {
            keep.Creator = account;
            return keep;
        }, keepData).SingleOrDefault();

        return keep;
    }


    public List<Keep> GetAll()
    {
        string sql = @"
        SELECT
        keep.*,
        accounts.*
        FROM keep
        INNER JOIN accounts ON accounts.id = keep.creator_id;";

        List<Keep> keeps = _db.Query(sql, (Keep keep, Profile account) =>
        {
            keep.Creator = account;
            return keep;
        }).ToList();

        return keeps;
    }

    public Keep GetById(int id)
    {
        string sql = @"
        SELECT
        keep.*,
        accounts.*
        FROM keep
        INNER JOIN accounts ON accounts.id = keep.creator_id
        WHERE keep.id = @id;";

        Keep keep = _db.Query(sql, (Keep keep, Profile account) =>
        {
            keep.Creator = account;
            return keep;
        }, new { id }).SingleOrDefault();

        return keep;
    }

    public void Update(Keep updateData)
    {
        string sql = @"
        UPDATE keep
        SET
        name = @Name,
        description = @Description,
        img = @Img
        WHERE id = @Id LIMIT 1;";

        int rowsAffected = _db.Execute(sql, updateData);

        if (rowsAffected != 1) throw new Exception($"{rowsAffected} were UPDATED and that is bad");
    }

    public void Delete(int id)
    {
        string sql = "DELETE FROM keep WHERE id = @id LIMIT 1;";

        int rowsAffected = _db.Execute(sql, new { id });

        if (rowsAffected != 1) throw new Exception($"{rowsAffected} were DELETED and that is bad");
    }
}

