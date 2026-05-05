using IMS.Entities;

namespace IMS.UseCases;

public class ViewInventoriesUseCase
{
    public async Task<IEnumerable<Inventory>> ExecuteAsync(string nameFilter = "")
    {
        // In a real application, this would retrieve data from a database or repository.
        // Here, we return a hardcoded list of inventories for demonstration purposes.
        return await Task.FromResult(Enumerable.Empty<Inventory>());
    }
}
