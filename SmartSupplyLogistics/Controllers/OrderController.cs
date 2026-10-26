// Sipariş oluşturma, ödeme alma, sipariş durumunu ilerletme ve iade işlemlerini yönetir.

using SmartSupplyLogistics.Models.Orders;
using SmartSupplyLogistics.Models.Users;
using SmartSupplyLogistics.Patterns.Observer;
using SmartSupplyLogistics.Patterns.Singleton;
using SmartSupplyLogistics.Patterns.Strategy;

namespace SmartSupplyLogistics.Controllers;

public class OrderController
{
    private readonly PaymentManager _paymentManager;
    private readonly StockManager _stockManager;
    private readonly Logger _logger;
    private int _orderCounter = 1000;
    private readonly List<Order> _orders = new();

    public OrderController(PaymentManager paymentManager, StockManager stockManager, Logger logger)
    {
        _paymentManager = paymentManager;
        _stockManager = stockManager;
        _logger = logger;
    }

    public Order CreateOrder(User user, List<OrderItem> items)
    {
        if (!user.Can("PlaceOrder"))
            throw new UnauthorizedAccessException($"{user.GetRole()} rolü sipariş oluşturamaz.");

        var order = new Order(++_orderCounter, user.UserId, items);
        _orders.Add(order);
        _logger.Log($"Sipariş oluşturuldu. Sipariş No: {order.OrderId}, Kullanıcı: {user.UserId}, Tutar: {order.TotalAmount:C}");
        return order;
    }

    public bool ProcessPayment(Order order, IPaymentStrategy strategy)
    {
        _paymentManager.SetStrategy(strategy);
        var result = _paymentManager.ExecutePayment(order);
        if (result) _logger.Log($"Ödeme onaylandı. Sipariş No: {order.OrderId}, Yöntem: {strategy.GetPaymentType()}");
        return result;
    }

    public void NextOrderStep(Order order)
    {
        var oldState = order.GetCurrentState();
        order.ProcessOrder();
        _logger.Log($"Sipariş durumu değişti. Sipariş No: {order.OrderId}, {oldState} -> {order.GetCurrentState()}");
    }

    public void CancelOrder(Order order)
    {
        var oldState = order.GetCurrentState();
        order.CancelOrder();
        _logger.Log($"Sipariş iptal edildi. Sipariş No: {order.OrderId}, {oldState} -> {order.GetCurrentState()}");
    }

    public void ReturnOrder(Order order, string reason)
    {
        var oldState = order.GetCurrentState();
        order.ReturnOrder(reason);
        _logger.Log($"İade süreci. Sipariş No: {order.OrderId}, {oldState} -> {order.GetCurrentState()}, Sebep: {reason}");
    }

    public void UpdateShipping(Order order, string trackingNo, string carrierName, decimal shippingPrice)
    {
        order.SetShipping(trackingNo, carrierName, shippingPrice);
        _logger.Log($"Kargo bilgisi eklendi. Sipariş No: {order.OrderId}, Firma: {carrierName}, Takip No: {trackingNo}, Ücret: {shippingPrice:C}");
    }

    public IEnumerable<Order> ViewOrderHistory(int userId) => _orders.Where(o => o.UserId == userId);
}
