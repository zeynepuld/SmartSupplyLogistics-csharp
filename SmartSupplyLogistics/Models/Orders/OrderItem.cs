using SmartSupplyLogistics.Models.Products;

namespace SmartSupplyLogistics.Models.Orders;

public class OrderItem
{
    public IProduct Product { get; }
    public int Quantity { get; }
    public decimal LineTotal => Product.GetPrice() * Quantity;

    public OrderItem(IProduct product, int quantity)
    {
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity), "Adet 1 veya daha büyük olmalıdır.");
        Product = product;
        Quantity = quantity;
    }
}
