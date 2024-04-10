namespace Product;

public class PackageInstance
{
    public PackageType packageType;
    public List<ProductInstance> productInstances;

    public PackageInstance(PackageType packageType)
    {
        this.packageType = packageType;
        productInstances = new List<ProductInstance>();
    }

    public void AddProductInstance(ProductInstance productInstance)
    {
        productInstances.Add(productInstance);
    }

    public List<ProductInstance> getContents()
    {
        return productInstances;
    }

    public double GetTotalCost()
    {
        double totalCost = 0.0;
        foreach (var productInstance in productInstances)
        {
            Price price = productInstance.getPrice();
            if (price != null)
            {
                totalCost += price.Amount;
            }
        }
        return totalCost;
    }
}