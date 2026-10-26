using SmartSupplyLogistics.Models.Products;

namespace SmartSupplyLogistics.Controllers;

public class ProductController
{
    private readonly ProductFactory _productFactory;

    public ProductController(ProductFactory productFactory)
    {
        _productFactory = productFactory;
    }

    public IProduct CreateProduct(string type, string name, decimal price, int stock)
        => _productFactory.CreateProduct(type, name, price, stock);

    public CompositeProduct CreateCompositeProduct(string name, decimal assemblyPrice, params IProduct[] components)
    {
        var composite = new CompositeProduct(name, assemblyPrice);
        foreach (var component in components)
            composite.Add(component);
        return composite;
    }
}
