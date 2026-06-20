using System.ComponentModel.DataAnnotations;

namespace IMS.Entities;

public class ValidateProductPricing : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var product = validationContext.ObjectInstance as Product;

        if (product is not null)
        {
            if (!IsProductCostValid(product))
            {
                return new ValidationResult($"The product's price: {product.Price.ToString("C")} is less than its inventories costs: {GetTotalProductInventoriesCost(product).ToString("C")}!", new List<string>() { validationContext.MemberName! });
            }
        }

        return ValidationResult.Success;
    }

    private decimal GetTotalProductInventoriesCost(Product product)
    {
        if (product is null || product.ProductInventories is null || product.ProductInventories.Count <= 0) return 0;

        return product.ProductInventories.Sum(p => p.Inventory?.Price * p.Inventory?.Quantity ?? 0);
    }

    private bool IsProductCostValid(Product product)
    {
        if (product is null || product.ProductInventories is null || product.ProductInventories.Count <= 0) return true;

        if (product.Price < GetTotalProductInventoriesCost(product)) return false;

        return true;
    }
}
