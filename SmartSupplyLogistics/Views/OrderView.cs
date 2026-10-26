using SmartSupplyLogistics.Models.Orders;

namespace SmartSupplyLogistics.Views;

public class OrderView
{
    public void ShowOrder(Order order)
    {
        Console.WriteLine("\n=== Sipariş ===");
        Console.WriteLine($"Sipariş No: {order.OrderId}");
        Console.WriteLine($"Durum: {order.GetCurrentState()}");
        Console.WriteLine($"Tutar: {order.TotalAmount:C}");
    }

    public void ShowOrderHistory(IEnumerable<Order> orders)
    {
        Console.WriteLine("\n=== Sipariş Geçmişi ===");
        foreach (var order in orders)
            Console.WriteLine($"#{order.OrderId} - {order.GetCurrentState()} - {order.TotalAmount:C}");
    }

    public void ShowShippingInfo(Order order, string carrierName, string trackingNo, decimal price)
    {
        Console.WriteLine("\n=== Kargo Bilgisi ===");
        Console.WriteLine($"Sipariş: {order.OrderId}");
        Console.WriteLine($"Firma: {carrierName}");
        Console.WriteLine($"Takip No: {trackingNo}");
        Console.WriteLine($"Kargo Ücreti: {price:C}");
    }
}
