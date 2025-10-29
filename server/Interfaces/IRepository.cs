namespace keepr.Interfaces;

// Interface is a contract that a class subscribes to. WHen you implement an interface, you must support the methods from the interface (names, return types, parameter types) but the class handles the actual code inside the methods
public interface IRepository<T>
{
    public T Create(T rawData);
    public T GetById(int id);
    public List<T> GetAll();
    public void Update(T updateData);
    public void Delete(int id);

}