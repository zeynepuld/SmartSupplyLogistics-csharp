namespace SmartSupplyLogistics.Views;

public class StockView
{
    public void ShowStockLevel(string productName, int stock) => Console.WriteLine($"{productName} stok: {stock}");
    public void ShowLowStockAlert(string productName) => Console.WriteLine($"DÜŞÜK STOK UYARISI: {productName}");
    public void RenderStockTable() => Console.WriteLine("Stok tablosu render edildi.");
    public void ShowNotification(string message) => Console.WriteLine($"[Bildirim] {message}");
}
