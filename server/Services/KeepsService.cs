namespace keepr.Services;

public class KeepsService
{
    private readonly KeepsRepository _repo;

    public KeepsService(KeepsRepository repo)
    {
        _repo = repo;
    }

    internal Keep CreateKeep(Keep keepData)
    {
        Keep keep = _repo.Create(keepData);
        return keep;
    }

    internal List<Keep> GetAllKeeps()
    {
        List<Keep> keeps = _repo.GetAll();
        return keeps;
    }

    internal Keep GetKeepById(int keepId)
    {
        Keep keep = _repo.GetById(keepId);
        if (keep == null) throw new Exception($"Invalid keep id: {keepId}");
        return keep;
    }

    internal Keep EditKeep(int keepId, Keep updateData, string userId)
    {
        Keep keep = GetKeepById(keepId);
        if (keep.CreatorId != userId) throw new Exception("You cannot alter another user's keep");

        keep.Name = updateData.Name ?? keep.Name;
        keep.Description = updateData.Description ?? keep.Description;
        keep.Img = updateData.Img ?? keep.Img;

        _repo.Update(keep);

        return keep;
    }

    internal string DeleteKeep(int keepId, string userId)
    {
        Keep keep = GetKeepById(keepId);
        if (keep.CreatorId != userId) throw new Exception("You cannot delete another user's keep");

        _repo.Delete(keepId);

        return $"Deleted {keep.Name}";
    }
}
