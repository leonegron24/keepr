
namespace keepr.Services;

public class VaultKeepsService
{
    private readonly VaultKeepsRepository _repo;
    private readonly VaultsService _vaultService;

    public VaultKeepsService(VaultKeepsRepository repo, VaultsService vaultService)
    {
        _repo = repo;
        _vaultService = vaultService;
    }

    internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
    {
        Vault vault = _vaultService.GetVaultById(vaultKeepData.VaultId, vaultKeepData.CreatorId);
        if (vault.CreatorId != vaultKeepData.CreatorId) throw new Exception("Hey! Thats not your vault!");
        VaultKeep vaultKeep = _repo.Create(vaultKeepData);
        return vaultKeep;
    }

    internal string DeleteVaultKeep(int vaultKeepId, string userId)
    {
        VaultKeep vaultKeep = GetVaultKeepById(vaultKeepId);
        if (vaultKeep.CreatorId != userId) throw new Exception($"You can't delete another users vaultKeep! 😠");
        _repo.Delete(vaultKeepId);
        return $"Successfully delete vaultKeep with Id: {vaultKeep.Id}";
    }

    private VaultKeep GetVaultKeepById(int vaultKeepId)
    {
        VaultKeep vaultKeep = _repo.GetVaultKeepById(vaultKeepId);
        if (vaultKeep == null) throw new Exception($"There is not vaultKeep with Id: {vaultKeepId}");
        return vaultKeep;
    }




    internal List<VaultKeepView> GetKeepsInVault(int vaultId, string userId)
    {
        Vault vault = _vaultService.GetVaultById(vaultId, userId);
        List<VaultKeepView> keeps = _repo.GetKeepsInVault(vaultId);
        return keeps;
    }

    internal List<VaultKeepView> GetKeepsInVault(int vaultId)
    {
        Vault vault = _vaultService.GetVaultById(vaultId);
        List<VaultKeepView> keeps = _repo.GetKeepsInVault(vaultId);
        return keeps;
    }
}
