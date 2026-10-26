namespace SmartSupplyLogistics.Models.Products;

public class SimpleProduct : IProduct
{
    public string Name { get; }
    public decimal Price { get; }
    public int Stock { get; private set; }
    public int CategoryId { get; }

    public SimpleProduct(string name, decimal price, int stock, int categoryId = 0)
    {
        Name = name;
        Price = price;
        Stock = stock;
        CategoryId = categoryId;
    }

    public string GetName() => Name;
    public decimal GetPrice() => Price;
    public int GetStock() => Stock;
    public string GetDescription() => $"Basit ürün: {Name}, Fiyat: {Price:C}, Stok: {Stock}";

    public void SetStock(int stock)
    {
        if (stock < 0) throw new ArgumentOutOfRangeException(nameof(stock), "Stok negatif olamaz.");
        Stock = stock;
    }
}
