
namespace Product;

public class ProductType : IProductIdentifier
{
    public string Name { get; set; }
    public string Description { get; set; }
    private List<Price> prices;

    public ProductType(string name, string description)
    {
        Name = name;
        Description = description;
        prices = new List<Price>();
    }

    public string GetIdentifier()
    {
        return Name;
    }

    public string GetProductDetails()
    {
        return $"Product type is {Name}, Description is:\n{Description}";
    }

    public void AddPrice(Price price)
    {
        prices.Add(price);
    }

    public List<Price> GetPrices()
    {
        return prices;
    }
}
