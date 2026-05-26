using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.UseCases.Inventory;

public interface IDeleteInventoryUseCase
{
    Task ExecuteAsync(int inventoryId);
}

public class DeleteInventoryUseCase : IDeleteInventoryUseCase
{
    private readonly IInventoryRepository _inventoryRepository;

    public DeleteInventoryUseCase(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }
    public async Task ExecuteAsync(int inventoryId)
    {
        await _inventoryRepository.DeleteInventoryAsync(inventoryId);
    }
}
