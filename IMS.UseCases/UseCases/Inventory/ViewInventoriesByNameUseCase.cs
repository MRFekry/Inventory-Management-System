using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.UseCases.Inventory;

public interface IViewInventoriesByNameUseCase
{
    Task<IEnumerable<Entities.Inventory>> ExecuteAsync(string nameFilter = "");
}

public class ViewInventoriesByNameUseCase : IViewInventoriesByNameUseCase
{
    private readonly IInventoryRepository _inventoryRepository;

    public ViewInventoriesByNameUseCase(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }

    public async Task<IEnumerable<Entities.Inventory>> ExecuteAsync(string nameFilter = "")
    {
        return await _inventoryRepository.GetInventoriesByNameAsync(nameFilter);
    }
}
