using SmartSupplyLogistics.Models.Orders;
using SmartSupplyLogistics.Patterns.Adapter;
using SmartSupplyLogistics.Patterns.Singleton;

namespace SmartSupplyLogistics.Patterns.Facade;

public class LogisticsFacade
{
    private readonly ILogisticsProvider _provider;
    private readonly Logger _logger;

    public LogisticsFacade(ILogisticsProvider provider, Logger logger)
    {
        _provider = provider;
        _logger = logger;
    }

    public (string trackingNo, decimal price) CreateShipment(Order order, decimal weight, decimal distance)
    {
        var price = _provider.CalculatePrice(weight, distance);
        var trackingNo = _provider.GenerateTrackingNo(order.OrderId);
        order.SetShipping(trackingNo, _provider.GetCarrierName(), price);
        _logger.Log($"Kargo oluşturuldu. Sipariş: {order.OrderId}, Firma: {_provider.GetCarrierName()}, Takip No: {trackingNo}, Ücret: {price:C}");
        return (trackingNo, price);
    }
}
