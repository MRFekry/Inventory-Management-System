using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.UseCases.Product;

public interface IEditProductUseCase
{
    Task ExecuteAsync(Entities.Product updatedProduct);
}

public class EditProductUseCase : IEditProductUseCase
{
    private readonly IProductRepository productRepository;

    public EditProductUseCase(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public async Task ExecuteAsync(Entities.Product updatedProduct)
    {
        await productRepository.EditProductAsync(updatedProduct);
    }
}
