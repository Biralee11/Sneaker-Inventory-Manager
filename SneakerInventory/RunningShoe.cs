namespace SneakerInventory;
public class RunningShoe : Sneaker
{
    private int _cushionLevel;
    public int CushionLevel
    {
        get {return _cushionLevel;}
        set
        {
            if (value >= 0)
            {_cushionLevel = value;}
            else
            {Console.WriteLine("CushionLevel cannot be negative");}
        }
    }
    public RunningShoe(string name, decimal price, string brand, int cushionLevel)
        : base(name, price, brand)
    {
        CushionLevel = cushionLevel;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"{Id}, {Name}, {Price}, {Brand}, {CushionLevel}");
    }
}