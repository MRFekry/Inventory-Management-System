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
                Name = "wheel",
                Quantity = 70,
                Price = 15.00m
            },
            new Inventory
            {
                Id = 2,
                Name = "seat",
                Quantity = 50,
                Price = 20.00m
            },
            new Inventory
            {
                Id = 3,
                Name = "pedal",
                Quantity = 200,
                Price = 10.00m
            },
            new Inventory
            {
                Id = 4,
                Name = "lamp",
                Quantity = 30,
                Price = 20.00m
            },
            new Inventory
            {
                Id = 5,
                Name = "display",
                Quantity = 20,
                Price = 100.00m
            },
            new Inventory
            {
                Id = 6,
                Name = "battery",
                Quantity = 5,
                Price = 500.00m
            },
            new Inventory
            {
                Id = 7,
                Name = "Cargo box",
                Quantity = 3,
                Price = 700.00m
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

    public Task EditInventoryAsync(Inventory updatedInventory)
    {
        if (_inventories.Any(i => i.Id != updatedInventory.Id && i.Name.Equals(updatedInventory.Name, StringComparison.OrdinalIgnoreCase)))
            return Task.CompletedTask; // Another inventory with the same name already exists, do not edit

        var inventory = _inventories.FirstOrDefault(i => i.Id == updatedInventory.Id);
        if (inventory != null)
        {
            // Edit the inventory (implementation for editing inventory goes here)
            inventory.Name = updatedInventory.Name;
            inventory.Quantity = updatedInventory.Quantity;
            inventory.Price = updatedInventory.Price;
        }
        return Task.CompletedTask;
    }

    public Task<Inventory?> GetInventoryByIdAsync(int id)
    {
        return Task.FromResult(_inventories.FirstOrDefault(i => i.Id == id));
    }

    public Task DeleteInventoryAsync(int inventoryId)
    {
        if (_inventories.Any(i => i.Id == inventoryId))
        {
            var inventoryToRemove = _inventories.First(i => i.Id == inventoryId);
            _inventories.Remove(inventoryToRemove);
        }

        return Task.CompletedTask;
    }
}
