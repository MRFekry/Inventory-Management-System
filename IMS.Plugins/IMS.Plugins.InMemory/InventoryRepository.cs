using IMS.Entities;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory;

public class InventoryRepository : IInventoryRepository
{
    private readonly List<Inventory> _inventories;

    public InventoryRepository()
    {
        _inventories = new List<Inventory>
        {
            new Inventory
            {
                Id = 1,
                Name = "Shirts",
                Quantity = 10,
                Price = 100.00m
            },
            new Inventory
            {
                Id = 2,
                Name = "Pants",
                Quantity = 20,
                Price = 200.00m
            },
            new Inventory
            {
                Id = 3,
                Name = "Jackets",
                Quantity = 30,
                Price = 300.00m
            },
        };
    }

    public Task<List<Inventory>> GetInventoriesByNameAsync(string nameFilter = "")
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
