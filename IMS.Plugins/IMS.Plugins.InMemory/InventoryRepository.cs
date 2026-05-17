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
            ).ToList()
        );
    }

    public Task AddInventoryAsync(Inventory inventory)
    {
        if (_inventories.Any(i => i.Name.Equals(inventory.Name, StringComparison.OrdinalIgnoreCase)))
        {
            return Task.CompletedTask; // Inventory with the same name already exists, do not add
        }

        var maxId = _inventories.Any() ? _inventories.Max(i => i.Id) : 0;
        inventory.Id = maxId + 1; // Assign a new unique ID to the inventory

        // Add the new inventory (implementation for adding inventory goes here)
        _inventories.Add(inventory);
        return Task.CompletedTask;
    }
}
