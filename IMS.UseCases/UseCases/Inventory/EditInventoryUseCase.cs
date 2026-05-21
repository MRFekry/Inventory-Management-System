using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.UseCases.Inventory;

public interface IEditInventoryUseCase
{
    Task ExecuteAsync(Entities.Inventory updatedInventory);
}

public class EditInventoryUseCase : IEditInventoryUseCase
{
    private readonly IInventoryRepository inventoryRepository;

    public EditInventoryUseCase(IInventoryRepository inventoryRepository)
    {
        this.inventoryRepository = inventoryRepository;
    }

    public async Task ExecuteAsync(Entities.Inventory updatedInventory)
    {
        await inventoryRepository.EditInventoryAsync(updatedInventory);
    }
}
