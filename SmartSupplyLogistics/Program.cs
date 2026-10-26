// Programın ana çalışma senaryosu burada başlatılır.
// Ürün oluşturma, sipariş verme, ödeme, kargo ve test işlemleri sırasıyla çalıştırılır.

using SmartSupplyLogistics.Controllers;
using SmartSupplyLogistics.Models.Orders;
using SmartSupplyLogistics.Models.Products;
using SmartSupplyLogistics.Models.Users;
using SmartSupplyLogistics.Patterns.Adapter;
using SmartSupplyLogistics.Patterns.Decorator;
using SmartSupplyLogistics.Patterns.Observer;
using SmartSupplyLogistics.Patterns.Strategy;
using SmartSupplyLogistics.Tests;
using SmartSupplyLogistics.Views;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var loggerPath = Path.Combine(AppContext.BaseDirectory, "system-log.txt");
var logger = SmartSupplyLogistics.Patterns.Singleton.Logger.GetInstance(loggerPath);

var productFactory = new ProductFactory();
var productController = new ProductController(productFactory);
var productView = new ProductView();
var orderView = new OrderView();
var stockView = new StockView();

var stockManager = new StockManager(threshold: 5);
stockManager.Register(new EmailNotifier("satinalma@firma.com"));
stockManager.Register(new SystemNotifier("Depo Sorumlusu Paneli"));

var paymentManager = new PaymentManager();
var orderController = new OrderController(paymentManager, stockManager, logger);
var stockController = new StockController(stockManager, logger);

var customer = new User(1, "Zeynep Müşteri", "zeynep@example.com", new CustomerRole());
var staff = new User(2, "Depo Personeli", "depo@example.com", new PersonnelRole());

IProduct pencil = productController.CreateProduct("simple", "Kalem", 20m, 10);
IProduct ram = productController.CreateProduct("simple", "RAM", 900m, 3);
IProduct cpu = productController.CreateProduct("simple", "CPU", 2500m, 2);
var computerCase = productController.CreateCompositeProduct("Bilgisayar Kasası", 1500m, ram, cpu);

productView.ShowProductList(new[] { pencil, ram, cpu, computerCase });

var order = orderController.CreateOrder(customer, new List<OrderItem>
{
    new OrderItem(pencil, 2),
    new OrderItem(computerCase, 1)
});
orderView.ShowOrder(order);

var paid = orderController.ProcessPayment(order, new CreditCardStrategy("4111111111111111", "123"));
if (paid)
{
    orderController.NextOrderStep(order); // Beklemede -> Onaylandı
    orderController.NextOrderStep(order); // Onaylandı -> Hazırlanıyor
    orderController.NextOrderStep(order); // Hazırlanıyor -> Kargoda
}

ILogisticsProvider cargo = new ArasAdapter(new ArasCargoApi());
cargo = new InsuredShippingDecorator(cargo);
cargo = new FragileItemDecorator(cargo);

var shippingPrice = cargo.CalculatePrice(weight: 4.5m, distance: 120m);
var trackingNo = cargo.GenerateTrackingNo(order.OrderId);
orderController.UpdateShipping(order, trackingNo, cargo.GetCarrierName(), shippingPrice);
orderView.ShowShippingInfo(order, cargo.GetCarrierName(), trackingNo, shippingPrice);

stockController.UpdateStock(staff, "RAM", 3);
stockController.UpdateStock(staff, "CPU", 2);
stockView.ShowNotification("Stok eşiği altındaki ürünler için bildirimler konsola yazdırıldı.");

orderController.ReturnOrder(order, "Kargoda ürün hasarlı göründü.");
orderView.ShowOrder(order);

ProjectTests.RunAll(); // test için
Console.WriteLine($"\nLog dosyası: {loggerPath}");
