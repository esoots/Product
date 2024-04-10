namespace Product;

public class ProductFeatureType
{
    public string Name { get; set; }
    public List<object> PossibleValues { get; set; }

    public ProductFeatureType(string name)
    {
        Name = name;
        PossibleValues = new List<object>();
    }

    public void AddPossibleValue(object value)
    {
        PossibleValues.Add(value);
    }
}