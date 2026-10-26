namespace SmartSupplyLogistics.Patterns.Adapter;

public class GlobalExpressAdapter : ILogisticsProvider
{
    private readonly GlobalExpressApi _globalExpressApi;

    public GlobalExpressAdapter(GlobalExpressApi globalExpressApi)
    {
        _globalExpressApi = globalExpressApi;
    }

    public decimal CalculatePrice(decimal weight, decimal distance) => _globalExpressApi.CalcShippingFee(weight, distance);
    public string GenerateTrackingNo(int orderId) => _globalExpressApi.CreateTracking(orderId);
    public string GetCarrierName() => "GlobalExpress";
}
