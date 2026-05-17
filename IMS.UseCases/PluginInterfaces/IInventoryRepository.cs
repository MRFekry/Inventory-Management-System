using IMS.Entities;

namespace IMS.UseCases.PluginInterfaces;

public interface IInventoryRepository
{
    Task<List<Inventory>> GetInventoriesByNameAsync(string nameFilter = "");
    Task AddInventoryAsync(Inventory inventory);
}