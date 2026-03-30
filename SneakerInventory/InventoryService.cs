namespace SneakerInventory;

// InventoryService handles all inventory operations — adding and displaying sneakers
public class InventoryService : IInventoryService
{
    // Fields to hold the dependencies this service needs
    private IRepository<Sneaker, string> _repository; // handles data access
    private ISneakerFactory _factory; // handles sneaker creation
    private PipelineService _pipeline;

    // Constructor — Program.cs hands us these two dependencies when creating the service
    public InventoryService(IRepository<Sneaker, string> repository, ISneakerFactory factory, PipelineService pipeline)
    {
        _repository = repository; 
        _factory = factory;
        _pipeline = pipeline;
    }

    public event Action<Sneaker>? SneakerAdded;

    // Adds a sneaker to the repository — does not care how the sneaker was created
    public void AddToInventory(Sneaker sneaker)
    {
        _pipeline.Execute(sneaker);
        SneakerAdded?.Invoke(sneaker);
        
    }    

    public void AddSneaker() //let the user add new Sneaker objects to the inventory
    {
        //let the user choose what type of sneaker it is
        bool validChoice = false;
        while (!validChoice)
        {   try
            {   Console.WriteLine("Choose Sneaker Type");
                Console.WriteLine("1. Casual Shoe");
                Console.WriteLine("2. Running Shoe");
                Console.WriteLine("3. Go back");//go back to the main menu
                int sneakerType = int.Parse(Console.ReadLine()!);

                switch (sneakerType)
                {   //1 For Casual Shoe
                    case 1:
                        Console.WriteLine("Add sneaker name");
                        string name = Console.ReadLine()!;
                        decimal price = 0;
                        bool validPrice = false;
                        while(!validPrice)
                        {
                            try
                            {
                                Console.WriteLine("Add sneaker price");
                                price = decimal.Parse(Console.ReadLine()!);
                                validPrice = true;
                            }
                            catch (FormatException)
                            {Console.WriteLine("Thats not a valid number, please try again");}
                        }
        
                        Console.WriteLine("Add sneaker brand");
                        string brand = Console.ReadLine()!;
                        Console.WriteLine("Add sneaker style");
                        string style = Console.ReadLine()!;                                
                        AddToInventory(_factory.CreateSneaker("casual", name, price, brand, new Dictionary<string, string> { {"style", style} })!);
                        Console.WriteLine("New sneaker added");
                        continue;

                    //2 for Running Shoe
                    case 2:
                        Console.WriteLine("Add sneaker name");
                        name = Console.ReadLine()!;
                        price = 0;
                        validPrice = false;
                        while(!validPrice)
                        {
                            try
                            {
                                Console.WriteLine("Add sneaker price");
                                price = decimal.Parse(Console.ReadLine()!);
                                validPrice = true;
                            }
                            catch (FormatException)
                            {Console.WriteLine("Thats not a valid number, please try again");}
                        }
    
                        Console.WriteLine("Add sneaker brand");
                        brand = Console.ReadLine()!;

                        int cushionLevel = 0;
                        bool validcushionLevel = false;
                        while(!validcushionLevel)
                        {
                            try
                            {
                                Console.WriteLine("Add cushion Level");
                                cushionLevel = int.Parse(Console.ReadLine()!);
                                validcushionLevel = true;
                            }
                            catch (FormatException)
                            {Console.WriteLine("Thats not a valid number, please try again");}
                        }
        
                        AddToInventory(_factory.CreateSneaker("running", name, price, brand, new Dictionary<string, string> { {"cushionLevel", cushionLevel.ToString()} })!);
                        Console.WriteLine("New sneaker added");
                        continue;

                    //go back to the main menu
                    case 3:
                        validChoice = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please enter 1 or 3");
                        break;
                }
            }
            catch (FormatException)
            {Console.WriteLine("Invalid choice, please enter 1 or 3");}
        }
    }


    public void DisplayAll() //Display all sneakers
    {
        foreach (Sneaker sneaker in _repository.GetAll())
            sneaker.DisplayInfo();
                
    }
}