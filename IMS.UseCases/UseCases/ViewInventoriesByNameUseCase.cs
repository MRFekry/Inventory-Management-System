using IMS.Entities;

namespace IMS.UseCases.UseCases;

public interface IViewInventoriesByNameUseCase
{
    Task<IEnumerable<Inventory>> ExecuteAsync(string nameFilter = "");
}

public class ViewInventoriesByNameUseCase : IViewInventoriesByNameUseCase
{
    private readonly IInventoryRepository _inventoryRepository;

    public ViewInventoriesByNameUseCase(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }

    public async Task<IEnumerable<Inventory>> ExecuteAsync(string nameFilter = "")
    {
        return await _inventoryRepository.GetInventoriesByNameAsync(nameFilter);
    }
}
