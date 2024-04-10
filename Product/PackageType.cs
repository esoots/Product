using System.Diagnostics;

namespace Product;

public class PackageType
{
    public string Name { get; set; }
    public string Description { get; set; }
    private List<ProductType> products;

    public PackageType(string name, string description)
    {
        Name = name;
        products = new List<ProductType>();
        Description = description;
    }

    public void addProductType(ProductType product)
    {
        products.Add(product);
    }

    public List<ProductType> getComponents()
    {
        return products;
    }
}