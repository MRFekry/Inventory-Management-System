using IMS.Entities;

namespace IMS.UseCases.UseCases;

public class ViewInventoriesUseCase
{
    private readonly IInventoryRepository _inventoryRepository;

    public ViewInventoriesUseCase(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }

    public async Task<IEnumerable<Inventory>> ExecuteAsync(string nameFilter = "")
    {
        return await _inventoryRepository.GetInventoriesByNameAsync(nameFilter);
    }
}
