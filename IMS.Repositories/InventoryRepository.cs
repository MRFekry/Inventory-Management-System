using IMS.Entities;

namespace IMS.Repositories;

public class InventoryRepository : IInventoryRepository
{
    public Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string nameFilter = "")
    {
        throw new NotImplementedException();
    }
}
