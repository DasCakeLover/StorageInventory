using StorageInventory.Domain;
using StorageInventory.Infrastructure;

namespace StorageInventory.Application;

public class InventoryService
{
    private readonly IInventoryRepository _repository;

    public InventoryService(IInventoryRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateBoxAsync(string name, string aisle, string shelf)
    {
        var box = new Box(name, new(aisle, shelf));
        await _repository.AddAsync(box);
    }

    public async Task<IEnumerable<Box>> GetAllAsync()
        => await _repository.GetAllAsync();
}