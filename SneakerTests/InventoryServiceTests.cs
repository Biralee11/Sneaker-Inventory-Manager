namespace SneakerTests;

public class InventoryServiceTests
{
    [Fact]
    public void AddToInventory_ShouldIncreaseCount()
    {
        // Arrange
        List<Sneaker> inventory = new List<Sneaker>();
        IRepository<Sneaker, string> repository = new SneakerRepository(inventory);
        ISneakerFactory factory = new SneakerFactory();
        PipelineService pipeline = new PipelineService();
        pipeline.Use(sneaker => repository.Add(sneaker));
        InventoryService service = new InventoryService(repository, factory, pipeline);
        CasualShoe sneaker = new CasualShoe("RX240", 220, "Nike", "Casual");

        // Act
        service.AddToInventory(sneaker);

        // Assert
        Assert.Single(inventory);
    }

    [Fact]
    public void Search_ByBrand_ShouldReturnCorrectSneakers()
    {
        // Arrange
        List<Sneaker> inventory = new List<Sneaker>
        {
            new CasualShoe("RX240", 220, "Nike", "Casual"),
            new CasualShoe("JX40", 120, "Uggs", "Streetwear"),
            new RunningShoe("RT100", 250, "Nike", 5)
        };
        IRepository<Sneaker, string> repository = new SneakerRepository(inventory);
        SearchService searchService = new SearchService(repository);

        // Act
        var result = searchService.SearchByBrand("nike");

        // Assert
        Assert.Equal(2, result.Count());
    }

   [Fact]
    public void Assign_Sneaker_Name_ShouldReturnCorrectSneakerName()
    {
        // Arrange
        Sneaker sneaker = new CasualShoe("RX240", 220, "Nike", "Casual");

        // Act
        string name = sneaker.Name;

        // Assert
        Assert.Equal("RX240", name);
    }
}