namespace SneakerInventory;
public class CasualShoe : Sneaker
{
    private string _style = "";
    public string Style
    {
        get {return _style;}
        set
        {
            if (value != "")
            {_style = value;}
            else
            {Console.WriteLine("Style cannot be empty");}
        }
    }
    public CasualShoe(string name, decimal price, string brand, string style)
        : base(name, price, brand)
    {
        Style = style;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"{Id}, {Name}, {Price}, {Brand}, {Style}");
    }
}