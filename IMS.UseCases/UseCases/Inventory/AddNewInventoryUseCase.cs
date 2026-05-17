using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.UseCases.Inventory;

public interface IAddNewInventoryUseCase
{
    Task ExecuteAsync(Entities.Inventory inventory);
}

public class AddNewInventoryUseCase : IAddNewInventoryUseCase
{
    private readonly IInventoryRepository _inventoryRepository;

    public AddNewInventoryUseCase(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }

    public async Task ExecuteAsync(Entities.Inventory inventory)
    {
        await _inventoryRepository.AddInventoryAsync(inventory);
    }
}
