namespace SneakerInventory;
public static class StringExtensions
{
    public static string ToSneakerId(this string value)
    {
        return value.ToUpper();
    }
}