using Product;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;

public class ProductInstance : IProductIdentifier
{
    public ProductType ProductType { get; set; }
    public List<ProductFeatureInstance> Features { get; }
    public string? SerialNumber { get; set; }

    public ProductInstance(ProductType productType, List<ProductFeatureInstance> featuresList, string? serialnumber)
    {
        ProductType = productType;
        Features = featuresList ?? new List<ProductFeatureInstance>();
        SerialNumber = serialnumber;
    }

    public string? GetIdentifier()
    {
        return SerialNumber;
    }

    public void AddFeature(ProductFeatureInstance feature) =>
        Features.Add(feature);

    public Price getPrice()
    {
        var currentDate = DateTime.Now;
        var activePrice = ProductType.GetPrices()
            .FirstOrDefault(price => currentDate >= price.ValidFrom && currentDate <= price.ValidTo);

        return activePrice!;
    }

    public string GetFormattedProductInfo()
    {
        var info = new StringBuilder();
        info.AppendLine($"Product: {ProductType.Name}");
        info.AppendLine($"Description: {ProductType.Description}");
        info.AppendLine("Features:");

        foreach (var feature in Features)
        {
            info.AppendLine($" - {feature.featureType.Name}: {feature.Value}");
        }

        var currentPrice = getPrice();
        if (currentPrice != null)
        {
            info.AppendLine($"Current Price: ${currentPrice.Amount}");
        }
        else
        {
            info.AppendLine("Current Price: Not Available");
        }

        return info.ToString();

    }
}