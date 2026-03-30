namespace SneakerTests;

public class InventoryServiceTests
{
    [Fact]
    public void AddToInventory_ShouldIncreaseCount()
    {
        // Arrange
        List<Sneaker> inventory = new List<Sneaker>();
        InventoryService service = new InventoryService(inventory);
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
    SearchService searchService = new SearchService(inventory);

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