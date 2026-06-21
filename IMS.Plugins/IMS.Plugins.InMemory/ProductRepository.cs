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
            new Product { Id = 1, Name = "Bike", Quantity = 50, Price = 300m },
            new Product { Id = 2, Name = "E-Bike", Quantity = 30, Price = 2500m },
            new Product { Id = 3, Name = "Cargo Bike", Quantity = 5, Price = 4500m },
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
            product.ProductInventories = updatedProduct.ProductInventories;
        }

        return Task.CompletedTask;
    }

    public Task<Product?> GetProductByIdAsync(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        Product? newProd = null;

        if (product is not null)
        {
            newProd = new Product();
            newProd.Id = product.Id;
            newProd.Name = product.Name;
            newProd.Quantity = product.Quantity;
            newProd.Price = product.Price;

            if (product.ProductInventories is not null && product.ProductInventories.Count > 0)
            {
                newProd.ProductInventories = new List<ProductInventory>(product.ProductInventories.Capacity);
                foreach (var pinv in product.ProductInventories)
                {
                    var productInventory = new ProductInventory
                    {
                        InventoryId = pinv.InventoryId,
                        ProductId = pinv.ProductId,
                        Product = product,
                        Inventory = new Inventory(),
                        InventoryQuantity = pinv.InventoryQuantity
                    };

                    if (pinv.Inventory is not null)
                    {
                        productInventory.Inventory.Id = pinv.Inventory.Id;
                        productInventory.Inventory.Name = pinv.Inventory.Name;
                        productInventory.Inventory.Quantity = pinv.Inventory.Quantity;
                        productInventory.Inventory.Price = pinv.Inventory.Price;
                    }

                    newProd.ProductInventories.Add(productInventory);
                }
            }
        }

        return Task.FromResult(newProd)!;
    }

    public Task DeleteProductAsync(int productId)
    {
        var product = _products.FirstOrDefault(p => p.Id == productId);
        if (product != null)
            _products.Remove(product);

        return Task.CompletedTask;
    }
}
