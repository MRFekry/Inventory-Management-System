using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.UseCases.Inventory;

public interface IViewInventoryByIdUseCase
{
    Task<Entities.Inventory?> ExecuteAsync(int id);
}

public class ViewInventoryByIdUseCase : IViewInventoryByIdUseCase
{
    private readonly IInventoryRepository _inventoryRepository;

    public ViewInventoryByIdUseCase(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }

    public async Task<Entities.Inventory?> ExecuteAsync(int id)
    {
        // Implementation for retrieving inventory by ID goes here
        return await _inventoryRepository.GetInventoryByIdAsync(id);
    }
}
