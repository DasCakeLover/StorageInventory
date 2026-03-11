using StorageInventory.Domain;
using StorageInventory.Infrastructure;

namespace StorageInventory.Application;

public class InventoryService
{
    // Dependency on the repository
    private readonly IInventoryRepository _repository;

    // Constructor with dependency injection
    public InventoryService(IInventoryRepository repository)
    {
        _repository = repository;
    }

    // Method for creating a new box
    public async Task CreateBoxAsync(string name, string aisle, string shelf)
    {
        var box = new Box(name, new(aisle, shelf));
        await _repository.AddAsync(box);
    }

    // Method for retrieving all boxes
    public async Task<IEnumerable<Box>> GetAllAsync()
        => await _repository.GetAllAsync();

    // Method for adding items to a box
    public async Task AddItemToBoxAsync(Guid boxId, string itemName, int quantity)
    {
        var boxes = await _repository.GetAllAsync();
        var box = boxes.FirstOrDefault(b => b.Id == boxId);
        if (box == null)
            throw new InvalidOperationException($"Box with ID '{boxId}' not found.");
        box.AddItem(itemName, quantity);
        await _repository.AddAsync(box);
    }
}