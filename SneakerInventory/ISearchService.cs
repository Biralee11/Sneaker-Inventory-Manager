namespace SneakerInventory;
public interface ISearchService
{
    IEnumerable<Sneaker> SearchByBrand(string brand);
    IEnumerable<Sneaker> SearchByPrice(decimal maxPrice);
    Sneaker? SearchById(string id);
    void Search();
    void Sort();
}