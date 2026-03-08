using StorageInventory.Application;
using StorageInventory.Infrastructure;

IInventoryRepository repository = new JsonInventoryRepository();
var service = new InventoryService(repository);

await service.CreateBoxAsync("Box1", "A1", "S1");

var boxes = await service.GetAllAsync();

foreach (var box in boxes)
{
    Console.WriteLine($"Box: {box.Name}, Location: {box.Location.Aisle}-{box.Location.Shelf}");
}