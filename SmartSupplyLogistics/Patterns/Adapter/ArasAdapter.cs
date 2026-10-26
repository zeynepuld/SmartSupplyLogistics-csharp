namespace SmartSupplyLogistics.Patterns.Adapter;

public class ArasAdapter : ILogisticsProvider
{
    private readonly ArasCargoApi _arasApi;

    public ArasAdapter(ArasCargoApi arasApi)
    {
        _arasApi = arasApi;
    }

    public decimal CalculatePrice(decimal weight, decimal distance) => _arasApi.HesaplaFiyat(weight, distance);
    public string GenerateTrackingNo(int orderId) => _arasApi.TakipNoOlustur(orderId);
    public string GetCarrierName() => "Aras Kargo";
}
