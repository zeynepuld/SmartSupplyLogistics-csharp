using SmartSupplyLogistics.Patterns.Adapter;

namespace SmartSupplyLogistics.Patterns.Decorator;

public class FragileItemDecorator : LogisticsDecorator
{
    public FragileItemDecorator(ILogisticsProvider innerProvider) : base(innerProvider) { }

    public override decimal CalculatePrice(decimal weight, decimal distance)
        => base.CalculatePrice(weight, distance) + 30m;

    public override string GetCarrierName() => base.GetCarrierName() + " + Kırılacak Eşya Koruması";
}
