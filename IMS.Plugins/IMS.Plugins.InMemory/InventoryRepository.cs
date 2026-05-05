using IMS.Entities;

namespace IMS.Plugins.InMemory;

public class InventoryRepository : IInventoryRepository
{
    private readonly IEnumerable<Inventory> _inventories;

    public InventoryRepository()
    {
        _inventories = new List<Inventory>
        {
            new Inventory
            {
                Id = 1,
                Name = "Inventory 1",
                Quantity = 10,
                Price = 100.00m
            },
            new Inventory
            {
                Id = 2,
                Name = "Inventory 2",
                Quantity = 20,
                Price = 200.00m
            },
            new Inventory
            {
                Id = 3,
                Name = "Inventory 3",
                Quantity = 30,
                Price = 300.00m
            },
        };
    }

    public Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string nameFilter = "")
    {
        if (string.IsNullOrWhiteSpace(nameFilter))
            return Task.FromResult(_inventories);

        return Task.FromResult(
            _inventories.Where(
                i => i.Name.Contains(nameFilter, StringComparison.OrdinalIgnoreCase)
            )
        );
    }
}
