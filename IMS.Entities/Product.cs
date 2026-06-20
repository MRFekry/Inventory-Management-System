using System.ComponentModel.DataAnnotations;

namespace IMS.Entities;

public class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    public string Name { get; set; } = string.Empty;

    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a positive integer.")]
    public int Quantity { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
    public decimal Price { get; set; }

    [ValidateProductPricing]
    public List<ProductInventory> ProductInventories { get; set; } = new List<ProductInventory>();

    public void AddInventory(Inventory inventory)
    {
        if (!ProductInventories.Any(pi => pi.Inventory is not null &&
             pi.Inventory.Name.Equals(inventory.Name)))
        {
            ProductInventories.Add(new ProductInventory
            {
                ProductId = Id,
                InventoryId = inventory.Id,
                InventoryQuantity = 1,
                Inventory = inventory,
                Product = this
            });
        }
    }

    public void DeleteInventory(ProductInventory productInventory)
    {
        if (productInventory is not null)
        {
            if (ProductInventories.Any(pinv => pinv.InventoryId == productInventory.InventoryId))
            {
                ProductInventories.Remove(productInventory);
            }
        }
    }
}
