namespace SneakerInventory;
using System.Text.Json;

// Handles saving and loading sneakers to and from a JSON file
public class FileService : IFileService
{
    // Holds a reference to the shared inventory list from Program.cs
    private List<Sneaker> _inventory;

    // Constructor — Program.cs hands us the inventory list when creating the service
    public FileService(List<Sneaker> inventory)
    {
        _inventory = inventory; // store the list so the whole class can use it
    }

    public async Task Save() //Save inventory to a file asynchronously
    {
        string json = JsonSerializer.Serialize(_inventory);
        await File.WriteAllTextAsync("Sneakers.json", json);
        Console.WriteLine("File save complete");
    }
    public async Task Load() //Load inventory from a file asynchronously
    {
        string json = await File.ReadAllTextAsync("Sneakers.json");
        List<Sneaker>? loadedInventory = JsonSerializer.Deserialize<List<Sneaker>>(json);
        if (loadedInventory != null)
        {
            foreach (Sneaker sneaker in loadedInventory)
                sneaker.DisplayInfo();
            Console.WriteLine("File Loading complete");
        }
        else
            Console.WriteLine("No inventory found");
    }
}