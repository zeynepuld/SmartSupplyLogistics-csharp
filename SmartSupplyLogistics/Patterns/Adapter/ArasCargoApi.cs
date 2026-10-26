namespace SmartSupplyLogistics.Patterns.Adapter;

public class ArasCargoApi
{
    public decimal HesaplaFiyat(decimal agirlik, decimal mesafe) => 35m + agirlik * 8m + mesafe * 0.45m;
    public string TakipNoOlustur(int orderId) => $"ARS-{DateTime.Now:yyyyMMdd}-{orderId}";
    public bool BaglantiKur() => true;
}
