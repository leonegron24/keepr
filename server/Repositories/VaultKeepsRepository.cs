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
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
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
}

