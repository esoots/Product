using Product;

public class ProductFeatureInstance
{
    public object Value { get; set; }
    public ProductFeatureType featureType;

    public ProductFeatureInstance(ProductFeatureType featureType, object value)
    {
        this.featureType = featureType;
        Value = value;
    }

    public string GetName()
    {
        return featureType.Name;
    }

    public List<object> GetPossibleValues()
    {
        return featureType.PossibleValues;
    }
}