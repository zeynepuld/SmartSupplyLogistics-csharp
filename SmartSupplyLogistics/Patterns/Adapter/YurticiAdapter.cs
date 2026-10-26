namespace SmartSupplyLogistics.Patterns.Adapter;

public class YurticiAdapter : ILogisticsProvider
{
    private readonly YurticiCargoApi _yurticiApi;

    public YurticiAdapter(YurticiCargoApi yurticiApi)
    {
        _yurticiApi = yurticiApi;
    }

    public decimal CalculatePrice(decimal weight, decimal distance) => _yurticiApi.UcretHesapla(weight, distance);
    public string GenerateTrackingNo(int orderId) => _yurticiApi.BarkodUret(orderId);
    public string GetCarrierName() => "Yurtiçi Kargo";
}
