namespace keepr.Models;

public class VaultKeep : RepoItem<int>
{
    public int KeepId { get; set; }
    public int VaultId { get; set; }
    public string CreatorId { get; set; }
}