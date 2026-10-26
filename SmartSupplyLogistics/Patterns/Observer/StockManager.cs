// Stok miktarını kontrol eder. Kritik stok durumunda bildirim sınıflarını çalıştırır.

namespace SmartSupplyLogistics.Patterns.Observer;

public class StockManager
{
    private readonly List<IStockObserver> _observers = new();
    private readonly int _threshold;

    public StockManager(int threshold)
    {
        _threshold = threshold;
    }

    public void Register(IStockObserver observer) => _observers.Add(observer);
    public void Unregister(IStockObserver observer) => _observers.Remove(observer);

    public void Notify(string productName, int stock)
    {
        foreach (var observer in _observers)
            observer.Update(productName, stock);
    }

    public void UpdateStock(string productName, int stock)
    {
        Console.WriteLine($"Stok güncellendi: {productName} -> {stock}");
        CheckThreshold(productName, stock);
    }

    public bool CheckThreshold(string productName, int stock)
    {
        var isCritical = stock < _threshold;
        if (isCritical) Notify(productName, stock);
        return isCritical;
    }
}
