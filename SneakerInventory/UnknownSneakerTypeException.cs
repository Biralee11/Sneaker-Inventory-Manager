namespace SneakerInventory;
public class UnknownSneakerTypeException : Exception
{
    public UnknownSneakerTypeException(string message) 
        : base(message)
    {
    }
}