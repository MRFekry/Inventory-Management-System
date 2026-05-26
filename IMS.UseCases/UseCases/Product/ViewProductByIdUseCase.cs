using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.UseCases.Product;

public interface IViewProductByIdUseCase
{
    Task<Entities.Product?> ExecuteAsync(int id);
}

public class ViewProductByIdUseCase : IViewProductByIdUseCase
{
    private readonly IProductRepository _productRepository;

    public ViewProductByIdUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Entities.Product?> ExecuteAsync(int id)
    {
        return await _productRepository.GetProductByIdAsync(id);
    }
}
