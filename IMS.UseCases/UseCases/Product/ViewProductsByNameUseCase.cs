using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.UseCases.Product;

public interface IViewProductsByNameUseCase
{
    Task<IEnumerable<Entities.Product>> ExecuteAsync(string nameFilter = "");
}

public class ViewProductsByNameUseCase : IViewProductsByNameUseCase
{
    private readonly IProductRepository _productRepository;

    public ViewProductsByNameUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Entities.Product>> ExecuteAsync(string nameFilter = "")
    {
        return await _productRepository.GetProductsByNameAsync(nameFilter);
    }
}
