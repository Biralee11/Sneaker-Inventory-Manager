namespace SneakerInventory;
public interface IInventoryService
{
    event Action<Sneaker>? SneakerAdded;
    void AddSneaker();
    void AddToInventory(Sneaker sneaker);
    void DisplayAll();
}