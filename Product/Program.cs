using Product;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        ProductFeatureType colorFeatureType = new ProductFeatureType("Color");
        colorFeatureType.AddPossibleValue("Black");
        colorFeatureType.AddPossibleValue("Red");
        colorFeatureType.AddPossibleValue("Silver");
        colorFeatureType.AddPossibleValue("Blue");
        colorFeatureType.AddPossibleValue("Pink");

        Console.WriteLine($"Feature type - {colorFeatureType.Name}:\n");

        foreach (var value in colorFeatureType.PossibleValues)
            Console.WriteLine($"- {value}");

        Console.Write("\n-----------------------");

        ProductFeatureType interiorFeatureType = new ProductFeatureType("Interior color");
        interiorFeatureType.AddPossibleValue("Black");
        interiorFeatureType.AddPossibleValue("White");
        interiorFeatureType.AddPossibleValue("Beige");
        interiorFeatureType.AddPossibleValue("Cappucino");

        Console.WriteLine($"\n\nFeature type - {interiorFeatureType.Name}:\n");

        foreach (var value in interiorFeatureType.PossibleValues)
            Console.WriteLine($"- {value}");

        Console.Write("\n-----------------------\n\n");

        ProductType TypeAudiA6 = new ProductType("Audi A6", "Audi model A6");
        TypeAudiA6.AddPrice(new Price(49999, new DateTime(1900, 01, 01), DateTime.Now.AddYears(1)));
        TypeAudiA6.AddPrice(new Price(51999, DateTime.Now.AddYears(1), DateTime.Now.AddYears(2)));
        TypeAudiA6.AddPrice(new Price(59999, DateTime.Now.AddYears(2), DateTime.Now.AddYears(200)));

        var blackInterior = new ProductFeatureInstance(interiorFeatureType, "Black");
        var blackExterior = new ProductFeatureInstance(colorFeatureType, "Black");
        var featureInstances1 = new List<ProductFeatureInstance> { blackInterior, blackExterior };

        var CappucinoInterior = new ProductFeatureInstance(interiorFeatureType, "Cappucino");
        var PinkExterior = new ProductFeatureInstance(colorFeatureType, "Pink");
        var featureInstances2 = new List<ProductFeatureInstance> { CappucinoInterior, PinkExterior };

        ProductInstance AudiA6instance1 = new ProductInstance(TypeAudiA6, featureInstances1, "A600001");
        ProductInstance AudiA6instance2 = new ProductInstance(TypeAudiA6, featureInstances2, "ST00001");

        Console.WriteLine(AudiA6instance1.GetFormattedProductInfo());
        Console.WriteLine("-----------------------");
        Console.WriteLine(AudiA6instance2.GetFormattedProductInfo());

        ProductType TypeWinterTires = new ProductType("Winter Tires", "Tires suitable for winter conditions");

        TypeWinterTires.AddPrice(new Price(239, new DateTime(1900, 01, 01), DateTime.Now.AddYears(5000)));

        ProductType TypeSummerTires = new ProductType("Summer Tires", "Tires suitable for summer conditions");

        TypeSummerTires.AddPrice(new Price(199, new DateTime(1900, 01, 01), DateTime.Now.AddYears(5000)));

        ProductInstance WinterTireInstance = new ProductInstance(TypeWinterTires, new List<ProductFeatureInstance>(), null);

        Console.WriteLine(WinterTireInstance.GetFormattedProductInfo());
        Console.WriteLine("-----------------------");

        ProductInstance SummerTireInstance = new ProductInstance(TypeSummerTires, new List<ProductFeatureInstance>(), null);

        Console.WriteLine(SummerTireInstance.GetFormattedProductInfo());
        Console.WriteLine("-----------------------\n");

        PackageType tirePackageType = new PackageType("Tire Package", "A package for tires");
        PackageType mixedPackageType = new PackageType("Mixed Package", "A mixed package of cars and tires");

        PackageInstance tirePackage = new PackageInstance(tirePackageType);
        tirePackage.AddProductInstance(WinterTireInstance);
        tirePackage.AddProductInstance(SummerTireInstance);

        PackageInstance mixedPackage = new PackageInstance(mixedPackageType);
        mixedPackage.AddProductInstance(AudiA6instance1);
        mixedPackage.AddProductInstance(WinterTireInstance);

        Console.WriteLine($"Total cost of {tirePackage.packageType.Name}: ${tirePackage.GetTotalCost()}");
        Console.WriteLine($"Total cost of {mixedPackage.packageType.Name}: ${mixedPackage.GetTotalCost()}");

        Console.WriteLine("-----------------------\n");

        ProductCatalog catalog = new ProductCatalog("My Product Catalog");

        catalog.AddProductType(TypeAudiA6);
        catalog.AddProductType(TypeWinterTires);
        catalog.AddProductType(TypeSummerTires);

        Console.WriteLine($"Product Catalog: {catalog.Name}");
        Console.WriteLine("Available Product Types:");

        foreach (var productType in catalog.ProductTypes)
        {
            Console.WriteLine($"- {productType.Name}: {productType.Description}");
        }
    }
}