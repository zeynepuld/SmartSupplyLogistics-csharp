namespace SmartSupplyLogistics.Models.Products;

public class ProductFactory
{
    private readonly Dictionary<string, Func<string, decimal, int, IProduct>> _creators;

    public ProductFactory()
    {
        _creators = new Dictionary<string, Func<string, decimal, int, IProduct>>(StringComparer.OrdinalIgnoreCase)
        {
            ["simple"] = (name, price, stock) => new SimpleProduct(name, price, stock)
        };
    }

    public void RegisterProductType(string type, Func<string, decimal, int, IProduct> creator)
    {
        _creators[type] = creator;
    }

    public IProduct CreateProduct(string type, string name, decimal price, int stock)
    {
        if (!_creators.TryGetValue(type, out var creator))
            throw new ArgumentException($"Desteklenmeyen ürün tipi: {type}");

        return creator(name, price, stock);
    }
}
