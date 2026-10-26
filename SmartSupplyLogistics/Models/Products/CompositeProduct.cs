namespace SmartSupplyLogistics.Models.Products;

public class CompositeProduct : IProduct
{
    public string Name { get; }
    public decimal AssemblyPrice { get; }
    private readonly List<IProduct> _components = new();

    public CompositeProduct(string name, decimal assemblyPrice)
    {
        Name = name;
        AssemblyPrice = assemblyPrice;
    }

    public void Add(IProduct product) => _components.Add(product);
    public void Remove(IProduct product) => _components.Remove(product);

    public string GetName() => Name;

    public decimal GetPrice() => AssemblyPrice + _components.Sum(c => c.GetPrice());

    public int GetStock() => _components.Count == 0 ? 0 : _components.Min(c => c.GetStock());

    public string GetDescription()
    {
        var componentNames = _components.Count == 0
            ? "parça yok"
            : string.Join(", ", _components.Select(c => c.GetName()));

        return $"Bileşik ürün: {Name}, Parçalar: {componentNames}, Toplam fiyat: {GetPrice():C}, Üretilebilir stok: {GetStock()}";
    }
}
