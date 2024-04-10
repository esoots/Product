namespace Product;

public class ProductCatalog
{
    public string Name { get; set; }
    public List<ProductType> ProductTypes;

    public ProductCatalog(string name)
    {
        Name = name;
        ProductTypes = new List<ProductType>();
    }

    public void AddProductType(ProductType productType)
    {
        ProductTypes.Add(productType);
    }

    public void RemoveProductType(ProductType productType)
    {
        ProductTypes.Remove(productType);
    }

    public ProductType FindProductTypeByIdentifier(string identifier)
    {
        foreach (var productType in ProductTypes)
        {
            if (productType.GetIdentifier()!.Equals(identifier, StringComparison.OrdinalIgnoreCase))
            {
                return productType;
            }
        }
        return null!;
    }


}