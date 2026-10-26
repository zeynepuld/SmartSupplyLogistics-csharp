using SmartSupplyLogistics.Patterns.Adapter;

namespace SmartSupplyLogistics.Patterns.Decorator;

public abstract class LogisticsDecorator : ILogisticsProvider
{
    protected readonly ILogisticsProvider InnerProvider;

    protected LogisticsDecorator(ILogisticsProvider innerProvider)
    {
        InnerProvider = innerProvider;
    }

    public virtual decimal CalculatePrice(decimal weight, decimal distance) => InnerProvider.CalculatePrice(weight, distance);
    public virtual string GenerateTrackingNo(int orderId) => InnerProvider.GenerateTrackingNo(orderId);
    public virtual string GetCarrierName() => InnerProvider.GetCarrierName();
}
