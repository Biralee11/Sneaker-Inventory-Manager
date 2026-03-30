namespace SneakerInventory;
using System.Text.Json.Serialization;

[JsonPolymorphic]
[JsonDerivedType(typeof(CasualShoe), "CasualShoe")]
[JsonDerivedType(typeof(RunningShoe), "RunningShoe")]

public abstract class Sneaker : IDisplayable
{
    private static int _counter = 0;
    private string _id = "";
    private string _name = "";
    private decimal _price;
    private string _brand = "";

    public string Id
    {
        get {return _id;}
    }
    public string Name
    {
        get {return _name;}
        set
        {
            if (value != "")
            {_name = value;}
            else
            {Console.WriteLine("Name cannot be empty");}
        }
    }
    public decimal Price
    {
        get {return _price;}
        set
        {
            if (value > 0)
            {_price = value;}
            else
            {Console.WriteLine("Price cannot be negative");}
        }
    }
    public string Brand
    {
        get {return _brand;}
        set
        {
            if (value != "")
            {_brand = value;}
            else
            {Console.WriteLine("Brand cannot be empty");}
        }
    }

    public Sneaker (string name, decimal price, string brand)
    {
        Name = name;
        Price = price;
        Brand = brand;

        _counter++;
        _id = $"SNK{_counter:D3}";
    }

    public abstract void DisplayInfo();
}