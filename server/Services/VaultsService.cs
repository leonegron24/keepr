

namespace keepr.Services;

public class VaultsService
{
    private readonly VaultsRepository _repo;

    public VaultsService(VaultsRepository repo)
    {
        _repo = repo;
    }

    internal Vault CreateVault(Vault vaultData)
    {
        Vault vault = _repo.Create(vaultData);
        return vault;
    }

    internal Vault GetVaultById(int vaultId, int userInfo)
    {
        Vault vault = _repo.GetById(vaultId);
        if (vault == null) throw new Exception($"There is on vault wit id: {vaultId}");
        return vault;
    }

}
