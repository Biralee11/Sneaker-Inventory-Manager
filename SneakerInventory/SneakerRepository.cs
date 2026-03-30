namespace SneakerInventory;
// Handles all data access for sneakers — the only class that touches the inventory list directly
public class SneakerRepository : IRepository<Sneaker, string>
{
    // The shared inventory list injected from Program.cs
    private List<Sneaker> _inventory;

    // Constructor — receives the inventory list from Program.cs
    public SneakerRepository(List<Sneaker> inventory)
    {
        _inventory = inventory;
    }

    
    public void Add(Sneaker sneaker)
    {
        _inventory.Add(sneaker);
    }

    // Returns all sneakers in the inventory
    public IEnumerable<Sneaker> GetAll()
    {
        return _inventory;
    }

   
    public Sneaker GetById(string id)
    {
        var sneaker = _inventory.FirstOrDefault(s => s.Id.ToSneakerId() == id.ToSneakerId());
        if (sneaker is null)
        {
            throw new SneakerNotFoundException("Sneaker not found");
        }
        else
        {return sneaker;}
    }

    
    public void Delete(Sneaker sneaker)
    {
        _inventory.Remove(sneaker);
    }
}