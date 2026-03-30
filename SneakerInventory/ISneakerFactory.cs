namespace SneakerInventory;
public interface ISneakerFactory
{
    Sneaker? CreateSneaker(string type, string name, decimal price, string brand, Dictionary<string, string> extraProperties);
}