namespace SneakerInventory;

public interface IFileService
{
    Task Save();
    Task Load();
}