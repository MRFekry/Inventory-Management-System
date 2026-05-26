using IMS.Entities;

namespace IMS.UseCases.PluginInterfaces;

public interface IProductRepository
{
    Task<List<Product>> GetProductsByNameAsync(string nameFilter = "");
    Task AddProductAsync(Product product);
    Task EditProductAsync(Product updatedProduct);
    Task<Product?> GetProductByIdAsync(int id);
    Task DeleteProductAsync(int productId);
}
