using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.UseCases.Product;

public interface IDeleteProductUseCase
{
    Task ExecuteAsync(int productId);
}

public class DeleteProductUseCase : IDeleteProductUseCase
{
    private readonly IProductRepository _productRepository;

    public DeleteProductUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task ExecuteAsync(int productId)
    {
        await _productRepository.DeleteProductAsync(productId);
    }
}
