namespace SneakerInventory;
// Handles all search and sort operations on the inventory
public class SearchService : ISearchService
{
    // Holds a reference to the repository to access sneaker data
    private IRepository<Sneaker, string> _repository;

    // Constructor — Program.cs hands us the repository when creating the service
    public SearchService (IRepository<Sneaker, string> repository)
    {
        _repository = repository; // store the repository so the whole class can use it
    }

    // Returns all sneakers that match the given brand (case insensitive)
    public IEnumerable<Sneaker> SearchByBrand(string brand)
    {
        return _repository.GetAll().Where(s => s.Brand.ToLower() == brand.ToLower());
    }

    // Returns all sneakers below the given price
    public IEnumerable<Sneaker> SearchByPrice(decimal maxPrice)
    {
        return _repository.GetAll().Where(s => s.Price < maxPrice);
    }

    // Returns a single sneaker matching the given ID, or null if not found
    public Sneaker? SearchById(string id)
    {
        return _repository.GetById(id);
    }


    public void Search() //Let user Search through inventory with a particular criteria and display sneakers that meet that criteria
    {
        bool validSearchChoice = false;
        while (!validSearchChoice)
        {   try
            {   Console.WriteLine("Choose search type");
                Console.WriteLine("1. Search by price");
                Console.WriteLine("2. Search by Brand");
                Console.WriteLine("3. Search by ID");                        
                Console.WriteLine("4. Go back");
                int searchType = int.Parse(Console.ReadLine()!);

                switch (searchType)
                {   //Let user Search through inventory with price and display sneakers that meet that criteria
                    case 1:
                        decimal maxPrice = 0;
                        bool validMaxPrice = false;
                        while (!validMaxPrice)
                        {
                            try
                            {
                                Console.WriteLine("Enter maximum price amount to search for sneaker");
                                maxPrice = decimal.Parse(Console.ReadLine()!);
                                validMaxPrice = true;
                            }

                            catch(FormatException)
                                {Console.WriteLine("Thats not a valid number, please try again");}
                        }
                        var result =_repository.GetAll().Where(s => s.Price < maxPrice);
                        foreach (Sneaker sneaker in result)
                            sneaker.DisplayInfo();
                        continue;

                            //Let user Search through inventory with brand and display sneakers that meet that criteria
                    case 2:
                        Console.WriteLine("These are the available brands:");
                        HashSet<string> brands = new(_repository.GetAll().Select(s => s.Brand));//Use HashSet to create a collection of just brand names
                        //display brand names
                        foreach (string brand in brands)
                        Console.WriteLine(brand);
                        Console.WriteLine("Enter sneaker brand");
                        string searchBrand = Console.ReadLine()!;
                        result = SearchByBrand(searchBrand);
                        foreach (Sneaker sneaker in result)
                        sneaker.DisplayInfo();
                        Console.WriteLine($"Total sneakers found: {result.Count()}");
                        continue;

                    //Let user Search through Inventory with ID and display the sneaker that has that ID
                    case 3:
                        Console.WriteLine("Enter sneaker ID");
                        string searchId = Console.ReadLine()!;
                        Sneaker? found = SearchById(searchId);//_inventory.FirstOrDefault(s => s.Id.ToUpper() == searchId.ToUpper());
                        if (found != null)
                            found.DisplayInfo();
                        else
                            Console.WriteLine("Sneaker not found");
                        continue;                               
                    
                    //go back to the main menu
                    case 4:
                        validSearchChoice = true;
                        break;
                
                    default:
                        Console.WriteLine("Invalid choice, please enter 1 or 4");
                        break;
                }
            }
            catch (FormatException)
            {Console.WriteLine("Invalid choice, please enter 1 or 4");}    
        }
    }

    public void Sort() //Let user Sort through inventory by price and display sneakers that meet this criteria
    {
        bool validSortChoice = false;
        while (!validSortChoice)
        {   try
            {   Console.WriteLine("Choose Sort Type");
                Console.WriteLine("1. Sort by price (lowest to highest)");
                Console.WriteLine("2. Sort by price (highest to lowest)");
                Console.WriteLine("3. Go back");
                int searchType = int.Parse(Console.ReadLine()!);
 
                switch (searchType)
                {   //Let user Sort through inventory by price (lowest to highest)
                    case 1:      
                        var result =_repository.GetAll().OrderBy(s => s.Price);
                        foreach (Sneaker sneaker in result)
                        sneaker.DisplayInfo();
                        continue;
 
                    //Let user Sort through inventory by price (highest to lowest)
                    case 2:
                        
                        result = _repository.GetAll().OrderByDescending(s => s.Price);
                        foreach (Sneaker sneaker in result)
                        sneaker.DisplayInfo();
                        continue;
                    
                    //go back to the main menu
                    case 3:
                        validSortChoice = true;
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

}