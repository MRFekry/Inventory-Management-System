using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.UseCases.Product;

public interface IAddNewProductUseCase
{
    Task ExecuteAsync(Entities.Product product);
}

public class AddNewProductUseCase : IAddNewProductUseCase
{
    private readonly IProductRepository _productRepository;

    public AddNewProductUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task ExecuteAsync(Entities.Product product)
    {
        await _productRepository.AddProductAsync(product);
    }
}
