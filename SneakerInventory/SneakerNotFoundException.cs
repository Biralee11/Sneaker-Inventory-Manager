namespace SneakerInventory;
public class SneakerNotFoundException : Exception
{
    public SneakerNotFoundException(string message) 
        : base(message)
    {
    }
}