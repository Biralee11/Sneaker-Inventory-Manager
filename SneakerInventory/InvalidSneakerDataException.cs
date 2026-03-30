namespace SneakerInventory;
public class InvalidSneakerDataException : Exception
{
    public InvalidSneakerDataException(string message) 
        : base(message)
    {
    }
}