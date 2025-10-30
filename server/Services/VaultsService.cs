


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

    internal string DeleteVault(int vaultId, string userId)
    {
        Vault vault = GetVaultById(vaultId, userId);
        if (vault.CreatorId != userId) throw new Exception("You can't delete another user's vault!");
        _repo.Delete(vaultId);
        return $"Deleted {vault.Name}";
    }

    internal Vault EditVault(Vault updateData, int vaultId, string userId)
    {
        Vault vault = GetVaultById(vaultId, userId);
        if (vault.CreatorId != userId) throw new Exception("You can not edit another user's vault!");
        vault.Name = updateData.Name ?? vault.Name;
        vault.Description = updateData.Description ?? vault.Description;
        vault.Img = updateData.Img ?? vault.Img;
        vault.IsPrivate = updateData.IsPrivate ?? vault.IsPrivate;

        _repo.Update(vault);
        return vault;
    }



    internal Vault GetVaultById(int vaultId, string userId)
    {
        Vault vault = _repo.GetById(vaultId);
        if (vault == null) throw new Exception($"There is no vault with id: {vaultId}");
        if (vault.IsPrivate == true && vault.CreatorId != userId) throw new Exception($"There is no vault with id: {vaultId} 😉");
        return vault;
    }

    internal Vault GetVaultById(int vaultId)
    {
        Vault vault = _repo.GetById(vaultId);
        if (vault == null) throw new Exception($"There is no vault with id: {vaultId}");
        if (vault.IsPrivate == true) throw new Exception($"There is no vault with id: {vaultId} 😉");
        return vault;
    }

}
