namespace SneakerInventory;

// Responsible for creating sneaker objects — the only place in the app that uses 'new' for sneakers
public class SneakerFactory : ISneakerFactory
{

    public Sneaker? CreateSneaker(string type, string name, decimal price, string brand, Dictionary<string, string> extraProperties)// extraProperties holds any type-specific data e.g. "style" for casual, "cushionLevel" for running
    {
        if (string.IsNullOrWhiteSpace(name) || price < 0 || string.IsNullOrWhiteSpace(brand))
        {
            throw new InvalidSneakerDataException("Invalid Sneaker Data");
        }
        else
        {
            switch (type.ToLower())
            {
                case "casual":
                    string style = extraProperties["style"]; // get style from the dictionary
                    return new CasualShoe(name, price, brand, style);
    
                case "running":
                    int cushionLevel = int.Parse(extraProperties["cushionLevel"]); // get cushionLevel from the dictionary and convert to int
                    return new RunningShoe(name, price, brand, cushionLevel);
    
                default:
                    throw new UnknownSneakerTypeException("Unknown sneaker type"); // if type doesn't match, throw an error
            }
        }

    }  
}