
namespace Product;

public class Price
{
    // producttype can have multiple prices
    // productinstance can have only on specific price
    public double Amount { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }

    public Price(double amount, DateTime validFrom, DateTime validTo)
    {
        Amount = amount;
        ValidFrom = validFrom;
        ValidTo = validTo;
    }
}