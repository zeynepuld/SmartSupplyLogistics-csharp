namespace SmartSupplyLogistics.Patterns.Adapter;

public class YurticiCargoApi
{
    public decimal UcretHesapla(decimal kg, decimal km) => 30m + kg * 7m + km * 0.40m;
    public string BarkodUret(int siparisId) => $"YRT-{DateTime.Now.Ticks % 100000}-{siparisId}";
    public bool Baglanti() => true;
}
