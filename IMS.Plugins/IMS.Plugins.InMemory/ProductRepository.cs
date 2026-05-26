using IMS.Entities;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory;

public class ProductRepository : IProductRepository
{
    private readonly List<Product> _products;

    public ProductRepository()
    {
        _products = new List<Product>
        {
            new Product { Id = 1, Name = "T-Shirt", Quantity = 50, Price = 19.99m },
            new Product { Id = 2, Name = "Jeans", Quantity = 30, Price = 49.99m },
            new Product { Id = 3, Name = "Sneakers", Quantity = 20, Price = 89.99m },
        };
    }

    public Task<List<Product>> GetProductsByNameAsync(string nameFilter = "")
    {
        if (string.IsNullOrWhiteSpace(nameFilter))
            return Task.FromResult(_products);

        return Task.FromResult(
            _products.Where(
                p => p.Name.Contains(nameFilter, StringComparison.OrdinalIgnoreCase)
            ).ToList()
        );
    }

    public Task AddProductAsync(Product product)
    {
        if (_products.Any(p => p.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase)))
            return Task.CompletedTask;

        var maxId = _products.Any() ? _products.Max(p => p.Id) : 0;
        product.Id = maxId + 1;

        _products.Add(product);
        return Task.CompletedTask;
    }

    public Task EditProductAsync(Product updatedProduct)
    {
        if (_products.Any(p => p.Id != updatedProduct.Id && p.Name.Equals(updatedProduct.Name, StringComparison.OrdinalIgnoreCase)))
            return Task.CompletedTask;

        var product = _products.FirstOrDefault(p => p.Id == updatedProduct.Id);
        if (product != null)
        {
            product.Name = updatedProduct.Name;
            product.Quantity = updatedProduct.Quantity;
            product.Price = updatedProduct.Price;
        }
        return Task.CompletedTask;
    }

    public Task<Product?> GetProductByIdAsync(int id)
    {
        return Task.FromResult(_products.FirstOrDefault(p => p.Id == id));
    }

    public Task DeleteProductAsync(int productId)
    {
        var product = _products.FirstOrDefault(p => p.Id == productId);
        if (product != null)
            _products.Remove(product);

        return Task.CompletedTask;
    }
}
