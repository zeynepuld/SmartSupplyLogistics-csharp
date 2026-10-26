namespace SmartSupplyLogistics.Patterns.Adapter;

public class GlobalExpressApi
{
    public decimal CalcShippingFee(decimal weight, decimal distance) => 60m + weight * 12m + distance * 0.70m;
    public string CreateTracking(int id) => $"GLX-{Guid.NewGuid().ToString()[..8].ToUpperInvariant()}-{id}";
    public bool Connect() => true;
}
