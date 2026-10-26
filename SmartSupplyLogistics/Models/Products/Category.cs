namespace SmartSupplyLogistics.Models.Products;

public class Category
{
    public int CategoryId { get; }
    public string Name { get; }
    public string Description { get; }
    private readonly List<IProduct> _products = new();

    public Category(int categoryId, string name, string description)
    {
        CategoryId = categoryId;
        Name = name;
        Description = description;
    }

    public string GetProducts() => string.Join(Environment.NewLine, _products.Select(p => p.GetDescription()));
    public void AddProduct(IProduct product) => _products.Add(product);
}
