namespace SneakerInventory;
public interface IRepository<T, TId>
{

    void Add(T item);


    IEnumerable<T> GetAll();


    T? GetById(TId id);

    void Delete(T item);
}