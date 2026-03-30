using SneakerInventory;

//create a list to store all Sneaker
List<Sneaker> Inventory = new List<Sneaker>
{
    new CasualShoe("RX240", 220, "Nike", "Formal Casual"),
    new CasualShoe("JX40", 120, "Uggs", "Streetwear"),
    new CasualShoe("RT100", 250, "Timberland", "Streetwear"),
    new RunningShoe("RX240", 220, "Nike", 5)
};


IRepository<Sneaker, string> repository = new SneakerRepository(Inventory); // Create the repository — the only place that directly accesses the inventory list


ISneakerFactory factory = new SneakerFactory(); // Create the factory — responsible for creating sneaker objects

PipelineService pipelineService = new PipelineService();

pipelineService.Use(sneaker => {
    if (string.IsNullOrWhiteSpace(sneaker.Name))
        throw new InvalidSneakerDataException("Sneaker name cannot be empty");
});

pipelineService.Use(sneaker => Console.WriteLine($"Processing sneaker: {sneaker.Name}"));

pipelineService.Use(sneaker => repository.Add(sneaker));

// Create the services — each receives what it needs via constructor injection
IInventoryService inventoryService = new InventoryService(repository, factory, pipelineService);
inventoryService.SneakerAdded += sneaker => Console.WriteLine($"Event fired: {sneaker.Name} was added to inventory");


IFileService fileService = new FileService(Inventory);                          
ISearchService searchService = new SearchService(repository);
                   

bool running = true;
while (running)
{   try
    {//Display menu options and allow user choice option
        Console.WriteLine("Sneaker Inventory Manager");
        Console.WriteLine("1. Add a sneaker");
        Console.WriteLine("2. Dislay all sneakers");
        Console.WriteLine("3. Search Sneaker(s)");
        Console.WriteLine("4. Sort by Price");
        Console.WriteLine("5. Save inventory to a file");
        Console.WriteLine("6. Load inventory from a file");
        Console.WriteLine("7. Exit");
        Console.WriteLine("Enter Menu Option");
        int menu = int.Parse(Console.ReadLine()!);
        switch (menu)
        {   //let the user add new Sneaker objects to the inventory
            case 1:
                inventoryService.AddSneaker();
                break;

            //Display all sneakers
            case 2:
                inventoryService.DisplayAll();
                break;

            //Let user Search through inventory with a particular criteria and display sneakers that meet that criteria
            case 3:
                searchService.Search();
                break;

            //Let user Sort through inventory by price and display sneakers that meet this criteria
            case 4:
                searchService.Sort();
                break;

            //Save inventory to a file asynchronously
            case 5:
                await fileService.Save();
                break;

            //Load inventory from a file
            case 6:
                await fileService.Load();
                break;
    
            //Exit Inventory
            case 7:
                running = false;
                break;

            default:
                Console.WriteLine("Invalid choice, please enter either number between 1-7");
                break;
        }
    }
    catch (FormatException)
        {Console.WriteLine("Invalid choice, please enter either number between 1-7");}
}