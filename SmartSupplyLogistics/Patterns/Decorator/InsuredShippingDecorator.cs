using SmartSupplyLogistics.Patterns.Adapter;

namespace SmartSupplyLogistics.Patterns.Decorator;

public class InsuredShippingDecorator : LogisticsDecorator
{
    public InsuredShippingDecorator(ILogisticsProvider innerProvider) : base(innerProvider) { }

    public override decimal CalculatePrice(decimal weight, decimal distance)
        => base.CalculatePrice(weight, distance) + 50m;

    public override string GetCarrierName() => base.GetCarrierName() + " + Sigortalı Gönderim";
}
