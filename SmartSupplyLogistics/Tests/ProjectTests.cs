using SmartSupplyLogistics.Models.Orders;
using SmartSupplyLogistics.Models.Orders.States;
using SmartSupplyLogistics.Models.Products;
using SmartSupplyLogistics.Patterns.Adapter;
using SmartSupplyLogistics.Patterns.Observer;

namespace SmartSupplyLogistics.Tests;

public static class ProjectTests
{
    public static void RunAll()
    {
        Console.WriteLine("\n=== Basit Unit Test Çıktıları ===");
        TestCompositeProductPrice();
        TestOrderStateFlow();
        TestShippingAdapter();
        TestStockThreshold();
        Console.WriteLine("Tüm testler geçti.");
    }

    private static void Assert(bool condition, string message)
    {
        if (!condition) throw new Exception("Test başarısız: " + message);
        Console.WriteLine("[OK] " + message);
    }

    private static void TestCompositeProductPrice()
    {
        var ram = new SimpleProduct("RAM", 1000m, 4);
        var cpu = new SimpleProduct("CPU", 2000m, 2);
        var pc = new CompositeProduct("PC", 500m);
        pc.Add(ram);
        pc.Add(cpu);

        Assert(pc.GetPrice() == 3500m, "Composite ürün fiyatı parça fiyatları + montaj bedeli olmalı.");
        Assert(pc.GetStock() == 2, "Composite ürün stok adedi en az stoklu parçaya göre hesaplanmalı.");
    }

    private static void TestOrderStateFlow()
    {
        var product = new SimpleProduct("Kalem", 10m, 20);
        var order = new Order(1, 1, new List<OrderItem> { new(product, 1) });

        order.ProcessOrder();
        Assert(order.GetCurrentState() == "Onaylandı", "Beklemede -> Onaylandı geçişi çalışmalı.");
        order.ProcessOrder();
        Assert(order.GetCurrentState() == "Hazırlanıyor", "Onaylandı -> Hazırlanıyor geçişi çalışmalı.");
        order.ProcessOrder();
        Assert(order.GetCurrentState() == "Kargoda", "Hazırlanıyor -> Kargoda geçişi çalışmalı.");
        order.ReturnOrder("Ürün hasarlı.");
        Assert(order.GetCurrentState() == "İade/İptal", "Kargoda -> İade geçişi çalışmalı.");
    }

    private static void TestShippingAdapter()
    {
        ILogisticsProvider provider = new YurticiAdapter(new YurticiCargoApi());
        var price = provider.CalculatePrice(2m, 10m);
        var tracking = provider.GenerateTrackingNo(99);

        Assert(price > 0, "Adapter kargo ücreti hesaplamalı.");
        Assert(tracking.StartsWith("YRT-"), "Adapter standart takip numarası üretmeli.");
    }

    private static void TestStockThreshold()
    {
        var stockManager = new StockManager(5);
        Assert(stockManager.CheckThreshold("RAM", 3), "Stok eşik altındaysa true dönmeli.");
        Assert(!stockManager.CheckThreshold("Kalem", 8), "Stok eşik üstündeyse false dönmeli.");
    }
}
