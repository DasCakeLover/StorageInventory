using StorageInventory.Domain;

namespace StorageInventory.Infrastructure;

public interface IInventoryRepository
{
    Task AddAsync(Box box);
    Task<IEnumerable<Box>> GetAllAsync();
}